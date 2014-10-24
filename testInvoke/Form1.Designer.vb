<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.statusBar = New System.Windows.Forms.StatusStrip()
        Me.statusProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.gridStatus = New System.Windows.Forms.DataGridView()
        Me.statusBar.SuspendLayout()
        CType(Me.gridStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(195, 8)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(90, 35)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusProgress})
        Me.statusBar.Location = New System.Drawing.Point(0, 271)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(472, 22)
        Me.statusBar.TabIndex = 1
        Me.statusBar.Text = "StatusStrip1"
        '
        'statusProgress
        '
        Me.statusProgress.Name = "statusProgress"
        Me.statusProgress.Size = New System.Drawing.Size(100, 16)
        '
        'gridStatus
        '
        Me.gridStatus.AllowUserToAddRows = False
        Me.gridStatus.AllowUserToDeleteRows = False
        Me.gridStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridStatus.Location = New System.Drawing.Point(0, 53)
        Me.gridStatus.Name = "gridStatus"
        Me.gridStatus.ReadOnly = True
        Me.gridStatus.Size = New System.Drawing.Size(472, 215)
        Me.gridStatus.TabIndex = 2
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 293)
        Me.Controls.Add(Me.gridStatus)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.btnStart)
        Me.Name = "mainForm"
        Me.Text = "testInvoke"
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        CType(Me.gridStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents statusProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents gridStatus As System.Windows.Forms.DataGridView

End Class
