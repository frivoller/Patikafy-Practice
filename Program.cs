using System;
using System.Collections.Generic;
using System.Linq;

public class Sarkici
{
    public string Adi { get; set; }
    public string MuzikTuru { get; set; }
    public int CikisYili { get; set; }
    public int AlbumSatis { get; set; } // Yaklaşık satış değerini milyon cinsinden saklayacağız
}

public class Program
{
    public static void Main()
    {
        // Sanatçı verilerini bir listeye ekleyelim
        List<Sarkici> sarkicilar = new List<Sarkici>
        {
            new Sarkici { Adi = "Ajda Pekkan", MuzikTuru = "Pop", CikisYili = 1968, AlbumSatis = 20 },
            new Sarkici { Adi = "Sezen Aksu", MuzikTuru = "Türk Halk Müziği / Pop", CikisYili = 1971, AlbumSatis = 10 },
            new Sarkici { Adi = "Funda Arar", MuzikTuru = "Pop", CikisYili = 1999, AlbumSatis = 3 },
            new Sarkici { Adi = "Sertab Erener", MuzikTuru = "Pop", CikisYili = 1994, AlbumSatis = 5 },
            new Sarkici { Adi = "Sıla", MuzikTuru = "Pop", CikisYili = 2009, AlbumSatis = 3 },
            new Sarkici { Adi = "Serdar Ortaç", MuzikTuru = "Pop", CikisYili = 1994, AlbumSatis = 10 },
            new Sarkici { Adi = "Tarkan", MuzikTuru = "Pop", CikisYili = 1992, AlbumSatis = 40 },
            new Sarkici { Adi = "Hande Yener", MuzikTuru = "Pop", CikisYili = 1999, AlbumSatis = 7 },
            new Sarkici { Adi = "Hadise", MuzikTuru = "Pop", CikisYili = 2005, AlbumSatis = 5 },
            new Sarkici { Adi = "Gülben Ergen", MuzikTuru = "Pop / Türk Halk Müziği", CikisYili = 1997, AlbumSatis = 10 },
            new Sarkici { Adi = "Neşet Ertaş", MuzikTuru = "Türk Halk Müziği / Türk Sanat Müziği", CikisYili = 1960, AlbumSatis = 2 }
        };

        // Adı 'S' ile başlayan şarkıcılar
        var sIleBaslayan = sarkicilar.Where(s => s.Adi.StartsWith("S")).ToList();
        Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
        sIleBaslayan.ForEach(s => Console.WriteLine(s.Adi));

        // Albüm satışları 10 milyon'un üzerinde olan şarkıcılar
        var albumSatisiOnMilyonUstu = sarkicilar.Where(s => s.AlbumSatis > 10).ToList();
        Console.WriteLine("\nAlbüm satışları 10 milyon'un üzerinde olan şarkıcılar:");
        albumSatisiOnMilyonUstu.ForEach(s => Console.WriteLine(s.Adi));

        // 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar
        var eskiPopSarkicilar = sarkicilar
            .Where(s => s.CikisYili < 2000 && s.MuzikTuru.Contains("Pop"))
            .OrderBy(s => s.CikisYili)
            .ThenBy(s => s.Adi)
            .ToList();
        Console.WriteLine("\n2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:");
        eskiPopSarkicilar.ForEach(s => Console.WriteLine($"{s.CikisYili} - {s.Adi}"));

        // En çok albüm satan şarkıcı
        var enCokSatan = sarkicilar.OrderByDescending(s => s.AlbumSatis).First();
        Console.WriteLine($"\nEn çok albüm satan şarkıcı: {enCokSatan.Adi} ({enCokSatan.AlbumSatis} milyon)");

        // En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı
        var enYeniSarkici = sarkicilar.OrderByDescending(s => s.CikisYili).First();
        var enEskiSarkici = sarkicilar.OrderBy(s => s.CikisYili).First();
        Console.WriteLine($"\nEn yeni çıkış yapan şarkıcı: {enYeniSarkici.Adi} ({enYeniSarkici.CikisYili})");
        Console.WriteLine($"En eski çıkış yapan şarkıcı: {enEskiSarkici.Adi} ({enEskiSarkici.CikisYili})");
    }
}
