using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class Menu
    {
        List<string> Comida { get; set; }
        List<double> Precio { get; set; }
        Random p = new Random();
        public Menu()
        {
            Precio = new List<double>();
            Comida = new List<string>{ "E", "Papas a la Francesa", "Guacamole", "Mini Sopes", "A", "Alitas", "Hamburguesas", "HotDogs", "DT",
            "Huevos Rancheros", "Omelet", "Huevos con Jamón", "DV","Tiramisu Vegano", "Omelet de Setas", "P", "Pasta al Pesto", "Pasta Bolognesa",
            "FC","Arrachera", "Tomahawk" , "Picanha", "FV", "Tinga de Setas", "Arrachera de Soya", "Sopa de Verdutras", "Po", "Flan", "Pastel de Chocolate",
            "B", "Sprite", "Agua de Horchata", "CocaCola", "BA", "Vino Caliente", "Cerveza", "Sake", "Fin"};
            for (int i = 0; i < Comida.Count; i++)
                Precio.Add(p.NextDouble());
        }
        public Dictionary<string, double> Datos(string inicio, string final)
        {
            Dictionary<string, double> regreso = new Dictionary<string, double>();
            for (int i = 0; i < Comida.Count; i++)
            {
                if (Comida[i].Equals(inicio))
                {
                    do
                    {
                        i++;
                        regreso.Add(Comida[i], Precio[i]);
                    } while (!Comida[i].Equals(final));
                }
            }
            return regreso;
        }
    }
}
