<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StaffInfoForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.FirstNameLabel = New System.Windows.Forms.Label()
        Me.LastNameLabel = New System.Windows.Forms.Label()
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.StaffInfoDataGridView = New System.Windows.Forms.DataGridView()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NewStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.StaffInfoDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchGroupBox.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FirstNameLabel
        '
        Me.FirstNameLabel.AutoSize = True
        Me.FirstNameLabel.Location = New System.Drawing.Point(47, 26)
        Me.FirstNameLabel.Name = "FirstNameLabel"
        Me.FirstNameLabel.Size = New System.Drawing.Size(60, 13)
        Me.FirstNameLabel.TabIndex = 0
        Me.FirstNameLabel.Text = "First Name:"
        '
        'LastNameLabel
        '
        Me.LastNameLabel.AutoSize = True
        Me.LastNameLabel.Location = New System.Drawing.Point(338, 26)
        Me.LastNameLabel.Name = "LastNameLabel"
        Me.LastNameLabel.Size = New System.Drawing.Size(61, 13)
        Me.LastNameLabel.TabIndex = 1
        Me.LastNameLabel.Text = "Last Name:"
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.Location = New System.Drawing.Point(113, 23)
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.FirstNameTextBox.TabIndex = 2
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.Location = New System.Drawing.Point(405, 23)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.LastNameTextBox.TabIndex = 3
        '
        'StaffInfoDataGridView
        '
        Me.StaffInfoDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StaffInfoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.StaffInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StaffInfoDataGridView.Location = New System.Drawing.Point(12, 96)
        Me.StaffInfoDataGridView.Name = "StaffInfoDataGridView"
        Me.StaffInfoDataGridView.ReadOnly = True
        Me.StaffInfoDataGridView.Size = New System.Drawing.Size(1160, 443)
        Me.StaffInfoDataGridView.TabIndex = 6
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Controls.Add(Me.LastNameTextBox)
        Me.SearchGroupBox.Controls.Add(Me.FirstNameLabel)
        Me.SearchGroupBox.Controls.Add(Me.LastNameLabel)
        Me.SearchGroupBox.Controls.Add(Me.FirstNameTextBox)
        Me.SearchGroupBox.Location = New System.Drawing.Point(12, 27)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(650, 61)
        Me.SearchGroupBox.TabIndex = 7
        Me.SearchGroupBox.TabStop = False
        Me.SearchGroupBox.Text = "Search"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewStaffToolStripMenuItem, Me.EditCustomerToolStripMenuItem, Me.DeleteCustomerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewStaffToolStripMenuItem
        '
        Me.NewStaffToolStripMenuItem.Name = "NewStaffToolStripMenuItem"
        Me.NewStaffToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.NewStaffToolStripMenuItem.Text = "New Staff"
        '
        'EditCustomerToolStripMenuItem
        '
        Me.EditCustomerToolStripMenuItem.Enabled = False
        Me.EditCustomerToolStripMenuItem.Name = "EditCustomerToolStripMenuItem"
        Me.EditCustomerToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.EditCustomerToolStripMenuItem.Text = "Edit Staff"
        '
        'DeleteCustomerToolStripMenuItem
        '
        Me.DeleteCustomerToolStripMenuItem.Enabled = False
        Me.DeleteCustomerToolStripMenuItem.Name = "DeleteCustomerToolStripMenuItem"
        Me.DeleteCustomerToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.DeleteCustomerToolStripMenuItem.Text = "Delete Staff"
        '
        'StaffInfoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 561)
        Me.Controls.Add(Me.SearchGroupBox)
        Me.Controls.Add(Me.StaffInfoDataGridView)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "StaffInfoForm"
        Me.Text = "Sakila Staff"
        CType(Me.StaffInfoDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FirstNameLabel As Label
    Friend WithEvents LastNameLabel As Label
    Friend WithEvents FirstNameTextBox As TextBox
    Friend WithEvents LastNameTextBox As TextBox
    Friend WithEvents StaffInfoDataGridView As DataGridView
    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents NewStaffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditCustomerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteCustomerToolStripMenuItem As ToolStripMenuItem
End Class
