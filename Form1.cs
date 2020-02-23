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

namespace Proyecto
{
    public partial class Form1 : Form
    {
        private Menu menu;
        private Dictionary<string, double> Alimentos;
        Carrito carrito = new Carrito();
        private string directorio;
        public Form1()
        {
            InitializeComponent();
            menu = new Menu();
            Alimentos = new Dictionary<string, double>();
            directorio = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
        }

        private void toolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Entradas";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\entradas.jpg");
            Alimentos = menu.Datos("E", "A");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Antojos";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\antojos.jpg");
            Alimentos = menu.Datos("A", "DT");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void tradicionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Desayunos";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\desayunos.jpg");
            Alimentos = menu.Datos("DT", "DV");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Desayunos";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\desayunosv.jpg");
            Alimentos = menu.Datos("DV", "P");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void pastaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Pastas";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\pasta.jpg");
            Alimentos = menu.Datos("P", "FC");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Carnes";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\Carnes.jpg");
            Alimentos = menu.Datos("FC", "FV");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Veganos";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\veganismo.jpg");
            Alimentos = menu.Datos("FV", "Po");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Postres";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\postres.jpg");
            Alimentos = menu.Datos("Po", "B");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Tragos";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\bebidasA.jpg");
            Alimentos = menu.Datos("BA", "Fin");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Aguas";
            pictureBox1.Image = Image.FromFile(directorio + "\\Imagenes\\bebidas.jpg");
            Alimentos = menu.Datos("B", "BA");
            for (int i = 0; i < Alimentos.Keys.Count - 1; i++)
                comboBox1.Items.Add(Alimentos.ElementAt(i).Key);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                carrito.Producto.Add(comboBox1.SelectedItem.ToString());
                carrito.Precio.Add(Alimentos[comboBox1.SelectedItem.ToString()]);
                listBox1.Items.Add(String.Format("{0}: {1:c}", comboBox1.SelectedItem.ToString(), Alimentos[comboBox1.SelectedItem.ToString()]));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar algun alimento");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(String.Format("El precio a pagar es: {0:c}", carrito.Calcular_Precio()));
            string usuario = Environment.UserName;
            String pedido = carrito.ToString() + String.Format("El precio a pagar es: {0:c}", carrito.Calcular_Precio());
            File.WriteAllText("C:\\Users\\" + usuario + "\\Documents" + "\\Pedido.txt", pedido);
            MessageBox.Show("Gracias por su pedido\nVuelva Pronto!");
            listBox1.Items.Clear();
            carrito.Precio.Clear();
            carrito.Producto.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(carrito.Producto, carrito.Precio);
            form3.Show();
            carrito.Producto = form3.Actualiza_Arcticulos();
            carrito.Precio = form3.Actualiza_Precios();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
