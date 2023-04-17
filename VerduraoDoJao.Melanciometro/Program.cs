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
            Dictionary<string, double[]> caminhoes = new Dictionary<string, double[]>();
            const double precoNormal = 5.5;
            const double precoBaby = 8.56;
            while (true)
            {
                Console.WriteLine("Escreva a placa do caminhão");
                string placa = Console.ReadLine();
                Console.Write("Escreva quantas Kg de melâncias normal?");
                int numMelancia = int.Parse(Console.ReadLine());
                Console.WriteLine("Escreva quantos Kg de melância Baby?");
                int numMelanciaBaby = int.Parse(Console.ReadLine());
                if (!caminhoes.ContainsKey(placa)){
                    caminhoes.Add(placa, new double[] { precoNormal * numMelancia, precoBaby * numMelanciaBaby });
                    Console.WriteLine($"CAMINHÃO PLACA:{placa} \n " +
                                      $"QUANTIDADE DE MELANCIA NORMAL R$:{caminhoes[placa][0]} \n" +
                                      $"QUANTIDADE DE MELANCIA BABY R$:{caminhoes[placa][1]}");
                    Console.WriteLine("CAMINHÃO REGISTRADO");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Caminhão já registrado de baixa para registrar nova carga");
                }


            }
        }
    }   
}
