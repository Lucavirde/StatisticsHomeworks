Imports System.Reflection

Public Class Form1
    Public r As New Random
    Public b As Bitmap
    Public g As Graphics
    Public Penpoints As New Pen(Color.Black)
    Dim the_brush As New SolidBrush(Color.Red)


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)

        Dim xy(1) As Double
        Dim points As Integer
        Dim dictX As New Dictionary(Of Integer, Integer)
        Dim VirtualWindow As New Rectangle(0, 0, Me.b.Width, Me.b.Height)
        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        points = Me.NumericUpDown1.Value

        For index = 0 To points

            xy = marsagliavalues()

            If dictX.ContainsKey(xy(0)) Then
                dictX(xy(0)) += 1
            Else
                dictX.Add(xy(0), 1)
            End If


        Next

        Dim dictsorted = dictX.OrderBy(Function(s) s.Key)

        g.TranslateTransform(0, b.Height)
        g.ScaleTransform(1, -1)

        Dim rectwidth As Double
        Dim idx, scalah As Double
        scalah = dictX.Values.Max / Me.PictureBox1.Height
        idx = 0
        rectwidth = Me.PictureBox1.Width / dictX.Count

        For Each item In dictsorted

            Dim rect As New Rectangle(idx, 0, rectwidth, item.Value / scalah)
            g.DrawRectangle(Penpoints, rect)
            g.FillRectangle(the_brush, rect)
            idx = idx + rectwidth

        Next

        Me.PictureBox1.Image = b

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub


    Public Function marsagliavalues() As Double()

        Dim x, y, j As Double

        x = (r.NextDouble()) * (1 - -1) + -1
        y = (r.NextDouble()) * (1 - -1) + -1

        j = (x * x) + (y * y)

        While (j < 0 Or j > 1)

            x = (r.NextDouble())
            y = (r.NextDouble())
            j = (x * x) + (y * y)

        End While

        x = x * Math.Sqrt(-2 * Math.Log(j) / j)
        y = y * Math.Sqrt(-2 * Math.Log(j) / j)

        Return {x, y}

    End Function

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)

        Dim xy(1) As Double
        Dim points As Integer
        Dim dictX As New Dictionary(Of Integer, Integer)
        Dim VirtualWindow As New Rectangle(0, 0, Me.b.Width, Me.b.Height)
        Dim val As Double
        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        points = Me.NumericUpDown1.Value

        For index = 0 To points

            xy = marsagliavalues()
            val = xy(0) * xy(0)
            If dictX.ContainsKey(val) Then
                dictX(val) += 1
            Else
                dictX.Add(val, 1)
            End If


        Next

        Dim dictsorted = dictX.OrderBy(Function(s) s.Key)

        g.TranslateTransform(0, b.Height)
        g.ScaleTransform(1, -1)

        Dim rectwidth As Double
        Dim idx, scalah As Double
        scalah = dictX.Values.Max / Me.PictureBox1.Height
        idx = 0
        rectwidth = Me.PictureBox1.Width / dictX.Count

        For Each item In dictsorted

            Dim rect As New Rectangle(idx, 0, rectwidth, item.Value / scalah)
            g.DrawRectangle(Penpoints, rect)
            g.FillRectangle(the_brush, rect)
            idx = idx + rectwidth

        Next

        Me.PictureBox1.Image = b
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)

        Dim xy(1) As Double
        Dim points As Integer
        Dim dictX As New Dictionary(Of Integer, Integer)
        Dim VirtualWindow As New Rectangle(0, 0, Me.b.Width, Me.b.Height)
        Dim val As Double
        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        points = Me.NumericUpDown1.Value

        For index = 0 To points

            xy = marsagliavalues()
            val = xy(0) / (xy(1) * xy(1))
            If dictX.ContainsKey(val) Then
                dictX(val) += 1
            Else
                dictX.Add(val, 1)

            End If


        Next

        Dim dictsorted = dictX.OrderBy(Function(s) s.Key)

        g.TranslateTransform(0, b.Height)
        g.ScaleTransform(1, -1)

        Dim rectwidth As Double
        Dim idx, scalah As Double
        scalah = dictX.Values.Max / Me.PictureBox1.Height
        idx = 0
        rectwidth = Me.PictureBox1.Width / dictX.Count

        For Each item In dictsorted

            Dim rect As New Rectangle(idx, 0, rectwidth, item.Value / scalah)
            g.DrawRectangle(Penpoints, rect)
            g.FillRectangle(the_brush, rect)
            idx = idx + rectwidth

        Next

        Me.PictureBox1.Image = b
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)

        Dim xy(1) As Double
        Dim points As Integer
        Dim dictX As New Dictionary(Of Integer, Integer)
        Dim VirtualWindow As New Rectangle(0, 0, Me.b.Width, Me.b.Height)
        Dim val As Double
        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        points = Me.NumericUpDown1.Value

        For index = 0 To points

            xy = marsagliavalues()
            val = (xy(0) * xy(0)) / (xy(1) * xy(1))
            If dictX.ContainsKey(val) Then
                dictX(val) += 1
            Else
                dictX.Add(val, 1)
            End If


        Next

        Dim dictsorted = dictX.OrderBy(Function(s) s.Key)

        g.TranslateTransform(0, b.Height)
        g.ScaleTransform(1, -1)

        Dim rectwidth As Double
        Dim idx, scalah As Double
        scalah = dictX.Values.Max / Me.PictureBox1.Height
        idx = 0
        rectwidth = Me.PictureBox1.Width / dictX.Count

        For Each item In dictsorted

            Dim rect As New Rectangle(idx, 0, rectwidth, item.Value / scalah)
            g.DrawRectangle(Penpoints, rect)
            g.FillRectangle(the_brush, rect)
            idx = idx + rectwidth

        Next

        Me.PictureBox1.Image = b
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)

        Dim xy(1) As Double
        Dim points As Integer
        Dim dictX As New Dictionary(Of Integer, Integer)
        Dim VirtualWindow As New Rectangle(0, 0, Me.b.Width, Me.b.Height)
        Dim val As Double
        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        points = Me.NumericUpDown1.Value

        For index = 0 To points

            xy = marsagliavalues()
            val = xy(0) / xy(1)
            If dictX.ContainsKey(val) Then
                dictX(val) += 1
            Else
                dictX.Add(val, 1)
            End If


        Next

        Dim dictsorted = dictX.OrderBy(Function(s) s.Key)

        g.TranslateTransform(0, b.Height)
        g.ScaleTransform(1, -1)

        Dim rectwidth As Double
        Dim idx, scalah As Double
        scalah = dictX.Values.Max / Me.PictureBox1.Height
        idx = 0
        rectwidth = Me.PictureBox1.Width / dictX.Count

        For Each item In dictsorted

            Dim rect As New Rectangle(idx, 0, rectwidth, item.Value / scalah)
            g.DrawRectangle(Penpoints, rect)
            g.FillRectangle(the_brush, rect)
            idx = idx + rectwidth

        Next

        Me.PictureBox1.Image = b
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub RichTextBox1_TextChanged_1(sender As Object, e As EventArgs)

    End Sub
End Class
