using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sayfaSiralama : System.Web.UI.Page
{
    string[] kparcalar, uparcalar;
    string kelime;
    string adres;
    int sayac = 0,sayac2=0,a;
    string sonuc;
    int buyuk1, buyuk2, buyuk3, kucuk1, kucuk2, kucuk3;
    ArrayList aList = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ListBox6.Items.Clear();
        ListBox7.Items.Clear();
        ListBox8.Items.Clear();
        ListBox4.Items.Clear();
        ListBox5.Items.Clear();
        adres = TextBox2.Text;



        if (String.IsNullOrEmpty(adres))
        {
            Response.Write("<script lang='JavaScript'>alert('Adres çubuğu boş olamaz!!!');</script>");
        }
        else
        {
            kelime = TextBox1.Text;

            SayfaAc(adres);
        }
    }
    public string SayfaAc(string adres)
    {
        uparcalar = adres.Split(',');
        for (a = 0; a < uparcalar.Length; a++)
        {
            WebRequest gelenIstek = HttpWebRequest.Create(uparcalar[a]);
            WebResponse gelenCevap;
            gelenCevap = gelenIstek.GetResponse();

            StreamReader donenDeger = new StreamReader(gelenCevap.GetResponseStream(), Encoding.UTF8);
            string gelenBilgi = donenDeger.ReadToEnd();

            int baslangic = gelenBilgi.IndexOf("<body") + 6;
            int bitis = gelenBilgi.Substring(baslangic).IndexOf("</body>");

            sonuc = gelenBilgi.Substring(baslangic, bitis);
            
            sonuc = sonuc.ToLower();
            //Label0.Text = sonuc;
            KelimeParcala();
        }

        ///------PUANLAMA
        if (uparcalar.Length==3)
        {
            int[] dizi1 = new int[kparcalar.Length];
            int[] dizi2 = new int[kparcalar.Length];
            int[] dizi3 = new int[kparcalar.Length];
            for (int i = 0; i < kparcalar.Length; i++)
            {
                dizi1[i] = Convert.ToInt32(ListBox1.Items[i].ToString());
                dizi2[i] = Convert.ToInt32(ListBox2.Items[i].ToString());
                dizi3[i] = Convert.ToInt32(ListBox3.Items[i].ToString());
            }
            int ort1 = 0, ort2 = 0, ort3 = 0;
            for (int i = 0; i < kparcalar.Length; i++)
            {
                ort1 += dizi1[i];
                ort2 += dizi2[i];
                ort3 += dizi3[i];
            }
            ort1 = ort1 / kparcalar.Length;
            ort2 = ort2 / kparcalar.Length;
            ort3 = ort3 / kparcalar.Length;

            double toplam1 = 0.0, toplam2 = 0.0, toplam3 = 0.0;
            for (int i = 0; i < kparcalar.Length; i++)
            {
                toplam1 += Math.Pow((dizi1[i] - ort1), 2);
                toplam2 += Math.Pow((dizi2[i] - ort1), 2);
                toplam3 += Math.Pow((dizi3[i] - ort1), 2);
            }

            double standartS1 = Math.Sqrt(toplam1 / (kparcalar.Length - 1)); ;
            double standartS2 = Math.Sqrt(toplam2 / (kparcalar.Length - 1)); ;
            double standartS3 = Math.Sqrt(toplam3 / (kparcalar.Length - 1)); ;


            if ((ort1 + standartS1) > (ort2 + standartS2) && (ort1 + standartS1) > (ort3 + standartS3))
            {
                ListBox4.Items.Add(uparcalar[0]);
                ListBox5.Items.Add((ort1 + standartS1).ToString());
                if ((ort2 + standartS2) > (ort3 + standartS3))
                {
                    ListBox4.Items.Add(uparcalar[1]);
                    ListBox5.Items.Add((ort2 + standartS2).ToString());
                }
                else
                {
                    ListBox4.Items.Add(uparcalar[2]);
                    ListBox5.Items.Add((ort3 + standartS3).ToString());
                }

                if (ListBox4.Items[1].Equals(uparcalar[1]))
                {
                    ListBox4.Items.Add(uparcalar[2]);
                    ListBox5.Items.Add((ort3 + standartS3).ToString());
                }
                else
                {
                    ListBox4.Items.Add(uparcalar[1]);
                    ListBox5.Items.Add((ort2 + standartS2).ToString());
                }

            }
            else if ((ort2 + standartS2) > (ort1 + standartS1) && (ort2 + standartS2) > (ort3 + standartS3))
            {
                ListBox4.Items.Add(uparcalar[1]);
                ListBox5.Items.Add((ort2 + standartS2).ToString());
                if ((ort1 + standartS1) > (ort3 + standartS3))
                {
                    ListBox4.Items.Add(uparcalar[0]);
                    ListBox5.Items.Add((ort1 + standartS1).ToString());
                }
                else
                {
                    ListBox4.Items.Add(uparcalar[2]);
                    ListBox5.Items.Add((ort3 + standartS3).ToString());
                }

                if (ListBox4.Items[1].Equals(uparcalar[0]))
                {
                    ListBox4.Items.Add(uparcalar[2]);
                    ListBox5.Items.Add((ort3 + standartS3).ToString());
                }
                else
                {
                    ListBox4.Items.Add(uparcalar[0]);
                    ListBox5.Items.Add((ort1 + standartS1).ToString());
                }
            }
            else if ((ort3 + standartS3) > (ort1 + standartS1) && (ort3 + standartS3) > (ort2 + standartS2))
            {
                ListBox4.Items.Add(uparcalar[2]);
                ListBox5.Items.Add((ort3 + standartS3).ToString());
                if ((ort1 + standartS1) > (ort2 + standartS2))
                {
                    ListBox4.Items.Add(uparcalar[0]);
                    ListBox5.Items.Add((ort1 + standartS1).ToString());
                }
                else
                {
                    ListBox4.Items.Add(uparcalar[1]);
                    ListBox5.Items.Add((ort2 + standartS2).ToString());
                }

                if (ListBox4.Items[1].Equals(uparcalar[1]))
                {
                    ListBox4.Items.Add(uparcalar[0]);
                    ListBox5.Items.Add((ort1 + standartS1).ToString());
                }
                else
                {
                    ListBox4.Items.Add(uparcalar[1]);
                    ListBox5.Items.Add((ort2 + standartS2).ToString());
                }
            }
            
        }
        else if (uparcalar.Length == 2)
        {
            int[] dizi4 = new int[kparcalar.Length];
            int[] dizi5 = new int[kparcalar.Length];

            for (int i = 0; i < kparcalar.Length; i++)
            {
                dizi4[i] = Convert.ToInt32(ListBox1.Items[i].ToString());
                dizi5[i] = Convert.ToInt32(ListBox2.Items[i].ToString());

            }
            int ort4 = 0, ort5 = 0;
            for (int i = 0; i < kparcalar.Length; i++)
            {
                ort4 += dizi4[i];
                ort5 += dizi5[i];

            }
            ort4 = ort4 / kparcalar.Length;
            ort5 = ort5 / kparcalar.Length;


            double toplam4 = 0.0, toplam5 = 0.0;
            for (int i = 0; i < uparcalar.Length; i++)
            {
                toplam4 += Math.Pow((dizi4[i] - ort4), 2);
                toplam5 += Math.Pow((dizi5[i] - ort5), 2);
            }
            double standartS4 = Math.Sqrt(toplam4 / (kparcalar.Length - 1)); ;
            double standartS5 = Math.Sqrt(toplam5 / (kparcalar.Length - 1)); ;



            if ((ort4 + standartS4) > (ort5 + standartS5))
            {
                ListBox4.Items.Add(uparcalar[0]);
                ListBox5.Items.Add((ort4 + standartS4).ToString());
                ListBox4.Items.Add(uparcalar[1]);
                ListBox5.Items.Add((ort5 + standartS5).ToString());
            }
            else if ((ort5 + standartS5) > (ort4 + standartS4))
            {
                ListBox4.Items.Add(uparcalar[1]);
                ListBox5.Items.Add((ort5 + standartS5).ToString());
                ListBox4.Items.Add(uparcalar[0]);
                ListBox5.Items.Add((ort4 + standartS4).ToString());
            }
        }
        else if (uparcalar.Length == 1)
        {
            int[] dizi6 = new int[kparcalar.Length];

            for (int i = 0; i < kparcalar.Length; i++)
            {
                dizi6[i] = Convert.ToInt32(ListBox1.Items[i].ToString());
                

            }
            int ort6 = 0;
            for (int i = 0; i < kparcalar.Length; i++)
            {
                ort6 += dizi6[i];
            }
            ort6 = ort6 / kparcalar.Length;

            double toplam6 = 0.0;
            for (int i = 0; i < uparcalar.Length; i++)
            {
                toplam6 += Math.Pow((dizi6[i] - ort6), 2);
            }
            double standartS6 = Math.Sqrt(toplam6 / (kparcalar.Length - 1)); ;

            ListBox4.Items.Add(uparcalar[0]);
            ListBox5.Items.Add((ort6 + standartS6).ToString());
        }



        return sonuc;
    }
    public void KelimeParcala()
    {
        kparcalar = kelime.Split(',');
        for (int i = 0; i < kparcalar.Length; i++)
        {
            kparcalar[i] = kparcalar[i].ToLower();
        }
        for (int j = 0; j < kparcalar.Length; j++)
        {
            kelimeAra(kparcalar[j]);
        }
    }
    public string kelimeAra(string kelime)
    {
        ListBox6.Items.Add(kelime);
        ListBox8.Items.Add(uparcalar[a]);
        int konum = sonuc.IndexOf(kelime);
        while (konum != -1)
        {
            if (sonuc[konum - 1] == ' ' && sonuc[konum + kelime.Length] == ' ')
            {
                konum = sonuc.IndexOf(kelime, konum + 1);
                sayac++;
            }
            else
                konum = sonuc.IndexOf(kelime, konum + 1);
        }
        ListBox7.Items.Add(sayac.ToString());
        
        if (sayac2<kparcalar.Length)
        {
            ListBox1.Items.Add(sayac.ToString());
            sayac2++;
        }
        else if(sayac2<(2*kparcalar.Length))
        {
            ListBox2.Items.Add(sayac.ToString());
            sayac2++;
        }
        else
        {
            ListBox3.Items.Add(sayac.ToString());
            sayac2++;
        }
        sayac = 0;

        return kelime;
    }
}