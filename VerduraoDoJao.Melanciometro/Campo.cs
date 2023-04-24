using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VerduraoDoJao.Melanciometro
{
    
    internal class Campo
    {
        public static Dictionary<string, Campo> campos = new Dictionary<string, Campo>();
        private string Pergunta;
        private string Tipo;
        public string Resposta;
        public Campo(string pergunta, string tipo) 
        {
            Pergunta = pergunta.Trim();
            Tipo = tipo;
        }
        public Campo(string pergunta, string tipo, string nome)
        {
            Pergunta = pergunta.Trim();
            Tipo = tipo;
            this.RegistraCampo(nome);
        }
        public bool Valido(string resposta)
        {
            if (resposta == null) return false;
            switch (this.Tipo)
            {
                case "Placa":
                    string placaMercosulPattern = "^[A-Z]{3}[0-9][0-9A-Z][0-9]{2}$";
                    string placaAntigaPattern = "^[A-Z]{3}-[0-9]{4}$";
                    if (Regex.IsMatch(resposta, placaMercosulPattern) || Regex.IsMatch(resposta,placaAntigaPattern))
                    {
                        return true;
                    }
                    else return false;
                case "Id":
                    if (IsValidCpf(resposta) || IsValidCnpj(resposta))
                    {
                        return true;
                    }
                    else return false;
                    //break;
                case "Quantidade":
                    double result;
                    if (double.TryParse(resposta, out result))
                    {
                        if (result > 0) return true;
                    }
                    else return false;
                    break;
            }
            return true;
        }
        public void RegistraCampo(string nome)
        {
            campos[nome] = this;
        }
        public string Show()
        {
            var cursor = Console.CursorTop;
            do
            {
                var space = "";
                if (Resposta != null)
                {
                    for (var i = 0; i <= Resposta.Length; i++)
                    {
                        space += " ";
                    }
                    Console.CursorTop = cursor;
                    Console.Write(space);
                }
                else
                {
                    Console.WriteLine(this.Pergunta);
                }
                Console.CursorLeft = 0;
                Resposta = Console.ReadLine();
                cursor = Console.CursorTop -1;
                //Console.WriteLine("cursor:"+cursor);
                //Console.ReadLine();
                //Console.WriteLine(Valido(Resposta));
                //Console.ReadLine();
            } while (!Valido(Resposta));
            return this.Resposta;
        }
        public bool IsValidCpf(string CPF)
        {
            List<byte> digitosCPF = new List<byte>();
            string DigitosVerificadores;
            byte PrimeiroVerificador, SegundoVerificador;
            string cpfPattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            if (Regex.IsMatch(CPF, cpfPattern))
            {
                var cpfDividido = CPF.Split('-');
                DigitosVerificadores = cpfDividido[1];
                PrimeiroVerificador = byte.Parse(DigitosVerificadores[0].ToString());
                SegundoVerificador = byte.Parse(DigitosVerificadores[1].ToString());
                var NoveDigitos = cpfDividido[0].Split('.');
                foreach (var TresDigitos in NoveDigitos)
                {
                    foreach(var Digito in TresDigitos)
                    {
                        digitosCPF.Add(byte.Parse(Digito.ToString()));
                    }
                }
                var PrimeiroVerificadorCalculado = ((digitosCPF[0] +
                                                     digitosCPF[1] * 2 + 
                                                     digitosCPF[2] * 3 + 
                                                     digitosCPF[3] * 4 + 
                                                     digitosCPF[4] * 5 + 
                                                     digitosCPF[5] * 6 + 
                                                     digitosCPF[6] * 7 + 
                                                     digitosCPF[7] * 8 + 
                                                     digitosCPF[8] * 9) %11) % 10;

                var SegundoVerificadorCalculado =  ((digitosCPF[1] +
                                                     digitosCPF[2] * 2 +
                                                     digitosCPF[3] * 3 +
                                                     digitosCPF[4] * 4 +
                                                     digitosCPF[5] * 5 +
                                                     digitosCPF[6] * 6 +
                                                     digitosCPF[7] * 7 +
                                                     digitosCPF[8] * 8 +
                                                     PrimeiroVerificadorCalculado * 9) % 11) % 10;
                if (PrimeiroVerificadorCalculado == PrimeiroVerificador && 
                    SegundoVerificadorCalculado == SegundoVerificador)
                {
                    return true;
                }
                else return false;

            }
            else return false;
        }
        public static bool IsValidCnpj(string cnpj)
        {
            string cnpjPattern = @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$";
            if(!Regex.IsMatch(cnpj, cnpjPattern)) { return false; }

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");      

            int[] weights1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] weights2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum1 = 0;
            for (int i = 0; i < weights1.Length; i++)
            {
                sum1 += weights1[i] * int.Parse(cnpj[i].ToString());
            }

            int sum2 = sum1;
            for (int i = 0; i < weights2.Length; i++)
            {
                sum2 += weights2[i] * int.Parse(cnpj[i].ToString());
            }

            int digit1 = sum1 % 11;
            digit1 = digit1 < 2 ? 0 : 11 - digit1;

            int digit2 = sum2 % 11;
            digit2 = digit2 < 2 ? 0 : 11 - digit2;

            return int.Parse(cnpj[12].ToString()) == digit1 && int.Parse(cnpj[13].ToString()) == digit2;
        }
    }
}
