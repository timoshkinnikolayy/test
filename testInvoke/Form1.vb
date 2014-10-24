Public Class mainForm

    Dim dt As New DataTable



    Private Sub mainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        
    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        'sayHelloWorld()

        dt.Columns.Add("id", Type.GetType("System.Int16"))
        dt.Columns.Add("name", Type.GetType("System.String"))
        dt.Columns.Add("progress", Type.GetType("System.Int16"))

        dt.PrimaryKey = {dt.Columns("id")}
        dt.Columns("id").AutoIncrement = False

        gridStatus.DataSource = dt


    End Sub



    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        With New Threading.Thread(AddressOf addRowToDataSource)
            .Start()
        End With


    End Sub

    Delegate Sub addRow(ByVal threadId As Integer)
    Delegate Sub updateRow(ByVal dr As DataRow)
    Delegate Sub updateProgress()


    Private Sub updateProgressToMainForm()

        Dim totalProgress As Integer = 0

        For Each dr As DataRow In dt.Rows
            totalProgress += dr("progress")
        Next

        statusProgress.Value = CInt(totalProgress \ dt.Rows.Count)
        statusText.Text = statusProgress.Value.ToString + "%"

        If statusProgress.Value = 100 Then
            statusText.Text = "Finished"
        End If

        Me.Text = Application.ProductName + " - " + statusText.Text

    End Sub


    Private Sub addRowToDataTable(threadId As Integer)

        Dim dr As DataRow

        dr = dt.Rows.Add(threadId, "Item #" + threadId.ToString, 0)

    End Sub

    Private Sub updateRowToDataTable(ByVal dr As DataRow)

        If Not IsDBNull(dr("progress")) Then
            dr("progress") += 1
        End If

    End Sub



    Public Sub addRowToDataSource()

        Dim dr As DataRow

        Dim threadId As Integer = System.Threading.Thread.CurrentThread.ManagedThreadId

        If gridStatus.InvokeRequired Then
            gridStatus.Invoke(New addRow(AddressOf addRowToDataTable), New Object() {threadId})
        Else
            dr = dt.Rows.Add(threadId, "Item #" + threadId.ToString, 0)
        End If

        updateRowToDataSource(threadId)

    End Sub


    Public Sub updateRowToDataSource(rowId As Integer)

        Dim myRnd As New Random
        Dim dr As DataRow = dt.Rows.Find(rowId)

        For x = 1 To 100

            System.Threading.Thread.Sleep(myRnd.Next(100, 800))

            If gridStatus.InvokeRequired Then
                gridStatus.Invoke(New updateRow(AddressOf updateRowToDataTable), New Object() {dr})
            Else
                dr.Item("progress") += 1
            End If

            Me.Invoke(New updateProgress(AddressOf updateProgressToMainForm))

        Next


    End Sub



End Class
