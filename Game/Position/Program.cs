using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace Position
{
    [Serializable]
    public class Position
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Position(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
        }

        // Els mètodes Serialize i Deserialize ens permeten passar a binari o a objecte (depenent del que volem fer) la informació de Position
        public static byte[] Serialize(object obj)
        {
            byte[] bytesPos;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                bytesPos = ms.ToArray();
            }

            return bytesPos;
        }

        public static object Deserialize(byte[] param)
        {
            object obj = null;
            using (MemoryStream ms = new MemoryStream(param))
            {
                IFormatter br = new BinaryFormatter();
                obj = (br.Deserialize(ms));
            }

            return obj;
        }
    }
}
