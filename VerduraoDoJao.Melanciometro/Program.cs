using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VerduraoDoJao.Melanciometro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,string>> caminhoes = new Dictionary<string, Dictionary<string, string>>();
            const double precoNormal = 5.5 ,  precoBaby = 8.56;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"1 - Registrar caminhão \n" +
                                  $"2 - Deletar caminhão \n" +
                                  $"3 - Ver registro de caminhão por placa \n" +
                                  $"4 - Ver registro por CPF/CNPJ \n" +
                                  $"5 - Sair");
                                
                var option = Console.ReadLine();                    
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Escreva a placa do caminhão");
                        string placa = Console.ReadLine();
                        Console.WriteLine("Escreva o cpf ou cnpj do  Proprietário"); 
                        string id  = Console.ReadLine();
                        Console.WriteLine("Escreva quantas Kg de melâncias normal?");
                        int numMelancia = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escreva quantos Kg de melância Baby?");
                        int numMelanciaBaby = int.Parse(Console.ReadLine());
                        if (!caminhoes.ContainsKey(placa))
                        {
                            caminhoes.Add(placa, new Dictionary<string, string>());
                            caminhoes[placa].Add("Melancia Normal", (numMelancia * precoNormal).ToString());
                            caminhoes[placa].Add("Melancia Baby", (numMelanciaBaby * precoBaby).ToString());
                            caminhoes[placa].Add("id", id);
                            Console.WriteLine($"CAMINHÃO PLACA:{placa} \n " +
                                              $"PROPRIETÁRIO CPF/CNPJ:{caminhoes[placa]["id"]}\n" +
                                              $"QUANTIDADE DE MELANCIA NORMAL R$:{caminhoes[placa]["Melancia Normal"]}\n" +
                                              $"QUANTIDADE DE MELANCIA BABY R$:{caminhoes[placa]["Melancia Baby"]}");
                            Console.WriteLine("CAMINHÃO REGISTRADO");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                           Console.WriteLine("Caminhão já registrado de baixa para registrar nova carga");
                           Console.ReadLine();
                           Console.Clear();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Digite a placa do caminhão para deletar");
                        var placaADeletar = Console.ReadLine();
                        if (!caminhoes.ContainsKey(placaADeletar))
                        {
                            Console.WriteLine($"Não existe o caminhão com a placa {placaADeletar} no registro de caminhões");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else 
                        {
                            Console.WriteLine($"Você tem certeza que quer deletar o caminhão de placa {placaADeletar}. S (Sim) ou N(não)");
                            var question = Console.ReadLine();
                            if (question == "S")
                            {
                                caminhoes.Remove(placaADeletar);
                                Console.WriteLine($"Caminhão de placa {placaADeletar} deletado!");
                            }
                           
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Digite a placa do caminhão:");
                        var placaAMostrar = Console.ReadLine();
                        if(!caminhoes.ContainsKey(placaAMostrar))
                        {
                            Console.WriteLine($"Não existe caminhão com a placa {placaAMostrar} no nosso registro");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"CAMINHÃO PLACA:{placaAMostrar} \n " +
                                              $"QUANTIDADE DE MELANCIA NORMAL R$:{caminhoes[placaAMostrar]["Melancia Normal"]} \n" +
                                              $"QUANTIDADE DE MELANCIA BABY R$:{caminhoes[placaAMostrar]["Melancia Baby"]}");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Digite o CPF/CNPJ");
                            var idAProcurar = Console.ReadLine();
                            Console.WriteLine($"CAMINHÕES COM CARGAS REGISTRADAS NO CPF/CNPJ:{idAProcurar} \n");
                            double cargaNormal = 0 , cargaBaby = 0;
                            foreach(string placaCaminhao  in caminhoes.Keys.ToList())
                            {
                                if (caminhoes[placaCaminhao]["id"] == idAProcurar)
                                {
                                    Console.WriteLine($"CAMINHÃO PLACA:{placaCaminhao}\n" +
                                                      $"CARGA DE MELÂNCIA NORMAL:R${caminhoes[placaCaminhao]["Melancia Normal"]}\n" +
                                                      $"CARGA DE MELÂNCIA BABY:R${caminhoes[placaCaminhao]["Melancia Baby"]}");
                                    Console.WriteLine("\n");
                                    cargaNormal += double.Parse(caminhoes[placaCaminhao]["Melancia Normal"]);
                                    cargaBaby   += double.Parse(caminhoes[placaCaminhao]["Melancia Baby"]);
                                }
                            }
                            Console.WriteLine($"CARGA TOTAL SOBRE O CPF/CNPJ {idAProcurar}");
                            Console.WriteLine($"CARGA DE MELÂNCIA NORMAL:R${cargaNormal} ");
                            Console.WriteLine($"CARGA DE MELÂNCIA BABY:R${cargaBaby}");
                            Console.ReadLine();
                            Console.Clear();

                        break;

                        case "5":
                            Console.Clear();
                            Console.WriteLine("Você tem certeza que deseja sair? 'S' para sim ou qualquer outra tecla para não");
                            var opcaoSair = Console.ReadLine();
                            if ( opcaoSair == "S")
                            {
                            Environment.Exit(0);
                            }
                            
                        break;

                }
                


            }
        }
    }   
}
