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

namespace Beadando_sp2p8b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadMovies();

            dataGridView1.DataSource = _movies;

        }

        private List<Movie> _movies = new List<Movie>();

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
                    s.Netflix = Convert.ToInt32(line[7]);
                    s.Hulu = Convert.ToInt32(line[8]);
                    s.Prime = Convert.ToInt32(line[9]);
                    s.Disney = Convert.ToInt32(line[10]);
                    s.Genres = line[13];
                    s.Language = line[15];
                    s.Duration = Convert.ToDouble(line[16]);
                    _movies.Add(s);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
