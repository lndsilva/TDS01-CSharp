namespace GPSFrancisco
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.btnVoluntarios = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnAtribuicoes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVoluntarios
            // 
            this.btnVoluntarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoluntarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoluntarios.Image = ((System.Drawing.Image)(resources.GetObject("btnVoluntarios.Image")));
            this.btnVoluntarios.Location = new System.Drawing.Point(24, 11);
            this.btnVoluntarios.Name = "btnVoluntarios";
            this.btnVoluntarios.Size = new System.Drawing.Size(154, 222);
            this.btnVoluntarios.TabIndex = 0;
            this.btnVoluntarios.Text = "V&oluntários";
            this.btnVoluntarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoluntarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVoluntarios.UseVisualStyleBackColor = true;
            this.btnVoluntarios.Click += new System.EventHandler(this.btnVoluntarios_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(686, 503);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(86, 46);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.Location = new System.Drawing.Point(375, 11);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(154, 222);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "&Usuários";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnAtribuicoes
            // 
            this.btnAtribuicoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtribuicoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtribuicoes.Image = ((System.Drawing.Image)(resources.GetObject("btnAtribuicoes.Image")));
            this.btnAtribuicoes.Location = new System.Drawing.Point(199, 11);
            this.btnAtribuicoes.Name = "btnAtribuicoes";
            this.btnAtribuicoes.Size = new System.Drawing.Size(154, 222);
            this.btnAtribuicoes.TabIndex = 3;
            this.btnAtribuicoes.Text = "&Atribuições";
            this.btnAtribuicoes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtribuicoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAtribuicoes.UseVisualStyleBackColor = true;
            this.btnAtribuicoes.Click += new System.EventHandler(this.btnAtribuicoes_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnAtribuicoes);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnVoluntarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPSFrancisco - Menu Principal";
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoluntarios;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnAtribuicoes;
    }
}