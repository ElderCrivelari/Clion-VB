<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menus
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menus))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Men_Fech = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Men_Clie = New System.Windows.Forms.ToolStripMenuItem()
        Me.Men_Reci = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpressãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Men_Irec = New System.Windows.Forms.ToolStripMenuItem()
        Me.SistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Men_Empr = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtualizaçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sta_Barr = New System.Windows.Forms.StatusStrip()
        Me.Sta_Bar1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Sta_Prog = New System.Windows.Forms.ToolStripProgressBar()
        Me.Tst_Internet = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Cmd_Novo = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Salv = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Pesq = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Dele = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Ante = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Prox = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Prnt = New System.Windows.Forms.ToolStripButton()
        Me.Tsp_Btns = New System.Windows.Forms.ToolStrip()
        Me.Cmd_Prim = New System.Windows.Forms.ToolStripButton()
        Me.Cmd_Ulti = New System.Windows.Forms.ToolStripButton()
        Me.Err_Prov = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Opn_File = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.Sta_Barr.SuspendLayout()
        Me.Tsp_Btns.SuspendLayout()
        CType(Me.Err_Prov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem, Me.ControleToolStripMenuItem, Me.ImpressãoToolStripMenuItem, Me.SistemaToolStripMenuItem, Me.AjudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(619, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArquivoToolStripMenuItem
        '
        Me.ArquivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Men_Fech, Me.ToolStripMenuItem1, Me.SairToolStripMenuItem})
        Me.ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem"
        Me.ArquivoToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ArquivoToolStripMenuItem.Text = "&Arquivo"
        '
        'Men_Fech
        '
        Me.Men_Fech.Image = CType(resources.GetObject("Men_Fech.Image"), System.Drawing.Image)
        Me.Men_Fech.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.Men_Fech.Name = "Men_Fech"
        Me.Men_Fech.Size = New System.Drawing.Size(109, 22)
        Me.Men_Fech.Text = "&Fechar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(106, 6)
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Image = CType(resources.GetObject("SairToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SairToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.SairToolStripMenuItem.Text = "&Sair"
        '
        'ControleToolStripMenuItem
        '
        Me.ControleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Men_Clie, Me.Men_Reci})
        Me.ControleToolStripMenuItem.Name = "ControleToolStripMenuItem"
        Me.ControleToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.ControleToolStripMenuItem.Text = "&Cadastros"
        '
        'Men_Clie
        '
        Me.Men_Clie.Name = "Men_Clie"
        Me.Men_Clie.Size = New System.Drawing.Size(116, 22)
        Me.Men_Clie.Text = "&Clientes"
        '
        'Men_Reci
        '
        Me.Men_Reci.Name = "Men_Reci"
        Me.Men_Reci.Size = New System.Drawing.Size(116, 22)
        Me.Men_Reci.Text = "&Recibos"
        '
        'ImpressãoToolStripMenuItem
        '
        Me.ImpressãoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Men_Irec})
        Me.ImpressãoToolStripMenuItem.Name = "ImpressãoToolStripMenuItem"
        Me.ImpressãoToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.ImpressãoToolStripMenuItem.Text = "&Relatórios"
        '
        'Men_Irec
        '
        Me.Men_Irec.Name = "Men_Irec"
        Me.Men_Irec.Size = New System.Drawing.Size(115, 22)
        Me.Men_Irec.Text = "&Recibos"
        '
        'SistemaToolStripMenuItem
        '
        Me.SistemaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Men_Empr, Me.OpçõesToolStripMenuItem, Me.AtualizaçãoToolStripMenuItem})
        Me.SistemaToolStripMenuItem.Name = "SistemaToolStripMenuItem"
        Me.SistemaToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.SistemaToolStripMenuItem.Text = "&Sistema"
        '
        'Men_Empr
        '
        Me.Men_Empr.Name = "Men_Empr"
        Me.Men_Empr.Size = New System.Drawing.Size(171, 22)
        Me.Men_Empr.Text = "&Dados da Empresa"
        '
        'OpçõesToolStripMenuItem
        '
        Me.OpçõesToolStripMenuItem.Enabled = False
        Me.OpçõesToolStripMenuItem.Name = "OpçõesToolStripMenuItem"
        Me.OpçõesToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.OpçõesToolStripMenuItem.Text = "Opções"
        '
        'AtualizaçãoToolStripMenuItem
        '
        Me.AtualizaçãoToolStripMenuItem.Name = "AtualizaçãoToolStripMenuItem"
        Me.AtualizaçãoToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.AtualizaçãoToolStripMenuItem.Text = "&Atualização"
        '
        'AjudaToolStripMenuItem
        '
        Me.AjudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SobreToolStripMenuItem})
        Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.AjudaToolStripMenuItem.Text = "A&juda"
        '
        'SobreToolStripMenuItem
        '
        Me.SobreToolStripMenuItem.Image = CType(resources.GetObject("SobreToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SobreToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.SobreToolStripMenuItem.Name = "SobreToolStripMenuItem"
        Me.SobreToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.SobreToolStripMenuItem.Text = "&Sobre"
        '
        'Sta_Barr
        '
        Me.Sta_Barr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Sta_Bar1, Me.Sta_Prog, Me.Tst_Internet})
        Me.Sta_Barr.Location = New System.Drawing.Point(0, 394)
        Me.Sta_Barr.Name = "Sta_Barr"
        Me.Sta_Barr.Size = New System.Drawing.Size(619, 22)
        Me.Sta_Barr.TabIndex = 2
        '
        'Sta_Bar1
        '
        Me.Sta_Bar1.Name = "Sta_Bar1"
        Me.Sta_Bar1.Size = New System.Drawing.Size(0, 17)
        '
        'Sta_Prog
        '
        Me.Sta_Prog.Name = "Sta_Prog"
        Me.Sta_Prog.RightToLeftLayout = True
        Me.Sta_Prog.Size = New System.Drawing.Size(100, 16)
        Me.Sta_Prog.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Sta_Prog.Visible = False
        '
        'Tst_Internet
        '
        Me.Tst_Internet.Name = "Tst_Internet"
        Me.Tst_Internet.Size = New System.Drawing.Size(604, 17)
        Me.Tst_Internet.Spring = True
        Me.Tst_Internet.Text = "Procurando conexão com a internet..."
        Me.Tst_Internet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Tst_Internet.ToolTipText = "Procurando..."
        '
        'Cmd_Novo
        '
        Me.Cmd_Novo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Novo.Image = CType(resources.GetObject("Cmd_Novo.Image"), System.Drawing.Image)
        Me.Cmd_Novo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Novo.Name = "Cmd_Novo"
        Me.Cmd_Novo.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Novo.Text = "Novo"
        Me.Cmd_Novo.ToolTipText = "Novo"
        '
        'Cmd_Salv
        '
        Me.Cmd_Salv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Salv.Image = CType(resources.GetObject("Cmd_Salv.Image"), System.Drawing.Image)
        Me.Cmd_Salv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Salv.Name = "Cmd_Salv"
        Me.Cmd_Salv.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Salv.Text = "Salvar"
        Me.Cmd_Salv.ToolTipText = "Salvar"
        '
        'Cmd_Pesq
        '
        Me.Cmd_Pesq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Pesq.Image = CType(resources.GetObject("Cmd_Pesq.Image"), System.Drawing.Image)
        Me.Cmd_Pesq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Pesq.Name = "Cmd_Pesq"
        Me.Cmd_Pesq.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Pesq.Text = "Pesquisar"
        Me.Cmd_Pesq.ToolTipText = "Pesquisar"
        '
        'Cmd_Dele
        '
        Me.Cmd_Dele.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Dele.Image = CType(resources.GetObject("Cmd_Dele.Image"), System.Drawing.Image)
        Me.Cmd_Dele.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Dele.Name = "Cmd_Dele"
        Me.Cmd_Dele.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Dele.Text = "Deletar"
        Me.Cmd_Dele.ToolTipText = "Apagar"
        '
        'Cmd_Ante
        '
        Me.Cmd_Ante.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Ante.Image = CType(resources.GetObject("Cmd_Ante.Image"), System.Drawing.Image)
        Me.Cmd_Ante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Ante.Name = "Cmd_Ante"
        Me.Cmd_Ante.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Ante.Text = "Anterior"
        Me.Cmd_Ante.ToolTipText = "Anterior"
        '
        'Cmd_Prox
        '
        Me.Cmd_Prox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Prox.Image = CType(resources.GetObject("Cmd_Prox.Image"), System.Drawing.Image)
        Me.Cmd_Prox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Prox.Name = "Cmd_Prox"
        Me.Cmd_Prox.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Prox.Text = "Proximo"
        Me.Cmd_Prox.ToolTipText = "Próximo"
        '
        'Cmd_Prnt
        '
        Me.Cmd_Prnt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Prnt.Image = CType(resources.GetObject("Cmd_Prnt.Image"), System.Drawing.Image)
        Me.Cmd_Prnt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Prnt.Name = "Cmd_Prnt"
        Me.Cmd_Prnt.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Prnt.Text = "Imprimir"
        Me.Cmd_Prnt.ToolTipText = "Imprimir"
        '
        'Tsp_Btns
        '
        Me.Tsp_Btns.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tsp_Btns.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cmd_Novo, Me.Cmd_Salv, Me.Cmd_Pesq, Me.Cmd_Dele, Me.Cmd_Prim, Me.Cmd_Ante, Me.Cmd_Prox, Me.Cmd_Ulti, Me.Cmd_Prnt})
        Me.Tsp_Btns.Location = New System.Drawing.Point(0, 24)
        Me.Tsp_Btns.Name = "Tsp_Btns"
        Me.Tsp_Btns.Size = New System.Drawing.Size(619, 25)
        Me.Tsp_Btns.TabIndex = 10
        Me.Tsp_Btns.Text = "ToolStrip1"
        '
        'Cmd_Prim
        '
        Me.Cmd_Prim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Prim.Image = CType(resources.GetObject("Cmd_Prim.Image"), System.Drawing.Image)
        Me.Cmd_Prim.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Prim.Name = "Cmd_Prim"
        Me.Cmd_Prim.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Prim.Text = "Primeiro"
        '
        'Cmd_Ulti
        '
        Me.Cmd_Ulti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cmd_Ulti.Image = CType(resources.GetObject("Cmd_Ulti.Image"), System.Drawing.Image)
        Me.Cmd_Ulti.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cmd_Ulti.Name = "Cmd_Ulti"
        Me.Cmd_Ulti.Size = New System.Drawing.Size(23, 22)
        Me.Cmd_Ulti.Text = "Ultimo"
        '
        'Err_Prov
        '
        Me.Err_Prov.ContainerControl = Me
        '
        'Opn_File
        '
        Me.Opn_File.FileName = "OpenFileDialog1"
        '
        'Menus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(619, 416)
        Me.Controls.Add(Me.Tsp_Btns)
        Me.Controls.Add(Me.Sta_Barr)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Menus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clion - Administrador de Clientes"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Sta_Barr.ResumeLayout(False)
        Me.Sta_Barr.PerformLayout()
        Me.Tsp_Btns.ResumeLayout(False)
        Me.Tsp_Btns.PerformLayout()
        CType(Me.Err_Prov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Men_Fech As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SobreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sta_Barr As System.Windows.Forms.StatusStrip
    Friend WithEvents Sta_Bar1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Sta_Prog As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Cmd_Novo As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Salv As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Pesq As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Dele As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Ante As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Prox As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Prnt As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tsp_Btns As System.Windows.Forms.ToolStrip
    Friend WithEvents Err_Prov As System.Windows.Forms.ErrorProvider
    Friend WithEvents Opn_File As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ControleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmd_Prim As System.Windows.Forms.ToolStripButton
    Friend WithEvents Cmd_Ulti As System.Windows.Forms.ToolStripButton
    Friend WithEvents Men_Clie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tst_Internet As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Men_Reci As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Men_Empr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImpressãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Men_Irec As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AtualizaçãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
