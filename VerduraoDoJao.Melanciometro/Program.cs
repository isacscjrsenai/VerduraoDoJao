using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{
    internal class Program
    {
        static void Main()
        {
            //Splash.Show();
            //Login.Logar();
            Menu.CriaMenuPrincipal();
            Menu.CriaMenuSemana();
            new Produto("Melância Normal", 5.50, 2.5);
            new Produto("Melância Baby", 8.56, 4.5);

            while (true)
            {
                Menu.Menus["Principal"].ShowSelectable();           
            }
        }
        
        internal static void RegistraCaminhao()
        {
            
            Console.Clear();
            string placa = new Campo("Escreva a placa do caminhão", "Placa","Placa").Show();
            string id = new Campo("Escreva o CPF ou CNPJ do Proprietário", "Id", "Id").Show();
            new Caminhao(placa, id);
            Menu.CriaMenuSemana();
            int diaDaSemana = (int)Menu.Menus["Semana"].ShowSelectable();
            Menu MenuVenda = ConstroiMenuVenda(placa, diaDaSemana);
            bool vendaFechada;
            do
            {
                vendaFechada = (bool)MenuVenda.ShowSelectable();
            } while (vendaFechada != true);
            
            do
            {
                do
                {
                    Console.Clear();
                    //menu
                    numMenu = 1;
                    opMenu = 0;
                    foreach (var prod in Produto.produtos)
                    {
                        Console.WriteLine($"{numMenu} - {prod.Nome} - R$ {prod.Preco}");
                        numMenu++;
                    }
                    Console.WriteLine($"{numMenu} - Fechar Venda");
                    Console.WriteLine("Digite a opção de produto para adicionar");
                    try
                    {
                        opMenu = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        //TODO Tratar exceção como o tipo correto de exceção
                        Console.WriteLine("Comando inválido");
                        Console.ReadLine();
                        opMenu = numMenu + 1;
                    }
                } while (opMenu > numMenu);
                
                //fim menu
                if (opMenu == numMenu)
                {
                    break;
                }
                var produto = Produto.produtos[opMenu - 1];
                idDaVenda = Caminhao.caminhoes[placa].CriaCarga();
                
                //Quantidade de produto
                double quantProduto = 0;
                quantProduto = double.Parse(new Campo($"Digite a quantidade de {produto.Nome} em Kg:","Quantidade").Show());                
                Console.WriteLine($"Digite o dia da semana:\n 1 - Segunda\n 2 - Terça-Feira\n 3 - Quarta-Feira\n 4 - Quinta-Feira\n 5 - Sexta-Feira");
                int diaDaSemana = int.Parse(Console.ReadLine());
                Caminhao.caminhoes[placa].AdicionaCarga(produto, diaDaSemana, quantProduto, idDaVenda);
            
            } while (opMenu != numMenu);
            ImprimiCaminhao(placa);
            Console.ReadLine();

        }
        internal static void DeletaCaminhao()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do Caminhão para Deletar");
            var placaADeletar = Console.ReadLine();
            if (Caminhao.caminhoes.ContainsKey(placaADeletar))
            {
               Caminhao.caminhoes.Remove(placaADeletar);
               Console.WriteLine("CAMINHÃO DELETADO");
               Console.ReadLine();
            }
            else 
            {
                Console.WriteLine($"Não existe o caminhão com a placa {placaADeletar} na base de dados");
                Console.ReadLine();
            }
            
        }
        internal static void ProcuraCaminhao()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do caminhão");
            var placaAProcurar = Console.ReadLine();
            if (Caminhao.caminhoes.ContainsKey(placaAProcurar))
            {
                ImprimiCaminhao(placaAProcurar);
            }
            else
            {
                Console.WriteLine($"Não existe o caminhão com a placa {placaAProcurar} na base de dados");
            }
            Console.ReadLine();
        }
        internal static void ProcuraId()
        {
            Console.Clear();
            Console.WriteLine("Digite o CPF/CNPJ");
            var id = Console.ReadLine();
            Console.WriteLine($"CAMINHÕES REGISTRADOS SOBRE O CPF/CNPJ:{id}");
            foreach (var caminhao in Caminhao.caminhoes)
            {
                if(caminhao.Value.Proprietario == id)
                {
                    ImprimiCaminhao(caminhao.Value.Placa);
                }
            }
            Console.ReadLine ();
        }
        internal static void RegistraProduto()
        {
            Console.Clear();
            Console.WriteLine("ADICIONAR UM PRODUTO");
            Console.WriteLine("Digite o nome do produto:");
            var nomeProduto = Console.ReadLine();
            nomeProduto = nomeProduto.Trim();
            var JaTaRegistrado = Produto.produtos.Any(x => x.Nome == nomeProduto);
            if (JaTaRegistrado)
            {
                Console.WriteLine("O produto já existe");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            double precoProduto =0, custoProduto = 0;
            do
            {
                if (custoProduto != 0 && precoProduto != 0 && custoProduto >= precoProduto)
                {
                    Console.WriteLine("O preço não é maior que o custo");
                }
                Console.WriteLine("Digite o preço do produto:");
                precoProduto = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite o custo do produto:");
                custoProduto = double.Parse(Console.ReadLine());
            } while (custoProduto >= precoProduto);        
            new Produto(nomeProduto,precoProduto,custoProduto);
            Console.WriteLine("PRODUTO ADICIONADO");
            Console.ReadLine();
            Console.Clear();           
        }
        internal static void DeletaProduto()
        {
            Console.Clear();
            Console.WriteLine("DELETAR UM PRODUTO");
            Console.WriteLine("Digite o nome do produto:");
            var produtoADeletar = Console.ReadLine();
            bool removido = false;
            foreach (var produto in Produto.produtos)
            {
                if (produto.Nome == produtoADeletar)
                {
                    Produto.produtos.Remove(produto);
                    removido = true;
                    break;
                }
            }
            if (removido)
            {
                Console.WriteLine("PRODUTO DELETADO");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Não existe registro de produto com o nome:{produtoADeletar}");
                Console.ReadLine();
            }
        }
        internal static void Sair()
        {
            Console.Clear();
            Console.WriteLine("Você tem certeza que deseja sair? 'S' para sim ou qualquer outra tecla para não");
            var opcaoSair = Console.ReadLine();
            if (opcaoSair == "S")
            {
                Environment.Exit(0);
            }
        }
        static void ImprimiCaminhao(string placaAProcurar)
        {
            var id = Caminhao.caminhoes[placaAProcurar].Proprietario;
            Console.WriteLine($"CAMINHÃO {placaAProcurar}");
            Console.WriteLine($"PROPRIETÁRIO CPF/CNPJ: {id}");
            Console.WriteLine("VENDAS");
            var idDasVendas = Caminhao.caminhoes[placaAProcurar].Cargas.Keys.ToList();

            foreach (var venda in idDasVendas)
            {
                Console.WriteLine($"VENDA {venda}");
                var carga = Caminhao.caminhoes[placaAProcurar].Cargas[venda].Produtos;
                double valorCarga = 0;
                foreach (var produto in carga)
                {
                    Console.WriteLine($"{produto.Key} - {produto.Value.QuantVendida} kg - R$ {produto.Value.ValorVendido} - {produto.Value.DescPromocao} ");
                    valorCarga += produto.Value.ValorVendido;
                }
                Console.WriteLine($"TOTAL DA VENDA {venda}: R${valorCarga}");
            }
            Console.WriteLine();
            
        }
        
        internal static int Semana(int dia)
        {
            return dia;
        } 

        internal static bool FechaVenda(string placa) 
        {
            ImprimiCaminhao(placa);
            return true;
        }

        internal static void RegistraVenda(Produto produto, int diaDaSemana)
        {

        }
        internal static Menu ConstroiMenuVenda(string placa, int diaDaSemana)
        {
            Menu MenuVenda = new Menu();
            MenuVenda.Caption = "Selecione o produto para adicionar";
            foreach (var produto in Produto.produtos)
            {
                var nome = produto.Nome;
                var promocao = Promocao.AplicaPromocao(produto, diaDaSemana);
                double preco = double.Parse(promocao[0]);
                var descricaoPromocao = promocao[1];
                MenuVenda.Opcoes.Add($"{nome} - R$ {preco} - {descricaoPromocao}", () => RegistraVenda(produto, diaDaSemana));
            }
            MenuVenda.Opcoes.Add("Fecha Venda", () => FechaVenda(placa));
            return MenuVenda;
        }
    }   
    

}
