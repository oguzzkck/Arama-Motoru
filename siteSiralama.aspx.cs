using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class siteSiralama : System.Web.UI.Page
{
    string[] kparcalar, uparcalar;
    string kelime;
    string adres;
    int sayac = 0;
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
            kparcalar = kelime.Split(',');
            //SayfaAc(adres);
            //string[] kparcalar;
            //KelimeParcala();
            //kparcalar = kelime.Split(',');

            VeriAl();
        }
        Label3.Text = ListBox6.Items.Count.ToString();
        Label4.Text = ListBox7.Items.Count.ToString();
        Label5.Text = ListBox8.Items.Count.ToString();
    }
    public void VeriAl()
    {
        Uri url = new Uri(adres);

        WebClient client = new WebClient();
        string html = client.DownloadString(url);
        MatchCollection m1 = Regex.Matches(html, "<a href=\"(.+?)\"", RegexOptions.Singleline);

        foreach (Match m in m1)
        {
            string link = m.Groups[1].Value;
            if (link.Contains("http") || link.Contains("#"))
            {

            }
            else
            {
                ListBox1.Items.Add(link);
                int indeks;
                int sayi = ListBox1.Items.Count;
                if (sayi > 1)
                {
                    string sonitem = ListBox1.Items[sayi - 1].ToString();
                    for (indeks = sayi - 2; indeks >= 0; indeks += -1)
                    {
                        if (ListBox1.Items[indeks].ToString() == sonitem)
                        {
                            ListBox1.Items.RemoveAt(indeks);
                        }
                        else
                        {
                            sonitem = ListBox1.Items[indeks].ToString();
                        }
                    }
                }
            }
                
        }
        for (int i = 0; i < ListBox1.Items.Count; i++)
        {
            SayfaAc(adres + ListBox1.Items[i]);
            //kelimeAra(kelime);
            //kelimeAra();
        }
    }

    public string SayfaAc(string adres)
    {
        WebRequest gelenIstek = HttpWebRequest.Create(adres);
        WebResponse gelenCevap;
        gelenCevap = gelenIstek.GetResponse();

        StreamReader donenDeger = new StreamReader(gelenCevap.GetResponseStream(), Encoding.UTF8);
        string gelenBilgi = donenDeger.ReadToEnd();

        int baslangic = gelenBilgi.IndexOf("<body") + 6;
        int bitis = gelenBilgi.Substring(baslangic).IndexOf("</body>");

        sonuc = gelenBilgi.Substring(baslangic, bitis);
        sonuc = sonuc.ToLower();
        ListBox8.Items.Add(adres);
        for (int i = 0; i < kparcalar.Length-1; i++)
        {
            ListBox8.Items.Add(" ");
        }
        
        //Label0.Text = sonuc;
        KelimeParcala();

        return sonuc;
    }
    public void KelimeParcala()
    {
        
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