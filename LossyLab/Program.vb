Imports System
Imports System.IO

Module Program
    Dim Password As String

    Sub Choices()
        Console.WriteLine("1. Enter a new password.")
        Console.WriteLine("2. Check your password.")
        Console.WriteLine("3. Change your password.")
        Console.WriteLine("4. Quit.")
    End Sub
    Sub PasswordInput()
        FileOpen(1, "Password.txt", OpenMode.Output)
        Console.Write("Enter Password:")
        Password = Console.ReadLine()
    End Sub
    Sub Main()
        Dim ChoiceOption As Integer
        Do
            Call Choices()
            ChoiceOption = 0
            While ChoiceOption > 4 Or ChoiceOption < 1
                Console.Write("Enter your choice: ")
                ChoiceOption = Console.ReadLine
            End While
            Select Case ChoiceOption
                Case 1
                Case 2
                Case 3
            End Select
        Loop Until ChoiceOption = 4
    End Sub
End Module