Imports System.Drawing.Drawing2D

Public Class Form1

    Public b, b2 As Bitmap
    Public g, g2 As Graphics
    Public r As New Random
    Public PenTrajectory As New Pen(Color.DarkGreen, 2)
    Public Penaverage As New Pen(Color.Red, 2)
    Public Penormalized As New Pen(Color.Purple, 2)


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        Me.b2 = New Bitmap(Me.PictureBox2.Width, Me.PictureBox2.Height)
        Me.g2 = Graphics.FromImage(b2)
        Me.g2.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        Me.g.Clear(Color.White)
        Me.g2.Clear(Color.White)

        Dim TrialsCount As Integer = 100
        Dim NumerOfTrajectories As Integer = 30
        Dim SuccessProbability As Double = 0.5

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount
        Dim absolutefreq As Integer = 0

        Dim VirtualWindow As New Rectangle(0, 0, Me.b.Width, Me.b.Height)

        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)
        g2.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)
        Dim average As Integer
        Dim YDevice2 As Integer
        Dim xDevice As Integer
        Dim dictaverage As New Dictionary(Of Integer, Integer)

        For i As Integer = 0 To NumerOfTrajectories

            Dim Punti As New List(Of Point)
            Dim Punti2 As New List(Of Point)
            Dim Punti3 As New List(Of Point)

            Dim success As Double = 0
            Dim unsucces As Integer = 0
            Dim tentatives As Integer = 0
            Dim YDevice As Integer

            For X As Integer = 1 To TrialsCount
                Dim Uniform As Double = r.NextDouble
                If Uniform < SuccessProbability Then
                    success += 1
                    absolutefreq += 1
                    tentatives += 1
                Else
                    unsucces += 1
                    tentatives += 1
                End If
                xDevice = FromXRealToXVirtual(X, minX, maxX, VirtualWindow.Left, VirtualWindow.Width)

                YDevice = FromYRealToYVirtual(success, minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti.Add(New Point(xDevice, YDevice))


                average = success * TrialsCount / (X + 1)
                YDevice2 = FromYRealToYVirtual(average, minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti2.Add(New Point(xDevice, YDevice2))

                Dim normalized As Double = success * (Math.Sqrt(TrialsCount)) / Math.Sqrt(X + 1)
                Dim YDevice3 As Integer = FromYRealToYVirtual(normalized, minY, maxY * SuccessProbability, VirtualWindow.Top, VirtualWindow.Height)
                Punti3.Add(New Point(xDevice, YDevice3))


            Next

            If dictaverage.ContainsKey(YDevice2) Then
                dictaverage(YDevice2) += 5
            Else
                dictaverage.Add(YDevice2, 5)
            End If

            g.DrawLines(PenTrajectory, Punti.ToArray)
            g.DrawLines(Penaverage, Punti2.ToArray)
            g.DrawLines(Penormalized, Punti3.ToArray)
        Next

        For Each item In dictaverage
            Dim rect As New Rectangle(0, item.Key, item.Value, 1)
            Dim the_brush As New SolidBrush(Color.Red)
            Dim the_pen As New Pen(Color.Red, 0)
            g2.FillRectangle(the_brush, rect)
            g2.DrawRectangle(the_pen, rect)

        Next

        Me.PictureBox1.Image = b
        Me.PictureBox2.Image = b2

    End Sub

    Function FromXRealToXVirtual(X As Double,
                                 minX As Double, maxX As Double,
                                 Left As Integer, W As Integer) As Integer

        If (maxX - minX) = 0 Then
            Return 0
        End If

        Return Left + W * (X - minX) / (maxX - minX)

    End Function

    Function FromYRealToYVirtual(Y As Double,
                                minY As Double, maxY As Double,
                                Top As Integer, H As Integer) As Integer

        If (maxY - minY) = 0 Then
            Return 0
        End If

        Return Top + H - H * (Y - minY) / (maxY - minY)

    End Function




    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

End Class
