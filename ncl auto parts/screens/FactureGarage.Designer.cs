namespace ncl_auto_parts.screens
{
    partial class FactureGarage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactureGarage));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.filter = new System.Windows.Forms.ComboBox();
            this.table = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.searchBar = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.facture = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.print = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.logo = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.id_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sevice_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // filter
            // 
            this.filter.FormattingEnabled = true;
            this.filter.Items.AddRange(new object[] {
            "Filtre",
            "Article en rupture de stock",
            "Date d\'ajout"});
            this.filter.Location = new System.Drawing.Point(300, 49);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(144, 21);
            this.filter.TabIndex = 81;
            this.filter.Text = "Filtre";
            // 
            // table
            // 
            this.table.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.table.ColumnHeadersHeight = 40;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_,
            this.client,
            this.Sevice_,
            this.Column2,
            this.Column3,
            this.no,
            this.Column5});
            this.table.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.table.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.table.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.table.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.table.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.table.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.table.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.table.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.table.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.table.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.table.CurrentTheme.Name = null;
            this.table.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.table.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.table.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.table.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.table.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.table.DefaultCellStyle = dataGridViewCellStyle3;
            this.table.EnableHeadersVisualStyles = false;
            this.table.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.table.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.table.HeaderBgColor = System.Drawing.Color.Empty;
            this.table.HeaderForeColor = System.Drawing.Color.White;
            this.table.Location = new System.Drawing.Point(11, 93);
            this.table.Name = "table";
            this.table.RowHeadersVisible = false;
            this.table.RowTemplate.Height = 40;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(892, 291);
            this.table.TabIndex = 79;
            this.table.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.table.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_CellContentClick);
            // 
            // searchBar
            // 
            this.searchBar.AcceptsReturn = false;
            this.searchBar.AcceptsTab = false;
            this.searchBar.AnimationSpeed = 200;
            this.searchBar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.searchBar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.searchBar.BackColor = System.Drawing.Color.Transparent;
            this.searchBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBar.BackgroundImage")));
            this.searchBar.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.searchBar.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.searchBar.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.searchBar.BorderColorIdle = System.Drawing.Color.Silver;
            this.searchBar.BorderRadius = 1;
            this.searchBar.BorderThickness = 1;
            this.searchBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.searchBar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBar.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.searchBar.DefaultText = "";
            this.searchBar.FillColor = System.Drawing.Color.White;
            this.searchBar.HideSelection = true;
            this.searchBar.IconLeft = global::ncl_auto_parts.Properties.Resources.search_24px1;
            this.searchBar.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBar.IconPadding = 10;
            this.searchBar.IconRight = null;
            this.searchBar.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBar.Lines = new string[0];
            this.searchBar.Location = new System.Drawing.Point(12, 35);
            this.searchBar.MaxLength = 32767;
            this.searchBar.MinimumSize = new System.Drawing.Size(100, 35);
            this.searchBar.Modified = false;
            this.searchBar.Multiline = false;
            this.searchBar.Name = "searchBar";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchBar.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.searchBar.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchBar.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchBar.OnIdleState = stateProperties4;
            this.searchBar.PasswordChar = '\0';
            this.searchBar.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.searchBar.PlaceholderText = "Enter text";
            this.searchBar.ReadOnly = false;
            this.searchBar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchBar.SelectedText = "";
            this.searchBar.SelectionLength = 0;
            this.searchBar.SelectionStart = 0;
            this.searchBar.ShortcutsEnabled = true;
            this.searchBar.Size = new System.Drawing.Size(271, 35);
            this.searchBar.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.searchBar.TabIndex = 80;
            this.searchBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchBar.TextMarginBottom = 0;
            this.searchBar.TextMarginLeft = 5;
            this.searchBar.TextMarginTop = 0;
            this.searchBar.TextPlaceholder = "Enter text";
            this.searchBar.UseSystemPasswordChar = false;
            this.searchBar.WordWrap = true;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            this.searchBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBar_KeyDown);
            // 
            // facture
            // 
            this.facture.AllowToggling = false;
            this.facture.AnimationSpeed = 200;
            this.facture.AutoGenerateColors = false;
            this.facture.BackColor = System.Drawing.Color.Transparent;
            this.facture.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.facture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("facture.BackgroundImage")));
            this.facture.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.facture.ButtonText = "Annulée facture";
            this.facture.ButtonTextMarginLeft = 0;
            this.facture.ColorContrastOnClick = 45;
            this.facture.ColorContrastOnHover = 45;
            this.facture.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.facture.CustomizableEdges = borderEdges1;
            this.facture.DialogResult = System.Windows.Forms.DialogResult.None;
            this.facture.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.facture.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.facture.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.facture.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.facture.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.facture.ForeColor = System.Drawing.Color.White;
            this.facture.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.facture.IconMarginLeft = 11;
            this.facture.IconPadding = 10;
            this.facture.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.facture.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.facture.IdleBorderRadius = 3;
            this.facture.IdleBorderThickness = 1;
            this.facture.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.facture.IdleIconLeftImage = null;
            this.facture.IdleIconRightImage = null;
            this.facture.IndicateFocus = false;
            this.facture.Location = new System.Drawing.Point(12, 390);
            this.facture.Name = "facture";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties5.BorderRadius = 3;
            stateProperties5.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties5.BorderThickness = 1;
            stateProperties5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties5.ForeColor = System.Drawing.Color.White;
            stateProperties5.IconLeftImage = null;
            stateProperties5.IconRightImage = null;
            this.facture.onHoverState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties6.BorderRadius = 3;
            stateProperties6.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties6.BorderThickness = 1;
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties6.ForeColor = System.Drawing.Color.White;
            stateProperties6.IconLeftImage = null;
            stateProperties6.IconRightImage = null;
            this.facture.OnPressedState = stateProperties6;
            this.facture.Size = new System.Drawing.Size(134, 45);
            this.facture.TabIndex = 78;
            this.facture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.facture.TextMarginLeft = 0;
            this.facture.UseDefaultRadiusAndThickness = true;
            this.facture.Click += new System.EventHandler(this.facture_Click);
            // 
            // print
            // 
            this.print.AllowToggling = false;
            this.print.AnimationSpeed = 200;
            this.print.AutoGenerateColors = false;
            this.print.BackColor = System.Drawing.Color.Transparent;
            this.print.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("print.BackgroundImage")));
            this.print.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.print.ButtonText = "imprimer";
            this.print.ButtonTextMarginLeft = 0;
            this.print.ColorContrastOnClick = 45;
            this.print.ColorContrastOnHover = 45;
            this.print.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.print.CustomizableEdges = borderEdges2;
            this.print.DialogResult = System.Windows.Forms.DialogResult.None;
            this.print.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.print.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.print.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.print.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.print.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.print.ForeColor = System.Drawing.Color.White;
            this.print.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.print.IconMarginLeft = 11;
            this.print.IconPadding = 10;
            this.print.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.print.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.print.IdleBorderRadius = 3;
            this.print.IdleBorderThickness = 1;
            this.print.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.print.IdleIconLeftImage = null;
            this.print.IdleIconRightImage = null;
            this.print.IndicateFocus = false;
            this.print.Location = new System.Drawing.Point(177, 390);
            this.print.Name = "print";
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.BorderRadius = 3;
            stateProperties7.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties7.BorderThickness = 1;
            stateProperties7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.ForeColor = System.Drawing.Color.White;
            stateProperties7.IconLeftImage = null;
            stateProperties7.IconRightImage = null;
            this.print.onHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties8.BorderRadius = 3;
            stateProperties8.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties8.BorderThickness = 1;
            stateProperties8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties8.ForeColor = System.Drawing.Color.White;
            stateProperties8.IconLeftImage = null;
            stateProperties8.IconRightImage = null;
            this.print.OnPressedState = stateProperties8;
            this.print.Size = new System.Drawing.Size(134, 45);
            this.print.TabIndex = 120;
            this.print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.print.TextMarginLeft = 0;
            this.print.UseDefaultRadiusAndThickness = true;
            this.print.Visible = false;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.White;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(644, -29);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(210, 116);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 121;
            this.logo.TabStop = false;
            this.logo.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // id_
            // 
            this.id_.HeaderText = "ID";
            this.id_.Name = "id_";
            // 
            // client
            // 
            this.client.HeaderText = "Nom du client";
            this.client.Name = "client";
            // 
            // Sevice_
            // 
            this.Sevice_.HeaderText = "Sevices";
            this.Sevice_.Name = "Sevice_";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Montant";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Devise";
            this.Column3.Name = "Column3";
            // 
            // no
            // 
            this.no.HeaderText = "No recu";
            this.no.Name = "no";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Date";
            this.Column5.Name = "Column5";
            // 
            // FactureGarage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.print);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.facture);
            this.Controls.Add(this.table);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FactureGarage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox filter;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox searchBar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton facture;
        private Bunifu.UI.WinForms.BunifuDataGridView table;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton print;
        private System.Windows.Forms.PictureBox logo;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_;
        private System.Windows.Forms.DataGridViewTextBoxColumn client;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sevice_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}