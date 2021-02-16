using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1
{
    class Cam : IAtikKutusu
    {
        private List<Atik> Atik { get; set; } // Atik adlı Listimiz.

        public int Kapasite { get; set; }
        public int DoluHacim { get; set; }
        public int DolulukOrani { get; set; }

        public int BosaltmaPuani { get; set; }

        public Cam() // kurucu fonksiyonumuzda değerlerin atanması
        {
            BosaltmaPuani = 600;
            Kapasite = 2200;
            Atik = new List<Atik>();

        }
        public bool Ekle(Atik atik) // Ekle methodu
        {
            if (Kapasite > atik.Hacim) //Kapasitemiz atığımızın hacmiden büyükse işlemleri yapıyoruz.
            {
                Atik.Add(atik); // Atik listimize gelen parametreli değeri ekliyoruz.
                DoluHacim += atik.Hacim; // doluhacmimizi güncelliyoruz
                double temp = Convert.ToDouble(DoluHacim) / Convert.ToDouble(Kapasite) * 100;
                DolulukOrani = Convert.ToInt32(temp); // doluluk oranını güncelledik.
                return true;
            }

            return false;
        }

        public bool Bosalt()// değişkenleri boşaltma
        {
            if (DolulukOrani >= 75)// doluluk orani 75'ten büyükse değişkenleri temizliyoruz
            {
                DoluHacim = 0;
                DolulukOrani = 0;
                BosaltmaPuani = 600;
                Atik.Clear();// Listimizi temizliyoruz.
                return true;
            }
            return false;
        }
    }
}
