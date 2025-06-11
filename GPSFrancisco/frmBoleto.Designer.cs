namespace GPSFrancisco
{
    partial class frmBoleto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoleto));
            this.btnCalculaBoleto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pctCodigoBarras = new System.Windows.Forms.PictureBox();
            this.txtNumCodigoBarras = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstParcelas = new System.Windows.Forms.ListBox();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiasBoleto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEmissaoBoleto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalculaParcelas = new System.Windows.Forms.Button();
            this.btnGerarCodigoBarras = new System.Windows.Forms.Button();
            this.pctQRCode = new System.Windows.Forms.PictureBox();
            this.btnGerarQRCode = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCodigoBarras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCalculaBoleto
            // 
            this.btnCalculaBoleto.Location = new System.Drawing.Point(15, 586);
            this.btnCalculaBoleto.Name = "btnCalculaBoleto";
            this.btnCalculaBoleto.Size = new System.Drawing.Size(186, 43);
            this.btnCalculaBoleto.TabIndex = 0;
            this.btnCalculaBoleto.Text = "Calcula boleto";
            this.btnCalculaBoleto.UseVisualStyleBackColor = true;
            this.btnCalculaBoleto.Click += new System.EventHandler(this.btnCalculaBoleto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pctQRCode);
            this.groupBox1.Controls.Add(this.pctCodigoBarras);
            this.groupBox1.Controls.Add(this.txtNumCodigoBarras);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lstParcelas);
            this.groupBox1.Controls.Add(this.txtValorTotal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDiasBoleto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEmissaoBoleto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 535);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da emissão";
            // 
            // pctCodigoBarras
            // 
            this.pctCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctCodigoBarras.Location = new System.Drawing.Point(38, 280);
            this.pctCodigoBarras.Name = "pctCodigoBarras";
            this.pctCodigoBarras.Size = new System.Drawing.Size(375, 85);
            this.pctCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctCodigoBarras.TabIndex = 10;
            this.pctCodigoBarras.TabStop = false;
            // 
            // txtNumCodigoBarras
            // 
            this.txtNumCodigoBarras.Location = new System.Drawing.Point(38, 239);
            this.txtNumCodigoBarras.MaxLength = 13;
            this.txtNumCodigoBarras.Name = "txtNumCodigoBarras";
            this.txtNumCodigoBarras.Size = new System.Drawing.Size(375, 26);
            this.txtNumCodigoBarras.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gerar código de barras";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Valor total produto";
            // 
            // lstParcelas
            // 
            this.lstParcelas.FormattingEnabled = true;
            this.lstParcelas.ItemHeight = 20;
            this.lstParcelas.Location = new System.Drawing.Point(488, 84);
            this.lstParcelas.Name = "lstParcelas";
            this.lstParcelas.Size = new System.Drawing.Size(246, 184);
            this.lstParcelas.TabIndex = 6;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(273, 84);
            this.txtValorTotal.MaxLength = 10;
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(140, 26);
            this.txtValorTotal.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor total produto";
            // 
            // txtDiasBoleto
            // 
            this.txtDiasBoleto.Location = new System.Drawing.Point(38, 157);
            this.txtDiasBoleto.MaxLength = 2;
            this.txtDiasBoleto.Name = "txtDiasBoleto";
            this.txtDiasBoleto.Size = new System.Drawing.Size(147, 26);
            this.txtDiasBoleto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade de dias";
            // 
            // dtpEmissaoBoleto
            // 
            this.dtpEmissaoBoleto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmissaoBoleto.Location = new System.Drawing.Point(38, 84);
            this.dtpEmissaoBoleto.Name = "dtpEmissaoBoleto";
            this.dtpEmissaoBoleto.Size = new System.Drawing.Size(112, 26);
            this.dtpEmissaoBoleto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data emissão do boleto";
            // 
            // btnCalculaParcelas
            // 
            this.btnCalculaParcelas.Location = new System.Drawing.Point(205, 586);
            this.btnCalculaParcelas.Name = "btnCalculaParcelas";
            this.btnCalculaParcelas.Size = new System.Drawing.Size(186, 43);
            this.btnCalculaParcelas.TabIndex = 2;
            this.btnCalculaParcelas.Text = "Calcula parcelas";
            this.btnCalculaParcelas.UseVisualStyleBackColor = true;
            this.btnCalculaParcelas.Click += new System.EventHandler(this.btnCalculaParcelas_Click);
            // 
            // btnGerarCodigoBarras
            // 
            this.btnGerarCodigoBarras.Location = new System.Drawing.Point(394, 586);
            this.btnGerarCodigoBarras.Name = "btnGerarCodigoBarras";
            this.btnGerarCodigoBarras.Size = new System.Drawing.Size(186, 43);
            this.btnGerarCodigoBarras.TabIndex = 3;
            this.btnGerarCodigoBarras.Text = "Gerar código de barras";
            this.btnGerarCodigoBarras.UseVisualStyleBackColor = true;
            this.btnGerarCodigoBarras.Click += new System.EventHandler(this.btnGerarCodigoBarras_Click);
            // 
            // pctQRCode
            // 
            this.pctQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctQRCode.Location = new System.Drawing.Point(488, 280);
            this.pctQRCode.Name = "pctQRCode";
            this.pctQRCode.Size = new System.Drawing.Size(246, 239);
            this.pctQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctQRCode.TabIndex = 11;
            this.pctQRCode.TabStop = false;
            // 
            // btnGerarQRCode
            // 
            this.btnGerarQRCode.Location = new System.Drawing.Point(586, 586);
            this.btnGerarQRCode.Name = "btnGerarQRCode";
            this.btnGerarQRCode.Size = new System.Drawing.Size(186, 43);
            this.btnGerarQRCode.TabIndex = 4;
            this.btnGerarQRCode.Text = "Gerar QRCode";
            this.btnGerarQRCode.UseVisualStyleBackColor = true;
            this.btnGerarQRCode.Click += new System.EventHandler(this.btnGerarQRCode_Click);
            // 
            // frmBoleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 659);
            this.Controls.Add(this.btnGerarQRCode);
            this.Controls.Add(this.btnGerarCodigoBarras);
            this.Controls.Add(this.btnCalculaParcelas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCalculaBoleto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBoleto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boleto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCodigoBarras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalculaBoleto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpEmissaoBoleto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiasBoleto;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalculaParcelas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstParcelas;
        private System.Windows.Forms.TextBox txtNumCodigoBarras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pctCodigoBarras;
        private System.Windows.Forms.Button btnGerarCodigoBarras;
        private System.Windows.Forms.PictureBox pctQRCode;
        private System.Windows.Forms.Button btnGerarQRCode;
    }
}