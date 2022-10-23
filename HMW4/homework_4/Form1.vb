Public Class Form1

    Public b As Bitmap
    Public g As Graphics
    Public r As New Random
    Public PenTrajectory As New Pen(Color.DarkGreen, 2)
    Public Penaverage As New Pen(Color.Red, 2)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.b = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)   'queste due righe ci saranno sempre prima di disegnare'
        Me.g = Graphics.FromImage(b)

        Me.g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Me.g.Clear(Color.White)

        '-------- trajectoy generation'
        Dim virtualwindow As New Rectangle(20, 20, Me.b.Width - 40, Me.b.Height - 40)
        Dim TrialsCount As Integer = 100
        Dim SuccessProbability As Double = 0.5
        Dim NumerOfTrajectories As Integer = 30


        Dim minX As Double = 0
        Dim minY As Double = 0
        Dim maxX As Double = TrialsCount
        Dim maxY As Double = TrialsCount
        Dim rLeft As Integer = 0
        Dim rTop As Integer = 0
        Dim rW As Integer = Me.Width
        Dim rH As Integer = Me.Width
        Dim absolutefreq As Integer = 0


        g.DrawRectangle(Pens.DarkSlateGray, virtualwindow)

        For i As Integer = 1 To NumerOfTrajectories

            Dim Punti As New List(Of Point)
            Dim success As Double = 0
            Dim unsucces As Integer = 0

            For X As Integer = 1 To TrialsCount

                Dim Uniform As Double = r.NextDouble
                If Uniform < SuccessProbability Then
                    success += 1
                    absolutefreq += 1
                Else
                    unsucces += 1
                    

                End If

                Dim xDevice As Integer = FromXRealToXVirtual(X, minX, maxX, virtualwindow.Left, virtualwindow.Width)
                Dim YDevice As Integer = FromXRealToXVirtual(success, minY, maxY, virtualwindow.Top, virtualwindow.Height)
                Punti.Add(New Point(xDevice, YDevice))

            Next
            g.DrawLines(PenTrajectory, Punti.ToArray)
            Dim p As Integer = FromXRealToXVirtual(TrialsCount, minX, maxX, virtualwindow.Left, virtualwindow.Width)
            Dim average As Integer = CInt(absolutefreq) / i
            Dim y As Integer = FromYRealToYVirtual(average, minY, maxY, virtualwindow.Top, virtualwindow.Height)
            g.DrawLine(Penaverage, New Point(20, 20), New Point(p, y))
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
End Class
