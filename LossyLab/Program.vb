Imports System
Imports System.IO

' This module contains the main logic of the Password Manager program
Module Program
    ' Declare global variables
    Dim Password As String ' This variable will store the user's password
    Dim InputFlag As Boolean ' This flag will indicate whether a password has been entered
    Dim ChoiceOption As Integer ' This variable will store the user's menu choice
    Dim ChangePassWord As Boolean ' This flag will indicate whether the user wants to change the password
    Dim CreatePassword As Boolean ' This flag will indicate whether the user wants to create a new password


    Sub Choices()
        ' Print empty line for better readability
        Console.WriteLine()
        ' Print the title of the program
        Console.WriteLine("========PASSWORD MANAGER========")
        Console.WriteLine("===========MAIN MENU============")
        ' Print the menu options
        Console.WriteLine("===(1) Enter a new password.====")
        Console.WriteLine("===(2) Check the password.======")
        Console.WriteLine("===(3) Change the password.====")
        Console.WriteLine("===(4) Exit the program.=======")
        Console.WriteLine("================================")
        ' Prompt the user to enter their choice
        Console.Write("Enter your choice (1-4):")
    End Sub


    Sub Main()
    ' Call the Choices subroutine to display the menu options
    Call Choices()
    ' Read the user's choice
    ChoiceOption = Console.ReadLine()

    ' Validate the user's choice
    While ChoiceOption > 4 Or ChoiceOption < 1
        ' If the choice is not valid, prompt the user to enter a valid choice
        Console.WriteLine("Invalid choice. Please try again.")
        Console.WriteLine()
        Choices()
        ChoiceOption = Console.ReadLine()
    End While

    ' Based on the user's choice, call the appropriate subroutine
    Select Case ChoiceOption
        Case 1
            PasswordInput()
        Case 2
            PasswordCheck()
        Case 3
            PasswordChange()
        Case 4
            ' If the user chose to exit, display a goodbye message and terminate the program
            Console.WriteLine("Thank you for using the Password Manager.")
            Console.WriteLine("Goodbye.")
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Environment.Exit(0)
    End Select
End Sub

' This subroutine is used to input the password
Sub PasswordInput()
    ' If the password has already been created and the user chose option 1, display a message and return to the main subroutine
    ' This is to prevent the user from setting a new password when one already exists
    If CreatePassword = True And ChoiceOption = 1 Then
        Console.WriteLine("YOU CAN SET THE PASSWORD ONLY ONCE")
        Call Main() ' Return to the main subroutine
    End If

    ' If the password has not been created yet, allow the user to create it
    If CreatePassword = False Then
        ' If the user chose option 1, display a welcome message
        If ChoiceOption = 1 Then
            Console.WriteLine("Welcome to password setting utility")
        End If
        ' Set the CreatePassword flag to True to indicate that a password is being created
        CreatePassword = True

        ' Prompt the user to enter a password
        InputFlag = False ' Set the InputFlag to False to indicate that a password has not been entered yet
        Console.Write("Enter a password:")
        Password = Console.ReadLine() ' Read the user's password
        Console.WriteLine()

        ' Check the entered password
        Dim CorrectLengthResult As Boolean ' This variable will store the result of the length check
        CorrectLengthResult = CorrectLength(Password) ' Check if the password is between 10 and 20 characters long
        Dim NoSpacesResult As Boolean ' This variable will store the result of the space check
        NoSpacesResult = NoSpaces(Password) ' Check if the password does not contain any spaces
        Dim UpperCasePresentResult As Boolean ' This variable will store the result of the uppercase letter check
        UpperCasePresentResult = UpperCasePresent(Password) ' Check if the password contains at least one uppercase letter
        Dim DigitPresentResult As Boolean ' This variable will store the result of the digit check
        DigitPresentResult = DigitPresent(Password) ' Check if the password contains at least one digit

        ' If the password is not valid, prompt the user to enter a valid password
        While CorrectLengthResult = False Or NoSpacesResult = False Or UpperCasePresentResult = False Or DigitPresentResult = False
            Console.WriteLine("UNACCEPTABLE PASSWORD, your password is rejected for the following reasons:")
            ' Display the reasons why the password is not valid
            If CorrectLengthResult = False Then
                Console.WriteLine("(^_^)Password must be between 10 and 20 characters long.")
            End If
            If NoSpacesResult = False Then
                Console.WriteLine("(^_^)Password must not contain any spaces.")
            End If
            If UpperCasePresentResult = False Then
                Console.WriteLine("(^_^)Password must contain at least one uppercase letter.")
            End If
            If DigitPresentResult = False Then
                Console.WriteLine("(^_^)Password must contain at least one digit.")
            End If
            Console.WriteLine()
            Console.WriteLine("RE-ENTER A PASSWORD") ' Prompt the user to enter a new password
            Console.Write("Enter a password:")
            Password = Console.ReadLine() ' Read the new password
            Console.WriteLine()
            ' Recheck the new password
            CorrectLengthResult = CorrectLength(Password)
            NoSpacesResult = NoSpaces(Password)
            UpperCasePresentResult = UpperCasePresent(Password)
            DigitPresentResult = DigitPresent(Password)
        End While

        ' If the password is valid, set the InputFlag to True and save the password to a file
        If CorrectLengthResult = True And NoSpacesResult = True And UpperCasePresentResult = True And DigitPresentResult = True Then
            InputFlag = True ' Set the InputFlag to True to indicate that a valid password has been entered
            ' If the user chose option 1 or wants to change the password, save the password to a file
            If ChoiceOption = 1 Or ChangePassWord = True Then
                FileOpen(1, "password.txt", OpenMode.Output) ' Open the file in output mode to overwrite the existing password
                PrintLine(1, Password) ' Write the password to the file
                FileClose(1) ' Close the file
                Console.WriteLine("Password accepted.") ' Display a message to confirm that the password has been accepted
                InputFlag = True ' Set the InputFlag to True to indicate that a valid password has been entered
                Console.WriteLine()
                Console.WriteLine("Press any key to continue...")
                ' If the user chose option 1, return to the main subroutine
                If ChoiceOption = 1 Then
                    Main()
                End If
            End If
        End If
    End If
End Sub
' This subroutine is used to check the password
Sub PasswordCheck()
    ' This loop checks if a password has been entered yet
    While PasswordInputPresent(InputFlag) = False
        ' If not, it prompts the user to set a password
        Console.WriteLine("No password has been entered yet.")
        Console.WriteLine("Please set a password first")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        ' Then it returns to the main function
        Main()
    End While

    ' If a password has been entered, it allows the user to check it
    If PasswordInputPresent(InputFlag) = True Then
        ' It first prompts the user to enter the set password
        ChangePassWord = False
        CreatePassword = False
        Console.WriteLine("ENTER THE SET PASSWORD ")
        Call PasswordInput()
        Console.WriteLine()
        ' It stores the entered password
        Dim StoredPassword As String = Password

        ' It opens the file where the original password is stored
        FileOpen(1, "Password.txt", OpenMode.Input)
        ' It reads the original password from the file
        Dim OGPasswrod As String
        OGPasswrod = LineInput(1)
        ' It closes the file
        FileClose(1)

        ' This loop checks if the entered password matches the original password
        While Password <> OGPasswrod
            CreatePassword = False
            Console.WriteLine()
            Console.WriteLine("PASSWORD MATCH NOT FOUND")
            Console.WriteLine("the password you entered is incorrect")
            Console.WriteLine()
            ' If not, it prompts the user to enter the password again
            Call PasswordInput()
        End While

        ' If the entered password matches the original password, it confirms the match
        If Password = OGPasswrod Then
            Console.WriteLine()
            Console.WriteLine("PASSWORD MATCH FOUND")
            Console.WriteLine("Your Password is correct")
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Console.WriteLine()

            ' If the user chose option 2, it returns to the main function
            If ChoiceOption = 2 Then
                Main()
            End If

            ' If the user chose option 3, it confirms that the password has been verified for changing
            If ChoiceOption = 3 Then
                Console.WriteLine("YOU HAVE VERIFIIED THE PASSWORD FOR CHANGING IT ")
            End If
        End If
    End If
End Sub
' This subroutine is used to change the password
Sub PasswordChange()
    ' This loop checks if a password has been entered yet
    While PasswordInputPresent(InputFlag) = False
        ' If not, it prompts the user to set a password
        Console.WriteLine("No password has been entered yet.")
        Console.WriteLine("Please set a password first")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        ' Then it returns to the main function
        Main()
    End While

    ' If a password has been entered, it allows the user to change it
    If PasswordInputPresent(InputFlag) = True Then
        ' It first checks the old password
        CreatePassword = False
        Console.WriteLine("Welcome to password changing utility")
        Call PasswordCheck()
        ' Then it allows the user to set a new password
        ChangePassWord = True
        Console.WriteLine("Now Set a new Password ")
        CreatePassword = False
        Call PasswordInput()
        ' Finally, it returns to the main function
        Call Main()
    End If
End Sub

' This function checks if the password length is between 10 and 20 characters
Function CorrectLength(ByRef Password) As Boolean
    If Password.Length >= 10 And Password.Length <= 20 Then
        Return True
    Else
        Return False
    End If
End Function

' This function checks if the password contains any spaces
Function NoSpaces(ByRef Password) As Boolean
    Dim SpacePresent As Boolean
    SpacePresent = False
    ' It loops through each character in the password
    For count As Integer = 0 To Password.Length - 1
        ' If it finds a space, it sets SpacePresent to True
        If Password.substring(count, 1) = " " Then
            SpacePresent = True
        End If
    Next
    ' If a space was found, it returns False, otherwise it returns True
    If SpacePresent = True Then
        Return False
    Else
        Return True
    End If
End Function

' This function checks if the password contains any uppercase letters
Function UpperCasePresent(ByRef Password) As Boolean
    Dim UpperCase As Boolean
    UpperCase = False
    ' It loops through each character in the password
    For count As Integer = 0 To Password.Length - 1
        ' If it finds an uppercase letter, it sets UpperCase to True
        If Password.substring(count, 1) = Password.substring(count, 1).toupper Then
            UpperCase = True
        End If
    Next
    ' If an uppercase letter was found, it returns True, otherwise it returns False
    If UpperCase = True Then
        Return True
    Else
        Return False
    End If
End Function

' This function checks if the password contains any digits
Function DigitPresent(ByRef Password) As Boolean
    Dim Numbers() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
    Dim Digit As Boolean
    Digit = False
    ' It loops through each character in the password
    For count As Integer = 0 To Password.Length - 1
        ' Then it loops through each number from 0 to 9
        For count2 As Integer = 0 To Numbers.Length - 1
            ' If it finds a digit, it sets Digit to True
            If Password.substring(count, 1) = Numbers(count2) Then
                Digit = True
            End If
        Next
    Next
    ' If a digit was found, it returns True, otherwise it returns False
    If Digit = True Then
        Return True
    Else
        Return False
    End If
End Function

' This function checks if a password has been entered
Function PasswordInputPresent(ByRef InputFlag As Boolean) As Boolean
    ' If a password has been entered, it returns True
    If InputFlag = True Then
        Return True
    End If
    ' If a password has not been entered, it returns False
    If InputFlag = False Then
        Return False
    End If
End Function

End Module