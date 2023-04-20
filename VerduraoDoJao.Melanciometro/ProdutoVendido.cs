using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{
    internal class ProdutoVendido
    {
        public double quantVendida;
        public double valorVendido;
        public double lucroObtido;
        public int diaDaSemana;
        public ProdutoVendido(Produto produto,double quantVendida, int diaDaSemana)
        {
            var preco = Promocao.AplicaPromacao(produto, diaDaSemana);
            var custo = produto.Custo;
            this.valorVendido = quantVendida * preco;
            this.quantVendida = quantVendida;
            this.lucroObtido = quantVendida * (preco - custo);
            this.diaDaSemana = diaDaSemana;
        }
    }
}
