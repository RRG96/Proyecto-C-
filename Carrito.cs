using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class Carrito
    {
        public List<string> Producto { get; set; }
        public List<double> Precio { get; set; }
        public Carrito()
        {
            Producto = new List<string>();
            Precio = new List<double>();
        }
        public double Calcular_Precio()
        {
            double costo_total = 0;
            foreach (double p in Precio)
                costo_total += p;
            return costo_total;
        }
        public override string ToString()
        {
            string pedido = "";
            for (int i = 0; i < Producto.Count; i++)
                pedido += String.Format("{0} : {1:c} \n", Producto[i], Precio[i]);
            return pedido;
        }
    }
}
