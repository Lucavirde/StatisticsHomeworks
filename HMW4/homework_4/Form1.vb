Public Class Form1

    Public b As Bitmap
    Public g As Graphics
    Public r As New Random
    Public PenTrajectory As New Pen(Color.DarkGreen, 2)
    Public Penaverage As New Pen(Color.Red, 2)
    Public Penormalized As New Pen(Color.Purple, 2)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Me.g = Graphics.FromImage(b)
        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)

        Dim TrialsCount As Integer = 100
        Dim NumerOfTrajectories As Integer = 30
        Dim SuccessProbability As Double = 0.5

        Dim minX As Double = 0
        Dim maxX As Double = TrialsCount
        Dim minY As Double = 0
        Dim maxY As Double = TrialsCount
        Dim absolutefreq As Integer = 0

        Dim VirtualWindow As New Rectangle(40, 40, Me.b.Width - 40, Me.b.Height - 40)

        g.DrawRectangle(Pens.DarkSlateGray, VirtualWindow)

        For i As Integer = 1 To NumerOfTrajectories

            Dim Punti As New List(Of Point)
            Dim Punti2 As New List(Of Point)
            Dim Punti3 As New List(Of Point)

            Dim success As Double = 0
            Dim unsucces As Integer = 0
            Dim tentatives As Integer = 0
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
                Dim xDevice As Integer = FromXRealToXVirtual(X, minX, maxX, VirtualWindow.Left, VirtualWindow.Width)

                Dim YDevice As Integer = FromYRealToYVirtual(success, minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti.Add(New Point(xDevice, YDevice))


                Dim average As Integer = success * TrialsCount / (X + 1)
                Dim YDevice2 As Integer = FromYRealToYVirtual(average, minY, maxY, VirtualWindow.Top, VirtualWindow.Height)
                Punti2.Add(New Point(xDevice, YDevice2))

                Dim normalized As Double = success * (Math.Sqrt(TrialsCount)) / Math.Sqrt(X + 1)
                Dim YDevice3 As Integer = FromYRealToYVirtual(normalized, minY, maxY * SuccessProbability, VirtualWindow.Top, VirtualWindow.Height)
                Punti3.Add(New Point(xDevice, YDevice3))
            Next
            g.DrawLines(PenTrajectory, Punti.ToArray)
            g.DrawLines(Penaverage, Punti2.ToArray)
            g.DrawLines(Penormalized, Punti3.ToArray)
        Next

        Me.PictureBox1.Image = b

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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
