namespace GPSFrancisco
{
    partial class frmGerenciarProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGerenciarProdutos));
            this.btnInserir = new System.Windows.Forms.Button();
            this.pcbFotoProduto = new System.Windows.Forms.PictureBox();
            this.cbbUnidade = new System.Windows.Forms.ComboBox();
            this.lblUnidade = new System.Windows.Forms.Label();
            this.ofdCarregarProduto = new System.Windows.Forms.OpenFileDialog();
            this.pnlCRUD = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.gpbInformacoesProduto = new System.Windows.Forms.GroupBox();
            this.lblImgCodigoBarras = new System.Windows.Forms.Label();
            this.pctCodigoBarras = new System.Windows.Forms.PictureBox();
            this.btnUnidade = new System.Windows.Forms.Button();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblCodigoBarras = new System.Windows.Forms.Label();
            this.lblValidade = new System.Windows.Forms.Label();
            this.dtpValidade = new System.Windows.Forms.DateTimePicker();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.dtpHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.lblLote = new System.Windows.Forms.Label();
            this.lblDataEntrada = new System.Windows.Forms.Label();
            this.dtpDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFotoProduto)).BeginInit();
            this.pnlCRUD.SuspendLayout();
            this.gpbInformacoesProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCodigoBarras)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInserir
            // 
            this.btnInserir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserir.Location = new System.Drawing.Point(709, 204);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(150, 29);
            this.btnInserir.TabIndex = 25;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // pcbFotoProduto
            // 
            this.pcbFotoProduto.BackColor = System.Drawing.Color.White;
            this.pcbFotoProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbFotoProduto.Location = new System.Drawing.Point(709, 54);
            this.pcbFotoProduto.Name = "pcbFotoProduto";
            this.pcbFotoProduto.Size = new System.Drawing.Size(150, 144);
            this.pcbFotoProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbFotoProduto.TabIndex = 21;
            this.pcbFotoProduto.TabStop = false;
            // 
            // cbbUnidade
            // 
            this.cbbUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUnidade.FormattingEnabled = true;
            this.cbbUnidade.Location = new System.Drawing.Point(493, 182);
            this.cbbUnidade.Name = "cbbUnidade";
            this.cbbUnidade.Size = new System.Drawing.Size(146, 28);
            this.cbbUnidade.TabIndex = 11;
            this.cbbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbbUnidade_SelectedIndexChanged);
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Location = new System.Drawing.Point(493, 161);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(69, 20);
            this.lblUnidade.TabIndex = 19;
            this.lblUnidade.Text = "Unidade";
            // 
            // ofdCarregarProduto
            // 
            this.ofdCarregarProduto.FileName = "openFileDialog1";
            // 
            // pnlCRUD
            // 
            this.pnlCRUD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlCRUD.Controls.Add(this.btnVoltar);
            this.pnlCRUD.Controls.Add(this.btnLimpar);
            this.pnlCRUD.Controls.Add(this.btnPesquisar);
            this.pnlCRUD.Controls.Add(this.btnExcluir);
            this.pnlCRUD.Controls.Add(this.btnAlterar);
            this.pnlCRUD.Controls.Add(this.btnCadastrar);
            this.pnlCRUD.Controls.Add(this.btnNovo);
            this.pnlCRUD.Location = new System.Drawing.Point(8, 313);
            this.pnlCRUD.Name = "pnlCRUD";
            this.pnlCRUD.Size = new System.Drawing.Size(867, 65);
            this.pnlCRUD.TabIndex = 20;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(744, 11);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(121, 42);
            this.btnVoltar.TabIndex = 24;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(621, 11);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(121, 42);
            this.btnLimpar.TabIndex = 23;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.Location = new System.Drawing.Point(497, 11);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(121, 42);
            this.btnPesquisar.TabIndex = 22;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.Location = new System.Drawing.Point(374, 11);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(121, 42);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.Location = new System.Drawing.Point(252, 11);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(121, 42);
            this.btnAlterar.TabIndex = 20;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.Location = new System.Drawing.Point(129, 11);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(121, 42);
            this.btnCadastrar.TabIndex = 19;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCadastrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.Location = new System.Drawing.Point(4, 11);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(121, 42);
            this.btnNovo.TabIndex = 18;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // gpbInformacoesProduto
            // 
            this.gpbInformacoesProduto.Controls.Add(this.lblImgCodigoBarras);
            this.gpbInformacoesProduto.Controls.Add(this.pctCodigoBarras);
            this.gpbInformacoesProduto.Controls.Add(this.btnUnidade);
            this.gpbInformacoesProduto.Controls.Add(this.txtQuantidade);
            this.gpbInformacoesProduto.Controls.Add(this.lblQuantidade);
            this.gpbInformacoesProduto.Controls.Add(this.lblCodigoBarras);
            this.gpbInformacoesProduto.Controls.Add(this.lblValidade);
            this.gpbInformacoesProduto.Controls.Add(this.dtpValidade);
            this.gpbInformacoesProduto.Controls.Add(this.lblHoraEntrada);
            this.gpbInformacoesProduto.Controls.Add(this.txtLote);
            this.gpbInformacoesProduto.Controls.Add(this.dtpHoraEntrada);
            this.gpbInformacoesProduto.Controls.Add(this.lblLote);
            this.gpbInformacoesProduto.Controls.Add(this.lblDataEntrada);
            this.gpbInformacoesProduto.Controls.Add(this.dtpDataEntrada);
            this.gpbInformacoesProduto.Controls.Add(this.btnInserir);
            this.gpbInformacoesProduto.Controls.Add(this.pcbFotoProduto);
            this.gpbInformacoesProduto.Controls.Add(this.cbbUnidade);
            this.gpbInformacoesProduto.Controls.Add(this.lblUnidade);
            this.gpbInformacoesProduto.Controls.Add(this.txtDescricao);
            this.gpbInformacoesProduto.Controls.Add(this.lblDescricao);
            this.gpbInformacoesProduto.Controls.Add(this.txtCodigoBarras);
            this.gpbInformacoesProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbInformacoesProduto.Location = new System.Drawing.Point(8, 6);
            this.gpbInformacoesProduto.Name = "gpbInformacoesProduto";
            this.gpbInformacoesProduto.Size = new System.Drawing.Size(865, 301);
            this.gpbInformacoesProduto.TabIndex = 18;
            this.gpbInformacoesProduto.TabStop = false;
            this.gpbInformacoesProduto.Text = "Informações do produto";
            // 
            // lblImgCodigoBarras
            // 
            this.lblImgCodigoBarras.AutoSize = true;
            this.lblImgCodigoBarras.Location = new System.Drawing.Point(301, 33);
            this.lblImgCodigoBarras.Name = "lblImgCodigoBarras";
            this.lblImgCodigoBarras.Size = new System.Drawing.Size(189, 20);
            this.lblImgCodigoBarras.TabIndex = 39;
            this.lblImgCodigoBarras.Text = "Imagem código de barras";
            // 
            // pctCodigoBarras
            // 
            this.pctCodigoBarras.BackColor = System.Drawing.Color.White;
            this.pctCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctCodigoBarras.Location = new System.Drawing.Point(301, 56);
            this.pctCodigoBarras.Name = "pctCodigoBarras";
            this.pctCodigoBarras.Size = new System.Drawing.Size(383, 85);
            this.pctCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctCodigoBarras.TabIndex = 38;
            this.pctCodigoBarras.TabStop = false;
            // 
            // btnUnidade
            // 
            this.btnUnidade.FlatAppearance.BorderSize = 0;
            this.btnUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnidade.Image = ((System.Drawing.Image)(resources.GetObject("btnUnidade.Image")));
            this.btnUnidade.Location = new System.Drawing.Point(645, 182);
            this.btnUnidade.Name = "btnUnidade";
            this.btnUnidade.Size = new System.Drawing.Size(39, 28);
            this.btnUnidade.TabIndex = 37;
            this.btnUnidade.UseVisualStyleBackColor = true;
            this.btnUnidade.Click += new System.EventHandler(this.btnUnidade_Click);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(268, 184);
            this.txtQuantidade.MaxLength = 100;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(96, 26);
            this.txtQuantidade.TabIndex = 35;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(268, 161);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(92, 20);
            this.lblQuantidade.TabIndex = 36;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // lblCodigoBarras
            // 
            this.lblCodigoBarras.AutoSize = true;
            this.lblCodigoBarras.Location = new System.Drawing.Point(19, 33);
            this.lblCodigoBarras.Name = "lblCodigoBarras";
            this.lblCodigoBarras.Size = new System.Drawing.Size(130, 20);
            this.lblCodigoBarras.TabIndex = 34;
            this.lblCodigoBarras.Text = "Código de barras";
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Location = new System.Drawing.Point(577, 232);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(71, 20);
            this.lblValidade.TabIndex = 33;
            this.lblValidade.Text = "Validade";
            // 
            // dtpValidade
            // 
            this.dtpValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpValidade.Location = new System.Drawing.Point(577, 257);
            this.dtpValidade.Name = "dtpValidade";
            this.dtpValidade.Size = new System.Drawing.Size(107, 26);
            this.dtpValidade.TabIndex = 32;
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.AutoSize = true;
            this.lblHoraEntrada.Location = new System.Drawing.Point(427, 232);
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(125, 20);
            this.lblHoraEntrada.TabIndex = 31;
            this.lblHoraEntrada.Text = "Hora da entrada";
            // 
            // txtLote
            // 
            this.txtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLote.Location = new System.Drawing.Point(379, 184);
            this.txtLote.MaxLength = 5;
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(102, 26);
            this.txtLote.TabIndex = 26;
            // 
            // dtpHoraEntrada
            // 
            this.dtpHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEntrada.Location = new System.Drawing.Point(427, 257);
            this.dtpHoraEntrada.Name = "dtpHoraEntrada";
            this.dtpHoraEntrada.Size = new System.Drawing.Size(97, 26);
            this.dtpHoraEntrada.TabIndex = 29;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(379, 161);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(41, 20);
            this.lblLote.TabIndex = 27;
            this.lblLote.Text = "Lote";
            // 
            // lblDataEntrada
            // 
            this.lblDataEntrada.AutoSize = true;
            this.lblDataEntrada.Location = new System.Drawing.Point(280, 232);
            this.lblDataEntrada.Name = "lblDataEntrada";
            this.lblDataEntrada.Size = new System.Drawing.Size(125, 20);
            this.lblDataEntrada.TabIndex = 30;
            this.lblDataEntrada.Text = "Data de entrada";
            // 
            // dtpDataEntrada
            // 
            this.dtpDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrada.Location = new System.Drawing.Point(280, 257);
            this.dtpDataEntrada.Name = "dtpDataEntrada";
            this.dtpDataEntrada.Size = new System.Drawing.Size(103, 26);
            this.dtpDataEntrada.TabIndex = 28;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(19, 184);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(243, 26);
            this.txtDescricao.TabIndex = 2;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(19, 161);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(80, 20);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(19, 56);
            this.txtCodigoBarras.MaxLength = 13;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(261, 26);
            this.txtCodigoBarras.TabIndex = 1;
            this.txtCodigoBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBarras_KeyDown);
            // 
            // frmGerenciarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 383);
            this.Controls.Add(this.pnlCRUD);
            this.Controls.Add(this.gpbInformacoesProduto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGerenciarProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPSFrancisco - Gerenciar Produtos";
            this.Load += new System.EventHandler(this.frmGerenciarProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbFotoProduto)).EndInit();
            this.pnlCRUD.ResumeLayout(false);
            this.gpbInformacoesProduto.ResumeLayout(false);
            this.gpbInformacoesProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCodigoBarras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.PictureBox pcbFotoProduto;
        private System.Windows.Forms.ComboBox cbbUnidade;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.OpenFileDialog ofdCarregarProduto;
        private System.Windows.Forms.Panel pnlCRUD;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.GroupBox gpbInformacoesProduto;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label lblValidade;
        private System.Windows.Forms.DateTimePicker dtpValidade;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.DateTimePicker dtpHoraEntrada;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Label lblDataEntrada;
        private System.Windows.Forms.DateTimePicker dtpDataEntrada;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblCodigoBarras;
        private System.Windows.Forms.Button btnUnidade;
        private System.Windows.Forms.Label lblImgCodigoBarras;
        private System.Windows.Forms.PictureBox pctCodigoBarras;
    }
}