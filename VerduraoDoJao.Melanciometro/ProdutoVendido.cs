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
        public double QuantVendida { get; set; }
        public double ValorVendido { get; set; }
        public double LucroObtido { get; set; }
        public int DiaDaSemana { get; set; }
        public string DescPromocao { get; set; }
        public ProdutoVendido(Produto produto,double quantVendida, int diaDaSemana)
        {
            var promocao = Promocao.AplicaPromocao(produto, diaDaSemana);
            double preco = double.Parse(promocao[0]);
            double custo = produto.Custo;
            ValorVendido = quantVendida * preco;
            QuantVendida = quantVendida;
            LucroObtido = quantVendida * (preco - custo);
            DiaDaSemana = diaDaSemana;
            DescPromocao = promocao[1];
        }
    }
}
