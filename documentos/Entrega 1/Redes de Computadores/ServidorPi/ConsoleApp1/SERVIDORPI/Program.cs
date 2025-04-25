using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Servidor
{
    static void Main()
    {
        int porta = 5000;
        TcpListener servidor = new TcpListener(IPAddress.Any, porta);
        servidor.Start();
        Console.WriteLine("Servidor iniciado na porta " + porta);

        while (true)
        {
            Console.WriteLine("Aguardando conexão...");
            TcpClient cliente = servidor.AcceptTcpClient();
            NetworkStream stream = cliente.GetStream();
            Console.WriteLine("conectou");

            // Recebe o comando do cliente
            byte[] buffer = new byte[1024];
            int bytesLidos = stream.Read(buffer, 0, buffer.Length);
            string mensagemRecebida = Encoding.ASCII.GetString(buffer, 0, bytesLidos).Trim();
            Console.WriteLine(mensagemRecebida);
            // Tenta converter o comando para inteiro (ID)
            if (int.TryParse(mensagemRecebida, out int idSensor))
            {
                string resposta = "";
                double consumo = 0;

                switch (idSensor)
                {
                    case 1:
                    case 2:
                        consumo = 1.5;
                        resposta = $"Sensor {idSensor} ligado. Consumo gerado: {consumo} KWh.";
                        break;
                    case 3:
                        consumo = 0.05;
                        resposta = $"Sensor {idSensor} ligado. Consumo gerado: {consumo} KWh.";
                        break;
                    case 4:
                        consumo = 3;
                        resposta = $"Sensor {idSensor} ligado. Consumo gerado: {consumo} KWh.";
                        break;
                    case 5:
                        consumo = 7;
                        resposta = $"Sensor {idSensor} ligado. Consumo gerado: {consumo} KWh.";
                        break;
                    default:
                        resposta = "ID inválido.";
                        break;
                }

                // Envia a resposta ao cliente
                byte[] respostaBytes = Encoding.ASCII.GetBytes(resposta);
                stream.Write(respostaBytes, 0, respostaBytes.Length);
            }
            else
            {
                string resposta = "Comando inválido.";
                byte[] respostaBytes = Encoding.ASCII.GetBytes(resposta);
                stream.Write(respostaBytes, 0, respostaBytes.Length);
            }

            stream.Close();
            cliente.Close();
        }
    }
}
