namespace DBFinalProject.UI
{
    partial class BranchEmployeeReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Closebtn = new System.Windows.Forms.Button();
            this.myPallet = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GreenTheme = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.PurpleTheme = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.employeesReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeesReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Controls.Add(this.Closebtn);
            this.kryptonPanel1.Location = new System.Drawing.Point(-1, -3);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Palette = this.myPallet;
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonPanel1.Size = new System.Drawing.Size(802, 81);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(267, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 34);
            this.label1.TabIndex = 12;
            this.label1.Text = "APEX BANK LIMITED";
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.Transparent;
            this.Closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Closebtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Closebtn.FlatAppearance.BorderSize = 0;
            this.Closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closebtn.ForeColor = System.Drawing.Color.White;
            this.Closebtn.Location = new System.Drawing.Point(768, 3);
            this.Closebtn.Margin = new System.Windows.Forms.Padding(0);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(34, 35);
            this.Closebtn.TabIndex = 11;
            this.Closebtn.Text = "X";
            this.Closebtn.UseVisualStyleBackColor = false;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // myPallet
            // 
            this.myPallet.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = System.Drawing.Color.Navy;
            this.myPallet.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color2 = System.Drawing.Color.SteelBlue;
            this.myPallet.ButtonStyles.ButtonCommon.OverrideDefault.Back.ColorAngle = 45F;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = System.Drawing.Color.Navy;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Back.Color2 = System.Drawing.Color.SteelBlue;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Back.ColorAngle = 45F;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Border.Rounding = 10;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Border.Width = 1;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.myPallet.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = System.Drawing.Color.SeaShell;
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Back.ColorAngle = 45F;
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Border.Rounding = 10;
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Border.Width = 1;
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.myPallet.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myPallet.ButtonStyles.ButtonForm.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.ButtonStyles.ButtonForm.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.ButtonStyles.ButtonForm.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.ButtonStyles.ButtonForm.StateDisabled.Border.Width = 0;
            this.myPallet.ButtonStyles.ButtonForm.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.ButtonStyles.ButtonForm.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.ButtonStyles.ButtonForm.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.ButtonStyles.ButtonForm.StateNormal.Border.Width = 0;
            this.myPallet.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.ButtonStyles.ButtonForm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.ButtonStyles.ButtonForm.StatePressed.Border.Width = 0;
            this.myPallet.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.ButtonStyles.ButtonForm.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.ButtonStyles.ButtonForm.StateTracking.Border.Width = 0;
            this.myPallet.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.myPallet.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            this.myPallet.GridStyles.GridCommon.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.myPallet.GridStyles.GridCommon.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.myPallet.GridStyles.GridCommon.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.Navy;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.SteelBlue;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.ColorAngle = 45F;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Rounding = 7;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Width = 3;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.Navy;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.SteelBlue;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderRow.Back.ColorAngle = 45F;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderRow.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderRow.Border.Rounding = 7;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderRow.Border.Width = 3;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.myPallet.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myPallet.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.myPallet.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.myPallet.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.myPallet.PanelStyles.PanelCommon.StateCommon.Color1 = System.Drawing.Color.Navy;
            this.myPallet.PanelStyles.PanelCommon.StateCommon.Color2 = System.Drawing.Color.LightBlue;
            this.myPallet.PanelStyles.PanelCommon.StateCommon.ColorAngle = 45F;
            this.myPallet.PanelStyles.PanelCommon.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 424);
            this.panel1.TabIndex = 4;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.employeesReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DBFinalProject.Reports.BranchEmplyees.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 424);
            this.reportViewer1.TabIndex = 0;
            // 
            // GreenTheme
            // 
            this.GreenTheme.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.GreenTheme.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color2 = System.Drawing.Color.LimeGreen;
            this.GreenTheme.ButtonStyles.ButtonCommon.OverrideDefault.Back.ColorAngle = 45F;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Back.Color2 = System.Drawing.Color.LimeGreen;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Back.ColorAngle = 45F;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Border.Color1 = System.Drawing.Color.DarkGreen;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Border.Color2 = System.Drawing.Color.DarkGreen;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Border.Rounding = 10;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Border.Width = 1;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = System.Drawing.Color.SeaShell;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Back.ColorAngle = 45F;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Border.Color1 = System.Drawing.Color.DarkGreen;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Border.Color2 = System.Drawing.Color.DarkGreen;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Border.Rounding = 10;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Border.Width = 1;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.GreenTheme.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenTheme.ButtonStyles.ButtonForm.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.ButtonStyles.ButtonForm.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.ButtonStyles.ButtonForm.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.ButtonStyles.ButtonForm.StateDisabled.Border.Width = 0;
            this.GreenTheme.ButtonStyles.ButtonForm.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.ButtonStyles.ButtonForm.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.ButtonStyles.ButtonForm.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.ButtonStyles.ButtonForm.StateNormal.Border.Width = 0;
            this.GreenTheme.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.ButtonStyles.ButtonForm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.ButtonStyles.ButtonForm.StatePressed.Border.Width = 0;
            this.GreenTheme.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.ButtonStyles.ButtonForm.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.ButtonStyles.ButtonForm.StateTracking.Border.Width = 0;
            this.GreenTheme.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.SeaGreen;
            this.GreenTheme.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.SeaGreen;
            this.GreenTheme.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.GreenTheme.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.ForestGreen;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.LimeGreen;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.ColorAngle = 45F;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Rounding = 7;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Width = 3;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.LimeGreen;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Back.ColorAngle = 45F;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Border.Rounding = 7;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Border.Width = 3;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.GreenTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenTheme.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.GreenTheme.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.GreenTheme.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.GreenTheme.PanelStyles.PanelCommon.StateCommon.Color1 = System.Drawing.Color.ForestGreen;
            this.GreenTheme.PanelStyles.PanelCommon.StateCommon.Color2 = System.Drawing.Color.LimeGreen;
            this.GreenTheme.PanelStyles.PanelCommon.StateCommon.ColorAngle = 45F;
            this.GreenTheme.PanelStyles.PanelCommon.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.GreenTheme.PanelStyles.PanelCustom1.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.GreenTheme.PanelStyles.PanelCustom1.StateCommon.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            // 
            // PurpleTheme
            // 
            this.PurpleTheme.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = System.Drawing.Color.MediumOrchid;
            this.PurpleTheme.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color2 = System.Drawing.Color.DarkMagenta;
            this.PurpleTheme.ButtonStyles.ButtonCommon.OverrideDefault.Back.ColorAngle = 45F;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = System.Drawing.Color.MediumOrchid;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Back.Color2 = System.Drawing.Color.DarkMagenta;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Back.ColorAngle = 45F;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Border.Color1 = System.Drawing.Color.DarkSlateGray;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Border.Color2 = System.Drawing.Color.DarkSlateGray;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Border.Rounding = 10;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Border.Width = 1;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = System.Drawing.Color.WhiteSmoke;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = System.Drawing.Color.SeaShell;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Back.ColorAngle = 45F;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Border.Color1 = System.Drawing.Color.DarkGreen;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Border.Color2 = System.Drawing.Color.DarkGreen;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Border.Rounding = 10;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Border.Width = 1;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.PurpleTheme.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateDisabled.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateDisabled.Border.Width = 0;
            this.PurpleTheme.ButtonStyles.ButtonForm.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateNormal.Border.Width = 0;
            this.PurpleTheme.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.ButtonStyles.ButtonForm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.ButtonStyles.ButtonForm.StatePressed.Border.Width = 0;
            this.PurpleTheme.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.ButtonStyles.ButtonForm.StateTracking.Border.Width = 0;
            this.PurpleTheme.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.DarkSlateGray;
            this.PurpleTheme.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.DarkSlateGray;
            this.PurpleTheme.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.PurpleTheme.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.MediumOrchid;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Color2 = System.Drawing.Color.DarkMagenta;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.ColorAngle = 45F;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Rounding = 7;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Border.Width = 3;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Back.Color1 = System.Drawing.Color.MediumOrchid;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Back.Color2 = System.Drawing.Color.DarkMagenta;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Back.ColorAngle = 45F;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Border.Rounding = 7;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Border.Width = 3;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.PurpleTheme.GridStyles.GridCommon.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurpleTheme.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PurpleTheme.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.PurpleTheme.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            this.PurpleTheme.PanelStyles.PanelCommon.StateCommon.Color1 = System.Drawing.Color.MediumOrchid;
            this.PurpleTheme.PanelStyles.PanelCommon.StateCommon.Color2 = System.Drawing.Color.DarkMagenta;
            this.PurpleTheme.PanelStyles.PanelCommon.StateCommon.ColorAngle = 45F;
            this.PurpleTheme.PanelStyles.PanelCommon.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.PurpleTheme.PanelStyles.PanelCustom1.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.PurpleTheme.PanelStyles.PanelCustom1.StateCommon.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // employeesReportBindingSource
            // 
            this.employeesReportBindingSource.DataSource = typeof(DBFinalProject.BL.EmployeesReport);
            // 
            // BranchEmployeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BranchEmployeeReport";
            this.Palette = this.myPallet;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Text = "BranchEmployeeReport";
            this.Load += new System.EventHandler(this.BranchEmployeeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeesReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public ComponentFactory.Krypton.Toolkit.KryptonPalette myPallet;
        public ComponentFactory.Krypton.Toolkit.KryptonPalette GreenTheme;
        public ComponentFactory.Krypton.Toolkit.KryptonPalette PurpleTheme;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource employeesReportBindingSource;
    }
}