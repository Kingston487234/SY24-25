Imports System.Runtime

Public Class form1
    Dim movements As New Dictionary(Of String, Collection)
    Dim tracks As New Dictionary(Of String, Integer)
    Dim score As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        follow(enemy, avatar, 25, 25)
        follow(enemy2, avatar, 25, 20)
        PaceX(enemy3, wall, 20)
    End Sub

    Sub follow(e As PictureBox, a As PictureBox, speedx As Integer, speedy As Integer)
        If e.Location.Y > a.Location.Y Then
            move(e, 0, -speedx)
        Else
            move(e, 0, speedx)
        End If
        If e.Location.X > a.Location.X Then
            move(e, -speedx, 0)
        Else
            move(e, speedx, 0)
        End If
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            move(avatar, -15, 0)
        End If
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            move(avatar, 15, 0)
        End If
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            move(avatar, 0, 15)
        End If
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            move(avatar, 0, -15)
        End If
        If e.KeyCode = Keys.Space Then
            avatar.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        End If
        avatar.Refresh()

    End Sub
    Sub PaceX(e As PictureBox, p As PictureBox, speed As Integer)
        Dim dir As Integer
        dir = e.Tag

        move(e, dir * speed, 0)

        If e.Location.X > p.Location.X + p.Width / 2 Then
            e.Tag = dir * -1
        End If
        If e.Location.X < p.Location.X Then
            e.Tag = dir * -1
        End If
    End Sub
    Sub PaceY(e As PictureBox, p As PictureBox, speed As Integer)
        Dim dir As Integer
        dir = e.Tag
        move(e, 0, dir * speed)

        If e.Location.Y < p.Location.Y Then
            e.Tag = dir * -1
        End If
        If e.Location.Y > p.Location.Y + p.Height / 2 Then
            e.Tag = dir * -1
        End If
    End Sub
    Sub Track(e As PictureBox, a As PictureBox)
        If Not tracks.ContainsKey(e.Name & a.Name) Then
            tracks.Add(e.Name & a.Name, 1)
        Else
            Dim idx As Integer
            idx = tracks(e.Name & a.Name)
            If movements.ContainsKey(a.Name) AndAlso idx < movements(a.Name).Count Then
                e.Location = movements(a.Name).Item(idx)
                tracks(e.Name & a.Name) = idx + 1
            End If

        End If
    End Sub


    Sub move(p As PictureBox, xdir As Integer, ydir As Integer)
        p.Location += New Point(xdir, ydir)

        If IntersectsWith(p, "wall") Then
            p.Location -= New Point(xdir, ydir)
        End If
        Dim c As PictureBox
        If IntersectsWith(p, "score", c) Then
            c.Visible = False
        End If
        If IntersectsWith(p, "Sui", c) Then
            Me.BackColor = Color.Green
        End If
        If IntersectsWith(p, "Sui", c) Then
            win.Visible = True
        End If
        If IntersectsWith(avatar, "1") Then
            Me.BackColor = Color.Red

        End If
        If Not movements.ContainsKey(p.Name) Then
            movements.Add(p.Name, New Collection)
        End If
        movements(p.Name).Add(p.Location)

    End Sub

    Function endingWith(s As String) As Collection
        Dim coll As New Collection
        For Each o In Controls
            Dim obj As PictureBox
            obj = TryCast(o, PictureBox)
            If Not obj Is Nothing Then
                If UCase(obj.Name).EndsWith(UCase(s)) Then
                    coll.Add(obj)
                End If
            End If
        Next
        Return coll
    End Function
    Function IntersectsWith(p As PictureBox, tag As String) As Boolean
        Return IntersectsWith(p, tag, Nothing)
    End Function
    Function IntersectsWith(p As PictureBox, tag As String, Optional ByRef other As PictureBox = Nothing) As Boolean
        For Each o In Controls
            Dim obj As PictureBox
            obj = TryCast(o, PictureBox)
            If Not obj Is Nothing AndAlso obj.Visible Then
                If p.Bounds.IntersectsWith(obj.Bounds) And (UCase(obj.Tag) = UCase(tag) Or
                    UCase(obj.Name).EndsWith(UCase(tag))) Then
                    other = obj
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        score += 1
        scorelable.Text = score
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        avatar.Location = New Point(185, 134)
        enemy3.Location = New Point(1000, 53)
        enemy.Location = New Point(986, 2)
        PictureBox47.Location = New Point(568, 166)
        PictureBox40.Location = New Point(576, 349)
        PictureBox19.Location = New Point(279, 440)
        PictureBox41.Location = New Point(912, 526)
        PictureBox39.Location = New Point(1255, 255)
        PictureBox47.Visible = True
        PictureBox40.Visible = True
        PictureBox19.Visible = True
        PictureBox41.Visible = True
        PictureBox39.Visible = True
        win.Visible = False
        Me.BackColor = Color.White
    End Sub
End Class

