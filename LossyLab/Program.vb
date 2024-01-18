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
                    Call PasswordInput()
                Case 2
                Case 3
            End Select
        Loop Until ChoiceOption = 4
    End Sub
End Module