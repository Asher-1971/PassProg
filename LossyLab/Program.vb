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
            If Password.(count) = " " Then
                SpacePresent = True
            End If
        Next
        If SpacePresent = True Then
            Return False
        Else
            Return True
        End If
    End function
End Module