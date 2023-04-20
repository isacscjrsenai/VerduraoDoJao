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
        private Dictionary<object, object> produtos;
        public Dictionary<object, object> Produtos { set; get; }
        public Carga(int id) { }
    }
}
