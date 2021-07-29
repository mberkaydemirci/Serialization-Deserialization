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
    class Dosya
    {
        int i=0,sayac=0,sayac2=0,sonuc=0,final;
        string satır,yenisatır;
        string[] indextekrar = new string[661];
        string a = "Metindeki toplam sözcük adedi:";
        string b = " \nMetindeki toplam sözcük adedi:" ;
        string c = " \nMetinde geçen en çok sözcük ve o sözcüğün adedi:";
        
        public static void indexyazdir(List<int> index)
        {
            foreach (int item in index)
            {
                Console.WriteLine(item);
            }
        }
        public void DosyaOkuma()
        {
            try
            {
                string dosyayolu = @"C:\Users\proxe\source\repos\Nesne2\odev2-oku.txt"; //Dosya yolunu belirledik
                FileStream fs = new FileStream(dosyayolu, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader str = new StreamReader(fs); //okumak için StreamReader oluşturduk
                List<int> index = new List<int>();
                while ((satır = str.ReadLine()) != null)
                {
                    yenisatır += satır;
                }
                yenisatır = yenisatır.ToLower(); // büyük küçük harf duyarlılığı kaldırdım
                string[] satırdizisi = yenisatır.Split(' ');  //tekrar sayılarını bulmak için diziye aktardım
                for (i = 0; i < satırdizisi.Length; i++)
                {
                    for (int j = 0; j < satırdizisi.Length; j++)
                    {
                        if (satırdizisi[i] == satırdizisi[j])
                        {
                            index.Add(i); //tekrar sayılarını liste kaydettim
                        }
                    }
                }

                string[] toplamsozcukadedi = yenisatır.Split(' ');
                char[] ayrac = { '.', '!' }; //cümle ., ! ile biter
                string[] toplamcumleadedi = yenisatır.Split(ayrac);
                toplamcumleadedi = toplamcumleadedi.Take(toplamcumleadedi.Count() - 1).ToArray(); //toplamcümleadedinde ekstradan 1 tane boş elaman
                for (i = 0; i < 661; i++)                                                          //ekliyor bu yüzden son elemanını siliyorum
                {                                                                                 //sebebini çözemedim ben de
                    indextekrar[i] = Convert.ToString(i); //kelime sayısı kadar dizi oluşturup içine sayıları atadım ki eşitlemem kolay olsun diye
                }
                for (i = 0; i < indextekrar.Length; i++)
                {
                    for (int j = 0; j < index.Count; j++)
                    {
                        if (Convert.ToInt32(indextekrar[i]) == index[j])
                        {
                            sayac++;
                            sayac2 = sayac;
                        }
                        if (sayac2 > sonuc)
                        {
                            sonuc = sayac2;
                            final = i;              //kurulan iki döngü sonucu hangi kelimenin maksimum sayıda tekrar ettiğini buldum
                        }

                    }
                    sayac = 0;
                }
                fs.Close();
                Serialzation serilestirme = new Serialzation(a, toplamsozcukadedi.Length, b, toplamcumleadedi.Length-3, c, toplamsozcukadedi[final], sonuc);
                serilestirme.Serilestirme(); //serileştirme fonk çağırıyorum
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
