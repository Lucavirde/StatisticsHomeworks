﻿Imports System.Security.Cryptography.X509Certificates

Public Class Form1


    Public t As New Timer  'oppure puoi trascinare un componente sul form e poi ritrovarlo qui'
    Public r As New Random
    Public sum As Double = 0
    Public count As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim numerovalori = 100
        Dim Media As Double = 0


        Me.RichTextBox1.Clear()

        For i As Integer = 1 To numerovalori
            Dim valorecasuale As Double = r.NextDouble
            Media += valorecasuale
            Me.RichTextBox1.AppendText(Environment.NewLine & r.NextDouble)

        Next 'incrementatore'

        Media /= numerovalori

        Me.RichTextBox1.AppendText(Environment.NewLine & "AVG: " & Media)

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim current As Double = r.NextDouble
        sum += current
        count += 1
        Me.RichTextBox1.AppendText(vbCrLf & " Current: " & current & " AVG: " & sum / count)
        Me.RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Timer1.Start() 'oppure me.timer.enable=true'

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Timer1.Stop()
    End Sub
End Class
