using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nesne2
{
    class Deserialzation
    {
        public static void Deserilestir()
        {
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                FileStream deserilestirme = new FileStream("Odev2.binary", FileMode.Open, FileAccess.Read, FileShare.None);
                Serialzation serilestirme = (Serialzation)format.Deserialize(deserilestirme); //deserileştirme yapıyorum yazdırabilmek için
                Console.WriteLine("Deserileştirildi");
                Console.Write(serilestirme.a + serilestirme.toplamsozcukadedi);
                Console.Write(serilestirme.b + serilestirme.toplamcumleadedi);
                Console.Write(serilestirme.c + serilestirme.enfazlagecensozcuk + "," + serilestirme.sayisi);
                deserilestirme.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DriveNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
