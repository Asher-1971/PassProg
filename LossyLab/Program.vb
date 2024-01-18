Imports System
Imports System.IO

Module Program
    Dim Password As String

    Sub Choices()
        Console.WriteLine("========PASSWORD MANAGER========")
        Console.WriteLine("===========MAIN MENU============")
        Console.WriteLine("===(1) Enter a new password.====")
        Console.WriteLine("===(2) Check the password.======")
        Console.WriteLine("===(3) Change the password.====")
        Console.WriteLine("===(4) Exit the program.=======")
        Console.WriteLine("================================")
        Console.Write("Enter your choice (1-4):")
    End Sub
    Sub Main()
        Call Choices()
        Dim ChoiceOption As Integer
        ChoiceOption = Console.ReadLine()

        While ChoiceOption > 4 Or ChoiceOption < 1
            Console.WriteLine("Invalid choice. Please try again.")
            Console.WriteLine()
            Choices()
            ChoiceOption = Console.ReadLine()
        End While

        Select Case ChoiceOption
            Case 1
                PasswordInput()
            Case 2
                PasswordCheck()
            Case 3
                PasswordChange()
            Case 4
                Console.WriteLine("Thank you for using the Password Manager.")
                Console.WriteLine("Goodbye.")
                Console.WriteLine()
                Console.WriteLine("Press any key to continue...")
                Console.ReadKey()
                Environment.Exit(0)
        End Select
    End Sub

    Sub PasswordInput()
        Dim Password As String
        Console.Write("Enter a password:")
        Password = Console.ReadLine()
        Console.WriteLine()
        Dim CorrectLengthResult As Boolean
        CorrectLengthResult = CorrectLength(Password)
        Dim NoSpacesResult As Boolean
        NoSpacesResult = NoSpaces(Password)
        Dim UpperCasePresentResult As Boolean
        UpperCasePresentResult = UpperCasePresent(Password)
        Dim DigitPresentResult As Boolean
        DigitPresentResult = DigitPresent(Password)

        While CorrectLengthResult = False Or NoSpacesResult = False Or UpperCasePresentResult = False Or DigitPresentResult = False
            Console.WriteLine("UNACCEPTABLE PASSWORD, your password is rejected for the following reasons:")
            If CorrectLengthResult = False Then
                Console.WriteLine("^_^Password must be between 10 and 20 characters long.")
            End If
            If NoSpacesResult = False Then
                Console.WriteLine("^_^Password must not contain any spaces.")
            End If
            If UpperCasePresentResult = False Then
                Console.WriteLine("^_^Password must contain at least one uppercase letter.")
            End If
            If DigitPresentResult = False Then
                Console.WriteLine("^_^Password must contain at least one digit.")
            End If
            Console.WriteLine()
            Console.Write("Enter a password:")
            Password = Console.ReadLine()
            Console.WriteLine()
            CorrectLengthResult = CorrectLength(Password)
            NoSpacesResult = NoSpaces(Password)
            UpperCasePresentResult = UpperCasePresent(Password)
            DigitPresentResult = DigitPresent(Password)
        End While
        If CorrectLengthResult = True And NoSpacesResult = True And UpperCasePresentResult = True And DigitPresentResult = True Then
            Console.WriteLine("Password accepted.")
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Console.Clear()
            Choices()
            Main()
        End If
    End Sub

    Sub PasswordCheck()
        Console.WriteLine("lele")
    End Sub

    Sub PasswordChange()
        Console.WriteLine("lele")
    End Sub


    Function CorrectLength(ByRef Password) As Boolean

        If Password.Length >= 10 And Password.Length <= 20 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function NoSpaces(ByRef Password) As Boolean
        Dim SpacePresent As Boolean
        SpacePresent = False
        For count As Integer = 0 To Password.Length - 1
            If Password.substring(count, 1) = " " Then
                SpacePresent = True
            End If
        Next
        If SpacePresent = True Then
            Return False
        Else
            Return True
        End If
    End Function

    Function UpperCasePresent(ByRef Password) As Boolean
        Dim UpperCase As Boolean
        UpperCase = False
        For count As Integer = 0 To Password.Length - 1
            If Password.substring(count, 1) = Password.substring(count, 1).toupper Then
                UpperCase = True
            End If
        Next
        If UpperCase = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Function DigitPresent(ByRef Password) As Boolean
        Dim Numbers() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        Dim Digit As Boolean
        Digit = False
        For count As Integer = 0 To Password.Length - 1
            For count2 As Integer = 0 To Numbers.Length - 1
                If Password.substring(count, 1) = Numbers(count2) Then
                    Digit = True
                End If
            Next
        Next
        If Digit = True Then
            Return True
        Else
            Return False
        End If
    End Function


End Module