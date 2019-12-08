using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public DataTable ReadCsvFile(string file)
        {
            DataTable dt = new DataTable();
            using (StreamReader streamReader = new StreamReader(file))
            {
                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadToEnd();
                    string[] rows = text.Split('\n');
                    if (rows.Length > 0)
                    {
                        //Add columns
                        string[] columns = rows[0].Split(',');
                        for (int j = 0; j < columns.Count(); j++)
                            dt.Columns.Add(columns[j]);
                        //Add rows
                        for (int i = 1; i < rows.Count() - 1; i++)
                        {
                            string[] data = rows[i].Split(',');
                            DataRow dr = dt.NewRow();
                            for (int k = 0; k < data.Count(); k++)
                                dr[k] = data[k];
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {


           using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV file|*.csv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    chart1.DataSource = ReadCsvFile(ofd.FileName);

                }
            }

         

          /* 
            this.chart1.Series["Series1"].Points.AddXY("10", 11);
            this.chart1.Series["Series1"].Points.AddXY("10", 3);
            this.chart1.Series["Series1"].Points.AddXY("10", 31);
            this.chart1.Series["Series1"].Points.AddXY("10", 13);
            this.chart1.Series["Series1"].Points.AddXY("10", 23);
            this.chart1.Series["Series1"].Points.AddXY("10", 11);
            this.chart1.Series["Series1"].Points.AddXY("10", 3);
            this.chart1.Series["Series1"].Points.AddXY("10", 31);
            this.chart1.Series["Series1"].Points.AddXY("10", 13);
            this.chart1.Series["Series1"].Points.AddXY("10", 23);


            this.chart1.Series["Series2"].Points.AddXY("20", 3);
            this.chart1.Series["Series2"].Points.AddXY("20", 30);
            this.chart1.Series["Series2"].Points.AddXY("20", 2);
            this.chart1.Series["Series2"].Points.AddXY("20", 23);
            this.chart1.Series["Series2"].Points.AddXY("20", 13);
            this.chart1.Series["Series2"].Points.AddXY("20", 3);
            this.chart1.Series["Series2"].Points.AddXY("20", 30);
            this.chart1.Series["Series2"].Points.AddXY("20", 2);
            this.chart1.Series["Series2"].Points.AddXY("20", 23);
            this.chart1.Series["Series2"].Points.AddXY("20", 13);


            this.chart1.Series["Series3"].Points.AddXY("30", 53);
            this.chart1.Series["Series3"].Points.AddXY("30", 22);
            this.chart1.Series["Series3"].Points.AddXY("30", 1.66666);
            this.chart1.Series["Series3"].Points.AddXY("30", 20.0022183624);
            this.chart1.Series["Series3"].Points.AddXY("30", 23);
            this.chart1.Series["Series3"].Points.AddXY("30", 53);
            this.chart1.Series["Series3"].Points.AddXY("30", 22);
            this.chart1.Series["Series3"].Points.AddXY("30", 1.66666);
            this.chart1.Series["Series3"].Points.AddXY("30", 20.0022183624);
            this.chart1.Series["Series3"].Points.AddXY("30", 23);


            this.chart1.Series["Series4"].Points.AddXY("", 76.000038827);
            this.chart1.Series["Series4"].Points.AddXY("", 1.34555);
            this.chart1.Series["Series4"].Points.AddXY("", 11);
            this.chart1.Series["Series4"].Points.AddXY("", 93);
            this.chart1.Series["Series4"].Points.AddXY("", 21);
            this.chart1.Series["Series4"].Points.AddXY("", 53);
            this.chart1.Series["Series4"].Points.AddXY("", 22);
            this.chart1.Series["Series4"].Points.AddXY("", 1.66666);
            this.chart1.Series["Series4"].Points.AddXY("", 20.0022183624);
            this.chart1.Series["Series4"].Points.AddXY("", 23);


            this.chart1.Series["Series5"].Points.AddXY("", 33);
            this.chart1.Series["Series5"].Points.AddXY("", 3);
            this.chart1.Series["Series5"].Points.AddXY("", 31);
            this.chart1.Series["Series5"].Points.AddXY("", 13);
            this.chart1.Series["Series5"].Points.AddXY("", 23);
            this.chart1.Series["Series5"].Points.AddXY("", 3.11123455);
            this.chart1.Series["Series5"].Points.AddXY("", 3.111);
            this.chart1.Series["Series5"].Points.AddXY("", 9.777);
            this.chart1.Series["Series5"].Points.AddXY("", 13.9999999);
            this.chart1.Series["Series5"].Points.AddXY("", 23.4422);

            this.chart1.Series["Series6"].Points.AddXY("", 3.11123455);
            this.chart1.Series["Series6"].Points.AddXY("", 3.111);
            this.chart1.Series["Series6"].Points.AddXY("", 9.777);
            this.chart1.Series["Series6"].Points.AddXY("", 13.9999999);
            this.chart1.Series["Series6"].Points.AddXY("", 23.4422);
            this.chart1.Series["Series6"].Points.AddXY("", 33);
            this.chart1.Series["Series6"].Points.AddXY("", 3);
            this.chart1.Series["Series6"].Points.AddXY("", 31);
            this.chart1.Series["Series6"].Points.AddXY("", 13);
            this.chart1.Series["Series6"].Points.AddXY("", 23);

            this.chart1.Series["Series7"].Points.AddXY("", 39);
            this.chart1.Series["Series7"].Points.AddXY("", 9);
            this.chart1.Series["Series7"].Points.AddXY("", 8);
            this.chart1.Series["Series7"].Points.AddXY("", 7.2222);
            this.chart1.Series["Series7"].Points.AddXY("", 23);
            this.chart1.Series["Series7"].Points.AddXY("", 80.125454);
            this.chart1.Series["Series7"].Points.AddXY("", 3);
            this.chart1.Series["Series7"].Points.AddXY("", 33.333);
            this.chart1.Series["Series7"].Points.AddXY("", 13.5554);
            this.chart1.Series["Series7"].Points.AddXY("", 23.111);

            this.chart1.Series["Series8"].Points.AddXY("", 80.125454);
            this.chart1.Series["Series8"].Points.AddXY("", 3);
            this.chart1.Series["Series8"].Points.AddXY("", 33.333);
            this.chart1.Series["Series8"].Points.AddXY("", 13.5554);
            this.chart1.Series["Series8"].Points.AddXY("", 23.111);
            this.chart1.Series["Series8"].Points.AddXY("", 33.3218);
            this.chart1.Series["Series8"].Points.AddXY("", 3.3251);
            this.chart1.Series["Series8"].Points.AddXY("", 31.15486);
            this.chart1.Series["Series8"].Points.AddXY("", 13.15843);
            this.chart1.Series["Series8"].Points.AddXY("", 23.15483);

            this.chart1.Series["Series9"].Points.AddXY("", 55);
            this.chart1.Series["Series9"].Points.AddXY("", 35.44);
            this.chart1.Series["Series9"].Points.AddXY("", 31.66);
            this.chart1.Series["Series9"].Points.AddXY("", 13.77);
            this.chart1.Series["Series9"].Points.AddXY("", 23.1514);
            this.chart1.Series["Series9"].Points.AddXY("", 39);
            this.chart1.Series["Series9"].Points.AddXY("", 9);
            this.chart1.Series["Series9"].Points.AddXY("", 8);
            this.chart1.Series["Series9"].Points.AddXY("", 7.2222);
            this.chart1.Series["Series9"].Points.AddXY("", 23);

            this.chart1.Series["Series10"].Points.AddXY("", 33.3218);
            this.chart1.Series["Series10"].Points.AddXY("", 3.3251);
            this.chart1.Series["Series10"].Points.AddXY("", 31.15486);
            this.chart1.Series["Series10"].Points.AddXY("", 13.15843);
            this.chart1.Series["Series10"].Points.AddXY("", 23.15483);
            this.chart1.Series["Series10"].Points.AddXY("", 55);
            this.chart1.Series["Series10"].Points.AddXY("", 35.44);
            this.chart1.Series["Series10"].Points.AddXY("", 31.66);
            this.chart1.Series["Series10"].Points.AddXY("", 13.77);
            this.chart1.Series["Series10"].Points.AddXY("", 23.1514); */


            chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chart1.BackColor = Color.Silver;
            chart1.BackSecondaryColor = Color.WhiteSmoke;

            //Set Border Skin;  
            chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;

            //Set chartArea1 color;  
            chart1.ChartAreas["ChartArea1"].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chart1.ChartAreas["ChartArea1"].BackColor = Color.LightGray;
            chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.White;
            chart1.ChartAreas["ChartArea1"].BorderColor = Color.Black;
            chart1.ChartAreas["ChartArea1"].BorderWidth = 5;
            chart1.ChartAreas["ChartArea1"].ShadowOffset = 4;

            //Set Axix X and Y;  
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "DataSample";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 14, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Black;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisX.LineColor = System.Drawing.Color.LightGray;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Histogram";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 14, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Black;
            chart1.ChartAreas["ChartArea1"].AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.LineColor = System.Drawing.Color.Gray;
            chart1.ChartAreas["ChartArea1"].AxisX.IsInterlaced = true;
            chart1.ChartAreas["ChartArea1"].AxisX.InterlacedColor = Color.FromArgb(250, Color.LightGray);
            //Set control series :  
            chart1.Series["Series1"].ChartArea = "ChartArea1";
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            chart1.Series["Series1"].BorderColor = Color.Gray;
            chart1.Series["Series1"].BorderWidth = 1;
            chart1.Series["Series1"].MarkerBorderColor = Color.Black;
            chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Auto;
            chart1.Series["Series1"]["HistogramUpColor"] = "Green";
            chart1.Series["Series1"]["HistogramDownColor"] = "Red";
            chart1.Series["Series1"]["PointWidth"] = "0.4";
            chart1.Series["Series1"].Color = Color.Black;
        } 

    }
    }
