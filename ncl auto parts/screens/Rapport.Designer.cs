namespace ncl_auto_parts.screens
{
    partial class Rapport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rapport));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.label1 = new System.Windows.Forms.Label();
            this.sur = new System.Windows.Forms.ComboBox();
            this.article = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.a = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.de = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.logo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(368, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 21);
            this.label1.TabIndex = 68;
            this.label1.Text = "Á";
            // 
            // sur
            // 
            this.sur.FormattingEnabled = true;
            this.sur.Items.AddRange(new object[] {
            "Vente",
            "Facture Auto parts",
            "Facture Garage"});
            this.sur.Location = new System.Drawing.Point(75, 117);
            this.sur.Name = "sur";
            this.sur.Size = new System.Drawing.Size(231, 21);
            this.sur.TabIndex = 72;
            this.sur.Text = "Sur";
            // 
            // article
            // 
            this.article.AllowToggling = false;
            this.article.AnimationSpeed = 200;
            this.article.AutoGenerateColors = false;
            this.article.BackColor = System.Drawing.Color.Transparent;
            this.article.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.article.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("article.BackgroundImage")));
            this.article.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.article.ButtonText = "Imprimer";
            this.article.ButtonTextMarginLeft = 0;
            this.article.ColorContrastOnClick = 45;
            this.article.ColorContrastOnHover = 45;
            this.article.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.article.CustomizableEdges = borderEdges1;
            this.article.DialogResult = System.Windows.Forms.DialogResult.None;
            this.article.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.article.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.article.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.article.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.article.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.article.ForeColor = System.Drawing.Color.White;
            this.article.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.article.IconMarginLeft = 11;
            this.article.IconPadding = 10;
            this.article.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.article.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.article.IdleBorderRadius = 3;
            this.article.IdleBorderThickness = 1;
            this.article.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.article.IdleIconLeftImage = global::ncl_auto_parts.Properties.Resources.print_24px;
            this.article.IdleIconRightImage = null;
            this.article.IndicateFocus = false;
            this.article.Location = new System.Drawing.Point(400, 172);
            this.article.Name = "article";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.BorderRadius = 3;
            stateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.ForeColor = System.Drawing.Color.White;
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.article.onHoverState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.BorderRadius = 3;
            stateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.ForeColor = System.Drawing.Color.White;
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.article.OnPressedState = stateProperties2;
            this.article.Size = new System.Drawing.Size(229, 39);
            this.article.TabIndex = 74;
            this.article.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.article.TextMarginLeft = 0;
            this.article.UseDefaultRadiusAndThickness = true;
            this.article.Click += new System.EventHandler(this.article_Click);
            // 
            // a
            // 
            this.a.BorderRadius = 1;
            this.a.Color = System.Drawing.Color.Silver;
            this.a.CustomFormat = "yyyy-MM-dd";
            this.a.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.a.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.a.DisabledColor = System.Drawing.Color.Gray;
            this.a.DisplayWeekNumbers = false;
            this.a.DPHeight = 0;
            this.a.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.a.FillDatePicker = false;
            this.a.ForeColor = System.Drawing.Color.Black;
            this.a.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.a.Icon = ((System.Drawing.Image)(resources.GetObject("a.Icon")));
            this.a.IconColor = System.Drawing.Color.Gray;
            this.a.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.a.Location = new System.Drawing.Point(395, 42);
            this.a.MinimumSize = new System.Drawing.Size(234, 32);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(234, 32);
            this.a.TabIndex = 71;
            this.a.Value = new System.DateTime(2025, 5, 5, 18, 11, 52, 0);
            // 
            // de
            // 
            this.de.BorderRadius = 1;
            this.de.Color = System.Drawing.Color.Silver;
            this.de.CustomFormat = "yyyy-MM-dd";
            this.de.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.de.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.de.DisabledColor = System.Drawing.Color.Gray;
            this.de.DisplayWeekNumbers = false;
            this.de.DPHeight = 0;
            this.de.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.de.FillDatePicker = false;
            this.de.ForeColor = System.Drawing.Color.Black;
            this.de.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.de.Icon = ((System.Drawing.Image)(resources.GetObject("de.Icon")));
            this.de.IconColor = System.Drawing.Color.Gray;
            this.de.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.de.Location = new System.Drawing.Point(75, 44);
            this.de.MinimumSize = new System.Drawing.Size(234, 32);
            this.de.Name = "de";
            this.de.Size = new System.Drawing.Size(234, 32);
            this.de.TabIndex = 70;
            this.de.Value = new System.DateTime(2025, 5, 5, 18, 11, 52, 0);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.White;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(9, 154);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(210, 116);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 120;
            this.logo.TabStop = false;
            this.logo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(36, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 21);
            this.label3.TabIndex = 121;
            this.label3.Text = "De";
            // 
            // Rapport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 243);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.article);
            this.Controls.Add(this.sur);
            this.Controls.Add(this.a);
            this.Controls.Add(this.de);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rapport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapport";
            this.Load += new System.EventHandler(this.Rapport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuDatePicker de;
        private Bunifu.UI.WinForms.BunifuDatePicker a;
        private System.Windows.Forms.ComboBox sur;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton article;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label3;
    }
}