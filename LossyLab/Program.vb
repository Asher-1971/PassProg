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
        Console.write("Enter your choice (1-4):")
    End Sub
   Sub Main()
        Dim ChoiceOption As Integer
        ChoiceOption = console.ReadLine()

        while ChoiceOption > 4 or ChoiceOption < 1
            Console.WriteLine("Invalid choice. Please try again.")
            Console.WriteLine()
            Choices()
            ChoiceOption = console.ReadLine()
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
        Dim CorrectLength, NoSpaces, UpperCasePresent, DigitPresent As Boolean
        Dim Password as string
        Console.WriteLine("Enter a password:")
        Password = Console.ReadLine()
        Console.WriteLine()
        CorrectLength = CorrectLength(Password)
        NoSpaces = NoSpaces(Password)
        UpperCasePresent = UpperCasePresent(Password)
        DigitPresent = DigitPresent(Password)
        
        While CorrectLength = False or NoSpaces = False or UpperCasePresent = False or DigitPresent = False
            If CorrectLength = False Then
                Console.WriteLine("Password must be between 10 and 20 characters long.")
            End If
            If NoSpaces = False Then
                Console.WriteLine("Password must not contain any spaces.")
            End If
            If UpperCasePresent = False Then
                Console.WriteLine("Password must contain at least one uppercase letter.")
            End If
            If DigitPresent = False Then
                Console.WriteLine("Password must contain at least one digit.")
            End If
            Console.WriteLine()
            Console.WriteLine("Enter a password:")
            Password = Console.ReadLine()
            Console.WriteLine()
            CorrectLength = CorrectLength(Password)
            NoSpaces = NoSpaces(Password)
            UpperCasePresent = UpperCasePresent(Password)
            DigitPresent = DigitPresent(Password)
        End While
    if CorrectLength = True and NoSpaces = True and UpperCasePresent = True and DigitPresent = True Then
        Console.WriteLine("Password accepted.")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
        Console.Clear()
        Choices()
        Main()
    End If
    End Sub
    End Sub
    
    function CorrectLength(byref Password) As Boolean
       
        If Password.Length >= 10 and Password.Length <=20 Then
            Return True
        Else
            Return False
        End If
    End function

    function NoSpaces(byref Password) As Boolean
        Dim SpacePresent As Boolean
        SpacePresent = False
        For count As Integer = 0 To Password.Length - 1
            If Password.substring(count,1) = " " Then
                SpacePresent = True
            End If
        Next
        If SpacePresent = True Then
            Return False
        Else
            Return True
        End If
    End function

    Function UpperCasePresent(byref Password) As Boolean
        Dim UpperCase As Boolean
        UpperCase = False
        For count As Integer = 0 To Password.Length - 1
            If Password.substring(count,1) = Password.substring(count,1).toupper Then
                UpperCase = True
            End If
        Next
        If UpperCase = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Function DigitPresent(byref Password) As Boolean
        dim Numbers() As String = {"0","1","2","3","4","5","6","7","8","9"}
        Dim Digit As Boolean
        Digit = False
        For count As Integer = 0 To Password.Length - 1
           for count2 As Integer = 0 To Numbers.Length - 1
                If Password.substring(count,1) = Number(count2)  Then
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