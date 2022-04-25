Imports System
Imports System.IO

Module Program
    Sub Main(args As String())
        'Dim FilePath As String = "C:\Users\larry\source\repos\parsingtxt\parsingtxt\VP014933_4931784-06-F3.txt"
        Dim FilePath As String = Path.GetFullPath("VP014933_4931784-06-F3.txt")
        Dim lines As New ArrayList
        Dim count0 As Integer = 0
        Dim count5 As Integer = 0
        Dim count6 As Integer = 0
        Dim count2 As Integer = 0
        Dim count1 As Integer = 0
        Dim j As Integer = 0
        Dim pos6 As New ArrayList
        Dim pos2 As New ArrayList
        Dim pos1 As New ArrayList
        'open file
        FileOpen(1, FilePath, OpenMode.Input)
        'Add lines to an array to be parsed
        Do While Not EOF(1)
            lines.Add(LineInput(1))
        Loop
        FileClose(1)
        'Parse the first 53 lines so that it only contains the relevant diagram, i keeps track of row
        For i = 0 To 52
            'count variable to track column
            j = 0
            'iterate over each line checking for each number
            For Each c As Char In lines(i)
                'iterate column counter
                j = j + 1
                'iterate count of 0 when 0 is found
                If c = "0" Then
                    count0 = count0 + 1
                    'iterate count of 5 when 5 is found
                ElseIf c = "5" Then
                    count5 = count5 + 1
                    'iterate count of 6 and add the position to an arraylist in format row, column when 6 is found
                ElseIf c = "6" Then
                    count6 = count6 + 1
                    pos6.Add(i.ToString + "," + j.ToString)
                    'iterate count of 2 and add the position to an arraylist in format row, column when 2 is found
                ElseIf c = "2" Then
                    count2 = count2 + 1
                    pos2.Add(i.ToString + "," + j.ToString)
                    'iterate count of 1 and add the position to an arraylist in format row,column when 1 is found
                ElseIf c = "1" Then
                    count1 = count1 + 1
                    pos1.Add(i.ToString + "," + j.ToString)
                End If
            Next
        Next
        'concatenate positions into one string for easier and cleaner printing 
        Dim result6 As String = String.Join(" ", pos6.ToArray)
        Dim result2 As String = String.Join(" ", pos2.ToArray)
        Dim result1 As String = String.Join(" ", pos1.ToArray)
        'print results
        Console.WriteLine("number Of 0 :" + count0.ToString)
        Console.WriteLine("number Of 5 :" + count5.ToString)
        Console.WriteLine("number Of 6 :" + count6.ToString + " at positions: ")
        Console.WriteLine(result6)
        Console.WriteLine("number Of 2 :" + count6.ToString + " at positions: ")
        Console.WriteLine(result2)
        Console.WriteLine("number Of 1 :" + count6.ToString + " at positions: ")
        Console.WriteLine(result1)
    End Sub
End Module
