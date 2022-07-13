using System.Net;
using System.Net.Sockets;
using System.Text;

public class clienteCSharp
{
    static void Main(string[] args)
    {
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        var connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
        socket.Connect(connect);
        var data = "";
        while(data != "Chau")
        {
            var enviar_info = new byte[100];
            byte[] recibir_info = new byte[100];
            int array_size = 0;

            Console.WriteLine("Cliente:");

            data = Console.ReadLine();

            enviar_info = Encoding.Default.GetBytes(data);

            socket.Send(enviar_info);

            array_size = socket.Receive(recibir_info,0, recibir_info.Length, 0);
            Array.Resize(ref recibir_info, array_size);
            var mensajeServidor = Encoding.Default.GetString(recibir_info);
            Console.WriteLine("Servidor: {0}", mensajeServidor);
        }
    }
}