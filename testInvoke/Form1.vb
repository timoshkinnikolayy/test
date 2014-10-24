Public Class mainForm

    Dim dt As New DataTable



    Private Sub mainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        
    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        dt.Columns.Add("id", Type.GetType("System.Int16"))
        dt.Columns.Add("name", Type.GetType("System.String"))
        dt.Columns.Add("progress", Type.GetType("System.Int16"))

        dt.PrimaryKey = {dt.Columns("id")}
        dt.Columns("id").AutoIncrement = True

        gridStatus.DataSource = dt


    End Sub



    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        With New Threading.Thread(AddressOf addRowToDataSource)
            .Start()
        End With


    End Sub

    Delegate Sub addRow()
    Delegate Sub updateRow(ByVal dr As DataRow)

    Private Sub addRowToDataTable()

        Dim dr As DataRow

        dr = dt.Rows.Add
        dr.Item("progress") = 0
        dr.Item("name") = "Item #" + dr.Item("id").ToString

    End Sub

    Private Sub updateRowToDataTable(ByVal dr As DataRow)

        If Not IsDBNull(dr("progress")) Then
            dr("progress") += 1
        End If

    End Sub



    Public Sub addRowToDataSource()

        Dim dr As DataRow

        If gridStatus.InvokeRequired Then
            gridStatus.Invoke(New addRow(AddressOf addRowToDataTable))
        Else
            dr = dt.Rows.Add
            dr.Item("progress") = 0
            dr.Item("name") = "Item #" + dr.Item("id").ToString
        End If

        updateRowToDataSource(dt.Rows.Count - 1)

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

        Next


    End Sub



End Class
