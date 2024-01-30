Imports System
Imports System.IO
Module Program
    Dim Password As String
    Dim InputFlag As Boolean
    Dim ChoiceOption As Integer
    Dim PC As Integer

    Sub Choices()
        Console.WriteLine()
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
        ChoiceOption = Console.ReadLine()


        While ChoiceOption > 4 Or ChoiceOption < 1
            Console.WriteLine("Invalid choice. Please try again.")
            Console.WriteLine()
            Choices()
            ChoiceOption = Console.ReadLine()
        End While

        PC = +1

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
                Environment.Exit(0)
        End Select
    End Sub

    Sub PasswordInput()
        InputFlag = False
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
            Console.Write("Enter a password:")
            Password = Console.ReadLine()
            Console.WriteLine()
            CorrectLengthResult = CorrectLength(Password)
            NoSpacesResult = NoSpaces(Password)
            UpperCasePresentResult = UpperCasePresent(Password)
            DigitPresentResult = DigitPresent(Password)
        End While
        If CorrectLengthResult = True And NoSpacesResult = True And UpperCasePresentResult = True And DigitPresentResult = True Then

            InputFlag = True

            If ChoiceOption = 1 Or ChoiceOption = 3 Then
                FileOpen(1, "password.txt", OpenMode.Output)
                PrintLine(1, Password)
                FileClose(1)
                Console.WriteLine("Password accepted.")
                InputFlag = True
                Console.WriteLine()
                Console.WriteLine("Press any key to continue...")
                Main()
            End If

        End If
    End Sub

    Sub PasswordCheck()
        While PasswordInputPresent(InputFlag) = False
            Console.WriteLine("No password has been entered yet.")
            Console.WriteLine("Please set a password first")
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Main()
        End While

        If PasswordInputPresent(InputFlag) = True Then

            Console.WriteLine("ENTER THE SET PASSWORD ")
            Call PasswordInput()
            Console.WriteLine()


            FileOpen(1, "Password.txt", OpenMode.Input)
            Dim OGPasswrod As String
            OGPasswrod = LineInput(1)
            FileClose(1)

            Console.WriteLine(Password)

            While Password <> OGPasswrod
                Console.WriteLine()
                Console.WriteLine("PASSWORD MATCH NOT FOUND")
                Console.WriteLine("the password you entered is incorrect")
                Console.WriteLine()

                Call PasswordInput()
            End While

            If Password = OGPasswrod Then
                Console.WriteLine()
                Console.WriteLine("PASSWORD MATCH FOUND")
                Console.WriteLine("Your Password is correct")
                Console.WriteLine()
                Console.WriteLine("Press any key to continue...")
                Console.WriteLine()

                If ChoiceOption = 3 Then
                    Main()
                End If
            End If

        End If
    End Sub

    Sub PasswordChange()
        While PasswordInputPresent(InputFlag) = False
            Console.WriteLine("No password has been entered yet.")
            Console.WriteLine("Please set a password first")
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Main()
        End While

        If PasswordInputPresent(InputFlag) = True Then
            Console.WriteLine("WELCOME TO PASSWORD CHANGING UTILITY")
            Call PasswordChange()

            Call PasswordInput()

        End If
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

    Function PasswordInputPresent(ByRef InputFlag As Boolean) As Boolean

        If InputFlag = True Then
            Return True
        End If

        If InputFlag = False Then
            Return False
        End If

    End Function

End Module