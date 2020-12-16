using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Beadando_sp2p8b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadMovies();
            LoadChart(); 

            dataGridView1.DataSource = _movies;

            Ball b = new Ball();
            panel1.Controls.Add(b);


        }

        private List<Movie> _movies = new List<Movie>();
        private List<Movie> _movieschart = new List<Movie>();
        private List<Ball> _balls = new List<Ball>();

        private void LoadMovies()
        {
            _movies.Clear();
            using (StreamReader sr = new StreamReader("Movies.csv", Encoding.Default))
            {
                sr.ReadLine(); // Remove headers
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');

                    Movie s = new Movie();
                    s.ID = Convert.ToInt32(line[1]);
                    s.Title = line[2];
                    s.Year = Convert.ToInt32(line[3]);
                    s.Age = line[4];
                    s.IMDB = Convert.ToDouble(line[5]);
                    s.Genres = line[13];
                    s.Language = line[15];
                    s.Duration = Convert.ToDouble(line[16]);
                    _movies.Add(s);
                }
            }
        }

        private void LoadChart()
        {

            _movieschart.Clear();
            using (StreamReader src = new StreamReader("Movies.csv", Encoding.Default))
            {
                src.ReadLine(); // Remove headers
                while (!src.EndOfStream)
                {
                    string[] line = src.ReadLine().Split(';');

                    Movie e = new Movie();
                    e.Title = line[2];
                    e.IMDB = Convert.ToDouble(line[5]);
                    _movieschart.Add(e);
                }
            }

            chart1.DataSource = _movieschart;
            Chart();
        }

        private void RefreshData()
        {
            var adatok = from x in _movies
                         where x.Genres == comboBox1.SelectedItem.ToString() && x.Year == numericUpDown1.Value
                         select new
                         {
                             Title = x.Title,
                             Age = x.Age,
                             Language = x.Language,
                             Duration = x.Duration,
                         };

            var adatokchart = from x in _movies
                         where x.Genres == comboBox1.SelectedItem.ToString()  && x.Year == numericUpDown1.Value
                              select new
                         {
                             Title = x.Title,
                             IMDB = x.IMDB,
                         };


            dataGridView1.DataSource = adatok.ToList();

            chart1.DataSource = adatokchart.ToList();
            Chart();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void Chart()
        {
            var series = chart1.Series[0];
            series.ChartType = SeriesChartType.Column;
            series.XValueMember = "Title";
            series.YValueMembers = "IMDB";
            series.BorderWidth = 2;

            var legend = chart1.Legends[0];
            legend.Enabled = false;

            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

 
    }
}
