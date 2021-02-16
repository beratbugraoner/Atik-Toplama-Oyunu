using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1
{
    class Atik : IAtik
    {
        public int Hacim { get; set; }

        public string Isim { get; set; }
        public Image Image { get; set; }
       
        public Atik(int hacim,  Image image , string isim) // gelen parametreleri atıyoruz.
        {
            Hacim = hacim;
            Isim = isim;
            Image = image;
            
        }
    }
}
