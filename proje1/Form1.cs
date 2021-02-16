using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace proje1
{
    public partial class Form1 : Form
    {
        private Cam camAtik;
        private Kagit kagitAtik;
        private Organik organikAtik;
        private Metal metalAtik;
        private Atik[] atik;
        Random rnd = new Random();
        private int randomSayi;
        private int zamanlayici = 60;
       
      

        public Form1()
        {
            InitializeComponent();
            camAtik = new Cam();
            kagitAtik = new Kagit();
            organikAtik = new Organik();
            metalAtik = new Metal();
            atik = new Atik[10];
            

            

            atik[0] = new Atik(550, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\konserve.png") , "konserve");
            atik[1] = new Atik(600, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\cam_sise.jpg"),"cam sise");
            atik[2] = new Atik(150, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\domates.jpg"),"domates");
            atik[3] = new Atik(200, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\dergi.jpg"),"dergi");
            atik[4] = new Atik(350, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\cola.png"),"kola");
            atik[5] = new Atik(250, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\gazete.jpg"),"gazete");
            atik[6] = new Atik(250, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\bardak.jpg"),"bardak");
            atik[7] = new Atik(120, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\salatalık.png"),"salatalık");
            atik[8] = new Atik(0, resimPictureBox.BackgroundImage = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\images\\beyaz.png"),"boş");
            //atik adlı dizimize atık resimlerimizi ve 1 adet beyaz sayfayı atıyoruz.


        }
        private void formTemizle()
        {
            camListBox.Items.Clear(); // Listbox itemlerini temizler

            kagıtListBox.Items.Clear();  // Listbox itemlerini temizler

            organikListBox.Items.Clear(); // Listbox itemlerini temizler

            metalListBox.Items.Clear(); // Listbox itemlerini temizler

            camProgress.Value = 0; // progress barı sıfırlar

            metalProgress.Value = 0; // progress barı sıfırlar

            organikProgress.Value = 0;// progress barı sıfırlar

            kagitProgress.Value = 0;// progress barı sıfırlar

        }

        private void resim()
        {
            randomSayi = rnd.Next(0, 8); // randomSayi değişkenine random değer atayarak pictureBox'a atik dizisinin randomSayi elemanını atıyoruz.
            resimPictureBox.Image = atik[randomSayi].Image;
        }
        private void buttonAktif()
        {
            organiPanel.Enabled = true; // paneli aktifleştirme
            camPanel.Enabled = true; // paneli aktifleştirme
            kagıtPanel.Enabled = true;// paneli aktifleştirme
            metalPanel.Enabled = true;// paneli aktifleştirme
            organikBosaltButton.Enabled = true; // button aktifleştirme
            camBosaltButton.Enabled = true; // button aktifleştirme
            kagıtBosaltButton.Enabled = true; // button aktifleştirme
            metalBosaltButton.Enabled = true; // button aktifleştirme
        }

        private void buttonInaktif()
        {
            organikBosaltButton.Enabled = false; // paneli inaktifleştirme
            camBosaltButton.Enabled = false;// paneli inaktifleştirme
            kagıtBosaltButton.Enabled = false;// paneli inaktifleştirme
            metalBosaltButton.Enabled = false;// paneli inaktifleştirme
            organiPanel.Enabled = false; // paneli inaktifleştirme
            camPanel.Enabled = false;// paneli inaktifleştirme
            kagıtPanel.Enabled = false;// paneli inaktifleştirme
            metalPanel.Enabled = false;// paneli inaktifleştirme

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            organiPanel.Enabled = false; // exe dosyayı ilk çalışırken panelin inaktif gelmesi
            camPanel.Enabled = false;// exe dosyayı ilk çalışırken panelin inaktif gelmesi
            kagıtPanel.Enabled = false;// exe dosyayı ilk çalışırken panelin inaktif gelmesi
            metalPanel.Enabled = false;// exe dosyayı ilk çalışırken panelin inaktif gelmesi
            organikBosaltButton.Enabled = false; // exe dosyayı ilk çalışırken buttonun inaktif gelmesi
            camBosaltButton.Enabled = false;// exe dosyayı ilk çalışırken buttonun inaktif gelmesi
            kagıtBosaltButton.Enabled = false;// exe dosyayı ilk çalışırken buttonun inaktif gelmesi
            metalBosaltButton.Enabled = false;// exe dosyayı ilk çalışırken buttonun inaktif gelmesi

        }

        private void yeniOyunButton_Click(object sender, EventArgs e)
        {
            camAtik.Bosalt();  // Atıkların değerlerini 0'lar.
            kagitAtik.Bosalt();
            metalAtik.Bosalt();
            organikAtik.Bosalt();
            buttonAktif();
            
            puanTextBox.BackColor = Color.GreenYellow; // textboxların renklerini buttona basılınca değiştirir.
            sureTextBox.BackColor = Color.DarkTurquoise;
            sureTextBox.ForeColor = Color.GreenYellow;
            puanTextBox.Text = "0"; // ilk puanın 0 olması
            resim(); // pictureBox'a resim atama
            timer.Enabled = true; // timer başladı
            timer.Interval = 500;
            formTemizle(); //formları temizledik yeni oyuna başlarken
            

        }
        
       
        private void timer_Tick_1(object sender, EventArgs e)
        {


            if (zamanlayici == 0 ) // süre 0'sa buttonları inaktifleştirir ve form temizler
            {
                resimPictureBox.Image = atik[8].Image;
                buttonInaktif();
                timer.Enabled = false;
                sureTextBox.Text = "60";
                MessageBox.Show("Puanınız : " + puanTextBox);
                formTemizle();
            }
            else if(zamanlayici < 61) // süre 60'dan küçükse geriye doğru sayar.
            {
                zamanlayici--;
                sureTextBox.Text = zamanlayici.ToString();
            }
            else
            {
                return;
            }

           
        }

       

        private void organikBosaltButton_Click(object sender, EventArgs e) 
        {
            if (organikAtik.DolulukOrani >= 75) // Organik atıkların doluluk oranı 75'ten büyükse aktifleşir.
            {


                organikAtik.Bosalt(); // organik değerlerini temizler.
                sureTextBox.Text = Convert.ToString(Convert.ToInt32(sureTextBox.Text) + 3); // süreye 3sn ekler
                zamanlayici = Convert.ToInt32(sureTextBox.Text);
                puanTextBox.Text = Convert.ToString(Convert.ToInt32(puanTextBox.Text) + organikAtik.BosaltmaPuani); // puana boşaltmaPuanını ekler.
                organikListBox.Items.Clear();
                organikProgress.Value = organikAtik.DolulukOrani; // progress bar yenilenir.


            }
        }



        private void kagıtBosaltButton_Click(object sender, EventArgs e)
        {

            if (kagitAtik.DolulukOrani >= 75)// Kagit atıkların doluluk oranı 75'ten büyükse aktifleşir.
            {
                kagitAtik.Bosalt();// kagıt değerlerini temizler.
                sureTextBox.Text = Convert.ToString(Convert.ToInt32(sureTextBox.Text) + 3); // süreye 3sn ekler
                zamanlayici = Convert.ToInt32(sureTextBox.Text);
                puanTextBox.Text = Convert.ToString(Convert.ToInt32(puanTextBox.Text) + kagitAtik.BosaltmaPuani);// puana boşaltmaPuanını ekler.
                kagıtListBox.Items.Clear();
                kagitProgress.Value = kagitAtik.DolulukOrani; // progress bar yenilenir.


            }
        }

        private void camBosaltButton_Click(object sender, EventArgs e)
        {

            if (camAtik.DolulukOrani >= 75)// cam atıkların doluluk oranı 75'ten büyükse aktifleşir.
            {
                camAtik.Bosalt();//cam değerlerini temizler.
                sureTextBox.Text = Convert.ToString(Convert.ToInt32(sureTextBox.Text) + 3); // süreye 3sn ekler
                zamanlayici = Convert.ToInt32(sureTextBox.Text);
                puanTextBox.Text = Convert.ToString(Convert.ToInt32(puanTextBox.Text) + camAtik.BosaltmaPuani);// puana boşaltmaPuanını ekler.
                camListBox.Items.Clear();
                camProgress.Value = camAtik.DolulukOrani;// progress bar yenilenir.


            }
        }

        private void metalBosaltButton_Click(object sender, EventArgs e)
        {


            if (metalAtik.DolulukOrani >= 75)// metal atıkların doluluk oranı 75'ten büyükse aktifleşir.
            {
                metalAtik.Bosalt();//metal değerlerini temizler.
                sureTextBox.Text = Convert.ToString(Convert.ToInt32(sureTextBox.Text) + 3); // süreye 3sn ekler
                zamanlayici = Convert.ToInt32(sureTextBox.Text);
                puanTextBox.Text = Convert.ToString(Convert.ToInt32(puanTextBox.Text) + metalAtik.BosaltmaPuani);// puana boşaltmaPuanını ekler.
                metalListBox.Items.Clear();
                metalProgress.Value = metalAtik.DolulukOrani;// progress bar yenilenir.


            }
        }

        private void organikAtikButton_Click(object sender, EventArgs e)
        {
            if (randomSayi == 2 || randomSayi == 7) // dizideki 2. ve 7.eleman organik atık olduğundan koşulumuz randomSayı'ya bu değerlerin atanması.
            {
                if (organikProgress.Value > 75) // eğer progress barımız doluysa butona basamıyoruz.
                {

                }
                else // progress barımızın değeri azsa işlemleri yapıyoruz
                {

                    organikAtik.Ekle(atik[randomSayi]);  // Ekle methoduyla atik dizisinin randomSayi elemanı eklenir.
                    organikProgress.Value = organikAtik.DolulukOrani;
                    organikListBox.Items.Add(atik[randomSayi].Isim); // listboxa yazdırdık.
                    puanTextBox.Text = Convert.ToString(Convert.ToInt32(puanTextBox.Text) + atik[randomSayi].Hacim); // puanımız Atığımızın hacmi kadar yükseldi
                    randomSayi = rnd.Next(0, 8); // bir sonraki resim için random sayı atadık ve pictureboxta yeni resim atadık.
                    resimPictureBox.Image = atik[randomSayi].Image;
                }
               
            }
        }

        private void camButton_Click(object sender, EventArgs e)
        {
            if (randomSayi == 6 || randomSayi == 1)// dizideki 1. ve 6.eleman cam atık olduğundan koşulumuz randomSayı'ya bu değerlerin atanması.
            {
                if (camProgress.Value > 75)// eğer progress barımız doluysa butona basamıyoruz
                {

                }
                else// progress barımızın değeri azsa işlemleri yapıyoruz
                {

                    camAtik.Ekle(atik[randomSayi]); // Ekle methoduyla atik dizisinin randomSayi elemanı eklenir.
                    camProgress.Value = camAtik.DolulukOrani;
                    camListBox.Items.Add(atik[randomSayi].Isim);// listboxa yazdırdık.
                    puanTextBox.Text = Convert.ToString(Convert.ToInt32(puanTextBox.Text) + atik[randomSayi].Hacim);// puanımız Atığımızın hacmi kadar yükseldi
                    randomSayi = rnd.Next(0, 8);// bir sonraki resim için random sayı atadık ve pictureboxta yeni resim atadık.
                    resimPictureBox.Image = atik[randomSayi].Image;

                }
                return;
            }
        }

        private void metalButton_Click(object sender, EventArgs e)
        {
           if(randomSayi == 4 || randomSayi == 0)// dizideki 4. ve 0.eleman metal atık olduğundan koşulumuz randomSayı'ya bu değerlerin atanması.
            {

                if (metalProgress.Value > 75)// eğer progress barımız doluysa butona basamıyoruz
                {

                }
                else// progress barımızın değeri azsa işlemleri yapıyoruz
                {

                    metalAtik.Ekle(atik[randomSayi]);// Ekle methoduyla atik dizisinin randomSayi elemanı eklenir.
                    metalProgress.Value = metalAtik.DolulukOrani;
                    metalListBox.Items.Add(atik[randomSayi].Isim);// listboxa yazdırdık.
                    puanTextBox.Text = Convert.ToString(Convert.ToInt32(puanTextBox.Text) + atik[randomSayi].Hacim);// puanımız Atığımızın hacmi kadar yükseldi
                    randomSayi = rnd.Next(0, 8);// bir sonraki resim için random sayı atadık ve pictureboxta yeni resim atadık.
                    resimPictureBox.Image = atik[randomSayi].Image;

                }
                return;
            }

        }
        private void kagıtButton_Click(object sender, EventArgs e)
        {
            if (randomSayi == 3 || randomSayi == 5)// dizideki 3. ve 5.eleman kağıt atık olduğundan koşulumuz randomSayı'ya bu değerlerin atanması.
            {

                if (kagitProgress.Value > 75)// eğer progress barımız doluysa butona basamıyoruz
                {

                }
                else// progress barımızın değeri azsa işlemleri yapıyoruz
                {

                    kagitAtik.Ekle(atik[randomSayi]);// Ekle methoduyla atik dizisinin randomSayi elemanı eklenir.
                    kagitProgress.Value = kagitAtik.DolulukOrani;
                    kagıtListBox.Items.Add(atik[randomSayi].Isim);// listboxa yazdırdık.
                    puanTextBox.Text = Convert.ToString(Convert.ToInt32(puanTextBox.Text) + atik[randomSayi].Hacim);// puanımız Atığımızın hacmi kadar yükseldi
                    randomSayi = rnd.Next(0, 8);// bir sonraki resim için random sayı atadık ve pictureboxta yeni resim atadık.
                    resimPictureBox.Image = atik[randomSayi].Image;
                }
                return;
            }
        }

        private void cıkısButton_Click(object sender, EventArgs e)
        {
            Close(); // oyundan çıkışı sağlar.
        }

      
    }
}
