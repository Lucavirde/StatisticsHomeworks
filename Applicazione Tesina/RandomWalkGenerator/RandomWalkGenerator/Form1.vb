Public Class Form1

    Public b, b2 As Bitmap
    Public g, g2 As Graphics
    Public r As New Random
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        Me.b2 = New Bitmap(Me.PictureBox1.Width, Me.PictureBox2.Height)
        Me.g2 = Graphics.FromImage(b2)
        Me.g2.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        Me.g.Clear(Color.White)
        Me.g2.Clear(Color.White)

        Dim TrialsCount As Integer = Me.NumericUpDown1.Value
        Dim NumerOfTrajectories As Integer = Me.NumericUpDown2.Value
        Dim SuccessProbability As Double = 0.5

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount * 2
        Dim VirtualWindow As New Rectangle(0, 0, Me.b.Width, Me.b.Height)
        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        Dim xDevice As Integer
        Dim dictY As New Dictionary(Of Integer, Integer)

        For i As Integer = 0 To NumerOfTrajectories

            Dim Punti As New List(Of Point)
            Dim Punti2 As New List(Of Point)

            Dim walkupdown As Double = 0
            Dim YDevice As Integer


            For X As Integer = 0 To TrialsCount
                Dim Uniform As Double = r.NextDouble()
                If Uniform < SuccessProbability Then
                    walkupdown += 3
                    If walkupdown > maxY Then
                        maxY = walkupdown
                    End If
                Else
                    walkupdown -= 3

                End If
                xDevice = FromXRealToXVirtual(X, minX, maxX, VirtualWindow.Left, VirtualWindow.Width)

                YDevice = FromYRealToYVirtual(walkupdown, minY, maxY, VirtualWindow.Top, VirtualWindow.Height / 2)
                Punti.Add(New Point(xDevice, YDevice))

            Next

            If dictY.ContainsKey(YDevice) Then
                dictY(YDevice) += 1
            Else
                dictY.Add(YDevice, 1)
            End If

            Dim rng As New Random()
            For x = 1 To 150
                Using pen = New Pen(Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256)))
                    g.DrawLines(pen, Punti.ToArray)
                End Using
            Next x

        Next
        Dim rectwidthy As Double
        Dim indexy, scalahy As Double
        scalahy = dictY.Values.Max / Me.PictureBox2.Width
        indexy = 0
        'rectwidthy = Me.PictureBox3.Width / dictY.Count

        For Each item In dictY

            Dim rect As New Rectangle(0, item.Key, item.Value / scalahy, 3)
            Dim the_brush As New SolidBrush(Color.Pink)
            Dim the_pen As New Pen(Color.Black, 0)
            g2.FillRectangle(the_brush, rect)
            g2.DrawRectangle(the_pen, rect)
            indexy = indexy + rectwidthy

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

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class
