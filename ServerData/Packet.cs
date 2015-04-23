using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace VirtualClassroom
{
    [Serializable]
    public class Packet
    {
        //тип пакета данных
        public PacketType packetType;
        public List<String> message;
        public Object user;
        public Object student;

        public Packet(Object user, Object student, PacketType packetType)
        {
            this.user = user;
            this.student = student;
            this.packetType = packetType;
            this.ToBytes();
        }

        public Packet(byte[] bytes)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(bytes);

            Packet p = (Packet)formatter.Deserialize(ms);
            this.packetType = p.packetType;

        }
        public byte[] ToBytes()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, this);
            byte[] bytes = ms.ToArray();
            ms.Close();

            return bytes;
        }

        public static string GetIP4Address()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress i in ips)
            {
                if (i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return i.ToString();
            }
            return "127.0.0.1";
        }

        public enum PacketType
        {
            Registration,
            Authentification,
            Message,
            PrivateMessage,
            File,
            Request
        }
    }
}
