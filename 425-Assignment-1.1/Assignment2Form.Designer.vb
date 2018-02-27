<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Assignment2Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.LastNameLabel = New System.Windows.Forms.Label()
        Me.PostalCodeLabel = New System.Windows.Forms.Label()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.PostalCodeTextBox = New System.Windows.Forms.TextBox()
        Me.CustomerAddressDataGridView = New System.Windows.Forms.DataGridView()
        Me.SearchGroupBox.SuspendLayout()
        CType(Me.CustomerAddressDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Controls.Add(Me.PostalCodeTextBox)
        Me.SearchGroupBox.Controls.Add(Me.LastNameTextBox)
        Me.SearchGroupBox.Controls.Add(Me.PostalCodeLabel)
        Me.SearchGroupBox.Controls.Add(Me.LastNameLabel)
        Me.SearchGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(728, 71)
        Me.SearchGroupBox.TabIndex = 0
        Me.SearchGroupBox.TabStop = False
        Me.SearchGroupBox.Text = "Search"
        '
        'LastNameLabel
        '
        Me.LastNameLabel.AutoSize = True
        Me.LastNameLabel.Location = New System.Drawing.Point(26, 31)
        Me.LastNameLabel.Name = "LastNameLabel"
        Me.LastNameLabel.Size = New System.Drawing.Size(61, 13)
        Me.LastNameLabel.TabIndex = 0
        Me.LastNameLabel.Text = "Last Name:"
        '
        'PostalCodeLabel
        '
        Me.PostalCodeLabel.AutoSize = True
        Me.PostalCodeLabel.Location = New System.Drawing.Point(353, 31)
        Me.PostalCodeLabel.Name = "PostalCodeLabel"
        Me.PostalCodeLabel.Size = New System.Drawing.Size(67, 13)
        Me.PostalCodeLabel.TabIndex = 0
        Me.PostalCodeLabel.Text = "Postal Code:"
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.Location = New System.Drawing.Point(93, 28)
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.LastNameTextBox.TabIndex = 1
        '
        'PostalCodeTextBox
        '
        Me.PostalCodeTextBox.Location = New System.Drawing.Point(426, 28)
        Me.PostalCodeTextBox.Name = "PostalCodeTextBox"
        Me.PostalCodeTextBox.Size = New System.Drawing.Size(200, 20)
        Me.PostalCodeTextBox.TabIndex = 1
        '
        'CustomerAddressDataGridView
        '
        Me.CustomerAddressDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustomerAddressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CustomerAddressDataGridView.Location = New System.Drawing.Point(12, 89)
        Me.CustomerAddressDataGridView.Name = "CustomerAddressDataGridView"
        Me.CustomerAddressDataGridView.Size = New System.Drawing.Size(1114, 450)
        Me.CustomerAddressDataGridView.TabIndex = 1
        '
        'Assignment2Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 551)
        Me.Controls.Add(Me.CustomerAddressDataGridView)
        Me.Controls.Add(Me.SearchGroupBox)
        Me.MaximizeBox = False
        Me.Name = "Assignment2Form"
        Me.Text = "Address Look Up"
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        CType(Me.CustomerAddressDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents PostalCodeTextBox As TextBox
    Friend WithEvents LastNameTextBox As TextBox
    Friend WithEvents PostalCodeLabel As Label
    Friend WithEvents LastNameLabel As Label
    Friend WithEvents CustomerAddressDataGridView As DataGridView
End Class
