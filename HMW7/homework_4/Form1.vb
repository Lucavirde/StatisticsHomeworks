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

        Dim TrialsCount As Integer = Me.NumericUpDown1.Value
        Dim NumerOfTrajectories As Integer = 100
        Dim lambda As Integer = Me.NumericUpDown2.Value
        Dim SuccessProbability As Double = lambda / TrialsCount

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
        Dim dictdistance As New Dictionary(Of Integer, Integer)
        Dim distance As Integer

        For i As Integer = 0 To NumerOfTrajectories

            Dim Punti As New List(Of Point)
            Dim Punti2 As New List(Of Point)

            Dim success As Double = 0
            Dim unsucces As Integer = 0
            Dim tentatives As Integer = 0
            Dim YDevice As Integer
            distance = 0
            For X As Integer = 1 To TrialsCount
                Dim Uniform As Double = r.NextDouble()
                If Uniform < SuccessProbability Then
                    success += 1
                    absolutefreq += 1
                    tentatives += 1
                    If dictdistance.ContainsKey(distance) Then
                        dictdistance(distance) += 1
                    Else
                        dictdistance.Add(distance, 1)
                    End If
                    distance = 0
                Else
                    unsucces += 1
                    tentatives += 1
                    distance += 1
                End If
                xDevice = FromXRealToXVirtual(X, minX, maxX, VirtualWindow.Left, VirtualWindow.Width)

                YDevice = FromYRealToYVirtual(success, minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti.Add(New Point(xDevice, YDevice))


                average = success * TrialsCount / (X + 1)
                YDevice2 = FromYRealToYVirtual(average, minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti2.Add(New Point(xDevice, YDevice2))


            Next



            g.DrawLines(PenTrajectory, Punti.ToArray)
            g.DrawLines(Penaverage, Punti2.ToArray)
        Next

        g2.TranslateTransform(0, b2.Height)
        g2.ScaleTransform(1, -1)

        Dim rectwidth As Double
        Dim index, scalah As Double
        scalah = dictdistance.Values.Max / Me.PictureBox2.Height
        index = 0
        rectwidth = Me.PictureBox2.Width / dictdistance.Count
        For Each item In dictdistance

            Dim rect As New Rectangle(index, 0, rectwidth, item.Value / scalah)
            Dim the_brush As New SolidBrush(Color.Red)
            Dim the_pen As New Pen(Color.Red, 0)
            g2.FillRectangle(the_brush, rect)
            g2.DrawRectangle(the_pen, rect)
            index = index + rectwidth

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

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

End Class
