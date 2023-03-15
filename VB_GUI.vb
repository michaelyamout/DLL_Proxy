Public Class MainForm

    ' Define variables for the file paths
    Dim inputFilePath As String = ""
    Dim outputFilePath As String = ""

    Private Sub btnBrowseInput_Click(sender As Object, e As EventArgs) Handles btnBrowseInput.Click
        ' Open a file dialog for the user to select the input DLL file
        Dim fileDialog As New OpenFileDialog()
        fileDialog.Filter = "DLL files|*.dll"
        If fileDialog.ShowDialog() = DialogResult.OK Then
            ' Update the input file path and display it in the text box
            inputFilePath = fileDialog.FileName
            txtInputFile.Text = inputFilePath
        End If
    End Sub

    Private Sub btnBrowseOutput_Click(sender As Object, e As EventArgs) Handles btnBrowseOutput.Click
        ' Open a file dialog for the user to select the output DLL file
        Dim fileDialog As New SaveFileDialog()
        fileDialog.Filter = "DLL files|*.dll"
        If fileDialog.ShowDialog() = DialogResult.OK Then
            ' Update the output file path and display it in the text box
            outputFilePath = fileDialog.FileName
            txtOutputFile.Text = outputFilePath
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        ' Check that the input and output file paths have been set
        If inputFilePath = "" Or outputFilePath = "" Then
            MessageBox.Show("Please select both an input and an output DLL file.")
            Return
        End If

        ' Call the Python script with the input and output file paths as arguments
        Dim process As New Process()
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = "python"
        startInfo.Arguments = "dll_export_copy.py " & inputFilePath & " " & outputFilePath
        startInfo.RedirectStandardOutput = True
        startInfo.UseShellExecute = False
        process.StartInfo = startInfo
        process.Start()

        ' Display the output of the Python script in a message box
        Dim output As String = process.StandardOutput.ReadToEnd()
        MessageBox.Show(output)
    End Sub

End Class
