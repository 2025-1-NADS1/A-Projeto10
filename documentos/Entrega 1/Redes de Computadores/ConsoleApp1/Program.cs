using System;
using System.Net.Sockets;
using System.Text;

class Cliente
{
    static void Main()
    {
        string ipServidor = "127.0.0.1"; // IP do servidor
        int porta = 5000; // Porta do servidor

        try
        {
                

           while (true)
             using (TcpClient cliente = new TcpClient())
                {

                    {
                        Console.WriteLine("Digite o ID do sensor para ligar (1 a 5), ou 0 para sair:");
                    string input = Console.ReadLine();
                    cliente.Connect(ipServidor, porta);
                    Console.WriteLine("Conectado ao servidor!");
                    NetworkStream stream = cliente.GetStream();

                    if (int.TryParse(input, out int sensorId))
                    {
                        if (sensorId == 0)
                        {
                            Console.WriteLine("Encerrando a conexão...");
                            break;
                        }
                        else if (sensorId >= 1 && sensorId <= 5)
                        {
                            // Envia o comando ao servidor
                            string mensagem = sensorId.ToString();
                            byte[] dados = Encoding.ASCII.GetBytes(mensagem);
                            stream.Write(dados, 0, dados.Length);

                            // Opcional: receber resposta do servidor
                            byte[] buffer = new byte[1024];
                            int bytesLidos = stream.Read(buffer, 0, buffer.Length);
                            string resposta = Encoding.ASCII.GetString(buffer, 0, bytesLidos);
                            Console.WriteLine("Resposta do servidor: " + resposta);
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira um número entre 1 e 5, ou 0 para sair.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                    }

                    stream.Close();
                    cliente.Close();
                }

               

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }
}