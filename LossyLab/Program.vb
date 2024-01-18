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

       
    End Sub 
    
    Sub PasswordInput()
        Dim CorrectLength, NoSpaces, UpperCasePresent, DigitPresent As Boolean
        FileOpen(1, "Password.txt", OpenMode.Output)
        Do
            CorrectLength = False
            NoSpaces = False
            UpperCasePresent = False
            DigitPresent = False
            Console.Write("Enter Password: ")
            Password = Console.ReadLine()
            If Password.Length >= 10 And Password.Length <= 20 Then
                CorrectLength = True
            End If
            For SpaceCheckCounter = 0 To Password.Length - 1
                If Password.Substring(SpaceCheckCounter, 1) <> " " Then
                    NoSpaces = True
                End If
            Next
        Loop Until CorrectLength And NoSpaces And UpperCasePresent And DigitPresent
        PrintLine(1, Password)
        FileClose(1)
    End Sub
    
End Module