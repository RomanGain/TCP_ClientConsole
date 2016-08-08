using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace TCP_ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
                try
                {
                    SendMessages();
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("Connection error:\n" + ex.ToString());
                }
                catch (System.IO.IOException io)
                {
                    Console.WriteLine("IOException:\n" + io.ToString());
                }
                finally
                {
                    Console.ReadKey();
                    //client.Close();
                }
        }


        static void SendMessages()
        {
            
            //str = Console.ReadLine();

            //Console.WriteLine("You : " + str);
            //Console.WriteLine("Connection :" + client.Connected);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("CLIENT");
                TcpClient client = new TcpClient();

                NetworkStream ns;
                client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));

                string str;
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                Console.WriteLine("i= " + i);
                str = i.ToString();
                System.Threading.Thread.Sleep(1000);
                sw.WriteLine(str);
            }


            //sw.WriteLine(str);

            //StreamReader sr = new StreamReader(client.GetStream());
            //Console.WriteLine("Companion : " + sr.ReadLine());

            //Console.WriteLine("Client : Пока");
            //sw.WriteLine("Пока");
            //Console.WriteLine("Server : " + sr.ReadLine());
        }

        static void count()
        {
            for (int i = 0; i<50; i++)
            {
                Console.WriteLine("i= " + i);
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadLine();
        }

    }
}
