using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace Nesne2
{  
    [Serializable]
    class Serialzation
    {
        public string  enfazlagecensozcuk,a,b,c;
        public int sayisi, toplamsozcukadedi, toplamcumleadedi;
        public Serialzation(string a,int toplamsozcukadedi,string b,int toplamcumleadedi,string c,string enfazlagecensozcuk,int sayisi)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.toplamsozcukadedi = toplamsozcukadedi;
            this.toplamcumleadedi = toplamcumleadedi;
            this.enfazlagecensozcuk = enfazlagecensozcuk;
            this.sayisi = sayisi;
        }
        public void Serilestirme()
        {
            try { 
            Serialzation serilestirme = new Serialzation(a,toplamsozcukadedi,b,toplamcumleadedi,c,enfazlagecensozcuk, sayisi); //obje oluşturdum serileştirmek için
            FileStream stream = new FileStream("Odev2.binary", FileMode.Create,FileAccess.Write,FileShare.None); //dosyayı açtım
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(stream, serilestirme);
            Console.WriteLine("\nSerileştirildi");
            stream.Close();
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
