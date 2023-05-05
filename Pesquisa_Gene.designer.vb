<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pesquisa_Gene
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grd_Pesq = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_Dcpf = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Txt_Dcrg = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Msk_Nasc = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Chk_Fale = New System.Windows.Forms.CheckBox()
        Me.Chk_Mudo = New System.Windows.Forms.CheckBox()
        Me.Chk_Canc = New System.Windows.Forms.CheckBox()
        Me.Txt_Tele = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Esta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Cida = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Bair = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Nume = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Ende = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Nome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Cepe = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_Clie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Grd_Pesq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Grd_Pesq)
        Me.Panel1.Location = New System.Drawing.Point(12, 197)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(569, 209)
        Me.Panel1.TabIndex = 0
        '
        'Grd_Pesq
        '
        Me.Grd_Pesq.AllowUserToAddRows = False
        Me.Grd_Pesq.AllowUserToDeleteRows = False
        Me.Grd_Pesq.AllowUserToOrderColumns = True
        Me.Grd_Pesq.AllowUserToResizeColumns = False
        Me.Grd_Pesq.AllowUserToResizeRows = False
        Me.Grd_Pesq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Grd_Pesq.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Grd_Pesq.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.Grd_Pesq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd_Pesq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd_Pesq.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grd_Pesq.Location = New System.Drawing.Point(0, 0)
        Me.Grd_Pesq.Name = "Grd_Pesq"
        Me.Grd_Pesq.ReadOnly = True
        Me.Grd_Pesq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grd_Pesq.ShowEditingIcon = False
        Me.Grd_Pesq.Size = New System.Drawing.Size(565, 205)
        Me.Grd_Pesq.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Txt_Dcpf)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Txt_Dcrg)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Msk_Nasc)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Chk_Fale)
        Me.GroupBox1.Controls.Add(Me.Chk_Mudo)
        Me.GroupBox1.Controls.Add(Me.Chk_Canc)
        Me.GroupBox1.Controls.Add(Me.Txt_Tele)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Txt_Esta)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Txt_Cida)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Txt_Bair)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Txt_Nume)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txt_Ende)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Txt_Nome)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Txt_Cepe)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Txt_Clie)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(569, 179)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pesquisar:"
        '
        'Txt_Dcpf
        '
        Me.Txt_Dcpf.Location = New System.Drawing.Point(335, 125)
        Me.Txt_Dcpf.Name = "Txt_Dcpf"
        Me.Txt_Dcpf.Size = New System.Drawing.Size(222, 20)
        Me.Txt_Dcpf.TabIndex = 11
        Me.Txt_Dcpf.Tag = "Código do item - Automático"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(272, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "CPF/CNPJ:"
        '
        'Txt_Dcrg
        '
        Me.Txt_Dcrg.Location = New System.Drawing.Point(38, 125)
        Me.Txt_Dcrg.Name = "Txt_Dcrg"
        Me.Txt_Dcrg.Size = New System.Drawing.Size(228, 20)
        Me.Txt_Dcrg.TabIndex = 10
        Me.Txt_Dcrg.Tag = "Código do item - Automático"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "RG:"
        '
        'Msk_Nasc
        '
        Me.Msk_Nasc.Location = New System.Drawing.Point(196, 47)
        Me.Msk_Nasc.Mask = "00/00/0000"
        Me.Msk_Nasc.Name = "Msk_Nasc"
        Me.Msk_Nasc.Size = New System.Drawing.Size(68, 20)
        Me.Msk_Nasc.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(124, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Nascimento:"
        '
        'Chk_Fale
        '
        Me.Chk_Fale.AutoSize = True
        Me.Chk_Fale.Location = New System.Drawing.Point(358, 154)
        Me.Chk_Fale.Name = "Chk_Fale"
        Me.Chk_Fale.Size = New System.Drawing.Size(71, 17)
        Me.Chk_Fale.TabIndex = 15
        Me.Chk_Fale.Text = "Falescido"
        Me.Chk_Fale.UseVisualStyleBackColor = True
        '
        'Chk_Mudo
        '
        Me.Chk_Mudo.AutoSize = True
        Me.Chk_Mudo.Location = New System.Drawing.Point(279, 154)
        Me.Chk_Mudo.Name = "Chk_Mudo"
        Me.Chk_Mudo.Size = New System.Drawing.Size(73, 17)
        Me.Chk_Mudo.TabIndex = 14
        Me.Chk_Mudo.Text = "Mudou-se"
        Me.Chk_Mudo.UseVisualStyleBackColor = True
        '
        'Chk_Canc
        '
        Me.Chk_Canc.AutoSize = True
        Me.Chk_Canc.Location = New System.Drawing.Point(196, 154)
        Me.Chk_Canc.Name = "Chk_Canc"
        Me.Chk_Canc.Size = New System.Drawing.Size(77, 17)
        Me.Chk_Canc.TabIndex = 13
        Me.Chk_Canc.Text = "Cancelado"
        Me.Chk_Canc.UseVisualStyleBackColor = True
        '
        'Txt_Tele
        '
        Me.Txt_Tele.Location = New System.Drawing.Point(69, 152)
        Me.Txt_Tele.Name = "Txt_Tele"
        Me.Txt_Tele.Size = New System.Drawing.Size(121, 20)
        Me.Txt_Tele.TabIndex = 12
        Me.Txt_Tele.Tag = "Código do item - Automático"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 155)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Telefones:"
        '
        'Txt_Esta
        '
        Me.Txt_Esta.Location = New System.Drawing.Point(530, 99)
        Me.Txt_Esta.Name = "Txt_Esta"
        Me.Txt_Esta.Size = New System.Drawing.Size(27, 20)
        Me.Txt_Esta.TabIndex = 9
        Me.Txt_Esta.Tag = "Código do item - Automático"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(502, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "UF:"
        '
        'Txt_Cida
        '
        Me.Txt_Cida.Location = New System.Drawing.Point(332, 99)
        Me.Txt_Cida.Name = "Txt_Cida"
        Me.Txt_Cida.Size = New System.Drawing.Size(164, 20)
        Me.Txt_Cida.TabIndex = 8
        Me.Txt_Cida.Tag = "Código do item - Automático"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(283, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Cidade:"
        '
        'Txt_Bair
        '
        Me.Txt_Bair.Location = New System.Drawing.Point(49, 99)
        Me.Txt_Bair.Name = "Txt_Bair"
        Me.Txt_Bair.Size = New System.Drawing.Size(228, 20)
        Me.Txt_Bair.TabIndex = 7
        Me.Txt_Bair.Tag = "Código do item - Automático"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Bairro:"
        '
        'Txt_Nume
        '
        Me.Txt_Nume.Location = New System.Drawing.Point(491, 73)
        Me.Txt_Nume.Name = "Txt_Nume"
        Me.Txt_Nume.Size = New System.Drawing.Size(66, 20)
        Me.Txt_Nume.TabIndex = 6
        Me.Txt_Nume.Tag = "Código do item - Automático"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(463, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Nº:"
        '
        'Txt_Ende
        '
        Me.Txt_Ende.Location = New System.Drawing.Point(42, 73)
        Me.Txt_Ende.Name = "Txt_Ende"
        Me.Txt_Ende.Size = New System.Drawing.Size(415, 20)
        Me.Txt_Ende.TabIndex = 5
        Me.Txt_Ende.Tag = "Código do item - Automático"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Rua:"
        '
        'Txt_Nome
        '
        Me.Txt_Nome.Location = New System.Drawing.Point(158, 21)
        Me.Txt_Nome.Name = "Txt_Nome"
        Me.Txt_Nome.Size = New System.Drawing.Size(399, 20)
        Me.Txt_Nome.TabIndex = 2
        Me.Txt_Nome.Tag = "Digite aqui a referência/nome da conta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(114, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Nome:"
        '
        'Txt_Cepe
        '
        Me.Txt_Cepe.Location = New System.Drawing.Point(54, 47)
        Me.Txt_Cepe.Name = "Txt_Cepe"
        Me.Txt_Cepe.Size = New System.Drawing.Size(54, 20)
        Me.Txt_Cepe.TabIndex = 3
        Me.Txt_Cepe.Tag = "Código do item - Automático"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "CEP:"
        '
        'Txt_Clie
        '
        Me.Txt_Clie.Location = New System.Drawing.Point(54, 21)
        Me.Txt_Clie.Name = "Txt_Clie"
        Me.Txt_Clie.Size = New System.Drawing.Size(54, 20)
        Me.Txt_Clie.TabIndex = 1
        Me.Txt_Clie.Tag = "Código do item - Automático"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Cliente:"
        '
        'Pesquisa_Gene
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 418)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Pesquisa_Gene"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa por :"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grd_Pesq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Grd_Pesq As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Msk_Nasc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Chk_Fale As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Mudo As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Canc As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Tele As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_Esta As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_Cida As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_Bair As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Nume As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Ende As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Nome As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Cepe As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_Clie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Dcpf As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txt_Dcrg As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
