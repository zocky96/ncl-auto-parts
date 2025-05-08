namespace ncl_auto_parts.screens
{
    partial class AutoPart
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
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoPart));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.devise = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.service = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.montant = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // devise
            // 
            this.devise.FormattingEnabled = true;
            this.devise.Items.AddRange(new object[] {
            "US",
            "HTG"});
            this.devise.Location = new System.Drawing.Point(24, 147);
            this.devise.Name = "devise";
            this.devise.Size = new System.Drawing.Size(234, 21);
            this.devise.TabIndex = 65;
            this.devise.Text = "Devise";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(21, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 64;
            this.label4.Text = "Service";
            // 
            // service
            // 
            this.service.AcceptsReturn = false;
            this.service.AcceptsTab = false;
            this.service.AnimationSpeed = 200;
            this.service.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.service.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.service.BackColor = System.Drawing.Color.Transparent;
            this.service.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("service.BackgroundImage")));
            this.service.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.service.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.service.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.service.BorderColorIdle = System.Drawing.Color.Silver;
            this.service.BorderRadius = 1;
            this.service.BorderThickness = 1;
            this.service.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.service.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.service.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.service.DefaultText = "";
            this.service.FillColor = System.Drawing.Color.White;
            this.service.HideSelection = true;
            this.service.IconLeft = null;
            this.service.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.service.IconPadding = 10;
            this.service.IconRight = null;
            this.service.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.service.Lines = new string[0];
            this.service.Location = new System.Drawing.Point(24, 50);
            this.service.MaxLength = 32767;
            this.service.MinimumSize = new System.Drawing.Size(100, 35);
            this.service.Modified = false;
            this.service.Multiline = false;
            this.service.Name = "service";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.service.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.Empty;
            stateProperties6.FillColor = System.Drawing.Color.White;
            stateProperties6.ForeColor = System.Drawing.Color.Empty;
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.service.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.service.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.service.OnIdleState = stateProperties8;
            this.service.PasswordChar = '\0';
            this.service.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.service.PlaceholderText = "Enter text";
            this.service.ReadOnly = false;
            this.service.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.service.SelectedText = "";
            this.service.SelectionLength = 0;
            this.service.SelectionStart = 0;
            this.service.ShortcutsEnabled = true;
            this.service.Size = new System.Drawing.Size(234, 35);
            this.service.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.service.TabIndex = 63;
            this.service.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.service.TextMarginBottom = 0;
            this.service.TextMarginLeft = 5;
            this.service.TextMarginTop = 0;
            this.service.TextPlaceholder = "Enter text";
            this.service.UseSystemPasswordChar = false;
            this.service.WordWrap = true;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(243, 63);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(0, 13);
            this.bunifuCustomLabel1.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(338, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 68;
            this.label1.Text = "Montant";
            // 
            // montant
            // 
            this.montant.AcceptsReturn = false;
            this.montant.AcceptsTab = false;
            this.montant.AnimationSpeed = 200;
            this.montant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.montant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.montant.BackColor = System.Drawing.Color.Transparent;
            this.montant.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("montant.BackgroundImage")));
            this.montant.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.montant.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.montant.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.montant.BorderColorIdle = System.Drawing.Color.Silver;
            this.montant.BorderRadius = 1;
            this.montant.BorderThickness = 1;
            this.montant.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.montant.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.montant.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.montant.DefaultText = "";
            this.montant.FillColor = System.Drawing.Color.White;
            this.montant.HideSelection = true;
            this.montant.IconLeft = null;
            this.montant.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.montant.IconPadding = 10;
            this.montant.IconRight = null;
            this.montant.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.montant.Lines = new string[0];
            this.montant.Location = new System.Drawing.Point(341, 50);
            this.montant.MaxLength = 32767;
            this.montant.MinimumSize = new System.Drawing.Size(100, 35);
            this.montant.Modified = false;
            this.montant.Multiline = false;
            this.montant.Name = "montant";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.montant.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.montant.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.montant.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.montant.OnIdleState = stateProperties4;
            this.montant.PasswordChar = '\0';
            this.montant.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.montant.PlaceholderText = "Enter text";
            this.montant.ReadOnly = false;
            this.montant.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.montant.SelectedText = "";
            this.montant.SelectionLength = 0;
            this.montant.SelectionStart = 0;
            this.montant.ShortcutsEnabled = true;
            this.montant.Size = new System.Drawing.Size(234, 35);
            this.montant.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.montant.TabIndex = 67;
            this.montant.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.montant.TextMarginBottom = 0;
            this.montant.TextMarginLeft = 5;
            this.montant.TextMarginTop = 0;
            this.montant.TextPlaceholder = "Enter text";
            this.montant.UseSystemPasswordChar = false;
            this.montant.WordWrap = true;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(560, 63);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(0, 13);
            this.bunifuCustomLabel2.TabIndex = 66;
            // 
            // AutoPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.montant);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.devise);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.service);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutoPart";
            this.Text = "AutoPart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox montant;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.ComboBox devise;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox service;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
    }
}