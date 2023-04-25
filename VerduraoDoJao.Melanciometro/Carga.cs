using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{
    internal class Carga
    {
        public int id;
        public bool fechada;
        public Dictionary<object, ProdutoVendido> Produtos { set; get; }
        public Carga(int idCarga) 
        {
            id = idCarga;
            Produtos = new Dictionary<object, ProdutoVendido>();
        }
    }
}
