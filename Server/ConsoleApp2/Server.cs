using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp2
{
  public  class Server
    {
        public void ExecuteServer()
        {
            
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 110);
            Socket listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);

            try
            {

                listener.Bind(localEndPoint);
                listener.Listen(10);
                 while (true)
                {

                    Console.WriteLine("Waiting connection  ");
                    Socket clientSocket = listener.Accept();
                    byte[] bytes = new Byte[1024];
                    string data = null;
                    int numByte = clientSocket.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes,
                                       0, numByte);

                    Console.WriteLine("Text received  {0} ", data);
                    int res = Int32.Parse(data);
                    int senddata = res*res;
                    Console.WriteLine(senddata);
                    byte[] message = Encoding.ASCII.GetBytes(senddata.ToString());
                    clientSocket.Send(message);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();

                }
            }


            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
} 
    

