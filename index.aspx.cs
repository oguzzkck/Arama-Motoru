using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using System.Collections;

public partial class index : System.Web.UI.Page
{

    string[] kparcalar,uparcalar,sayi;
    string kelime;
    string adres;
    int sayac = 0,x=1;
    string sonuc;
    ArrayList deger = new ArrayList();

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
    {   sayi = kelime.Split(',');
        uparcalar = adres.Split(',');
        for (int i = 0; i < uparcalar.Length; i++)
        {
            WebRequest gelenIstek = HttpWebRequest.Create(uparcalar[i]);
            WebResponse gelenCevap;
            gelenCevap = gelenIstek.GetResponse();

            StreamReader donenDeger = new StreamReader(gelenCevap.GetResponseStream(), Encoding.UTF8);
            string gelenBilgi = donenDeger.ReadToEnd();

            int baslangic = gelenBilgi.IndexOf("<body") + 6;
            int bitis = gelenBilgi.Substring(baslangic).IndexOf("</body>");

            sonuc = gelenBilgi.Substring(baslangic, bitis);
            sonuc = sonuc.ToLower();
            ListBox8.Items.Add(uparcalar[i]);
            for (int j = 0; j <sayi.Length-1; j++)
            {
                ListBox8.Items.Add(" ");
            }
            KelimeParcala();
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
            //konum = sonuc.IndexOf(kelime, konum + 1);
            //sayac++;
        }
        ListBox7.Items.Add(sayac.ToString());
        sayac = 0;
        
        return kelime;
    }

    protected void ListBox8_SelectedIndexChanged(object sender, EventArgs e)
    {
        int konum = ListBox8.SelectedIndex;
        ListBox7.SelectedIndex = konum;
        ListBox6.SelectedIndex = konum;
    }
}      