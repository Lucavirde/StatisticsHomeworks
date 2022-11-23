Imports System.Globalization

Public Class Form1

    Public r As New Random
    Public b, bx, b2 As Bitmap
    Public g, gx, g2 As Graphics
    Public Penpoints As New Pen(Color.Red)
    Dim the_brush As New SolidBrush(Color.Red)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)

        Me.bx = New Bitmap(Me.PictureBox2.Width, Me.PictureBox2.Height)
        Me.gx = Graphics.FromImage(bx)
        Me.gx.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.gx.Clear(Color.White)

        Me.b2 = New Bitmap(Me.PictureBox3.Width, Me.PictureBox3.Height)
        Me.g2 = Graphics.FromImage(b2)
        Me.g2.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g2.Clear(Color.White)

        Dim points As Integer
        Dim distance, alfa, X, Y As Double
        Dim YDevice As Integer
        Dim xDevice As Integer

        points = Me.NumericUpDown1.value

        Dim minX As Double = -1
        Dim maxX As Double = 1
        Dim minY As Double = -1
        Dim maxY As Double = 1

        Dim VirtualWindow As New Rectangle(0, 0, Me.b.Width, Me.b.Height)
        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)
        g.TranslateTransform(0, b.Height)
        g.ScaleTransform(1, -1)

        Dim dictX As New Dictionary(Of Integer, Integer)
        Dim dictY As New Dictionary(Of Integer, Integer)

        For i = 0 To points
            distance = r.NextDouble()
            alfa = r.Next(360)
            X = distance * Math.Cos(alfa)
            Y = distance * Math.Sin(alfa)
            xDevice = FromXRealToXVirtual(X, minX, maxX, VirtualWindow.Left, VirtualWindow.Width)
            YDevice = FromYRealToYVirtual(Y, minY, maxY, VirtualWindow.Top, VirtualWindow.Height)

            If dictX.ContainsKey(xDevice) Then
                dictX(xDevice) += 1
            Else
                dictX.Add(xDevice, 1)
            End If

            If dictY.ContainsKey(YDevice) Then
                dictY(YDevice) += 1
            Else
                dictY.Add(YDevice, 1)
            End If

            Dim rect As New Rectangle(xDevice, YDevice, 1, 1)
            g.DrawRectangle(Penpoints, rect)
            g.FillRectangle(the_brush, rect)
        Next

        Dim rectwidthx As Double
        Dim index, scalahx As Double
        scalahx = dictX.Values.Max / Me.PictureBox2.Height
        index = 0
        'rectwidthx = Me.PictureBox2.Width / dictX.Count

        For Each item In dictX

            Dim rect As New Rectangle(item.Key, 0, 1, item.Value / scalahx)
            Dim the_brush As New SolidBrush(Color.Red)
            Dim the_pen As New Pen(Color.Red, 0)
            gx.FillRectangle(the_brush, rect)
            gx.DrawRectangle(the_pen, rect)
            index = index + rectwidthx

        Next

        Dim rectwidthy As Double
        Dim indexy, scalahy As Double
        scalahy = dictY.Values.Max / Me.PictureBox3.Width
        indexy = 0
        'rectwidthy = Me.PictureBox3.Width / dictY.Count

        For Each item In dictY

            Dim rect As New Rectangle(0, item.Key, item.Value / scalahy, 1)
            Dim the_brush As New SolidBrush(Color.Red)
            Dim the_pen As New Pen(Color.Red, 0)
            g2.FillRectangle(the_brush, rect)
            g2.DrawRectangle(the_pen, rect)
            indexy = indexy + rectwidthy

        Next

        Me.PictureBox1.Image = b
        Me.PictureBox2.Image = bx
        Me.PictureBox3.Image = b2

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

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub
End Class
