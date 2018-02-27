Public Class ImageRoutinesClass
    Public Sub LoadImage(ByVal aPictureBox As PictureBox)

        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        ofd.Filter = "JPEG files (*.jpg)|*.jpg|Bitmap files (*.bmp)|*.bmp"
        Dim result As DialogResult = ofd.ShowDialog
        If Not (aPictureBox) Is Nothing And ofd.FileName <> String.Empty Then
            aPictureBox.Image = Image.FromFile(ofd.FileName)
        End If

    End Sub

    Public Sub LoadBackgroundImage(ByVal aPictureBox As PictureBox)

        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        ofd.Filter = "JPEG files (*.jpg)|*.jpg|Bitmap files (*.bmp)|*.bmp"
        Dim result As DialogResult = ofd.ShowDialog
        If Not (aPictureBox) Is Nothing And ofd.FileName <> String.Empty Then
            aPictureBox.BackgroundImage = Image.FromFile(ofd.FileName)
            aPictureBox.BackgroundImageLayout = ImageLayout.Zoom
        End If

    End Sub
End Class
