namespace Weather_Application
{
    partial class Weather
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Weather));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.weatherInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentConditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloudCoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windChillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.humidityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forecastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highTemperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowTemperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precipitationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tomorrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highTemperatureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lowTemperatureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.weatherToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.precipitationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.daysAheadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highTemperatureToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lowTemperatureToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.weatherToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.precipitationToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.radarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.futurePrecipitationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.futureCloudCoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.btnSwitchUnits = new System.Windows.Forms.Button();
            this.lblUnitType = new System.Windows.Forms.Label();
            this.tmrRadar = new System.Windows.Forms.Timer(this.components);
            this.lblOpenWeather = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.lblBack2 = new System.Windows.Forms.Label();
            this.lblFront = new System.Windows.Forms.Label();
            this.lblFront2 = new System.Windows.Forms.Label();
            this.tmrCloud = new System.Windows.Forms.Timer(this.components);
            this.picMap = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weatherInfoToolStripMenuItem,
            this.forecastToolStripMenuItem,
            this.radarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(941, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // weatherInfoToolStripMenuItem
            // 
            this.weatherInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentConditionToolStripMenuItem,
            this.cloudCoverToolStripMenuItem,
            this.temperatureToolStripMenuItem,
            this.windChillToolStripMenuItem,
            this.windToolStripMenuItem,
            this.humidityToolStripMenuItem});
            this.weatherInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.weatherInfoToolStripMenuItem.Name = "weatherInfoToolStripMenuItem";
            this.weatherInfoToolStripMenuItem.Size = new System.Drawing.Size(121, 27);
            this.weatherInfoToolStripMenuItem.Text = "Weather Info";
            // 
            // currentConditionToolStripMenuItem
            // 
            this.currentConditionToolStripMenuItem.Name = "currentConditionToolStripMenuItem";
            this.currentConditionToolStripMenuItem.Size = new System.Drawing.Size(245, 28);
            this.currentConditionToolStripMenuItem.Text = "Current Condition";
            this.currentConditionToolStripMenuItem.Click += new System.EventHandler(this.currentConditionToolStripMenuItem_Click);
            // 
            // cloudCoverToolStripMenuItem
            // 
            this.cloudCoverToolStripMenuItem.Name = "cloudCoverToolStripMenuItem";
            this.cloudCoverToolStripMenuItem.Size = new System.Drawing.Size(245, 28);
            this.cloudCoverToolStripMenuItem.Text = "Cloud Cover";
            this.cloudCoverToolStripMenuItem.Click += new System.EventHandler(this.cloudCoverToolStripMenuItem_Click);
            // 
            // temperatureToolStripMenuItem
            // 
            this.temperatureToolStripMenuItem.Name = "temperatureToolStripMenuItem";
            this.temperatureToolStripMenuItem.Size = new System.Drawing.Size(245, 28);
            this.temperatureToolStripMenuItem.Text = "Current Temperature";
            this.temperatureToolStripMenuItem.Click += new System.EventHandler(this.temperatureToolStripMenuItem_Click);
            // 
            // windChillToolStripMenuItem
            // 
            this.windChillToolStripMenuItem.Name = "windChillToolStripMenuItem";
            this.windChillToolStripMenuItem.Size = new System.Drawing.Size(245, 28);
            this.windChillToolStripMenuItem.Text = "Wind Chill";
            this.windChillToolStripMenuItem.Click += new System.EventHandler(this.windChillToolStripMenuItem_Click);
            // 
            // windToolStripMenuItem
            // 
            this.windToolStripMenuItem.Name = "windToolStripMenuItem";
            this.windToolStripMenuItem.Size = new System.Drawing.Size(245, 28);
            this.windToolStripMenuItem.Text = "Wind";
            this.windToolStripMenuItem.Click += new System.EventHandler(this.windToolStripMenuItem_Click);
            // 
            // humidityToolStripMenuItem
            // 
            this.humidityToolStripMenuItem.Name = "humidityToolStripMenuItem";
            this.humidityToolStripMenuItem.Size = new System.Drawing.Size(245, 28);
            this.humidityToolStripMenuItem.Text = "Humidity";
            this.humidityToolStripMenuItem.Click += new System.EventHandler(this.humidityToolStripMenuItem_Click);
            // 
            // forecastToolStripMenuItem
            // 
            this.forecastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayToolStripMenuItem,
            this.tomorrowToolStripMenuItem,
            this.daysAheadToolStripMenuItem});
            this.forecastToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.forecastToolStripMenuItem.Name = "forecastToolStripMenuItem";
            this.forecastToolStripMenuItem.Size = new System.Drawing.Size(85, 27);
            this.forecastToolStripMenuItem.Text = "Forecast";
            // 
            // todayToolStripMenuItem
            // 
            this.todayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highTemperatureToolStripMenuItem,
            this.lowTemperatureToolStripMenuItem,
            this.weatherToolStripMenuItem,
            this.precipitationToolStripMenuItem});
            this.todayToolStripMenuItem.Name = "todayToolStripMenuItem";
            this.todayToolStripMenuItem.Size = new System.Drawing.Size(190, 28);
            this.todayToolStripMenuItem.Text = "Today";
            // 
            // highTemperatureToolStripMenuItem
            // 
            this.highTemperatureToolStripMenuItem.Name = "highTemperatureToolStripMenuItem";
            this.highTemperatureToolStripMenuItem.Size = new System.Drawing.Size(223, 28);
            this.highTemperatureToolStripMenuItem.Text = "High Temperature";
            this.highTemperatureToolStripMenuItem.Click += new System.EventHandler(this.highTemperatureToolStripMenuItem_Click);
            // 
            // lowTemperatureToolStripMenuItem
            // 
            this.lowTemperatureToolStripMenuItem.Name = "lowTemperatureToolStripMenuItem";
            this.lowTemperatureToolStripMenuItem.Size = new System.Drawing.Size(223, 28);
            this.lowTemperatureToolStripMenuItem.Text = "Low Temperature";
            this.lowTemperatureToolStripMenuItem.Click += new System.EventHandler(this.lowTemperatureToolStripMenuItem_Click);
            // 
            // weatherToolStripMenuItem
            // 
            this.weatherToolStripMenuItem.Name = "weatherToolStripMenuItem";
            this.weatherToolStripMenuItem.Size = new System.Drawing.Size(223, 28);
            this.weatherToolStripMenuItem.Text = "Weather";
            this.weatherToolStripMenuItem.Click += new System.EventHandler(this.weatherToolStripMenuItem_Click);
            // 
            // precipitationToolStripMenuItem
            // 
            this.precipitationToolStripMenuItem.Name = "precipitationToolStripMenuItem";
            this.precipitationToolStripMenuItem.Size = new System.Drawing.Size(223, 28);
            this.precipitationToolStripMenuItem.Text = "Precipitation";
            this.precipitationToolStripMenuItem.Click += new System.EventHandler(this.precipitationToolStripMenuItem_Click);
            // 
            // tomorrowToolStripMenuItem
            // 
            this.tomorrowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highTemperatureToolStripMenuItem1,
            this.lowTemperatureToolStripMenuItem1,
            this.weatherToolStripMenuItem1,
            this.precipitationToolStripMenuItem1});
            this.tomorrowToolStripMenuItem.Name = "tomorrowToolStripMenuItem";
            this.tomorrowToolStripMenuItem.Size = new System.Drawing.Size(190, 28);
            this.tomorrowToolStripMenuItem.Text = "Tomorrow";
            // 
            // highTemperatureToolStripMenuItem1
            // 
            this.highTemperatureToolStripMenuItem1.Name = "highTemperatureToolStripMenuItem1";
            this.highTemperatureToolStripMenuItem1.Size = new System.Drawing.Size(223, 28);
            this.highTemperatureToolStripMenuItem1.Text = "High Temperature";
            this.highTemperatureToolStripMenuItem1.Click += new System.EventHandler(this.highTemperatureToolStripMenuItem1_Click);
            // 
            // lowTemperatureToolStripMenuItem1
            // 
            this.lowTemperatureToolStripMenuItem1.Name = "lowTemperatureToolStripMenuItem1";
            this.lowTemperatureToolStripMenuItem1.Size = new System.Drawing.Size(223, 28);
            this.lowTemperatureToolStripMenuItem1.Text = "Low Temperature";
            this.lowTemperatureToolStripMenuItem1.Click += new System.EventHandler(this.lowTemperatureToolStripMenuItem1_Click);
            // 
            // weatherToolStripMenuItem1
            // 
            this.weatherToolStripMenuItem1.Name = "weatherToolStripMenuItem1";
            this.weatherToolStripMenuItem1.Size = new System.Drawing.Size(223, 28);
            this.weatherToolStripMenuItem1.Text = "Weather";
            this.weatherToolStripMenuItem1.Click += new System.EventHandler(this.weatherToolStripMenuItem1_Click);
            // 
            // precipitationToolStripMenuItem1
            // 
            this.precipitationToolStripMenuItem1.Name = "precipitationToolStripMenuItem1";
            this.precipitationToolStripMenuItem1.Size = new System.Drawing.Size(223, 28);
            this.precipitationToolStripMenuItem1.Text = "Precipitation";
            this.precipitationToolStripMenuItem1.Click += new System.EventHandler(this.precipitationToolStripMenuItem1_Click);
            // 
            // daysAheadToolStripMenuItem
            // 
            this.daysAheadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highTemperatureToolStripMenuItem2,
            this.lowTemperatureToolStripMenuItem2,
            this.weatherToolStripMenuItem2,
            this.precipitationToolStripMenuItem2});
            this.daysAheadToolStripMenuItem.Name = "daysAheadToolStripMenuItem";
            this.daysAheadToolStripMenuItem.Size = new System.Drawing.Size(190, 28);
            this.daysAheadToolStripMenuItem.Text = "2 Days Ahead";
            // 
            // highTemperatureToolStripMenuItem2
            // 
            this.highTemperatureToolStripMenuItem2.Name = "highTemperatureToolStripMenuItem2";
            this.highTemperatureToolStripMenuItem2.Size = new System.Drawing.Size(223, 28);
            this.highTemperatureToolStripMenuItem2.Text = "High Temperature";
            this.highTemperatureToolStripMenuItem2.Click += new System.EventHandler(this.highTemperatureToolStripMenuItem2_Click);
            // 
            // lowTemperatureToolStripMenuItem2
            // 
            this.lowTemperatureToolStripMenuItem2.Name = "lowTemperatureToolStripMenuItem2";
            this.lowTemperatureToolStripMenuItem2.Size = new System.Drawing.Size(223, 28);
            this.lowTemperatureToolStripMenuItem2.Text = "Low Temperature";
            this.lowTemperatureToolStripMenuItem2.Click += new System.EventHandler(this.lowTemperatureToolStripMenuItem2_Click);
            // 
            // weatherToolStripMenuItem2
            // 
            this.weatherToolStripMenuItem2.Name = "weatherToolStripMenuItem2";
            this.weatherToolStripMenuItem2.Size = new System.Drawing.Size(223, 28);
            this.weatherToolStripMenuItem2.Text = "Weather";
            this.weatherToolStripMenuItem2.Click += new System.EventHandler(this.weatherToolStripMenuItem2_Click);
            // 
            // precipitationToolStripMenuItem2
            // 
            this.precipitationToolStripMenuItem2.Name = "precipitationToolStripMenuItem2";
            this.precipitationToolStripMenuItem2.Size = new System.Drawing.Size(223, 28);
            this.precipitationToolStripMenuItem2.Text = "Precipitation";
            this.precipitationToolStripMenuItem2.Click += new System.EventHandler(this.precipitationToolStripMenuItem2_Click);
            // 
            // radarToolStripMenuItem
            // 
            this.radarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.futurePrecipitationToolStripMenuItem,
            this.futureCloudCoverToolStripMenuItem});
            this.radarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radarToolStripMenuItem.Name = "radarToolStripMenuItem";
            this.radarToolStripMenuItem.Size = new System.Drawing.Size(66, 27);
            this.radarToolStripMenuItem.Text = "Radar";
            // 
            // futurePrecipitationToolStripMenuItem
            // 
            this.futurePrecipitationToolStripMenuItem.Name = "futurePrecipitationToolStripMenuItem";
            this.futurePrecipitationToolStripMenuItem.Size = new System.Drawing.Size(236, 28);
            this.futurePrecipitationToolStripMenuItem.Text = "Future Precipitation";
            this.futurePrecipitationToolStripMenuItem.Click += new System.EventHandler(this.futurePrecipitationToolStripMenuItem_Click);
            // 
            // futureCloudCoverToolStripMenuItem
            // 
            this.futureCloudCoverToolStripMenuItem.Name = "futureCloudCoverToolStripMenuItem";
            this.futureCloudCoverToolStripMenuItem.Size = new System.Drawing.Size(236, 28);
            this.futureCloudCoverToolStripMenuItem.Text = "Future Cloud Cover";
            this.futureCloudCoverToolStripMenuItem.Click += new System.EventHandler(this.futureCloudCoverToolStripMenuItem_Click);
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.Location = new System.Drawing.Point(3, 646);
            this.lblLastUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(110, 17);
            this.lblLastUpdate.TabIndex = 11;
            this.lblLastUpdate.Text = "Last Updated:";
            // 
            // btnSwitchUnits
            // 
            this.btnSwitchUnits.Location = new System.Drawing.Point(843, 639);
            this.btnSwitchUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSwitchUnits.Name = "btnSwitchUnits";
            this.btnSwitchUnits.Size = new System.Drawing.Size(99, 23);
            this.btnSwitchUnits.TabIndex = 12;
            this.btnSwitchUnits.Text = "Switch Units";
            this.btnSwitchUnits.UseVisualStyleBackColor = true;
            this.btnSwitchUnits.Click += new System.EventHandler(this.btnSwitchUnits_Click);
            // 
            // lblUnitType
            // 
            this.lblUnitType.AutoSize = true;
            this.lblUnitType.BackColor = System.Drawing.Color.Transparent;
            this.lblUnitType.Location = new System.Drawing.Point(689, 644);
            this.lblUnitType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnitType.Name = "lblUnitType";
            this.lblUnitType.Size = new System.Drawing.Size(148, 17);
            this.lblUnitType.TabIndex = 13;
            this.lblUnitType.Text = "Current Units: Imperial";
            // 
            // tmrRadar
            // 
            this.tmrRadar.Interval = 2000;
            this.tmrRadar.Tick += new System.EventHandler(this.tmrRadar_Tick);
            // 
            // lblOpenWeather
            // 
            this.lblOpenWeather.AutoSize = true;
            this.lblOpenWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenWeather.Location = new System.Drawing.Point(401, 5);
            this.lblOpenWeather.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpenWeather.Name = "lblOpenWeather";
            this.lblOpenWeather.Size = new System.Drawing.Size(226, 20);
            this.lblOpenWeather.TabIndex = 15;
            this.lblOpenWeather.Text = "Powered by OpenWeather";
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.BackColor = System.Drawing.Color.Transparent;
            this.lblBack.Location = new System.Drawing.Point(904, 596);
            this.lblBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(37, 17);
            this.lblBack.TabIndex = 16;
            this.lblBack.Text = "High";
            this.lblBack.Visible = false;
            // 
            // lblBack2
            // 
            this.lblBack2.AutoSize = true;
            this.lblBack2.BackColor = System.Drawing.Color.Transparent;
            this.lblBack2.Location = new System.Drawing.Point(904, 620);
            this.lblBack2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBack2.Name = "lblBack2";
            this.lblBack2.Size = new System.Drawing.Size(37, 17);
            this.lblBack2.TabIndex = 17;
            this.lblBack2.Text = "High";
            this.lblBack2.Visible = false;
            // 
            // lblFront
            // 
            this.lblFront.AutoSize = true;
            this.lblFront.BackColor = System.Drawing.Color.Transparent;
            this.lblFront.Location = new System.Drawing.Point(4, 598);
            this.lblFront.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFront.Name = "lblFront";
            this.lblFront.Size = new System.Drawing.Size(33, 17);
            this.lblFront.TabIndex = 18;
            this.lblFront.Text = "Low";
            this.lblFront.Visible = false;
            // 
            // lblFront2
            // 
            this.lblFront2.AutoSize = true;
            this.lblFront2.BackColor = System.Drawing.Color.Transparent;
            this.lblFront2.Location = new System.Drawing.Point(4, 623);
            this.lblFront2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFront2.Name = "lblFront2";
            this.lblFront2.Size = new System.Drawing.Size(33, 17);
            this.lblFront2.TabIndex = 19;
            this.lblFront2.Text = "Low";
            this.lblFront2.Visible = false;
            // 
            // tmrCloud
            // 
            this.tmrCloud.Interval = 2000;
            this.tmrCloud.Tick += new System.EventHandler(this.tmrCloud_Tick);
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.Color.Transparent;
            this.picMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMap.Image = global::Weather_Application.Properties.Resources.Possible_Map2;
            this.picMap.Location = new System.Drawing.Point(0, 0);
            this.picMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(941, 592);
            this.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMap.TabIndex = 14;
            this.picMap.TabStop = false;
            this.picMap.Click += new System.EventHandler(this.picMap_Click);
            // 
            // Weather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(941, 665);
            this.Controls.Add(this.lblFront2);
            this.Controls.Add(this.lblFront);
            this.Controls.Add(this.lblBack2);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.lblOpenWeather);
            this.Controls.Add(this.lblUnitType);
            this.Controls.Add(this.btnSwitchUnits);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picMap);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Weather";
            this.Text = "Weather";
            this.Load += new System.EventHandler(this.Weather_Load);
            this.ResizeEnd += new System.EventHandler(this.Weather_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem weatherInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temperatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem humidityToolStripMenuItem;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.ToolStripMenuItem currentConditionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windChillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forecastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highTemperatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowTemperatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tomorrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highTemperatureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lowTemperatureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem daysAheadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highTemperatureToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem lowTemperatureToolStripMenuItem2;
        private System.Windows.Forms.Button btnSwitchUnits;
        private System.Windows.Forms.ToolStripMenuItem weatherToolStripMenuItem;
        private System.Windows.Forms.Label lblUnitType;
        private System.Windows.Forms.ToolStripMenuItem weatherToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem weatherToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem precipitationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precipitationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem precipitationToolStripMenuItem2;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ToolStripMenuItem radarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem futurePrecipitationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem futureCloudCoverToolStripMenuItem;
        private System.Windows.Forms.Timer tmrRadar;
        private System.Windows.Forms.Label lblOpenWeather;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.ToolStripMenuItem cloudCoverToolStripMenuItem;
        private System.Windows.Forms.Label lblBack2;
        private System.Windows.Forms.Label lblFront;
        private System.Windows.Forms.Label lblFront2;
        private System.Windows.Forms.Timer tmrCloud;
    }
}

