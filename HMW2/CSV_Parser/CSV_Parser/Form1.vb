Imports Microsoft.VisualBasic.FileIO

Public Class Form1

    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub RichTextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Using parser As TextFieldParser = New TextFieldParser("C:\Users\luca1\Documents\GitHub\StatisticsHomeworks\HMW2\student_statistics.csv")
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            While Not parser.EndOfData
                Dim fields As String() = parser.ReadFields()

                For Each field As String In fields
                    Me.RichTextBox1.AppendText(field & " ")
                Next

                Me.RichTextBox1.AppendText(vbLf)
                Me.RichTextBox1.ScrollToCaret()
            End While
        End Using
    End Sub
End Class
