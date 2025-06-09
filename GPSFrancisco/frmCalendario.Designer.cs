namespace GPSFrancisco
{
    partial class frmCalendario
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
            this.dtpFormaLong = new System.Windows.Forms.DateTimePicker();
            this.dtpFormaShort = new System.Windows.Forms.DateTimePicker();
            this.lblFormatLong = new System.Windows.Forms.Label();
            this.lblFormatShort = new System.Windows.Forms.Label();
            this.lblFormaTimer = new System.Windows.Forms.Label();
            this.dtpFormaTimer = new System.Windows.Forms.DateTimePicker();
            this.lblFormaCustom = new System.Windows.Forms.Label();
            this.dtpFormaCustom = new System.Windows.Forms.DateTimePicker();
            this.btnCarregaData = new System.Windows.Forms.Button();
            this.txtCalendario = new System.Windows.Forms.TextBox();
            this.cldCalendario = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // dtpFormaLong
            // 
            this.dtpFormaLong.Location = new System.Drawing.Point(31, 46);
            this.dtpFormaLong.Name = "dtpFormaLong";
            this.dtpFormaLong.Size = new System.Drawing.Size(230, 20);
            this.dtpFormaLong.TabIndex = 0;
            this.dtpFormaLong.Value = new System.DateTime(2025, 7, 7, 0, 0, 0, 0);
            // 
            // dtpFormaShort
            // 
            this.dtpFormaShort.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFormaShort.Location = new System.Drawing.Point(31, 128);
            this.dtpFormaShort.Name = "dtpFormaShort";
            this.dtpFormaShort.Size = new System.Drawing.Size(88, 20);
            this.dtpFormaShort.TabIndex = 1;
            // 
            // lblFormatLong
            // 
            this.lblFormatLong.AutoSize = true;
            this.lblFormatLong.Location = new System.Drawing.Point(31, 18);
            this.lblFormatLong.Name = "lblFormatLong";
            this.lblFormatLong.Size = new System.Drawing.Size(72, 13);
            this.lblFormatLong.TabIndex = 2;
            this.lblFormatLong.Text = "Format - Long";
            // 
            // lblFormatShort
            // 
            this.lblFormatShort.AutoSize = true;
            this.lblFormatShort.Location = new System.Drawing.Point(31, 102);
            this.lblFormatShort.Name = "lblFormatShort";
            this.lblFormatShort.Size = new System.Drawing.Size(73, 13);
            this.lblFormatShort.TabIndex = 3;
            this.lblFormatShort.Text = "Format - Short";
            // 
            // lblFormaTimer
            // 
            this.lblFormaTimer.AutoSize = true;
            this.lblFormaTimer.Location = new System.Drawing.Point(31, 175);
            this.lblFormaTimer.Name = "lblFormaTimer";
            this.lblFormaTimer.Size = new System.Drawing.Size(71, 13);
            this.lblFormaTimer.TabIndex = 5;
            this.lblFormaTimer.Text = "Format - Time";
            // 
            // dtpFormaTimer
            // 
            this.dtpFormaTimer.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFormaTimer.Location = new System.Drawing.Point(31, 195);
            this.dtpFormaTimer.Name = "dtpFormaTimer";
            this.dtpFormaTimer.Size = new System.Drawing.Size(88, 20);
            this.dtpFormaTimer.TabIndex = 4;
            // 
            // lblFormaCustom
            // 
            this.lblFormaCustom.AutoSize = true;
            this.lblFormaCustom.Location = new System.Drawing.Point(31, 255);
            this.lblFormaCustom.Name = "lblFormaCustom";
            this.lblFormaCustom.Size = new System.Drawing.Size(83, 13);
            this.lblFormaCustom.TabIndex = 7;
            this.lblFormaCustom.Text = "Format - Custom";
            // 
            // dtpFormaCustom
            // 
            this.dtpFormaCustom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFormaCustom.Location = new System.Drawing.Point(31, 274);
            this.dtpFormaCustom.Name = "dtpFormaCustom";
            this.dtpFormaCustom.Size = new System.Drawing.Size(88, 20);
            this.dtpFormaCustom.TabIndex = 6;
            // 
            // btnCarregaData
            // 
            this.btnCarregaData.Location = new System.Drawing.Point(321, 255);
            this.btnCarregaData.Name = "btnCarregaData";
            this.btnCarregaData.Size = new System.Drawing.Size(228, 30);
            this.btnCarregaData.TabIndex = 9;
            this.btnCarregaData.Text = "Carrega Data";
            this.btnCarregaData.UseVisualStyleBackColor = true;
            this.btnCarregaData.Click += new System.EventHandler(this.btnCarregaData_Click);
            // 
            // txtCalendario
            // 
            this.txtCalendario.Location = new System.Drawing.Point(321, 220);
            this.txtCalendario.Name = "txtCalendario";
            this.txtCalendario.Size = new System.Drawing.Size(313, 20);
            this.txtCalendario.TabIndex = 10;
            // 
            // cldCalendario
            // 
            this.cldCalendario.Location = new System.Drawing.Point(322, 46);
            this.cldCalendario.Name = "cldCalendario";
            this.cldCalendario.TabIndex = 11;
            this.cldCalendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cldCalendario_DateChanged);
            this.cldCalendario.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cldCalendario_DateSelected);
            // 
            // frmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cldCalendario);
            this.Controls.Add(this.txtCalendario);
            this.Controls.Add(this.btnCarregaData);
            this.Controls.Add(this.lblFormaCustom);
            this.Controls.Add(this.dtpFormaCustom);
            this.Controls.Add(this.lblFormaTimer);
            this.Controls.Add(this.dtpFormaTimer);
            this.Controls.Add(this.lblFormatShort);
            this.Controls.Add(this.lblFormatLong);
            this.Controls.Add(this.dtpFormaShort);
            this.Controls.Add(this.dtpFormaLong);
            this.Name = "frmCalendario";
            this.Text = "frmCalendario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFormaLong;
        private System.Windows.Forms.DateTimePicker dtpFormaShort;
        private System.Windows.Forms.Label lblFormatLong;
        private System.Windows.Forms.Label lblFormatShort;
        private System.Windows.Forms.Label lblFormaTimer;
        private System.Windows.Forms.DateTimePicker dtpFormaTimer;
        private System.Windows.Forms.Label lblFormaCustom;
        private System.Windows.Forms.DateTimePicker dtpFormaCustom;
        private System.Windows.Forms.Button btnCarregaData;
        private System.Windows.Forms.TextBox txtCalendario;
        private System.Windows.Forms.MonthCalendar cldCalendario;
    }
}