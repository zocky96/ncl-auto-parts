namespace ncl_auto_parts.screens
{
    partial class Cart
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cart));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.tableCart = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.IDCart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videCart = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.deleteCart = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.vendre = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.devise = new System.Windows.Forms.ComboBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tableCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // tableCart
            // 
            this.tableCart.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.tableCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tableCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tableCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tableCart.ColumnHeadersHeight = 40;
            this.tableCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCart,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.tableCart.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.tableCart.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tableCart.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tableCart.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.tableCart.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tableCart.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.tableCart.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.tableCart.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.tableCart.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.tableCart.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tableCart.CurrentTheme.Name = null;
            this.tableCart.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tableCart.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tableCart.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tableCart.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.tableCart.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableCart.DefaultCellStyle = dataGridViewCellStyle3;
            this.tableCart.EnableHeadersVisualStyles = false;
            this.tableCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.tableCart.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.tableCart.HeaderBgColor = System.Drawing.Color.Empty;
            this.tableCart.HeaderForeColor = System.Drawing.Color.White;
            this.tableCart.Location = new System.Drawing.Point(12, 58);
            this.tableCart.Name = "tableCart";
            this.tableCart.RowHeadersVisible = false;
            this.tableCart.RowTemplate.Height = 40;
            this.tableCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableCart.Size = new System.Drawing.Size(885, 324);
            this.tableCart.TabIndex = 59;
            this.tableCart.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.tableCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableCart_CellContentClick);
            // 
            // IDCart
            // 
            this.IDCart.HeaderText = "ID";
            this.IDCart.Name = "IDCart";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nom du produit";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Prix";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantité";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nom du client";
            this.Column3.Name = "Column3";
            // 
            // videCart
            // 
            this.videCart.AllowToggling = false;
            this.videCart.AnimationSpeed = 200;
            this.videCart.AutoGenerateColors = false;
            this.videCart.BackColor = System.Drawing.Color.Transparent;
            this.videCart.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.videCart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("videCart.BackgroundImage")));
            this.videCart.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.videCart.ButtonText = "vider le panier";
            this.videCart.ButtonTextMarginLeft = 0;
            this.videCart.ColorContrastOnClick = 45;
            this.videCart.ColorContrastOnHover = 45;
            this.videCart.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.videCart.CustomizableEdges = borderEdges2;
            this.videCart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.videCart.DisabledBorderColor = System.Drawing.Color.Empty;
            this.videCart.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.videCart.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.videCart.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.videCart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.videCart.ForeColor = System.Drawing.Color.White;
            this.videCart.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.videCart.IconMarginLeft = 11;
            this.videCart.IconPadding = 10;
            this.videCart.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.videCart.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.videCart.IdleBorderRadius = 3;
            this.videCart.IdleBorderThickness = 1;
            this.videCart.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.videCart.IdleIconLeftImage = null;
            this.videCart.IdleIconRightImage = null;
            this.videCart.IndicateFocus = false;
            this.videCart.Location = new System.Drawing.Point(504, 407);
            this.videCart.Name = "videCart";
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.BorderRadius = 3;
            stateProperties3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties3.BorderThickness = 1;
            stateProperties3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.ForeColor = System.Drawing.Color.White;
            stateProperties3.IconLeftImage = null;
            stateProperties3.IconRightImage = null;
            this.videCart.onHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties4.BorderRadius = 3;
            stateProperties4.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties4.BorderThickness = 1;
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties4.ForeColor = System.Drawing.Color.White;
            stateProperties4.IconLeftImage = null;
            stateProperties4.IconRightImage = null;
            this.videCart.OnPressedState = stateProperties4;
            this.videCart.Size = new System.Drawing.Size(134, 45);
            this.videCart.TabIndex = 61;
            this.videCart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.videCart.TextMarginLeft = 0;
            this.videCart.UseDefaultRadiusAndThickness = true;
            this.videCart.Visible = false;
            this.videCart.Click += new System.EventHandler(this.videCart_Click);
            // 
            // deleteCart
            // 
            this.deleteCart.AllowToggling = false;
            this.deleteCart.AnimationSpeed = 200;
            this.deleteCart.AutoGenerateColors = false;
            this.deleteCart.BackColor = System.Drawing.Color.Transparent;
            this.deleteCart.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.deleteCart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteCart.BackgroundImage")));
            this.deleteCart.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.deleteCart.ButtonText = "Suprimer";
            this.deleteCart.ButtonTextMarginLeft = 0;
            this.deleteCart.ColorContrastOnClick = 45;
            this.deleteCart.ColorContrastOnHover = 45;
            this.deleteCart.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.deleteCart.CustomizableEdges = borderEdges3;
            this.deleteCart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.deleteCart.DisabledBorderColor = System.Drawing.Color.Empty;
            this.deleteCart.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.deleteCart.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.deleteCart.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.deleteCart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.deleteCart.ForeColor = System.Drawing.Color.White;
            this.deleteCart.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.deleteCart.IconMarginLeft = 11;
            this.deleteCart.IconPadding = 10;
            this.deleteCart.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.deleteCart.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.deleteCart.IdleBorderRadius = 3;
            this.deleteCart.IdleBorderThickness = 1;
            this.deleteCart.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.deleteCart.IdleIconLeftImage = null;
            this.deleteCart.IdleIconRightImage = null;
            this.deleteCart.IndicateFocus = false;
            this.deleteCart.Location = new System.Drawing.Point(345, 407);
            this.deleteCart.Name = "deleteCart";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties5.BorderRadius = 3;
            stateProperties5.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties5.BorderThickness = 1;
            stateProperties5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties5.ForeColor = System.Drawing.Color.White;
            stateProperties5.IconLeftImage = null;
            stateProperties5.IconRightImage = null;
            this.deleteCart.onHoverState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties6.BorderRadius = 3;
            stateProperties6.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties6.BorderThickness = 1;
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties6.ForeColor = System.Drawing.Color.White;
            stateProperties6.IconLeftImage = null;
            stateProperties6.IconRightImage = null;
            this.deleteCart.OnPressedState = stateProperties6;
            this.deleteCart.Size = new System.Drawing.Size(134, 45);
            this.deleteCart.TabIndex = 60;
            this.deleteCart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteCart.TextMarginLeft = 0;
            this.deleteCart.UseDefaultRadiusAndThickness = true;
            this.deleteCart.Visible = false;
            this.deleteCart.Click += new System.EventHandler(this.deleteCart_Click);
            // 
            // vendre
            // 
            this.vendre.AllowToggling = false;
            this.vendre.AnimationSpeed = 200;
            this.vendre.AutoGenerateColors = false;
            this.vendre.BackColor = System.Drawing.Color.Transparent;
            this.vendre.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.vendre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vendre.BackgroundImage")));
            this.vendre.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.vendre.ButtonText = "Vendre";
            this.vendre.ButtonTextMarginLeft = 0;
            this.vendre.ColorContrastOnClick = 45;
            this.vendre.ColorContrastOnHover = 45;
            this.vendre.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.vendre.CustomizableEdges = borderEdges1;
            this.vendre.DialogResult = System.Windows.Forms.DialogResult.None;
            this.vendre.DisabledBorderColor = System.Drawing.Color.Empty;
            this.vendre.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.vendre.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.vendre.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.vendre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.vendre.ForeColor = System.Drawing.Color.White;
            this.vendre.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.vendre.IconMarginLeft = 11;
            this.vendre.IconPadding = 10;
            this.vendre.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.vendre.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.vendre.IdleBorderRadius = 3;
            this.vendre.IdleBorderThickness = 1;
            this.vendre.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.vendre.IdleIconLeftImage = null;
            this.vendre.IdleIconRightImage = null;
            this.vendre.IndicateFocus = false;
            this.vendre.Location = new System.Drawing.Point(12, 407);
            this.vendre.Name = "vendre";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.BorderRadius = 3;
            stateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.ForeColor = System.Drawing.Color.White;
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.vendre.onHoverState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.BorderRadius = 3;
            stateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.ForeColor = System.Drawing.Color.White;
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.vendre.OnPressedState = stateProperties2;
            this.vendre.Size = new System.Drawing.Size(134, 45);
            this.vendre.TabIndex = 62;
            this.vendre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.vendre.TextMarginLeft = 0;
            this.vendre.UseDefaultRadiusAndThickness = true;
            this.vendre.Click += new System.EventHandler(this.vendre_Click);
            // 
            // devise
            // 
            this.devise.FormattingEnabled = true;
            this.devise.Items.AddRange(new object[] {
            "US",
            "HTG"});
            this.devise.Location = new System.Drawing.Point(169, 431);
            this.devise.Name = "devise";
            this.devise.Size = new System.Drawing.Size(148, 21);
            this.devise.TabIndex = 63;
            this.devise.Text = "Devise";
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
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(579, -4);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(225, 138);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 64;
            this.logo.TabStop = false;
            this.logo.Visible = false;
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 471);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.devise);
            this.Controls.Add(this.vendre);
            this.Controls.Add(this.videCart);
            this.Controls.Add(this.deleteCart);
            this.Controls.Add(this.tableCart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cart";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.Cart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuDataGridView tableCart;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton vendre;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton videCart;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton deleteCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox devise;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox logo;
    }
}