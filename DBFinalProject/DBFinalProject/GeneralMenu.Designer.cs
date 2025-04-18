namespace DBFinalProject
{
    partial class GeneralMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralMenu));
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.myPallet = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.commonInterface1 = new DBFinalProject.CommonInterface();
            this.depositMoney1 = new DBFinalProject.DepositMoney();
            this.sidebar.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.ButtonStyles.ButtonCustom1.StateCommon.Back.Color1 = System.Drawing.Color.RoyalBlue;
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.Rounding = 12;
            this.kryptonPalette1.PalettePaint += new System.EventHandler<ComponentFactory.Krypton.Toolkit.PaletteLayoutEventArgs>(this.kryptonPalette1_PalettePaint);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.RoyalBlue;
            this.sidebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sidebar.Controls.Add(this.flowLayoutPanel2);
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel6);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.MaximumSize = new System.Drawing.Size(217, 640);
            this.sidebar.MinimumSize = new System.Drawing.Size(60, 640);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(217, 640);
            this.sidebar.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.menuButton);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(218, 51);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // menuButton
            // 
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButton.Image = ((System.Drawing.Image)(resources.GetObject("menuButton.Image")));
            this.menuButton.Location = new System.Drawing.Point(3, 14);
            this.menuButton.Name = "menuButton";
            this.menuButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.menuButton.Size = new System.Drawing.Size(44, 34);
            this.menuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuButton.TabIndex = 0;
            this.menuButton.TabStop = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(53, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "MENU";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 48);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(-15, -16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 82);
            this.button1.TabIndex = 1;
            this.button1.Text = "                       DEPOSIT MONEY";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(3, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 48);
            this.panel2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(-15, -13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 70);
            this.button2.TabIndex = 1;
            this.button2.Text = "                       PURCHASE";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(3, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(214, 48);
            this.panel3.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(-15, -11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(240, 70);
            this.button3.TabIndex = 1;
            this.button3.Text = "                       SEND MONEY";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button4);
            this.panel4.Location = new System.Drawing.Point(3, 222);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(214, 48);
            this.panel4.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(-15, -13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(240, 70);
            this.button4.TabIndex = 1;
            this.button4.Text = "                       APPLY FOR LOAN\r\n";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button5);
            this.panel5.Location = new System.Drawing.Point(3, 276);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(214, 48);
            this.panel5.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(-15, -13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(240, 70);
            this.button5.TabIndex = 1;
            this.button5.Text = "                      CURRENCY EXCHANGE";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button6);
            this.panel6.Location = new System.Drawing.Point(3, 330);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(214, 48);
            this.panel6.TabIndex = 5;
            // 
            // button6
            // 
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(-15, -13);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(240, 70);
            this.button6.TabIndex = 1;
            this.button6.Text = "                      WITHDRAW MONEY";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 5;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Custom;
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
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button7.Location = new System.Drawing.Point(1106, -2);
            this.button7.Margin = new System.Windows.Forms.Padding(0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(34, 35);
            this.button7.TabIndex = 20;
            this.button7.Text = "X";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // commonInterface1
            // 
            this.commonInterface1.Location = new System.Drawing.Point(234, 12);
            this.commonInterface1.Name = "commonInterface1";
            this.commonInterface1.Size = new System.Drawing.Size(892, 594);
            this.commonInterface1.TabIndex = 21;
            // 
            // depositMoney1
            // 
            this.depositMoney1.Location = new System.Drawing.Point(234, 0);
            this.depositMoney1.Name = "depositMoney1";
            this.depositMoney1.Size = new System.Drawing.Size(923, 628);
            this.depositMoney1.TabIndex = 22;
            this.depositMoney1.Visible = false;
            // 
            // GeneralMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 640);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.commonInterface1);
            this.Controls.Add(this.depositMoney1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GeneralMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeneralMenu";
            this.sidebar.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox menuButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer sidebarTimer;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette myPallet;
        private System.Windows.Forms.Button button7;
        private CommonInterface commonInterface1;
        private DepositMoney depositMoney1;
    }
}