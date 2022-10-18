Imports Microsoft.VisualBasic.FileIO

Public Class Form1

    Private array1 As Integer() = {20, 21, 22, 23, 24, 25, 26, 27, 28, 29}
    Private array2 As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.RichTextBox1.AppendText("Calculating the univariate distribution of the students' age: " & vbLf)
        Me.RichTextBox1.ScrollToCaret()

        Using parser As TextFieldParser = New TextFieldParser("C:\Users\luca1\Desktop\datasetwhireshark.csv")
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")
            Dim header As String() = parser.ReadFields()
            Dim index As Integer = 0

            For i As Integer = 0 To header.Length - 1

                If header(i) = "Count" Then
                    index = i
                End If
            Next

            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()

                For i As Double = 0 To array1.Length - 1

                    If array1(i) = Int32.Parse(fields(index)) Then
                        array2(i) += 1
                    End If
                Next
            End While
        End Using

        For i As Integer = 0 To array1.Length - 1
            Dim eta As Integer = array1(i)
            Dim numero As Integer = array2(i)
            Me.RichTextBox1.AppendText(eta.ToString() & ": " & numero.ToString() & vbLf)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
