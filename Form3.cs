using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form3 : Form
    {
        List<string> Articulos;
        List<double> Precios;
        public Form3(List<string> articulos, List<double> precios)
        {
            InitializeComponent();
            foreach (string articulo in articulos)
                comboBox1.Items.Add(articulo);
            Articulos = articulos;
            Precios = precios;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Articulos.Remove(comboBox1.SelectedItem.ToString());
                Precios.Remove(Precios.ElementAt(comboBox1.SelectedIndex));
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
            catch(Exception)
            {
                MessageBox.Show("Debe seleccionar un alimento");
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<string> Actualiza_Arcticulos()
        {
            return Articulos;
        }
        public List<double> Actualiza_Precios()
        {
            return Precios;
        }
    }
}
