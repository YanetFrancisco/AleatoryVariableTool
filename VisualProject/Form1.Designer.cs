namespace VisualProject
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.histograma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.poligono = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cant_intervalos = new System.Windows.Forms.Label();
            this.cant_intervaloss = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.max = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.alfa = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cantidad_variables = new System.Windows.Forms.NumericUpDown();
            this.parametro2_n = new System.Windows.Forms.NumericUpDown();
            this.parametro1_n = new System.Windows.Forms.NumericUpDown();
            this.generar = new System.Windows.Forms.Button();
            this.label_parametro2 = new System.Windows.Forms.Label();
            this.label_parametro1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.min = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.distribucion = new System.Windows.Forms.ComboBox();
            this.ho = new System.Windows.Forms.Label();
            this.ha = new System.Windows.Forms.Label();
            this.respuesta = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.histograma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poligono)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cant_intervaloss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alfa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad_variables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametro2_n)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametro1_n)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // histograma
            // 
            chartArea1.Name = "ChartArea1";
            this.histograma.ChartAreas.Add(chartArea1);
            this.histograma.IsSoftShadows = false;
            legend1.Name = "Legend1";
            this.histograma.Legends.Add(legend1);
            this.histograma.Location = new System.Drawing.Point(23, 33);
            this.histograma.Name = "histograma";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "PointWidth=1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.histograma.Series.Add(series1);
            this.histograma.Size = new System.Drawing.Size(456, 322);
            this.histograma.TabIndex = 0;
            this.histograma.Text = "chart1";
            // 
            // poligono
            // 
            chartArea2.Name = "ChartArea1";
            this.poligono.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.poligono.Legends.Add(legend2);
            this.poligono.Location = new System.Drawing.Point(36, 20);
            this.poligono.Name = "poligono";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.poligono.Series.Add(series2);
            this.poligono.Size = new System.Drawing.Size(431, 321);
            this.poligono.TabIndex = 1;
            this.poligono.Text = "chart2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(737, 703);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Histograma";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cant_intervalos);
            this.groupBox1.Controls.Add(this.cant_intervaloss);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.max);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.alfa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cantidad_variables);
            this.groupBox1.Controls.Add(this.parametro2_n);
            this.groupBox1.Controls.Add(this.parametro1_n);
            this.groupBox1.Controls.Add(this.generar);
            this.groupBox1.Controls.Add(this.label_parametro2);
            this.groupBox1.Controls.Add(this.label_parametro1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.min);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.distribucion);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(903, 78);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuracion";
            // 
            // cant_intervalos
            // 
            this.cant_intervalos.AutoSize = true;
            this.cant_intervalos.Location = new System.Drawing.Point(373, 17);
            this.cant_intervalos.Name = "cant_intervalos";
            this.cant_intervalos.Size = new System.Drawing.Size(53, 13);
            this.cant_intervalos.TabIndex = 21;
            this.cant_intervalos.Text = "Intervalos";
            // 
            // cant_intervaloss
            // 
            this.cant_intervaloss.DecimalPlaces = 4;
            this.cant_intervaloss.Location = new System.Drawing.Point(371, 33);
            this.cant_intervaloss.Name = "cant_intervaloss";
            this.cant_intervaloss.Size = new System.Drawing.Size(59, 20);
            this.cant_intervaloss.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Maximo";
            // 
            // max
            // 
            this.max.DecimalPlaces = 4;
            this.max.Location = new System.Drawing.Point(301, 33);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(60, 20);
            this.max.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(651, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Confianza";
            // 
            // alfa
            // 
            this.alfa.DecimalPlaces = 4;
            this.alfa.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.alfa.Location = new System.Drawing.Point(649, 32);
            this.alfa.Name = "alfa";
            this.alfa.Size = new System.Drawing.Size(86, 20);
            this.alfa.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(755, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cant.";
            // 
            // cantidad_variables
            // 
            this.cantidad_variables.Location = new System.Drawing.Point(754, 31);
            this.cantidad_variables.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cantidad_variables.Name = "cantidad_variables";
            this.cantidad_variables.Size = new System.Drawing.Size(47, 20);
            this.cantidad_variables.TabIndex = 13;
            // 
            // parametro2_n
            // 
            this.parametro2_n.DecimalPlaces = 4;
            this.parametro2_n.Enabled = false;
            this.parametro2_n.Location = new System.Drawing.Point(555, 32);
            this.parametro2_n.Name = "parametro2_n";
            this.parametro2_n.Size = new System.Drawing.Size(72, 20);
            this.parametro2_n.TabIndex = 12;
            // 
            // parametro1_n
            // 
            this.parametro1_n.DecimalPlaces = 4;
            this.parametro1_n.Enabled = false;
            this.parametro1_n.Location = new System.Drawing.Point(460, 32);
            this.parametro1_n.Name = "parametro1_n";
            this.parametro1_n.Size = new System.Drawing.Size(74, 20);
            this.parametro1_n.TabIndex = 11;
            // 
            // generar
            // 
            this.generar.Location = new System.Drawing.Point(812, 33);
            this.generar.Name = "generar";
            this.generar.Size = new System.Drawing.Size(75, 23);
            this.generar.TabIndex = 10;
            this.generar.Text = "Generar";
            this.generar.UseVisualStyleBackColor = true;
            this.generar.Click += new System.EventHandler(this.generar_Click);
            // 
            // label_parametro2
            // 
            this.label_parametro2.AutoSize = true;
            this.label_parametro2.Enabled = false;
            this.label_parametro2.Location = new System.Drawing.Point(569, 12);
            this.label_parametro2.Name = "label_parametro2";
            this.label_parametro2.Size = new System.Drawing.Size(19, 13);
            this.label_parametro2.TabIndex = 8;
            this.label_parametro2.Text = "pe";
            // 
            // label_parametro1
            // 
            this.label_parametro1.AutoSize = true;
            this.label_parametro1.Enabled = false;
            this.label_parametro1.Location = new System.Drawing.Point(459, 13);
            this.label_parametro1.Name = "label_parametro1";
            this.label_parametro1.Size = new System.Drawing.Size(19, 13);
            this.label_parametro1.TabIndex = 6;
            this.label_parametro1.Text = "pe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Minimo";
            // 
            // min
            // 
            this.min.DecimalPlaces = 4;
            this.min.Location = new System.Drawing.Point(233, 33);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(59, 20);
            this.min.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Distribucion";
            // 
            // distribucion
            // 
            this.distribucion.FormattingEnabled = true;
            this.distribucion.Location = new System.Drawing.Point(79, 29);
            this.distribucion.Name = "distribucion";
            this.distribucion.Size = new System.Drawing.Size(121, 21);
            this.distribucion.TabIndex = 0;
            this.distribucion.SelectedValueChanged += new System.EventHandler(this.distribucion_SelectedValueChanged);
            // 
            // ho
            // 
            this.ho.AutoSize = true;
            this.ho.Location = new System.Drawing.Point(30, 505);
            this.ho.Name = "ho";
            this.ho.Size = new System.Drawing.Size(0, 13);
            this.ho.TabIndex = 5;
            // 
            // ha
            // 
            this.ha.AutoSize = true;
            this.ha.Location = new System.Drawing.Point(30, 536);
            this.ha.Name = "ha";
            this.ha.Size = new System.Drawing.Size(0, 13);
            this.ha.TabIndex = 6;
            // 
            // respuesta
            // 
            this.respuesta.AutoSize = true;
            this.respuesta.Location = new System.Drawing.Point(28, 567);
            this.respuesta.Name = "respuesta";
            this.respuesta.Size = new System.Drawing.Size(0, 13);
            this.respuesta.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(201, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 395);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.histograma);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(550, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Histograma";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.poligono);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(550, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Poligono de Frecuencia ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chart1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(550, 369);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Poligono de Frecuencia Acumulada";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(19, 16);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(448, 332);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 629);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.respuesta);
            this.Controls.Add(this.ha);
            this.Controls.Add(this.ho);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.histograma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poligono)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cant_intervaloss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alfa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad_variables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametro2_n)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parametro1_n)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart histograma;
        private System.Windows.Forms.DataVisualization.Charting.Chart poligono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox distribucion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown min;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generar;
        private System.Windows.Forms.Label label_parametro2;
        private System.Windows.Forms.Label label_parametro1;
        private System.Windows.Forms.NumericUpDown parametro2_n;
        private System.Windows.Forms.NumericUpDown parametro1_n;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown cantidad_variables;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown alfa;
        private System.Windows.Forms.Label ho;
        private System.Windows.Forms.Label ha;
        private System.Windows.Forms.Label respuesta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown max;
        private System.Windows.Forms.Label cant_intervalos;
        private System.Windows.Forms.NumericUpDown cant_intervaloss;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

