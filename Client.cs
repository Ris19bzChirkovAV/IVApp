using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;



    public class Client
    {
        static TcpClient client;

        public Client(int port, string connectIp)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Parse(connectIp), port);
        }

        public void begin()
        {
            Thread clientListener = new Thread(Reader);
            clientListener.Start();
        }

        public void sendMsg(string msg)
        {
            msg.Trim();
            byte[] Buffer = Encoding.ASCII.GetBytes((msg).ToCharArray());
            client.GetStream().Write(Buffer, 0, Buffer.Length);
            Chat.message.Add(msg);
        }

        static void Reader()
        {
            while(true)
            {
                NetworkStream NS = client.GetStream();
                List<byte> Buffer = new List<byte>();
                while(NS.DataAvailable)
                {
                    int ReadByte = NS.ReadByte();
                    if(ReadByte > -1)
                    {
                        Buffer.Add((byte)ReadByte);
                    }
                }
            if (Buffer.Count > 0)
               Chat.message.Add(Encoding.ASCII.GetString(Buffer.ToArray()));
            }
        }

        ~Client()
        {
            if (client != null)
            {
                client.Close();
            }
        }



    }

