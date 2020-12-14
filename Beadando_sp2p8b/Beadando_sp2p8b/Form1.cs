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
            using (StreamReader sr = new StreamReader("IMDbmovies.csv", Encoding.Default))
            {
                sr.ReadLine(); // Remove headers
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Movie s = new Movie();
                    s.Title = line[1];
                    _movies.Add(s);
                }
            }
        }
    }
}
