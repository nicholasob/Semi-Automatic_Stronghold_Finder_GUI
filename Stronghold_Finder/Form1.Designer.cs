namespace Stronghold_Finder
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.getWindow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IsRunningText = new System.Windows.Forms.Label();
            this.timeInterval = new System.Windows.Forms.NumericUpDown();
            this.Position_Update = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.START = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Modify = new System.Windows.Forms.CheckBox();
            this.GroupBox_Angle = new System.Windows.Forms.GroupBox();
            this.Preview_Image_Angle = new System.Windows.Forms.Button();
            this.Swich_Angle = new System.Windows.Forms.Button();
            this.Preview_Angle = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.HEIGHT_angle = new System.Windows.Forms.NumericUpDown();
            this.WIDTH_angle = new System.Windows.Forms.NumericUpDown();
            this.Y_angle = new System.Windows.Forms.NumericUpDown();
            this.X_angle = new System.Windows.Forms.NumericUpDown();
            this.SAVE_Angles = new System.Windows.Forms.Button();
            this.GroupBox_Coordinates = new System.Windows.Forms.GroupBox();
            this.Preview_Image_Coords = new System.Windows.Forms.Button();
            this.Swich_Coords = new System.Windows.Forms.Button();
            this.Preview_Coordinates = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SAVE_Coordinates = new System.Windows.Forms.Button();
            this.HEIGHT_coordinate = new System.Windows.Forms.NumericUpDown();
            this.WIDTH_coordinate = new System.Windows.Forms.NumericUpDown();
            this.Y_coordinate = new System.Windows.Forms.NumericUpDown();
            this.X_coordinate = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Destination = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.positionUpdate = new System.Windows.Forms.Timer(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GroupBox_Angle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HEIGHT_angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WIDTH_angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_angle)).BeginInit();
            this.GroupBox_Coordinates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HEIGHT_coordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WIDTH_coordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_coordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_coordinate)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 6;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 75F;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 19);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(750, 500);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Paint += new System.Windows.Forms.PaintEventHandler(this.chart1_Paint);
            // 
            // getWindow
            // 
            this.getWindow.Location = new System.Drawing.Point(6, 19);
            this.getWindow.Name = "getWindow";
            this.getWindow.Size = new System.Drawing.Size(101, 48);
            this.getWindow.TabIndex = 1;
            this.getWindow.Text = "Get Minecraft Window";
            this.getWindow.UseVisualStyleBackColor = true;
            this.getWindow.Click += new System.EventHandler(this.getWindow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Window Title:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IsRunningText);
            this.groupBox1.Controls.Add(this.timeInterval);
            this.groupBox1.Controls.Add(this.Position_Update);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.START);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.getWindow);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start here";
            // 
            // IsRunningText
            // 
            this.IsRunningText.AutoSize = true;
            this.IsRunningText.ForeColor = System.Drawing.Color.Red;
            this.IsRunningText.Location = new System.Drawing.Point(696, 13);
            this.IsRunningText.Name = "IsRunningText";
            this.IsRunningText.Size = new System.Drawing.Size(73, 13);
            this.IsRunningText.TabIndex = 11;
            this.IsRunningText.Text = "NOT Running";
            // 
            // timeInterval
            // 
            this.timeInterval.Enabled = false;
            this.timeInterval.Location = new System.Drawing.Point(241, 87);
            this.timeInterval.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.timeInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeInterval.Name = "timeInterval";
            this.timeInterval.Size = new System.Drawing.Size(68, 20);
            this.timeInterval.TabIndex = 10;
            this.timeInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeInterval.ValueChanged += new System.EventHandler(this.timeInterval_ValueChanged);
            // 
            // Position_Update
            // 
            this.Position_Update.AutoSize = true;
            this.Position_Update.Location = new System.Drawing.Point(134, 88);
            this.Position_Update.Name = "Position_Update";
            this.Position_Update.Size = new System.Drawing.Size(101, 17);
            this.Position_Update.TabIndex = 9;
            this.Position_Update.Text = "Position Update";
            this.Position_Update.UseVisualStyleBackColor = true;
            this.Position_Update.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // START
            // 
            this.START.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.START.Location = new System.Drawing.Point(685, 29);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(94, 57);
            this.START.TabIndex = 7;
            this.START.Text = "Start Key Detect";
            this.START.UseVisualStyleBackColor = true;
            this.START.Click += new System.EventHandler(this.START_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hotkey:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Location = new System.Drawing.Point(12, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(785, 536);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gaphical overview";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Modify);
            this.groupBox3.Controls.Add(this.GroupBox_Angle);
            this.groupBox3.Controls.Add(this.GroupBox_Coordinates);
            this.groupBox3.Location = new System.Drawing.Point(803, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 310);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Values For Screenshot";
            // 
            // Modify
            // 
            this.Modify.AutoSize = true;
            this.Modify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modify.Location = new System.Drawing.Point(220, -1);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(102, 20);
            this.Modify.TabIndex = 13;
            this.Modify.Text = "Modifying?";
            this.Modify.UseVisualStyleBackColor = true;
            // 
            // GroupBox_Angle
            // 
            this.GroupBox_Angle.Controls.Add(this.Preview_Image_Angle);
            this.GroupBox_Angle.Controls.Add(this.Swich_Angle);
            this.GroupBox_Angle.Controls.Add(this.Preview_Angle);
            this.GroupBox_Angle.Controls.Add(this.label11);
            this.GroupBox_Angle.Controls.Add(this.label10);
            this.GroupBox_Angle.Controls.Add(this.label9);
            this.GroupBox_Angle.Controls.Add(this.label8);
            this.GroupBox_Angle.Controls.Add(this.HEIGHT_angle);
            this.GroupBox_Angle.Controls.Add(this.WIDTH_angle);
            this.GroupBox_Angle.Controls.Add(this.Y_angle);
            this.GroupBox_Angle.Controls.Add(this.X_angle);
            this.GroupBox_Angle.Controls.Add(this.SAVE_Angles);
            this.GroupBox_Angle.Location = new System.Drawing.Point(6, 166);
            this.GroupBox_Angle.Name = "GroupBox_Angle";
            this.GroupBox_Angle.Size = new System.Drawing.Size(310, 138);
            this.GroupBox_Angle.TabIndex = 1;
            this.GroupBox_Angle.TabStop = false;
            this.GroupBox_Angle.Text = "Angle values";
            // 
            // Preview_Image_Angle
            // 
            this.Preview_Image_Angle.Location = new System.Drawing.Point(168, 109);
            this.Preview_Image_Angle.Name = "Preview_Image_Angle";
            this.Preview_Image_Angle.Size = new System.Drawing.Size(86, 23);
            this.Preview_Image_Angle.TabIndex = 12;
            this.Preview_Image_Angle.Text = "Preview Image";
            this.Preview_Image_Angle.UseVisualStyleBackColor = true;
            this.Preview_Image_Angle.Click += new System.EventHandler(this.Preview_Image_Angle_Click);
            // 
            // Swich_Angle
            // 
            this.Swich_Angle.Location = new System.Drawing.Point(9, 109);
            this.Swich_Angle.Name = "Swich_Angle";
            this.Swich_Angle.Size = new System.Drawing.Size(48, 23);
            this.Swich_Angle.TabIndex = 11;
            this.Swich_Angle.Text = "Switch";
            this.Swich_Angle.UseVisualStyleBackColor = true;
            this.Swich_Angle.Click += new System.EventHandler(this.Swich_Angle_Click);
            // 
            // Preview_Angle
            // 
            this.Preview_Angle.Location = new System.Drawing.Point(63, 109);
            this.Preview_Angle.Name = "Preview_Angle";
            this.Preview_Angle.Size = new System.Drawing.Size(98, 23);
            this.Preview_Angle.TabIndex = 10;
            this.Preview_Angle.Text = "Preview Changes";
            this.Preview_Angle.UseVisualStyleBackColor = true;
            this.Preview_Angle.Click += new System.EventHandler(this.Preview_Angle_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Height";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Width";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "X";
            // 
            // HEIGHT_angle
            // 
            this.HEIGHT_angle.Location = new System.Drawing.Point(184, 83);
            this.HEIGHT_angle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HEIGHT_angle.Name = "HEIGHT_angle";
            this.HEIGHT_angle.Size = new System.Drawing.Size(120, 20);
            this.HEIGHT_angle.TabIndex = 5;
            // 
            // WIDTH_angle
            // 
            this.WIDTH_angle.Location = new System.Drawing.Point(9, 83);
            this.WIDTH_angle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.WIDTH_angle.Name = "WIDTH_angle";
            this.WIDTH_angle.Size = new System.Drawing.Size(120, 20);
            this.WIDTH_angle.TabIndex = 4;
            // 
            // Y_angle
            // 
            this.Y_angle.Location = new System.Drawing.Point(184, 32);
            this.Y_angle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Y_angle.Name = "Y_angle";
            this.Y_angle.Size = new System.Drawing.Size(120, 20);
            this.Y_angle.TabIndex = 3;
            // 
            // X_angle
            // 
            this.X_angle.Location = new System.Drawing.Point(9, 32);
            this.X_angle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.X_angle.Name = "X_angle";
            this.X_angle.Size = new System.Drawing.Size(120, 20);
            this.X_angle.TabIndex = 2;
            // 
            // SAVE_Angles
            // 
            this.SAVE_Angles.Location = new System.Drawing.Point(260, 109);
            this.SAVE_Angles.Name = "SAVE_Angles";
            this.SAVE_Angles.Size = new System.Drawing.Size(44, 23);
            this.SAVE_Angles.TabIndex = 1;
            this.SAVE_Angles.Text = "Save";
            this.SAVE_Angles.UseVisualStyleBackColor = true;
            this.SAVE_Angles.Click += new System.EventHandler(this.SAVE_Angles_Click);
            // 
            // GroupBox_Coordinates
            // 
            this.GroupBox_Coordinates.Controls.Add(this.Preview_Image_Coords);
            this.GroupBox_Coordinates.Controls.Add(this.Swich_Coords);
            this.GroupBox_Coordinates.Controls.Add(this.Preview_Coordinates);
            this.GroupBox_Coordinates.Controls.Add(this.label7);
            this.GroupBox_Coordinates.Controls.Add(this.label6);
            this.GroupBox_Coordinates.Controls.Add(this.label5);
            this.GroupBox_Coordinates.Controls.Add(this.SAVE_Coordinates);
            this.GroupBox_Coordinates.Controls.Add(this.HEIGHT_coordinate);
            this.GroupBox_Coordinates.Controls.Add(this.WIDTH_coordinate);
            this.GroupBox_Coordinates.Controls.Add(this.Y_coordinate);
            this.GroupBox_Coordinates.Controls.Add(this.X_coordinate);
            this.GroupBox_Coordinates.Controls.Add(this.label4);
            this.GroupBox_Coordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_Coordinates.Location = new System.Drawing.Point(6, 19);
            this.GroupBox_Coordinates.Name = "GroupBox_Coordinates";
            this.GroupBox_Coordinates.Size = new System.Drawing.Size(310, 141);
            this.GroupBox_Coordinates.TabIndex = 0;
            this.GroupBox_Coordinates.TabStop = false;
            this.GroupBox_Coordinates.Text = "Coordinates values";
            // 
            // Preview_Image_Coords
            // 
            this.Preview_Image_Coords.Location = new System.Drawing.Point(168, 114);
            this.Preview_Image_Coords.Name = "Preview_Image_Coords";
            this.Preview_Image_Coords.Size = new System.Drawing.Size(86, 23);
            this.Preview_Image_Coords.TabIndex = 12;
            this.Preview_Image_Coords.Text = "Preview Image";
            this.Preview_Image_Coords.UseVisualStyleBackColor = true;
            this.Preview_Image_Coords.Click += new System.EventHandler(this.Preview_Image_Coords_Click);
            // 
            // Swich_Coords
            // 
            this.Swich_Coords.Location = new System.Drawing.Point(9, 114);
            this.Swich_Coords.Name = "Swich_Coords";
            this.Swich_Coords.Size = new System.Drawing.Size(48, 23);
            this.Swich_Coords.TabIndex = 11;
            this.Swich_Coords.Text = "Switch";
            this.Swich_Coords.UseVisualStyleBackColor = true;
            this.Swich_Coords.Click += new System.EventHandler(this.Swich_Coords_Click);
            // 
            // Preview_Coordinates
            // 
            this.Preview_Coordinates.Location = new System.Drawing.Point(63, 114);
            this.Preview_Coordinates.Name = "Preview_Coordinates";
            this.Preview_Coordinates.Size = new System.Drawing.Size(98, 23);
            this.Preview_Coordinates.TabIndex = 10;
            this.Preview_Coordinates.Text = "Preview Changes";
            this.Preview_Coordinates.UseVisualStyleBackColor = true;
            this.Preview_Coordinates.Click += new System.EventHandler(this.Preview_Coordinates_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Y";
            // 
            // SAVE_Coordinates
            // 
            this.SAVE_Coordinates.Location = new System.Drawing.Point(260, 114);
            this.SAVE_Coordinates.Name = "SAVE_Coordinates";
            this.SAVE_Coordinates.Size = new System.Drawing.Size(44, 23);
            this.SAVE_Coordinates.TabIndex = 6;
            this.SAVE_Coordinates.Text = "Save";
            this.SAVE_Coordinates.UseVisualStyleBackColor = true;
            this.SAVE_Coordinates.Click += new System.EventHandler(this.SAVE_Coordinates_Click);
            // 
            // HEIGHT_coordinate
            // 
            this.HEIGHT_coordinate.Location = new System.Drawing.Point(184, 88);
            this.HEIGHT_coordinate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HEIGHT_coordinate.Name = "HEIGHT_coordinate";
            this.HEIGHT_coordinate.Size = new System.Drawing.Size(120, 20);
            this.HEIGHT_coordinate.TabIndex = 5;
            // 
            // WIDTH_coordinate
            // 
            this.WIDTH_coordinate.Location = new System.Drawing.Point(9, 88);
            this.WIDTH_coordinate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.WIDTH_coordinate.Name = "WIDTH_coordinate";
            this.WIDTH_coordinate.Size = new System.Drawing.Size(120, 20);
            this.WIDTH_coordinate.TabIndex = 4;
            // 
            // Y_coordinate
            // 
            this.Y_coordinate.Location = new System.Drawing.Point(184, 32);
            this.Y_coordinate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Y_coordinate.Name = "Y_coordinate";
            this.Y_coordinate.Size = new System.Drawing.Size(120, 20);
            this.Y_coordinate.TabIndex = 3;
            // 
            // X_coordinate
            // 
            this.X_coordinate.Location = new System.Drawing.Point(9, 32);
            this.X_coordinate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.X_coordinate.Name = "X_coordinate";
            this.X_coordinate.Size = new System.Drawing.Size(120, 20);
            this.X_coordinate.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "X";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.Destination);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(803, 338);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(322, 327);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Information";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "RESTART";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Destination
            // 
            this.Destination.AutoSize = true;
            this.Destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.31F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Destination.Location = new System.Drawing.Point(12, 241);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(32, 17);
            this.Destination.TabIndex = 10;
            this.Destination.Text = "Null";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(123, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 16);
            this.label20.TabIndex = 8;
            this.label20.Text = "Null";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Blocks from stronghold:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(123, 165);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 16);
            this.label18.TabIndex = 6;
            this.label18.Text = "Null";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 165);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Stronghold prediction:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Angle: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Coordinates: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(82, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Null";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(82, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Null";
            // 
            // positionUpdate
            // 
            this.positionUpdate.Tick += new System.EventHandler(this.positionUpdate_Tick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(885, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Status: ";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(934, 6);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 13);
            this.Status.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 677);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Automatic Stronghold Finder by nicholasob";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GroupBox_Angle.ResumeLayout(false);
            this.GroupBox_Angle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HEIGHT_angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WIDTH_angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_angle)).EndInit();
            this.GroupBox_Coordinates.ResumeLayout(false);
            this.GroupBox_Coordinates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HEIGHT_coordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WIDTH_coordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_coordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_coordinate)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button getWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button START;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown timeInterval;
        private System.Windows.Forms.CheckBox Position_Update;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox GroupBox_Coordinates;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button SAVE_Coordinates;
        private System.Windows.Forms.NumericUpDown HEIGHT_coordinate;
        private System.Windows.Forms.NumericUpDown WIDTH_coordinate;
        private System.Windows.Forms.NumericUpDown Y_coordinate;
        private System.Windows.Forms.NumericUpDown X_coordinate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox GroupBox_Angle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown HEIGHT_angle;
        private System.Windows.Forms.NumericUpDown WIDTH_angle;
        private System.Windows.Forms.NumericUpDown Y_angle;
        private System.Windows.Forms.NumericUpDown X_angle;
        private System.Windows.Forms.Button SAVE_Angles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Preview_Angle;
        private System.Windows.Forms.Button Preview_Coordinates;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Timer positionUpdate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label IsRunningText;
        private System.Windows.Forms.Label Destination;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Swich_Coords;
        private System.Windows.Forms.Button Swich_Angle;
        private System.Windows.Forms.Button Preview_Image_Angle;
        private System.Windows.Forms.Button Preview_Image_Coords;
        private System.Windows.Forms.CheckBox Modify;
    }
}

