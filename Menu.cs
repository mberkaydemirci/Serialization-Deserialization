using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nesne2
{
    class Menu
    {

        public static void MenuSec()
        {
            Dosya dosya = new Dosya();
            int kontrol;
            bool hata = false;
            bool exit = false;
            while (!exit)  //2.seçeneği seçebilmemiz için gereken döngü
            {
                Console.WriteLine("1.Dosyayı Aç, oku ve serileştir");
                Console.WriteLine("2.Deserileştir ve ekrana yazdır");
                kontrol = Convert.ToInt32(Console.ReadLine());
                if (kontrol == 1)
            {
                dosya.DosyaOkuma();
                hata = true;
            }
            else if(kontrol == 2)
            {
                    try
                    {
                        if (hata == false)
                        {
                            throw new ArithmeticException("1.Seçeneği seçmeden 2.Seçeneği Seçemezsiniz !!!!!"); //hata olduğunu tanımladım
                        }
                        else
                        {
                            Deserialzation.Deserilestir();
                            exit = true;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message); //hata mesajı
                    }
            }

            }
        }
    }
}
