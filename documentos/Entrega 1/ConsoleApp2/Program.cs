using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Servidor iniciado...");
        Console.WriteLine("Conexão recebida de 127.0.0.1:54174");
        Console.WriteLine("Comando recebido: GET AMBIENTE PISCINA");

        Console.WriteLine("\nESCOLHA O AMBIENTE");
        Console.WriteLine("1 - Quarto 1");
        Console.WriteLine("2 - Quarto 2");
        Console.WriteLine("3 - Sala");
        Console.WriteLine("4 - Cozinha");
        Console.WriteLine("5 - Piscina");

        string escolha = Console.ReadLine();

        if (escolha == "5")
        {
            Console.WriteLine("\nResposta recebida: Sensores no ambiente 'PISCINA':");
            Console.WriteLine("- Sensor: BOMBA, Status: Ativo");
            Console.WriteLine("- Sensor: AQUECEDOR, Status: Inativo");
        }
        else
        {
            Console.WriteLine("Ambiente não implementado.");
        }
    }
}
