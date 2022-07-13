using System.Net;
using System.Net.Sockets;
using System.Text;

public class servidorCSharp
{
    static void Main(string[] args)
    {
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

        socket.Bind(connect);
        socket.Listen(10);
        Console.WriteLine("Servidor Conectado");

        var conexion = socket.Accept();
        Console.WriteLine("Conexión aceptada");

        while(true)
        {
            byte[] recibir_info = new byte[100];
            var enviar_info = new byte[100];
            int array_size = 0;

            array_size = conexion.Receive(recibir_info,0, recibir_info.Length, 0);
            Array.Resize(ref recibir_info, array_size);
            var data = Encoding.Default.GetString(recibir_info);

            Console.WriteLine("Cliente: {0}", data);
            Console.WriteLine("Servidor:");

            var mensajeServidorParaCliente = Console.ReadLine();

            enviar_info = Encoding.Default.GetBytes(mensajeServidorParaCliente);

            conexion.Send(enviar_info);
        }
    }
}