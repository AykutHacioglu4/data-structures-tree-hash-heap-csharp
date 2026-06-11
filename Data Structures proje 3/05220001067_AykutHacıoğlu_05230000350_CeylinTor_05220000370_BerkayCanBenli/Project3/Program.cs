using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Kelime
{
    // Kelime sınıfı kelime değerini ve sol/sag alt düğümleri tutar
    public string KelimeDegeri { get; set; }
    public Kelime Sol { get; set; }
    public Kelime Sag { get; set; }

    // Yapıcı metod kelime değeri alır ve sol/sag bağlantıları başta null olarak ayarlanır
    public Kelime(string kelime)
    {
        KelimeDegeri = kelime;
        Sol = null;
        Sag = null;
    }

    // Yeni bir kelime ekler alfabetik sıraya göre yerleştirir
    public void Ekle(Kelime yeniKelime)
    {
        if (string.Compare(yeniKelime.KelimeDegeri, KelimeDegeri) < 0)
        {
            // Yeni kelime mevcut kelimeden küçükse sola eklenir
            if (Sol == null)
                Sol = yeniKelime;
            else
                Sol.Ekle(yeniKelime); // Rekürsif ekleme
        }
        else if (string.Compare(yeniKelime.KelimeDegeri, KelimeDegeri) > 0)
        {
            // Yeni kelime mevcut kelimeden büyükse sağa eklenir
            if (Sag == null)
                Sag = yeniKelime;
            else
                Sag.Ekle(yeniKelime); // Rekürsif ekleme
        }
    }

    // Ağaçtaki derinliği hesaplayıp en uzun yolu bulur
    public int DerinlikHesapla()
    {
        int solDerinlik = Sol?.DerinlikHesapla() ?? 0; // Sol alt ağaç derinliği
        int sagDerinlik = Sag?.DerinlikHesapla() ?? 0; // Sağ alt ağaç derinliği
        return Math.Max(solDerinlik, sagDerinlik) + 1; // En uzun yolu döndür
    }

    // Ağaçtaki toplam düğüm sayısını hesaplar
    public int DugumSayisiHesapla()
    {
        int solDugumSayisi = Sol?.DugumSayisiHesapla() ?? 0; // Sol alt ağacın düğüm sayısı
        int sagDugumSayisi = Sag?.DugumSayisiHesapla() ?? 0; // Sağ alt ağacın düğüm sayısı
        return solDugumSayisi + sagDugumSayisi + 1; // Kendisi dahil tüm düğümleri döndür
    }

    // Kelimeleri sıralı bir şekilde listelemeye yarar
    public void Listele(ref List<string> kelimeler)
    {
        Sol?.Listele(ref kelimeler); // Sol alt ağaçtan kelimeler alınır
        kelimeler.Add(KelimeDegeri); // Mevcut kelime eklenir
        Sag?.Listele(ref kelimeler); // Sağ alt ağaçtan kelimeler alınır
    }

    // Ağaçtaki kelimeleri yazdırır
    public void Yazdir()
    {
        Sol?.Yazdir(); // Sol alt ağaç yazdırılır
        Console.WriteLine(KelimeDegeri); // Mevcut kelime yazdırılır
        Sag?.Yazdir(); // Sağ alt ağaç yazdırılır
    }
}

class Balik
{
    // Balık sınıfı balığın adı ve kelimelerinin yer aldığı ağaç yapısını tutar
    public string Ad { get; set; }
    public Kelime Kelimeler { get; set; }

    // Yapıcı metod balık adı alır
    public Balik(string ad)
    {
        Ad = ad;
        Kelimeler = null; // Başlangıçta kelimeler yok
    }

    // Yeni bir kelime ekler kelime ağacına eklenir
    public void KelimeEkle(string kelime)
    {
        Kelime yeniKelime = new Kelime(kelime);
        if (Kelimeler == null)
            Kelimeler = yeniKelime; // Eğer kelimeler yoksa başta ekler
        else
            Kelimeler.Ekle(yeniKelime); // Kelimeyi ekleme metodu ile ekler
    }

    // Balığın kelimelerini ve ağacının özelliklerini listeleyen metod
    public void Listele()
    {
        Console.WriteLine($"Balık Adı: {Ad}");
        int derinlik = KelimeAgaciDerinligi(); // Kelime ağacının derinliği
        int dugumSayisi = KelimeAgaciDugumSayisi(); // Kelime ağacındaki düğüm sayısı
        int dengeliDerinlik = DengeliDerinlikHesapla(); // Dengeli ağacın derinliği

        // Bilgileri yazdırır
        Console.WriteLine($"Derinlik: {derinlik}, Düğüm Sayısı: {dugumSayisi}, Dengeli Derinlik: {dengeliDerinlik}");

        if (Kelimeler != null)
        {
            List<string> kelimeler = new List<string>();
            Kelimeler.Listele(ref kelimeler); // Kelimeler sıralı olarak alınır
            Console.WriteLine($"Kelimeler: {string.Join(", ", kelimeler)}");
        }
        else
        {
            Console.WriteLine("Bu balığın kelimeleri yok.");
        }
    }

    // Kelime ağacının derinliğini hesaplar
    public int KelimeAgaciDerinligi() => Kelimeler?.DerinlikHesapla() ?? 0;

    // Kelime ağacındaki düğüm sayısını hesaplar
    public int KelimeAgaciDugumSayisi() => Kelimeler?.DugumSayisiHesapla() ?? 0;

    // Dengeli ağaç derinliğini hesaplamak için bir metod
    public int DengeliDerinlikHesapla()
    {
        var kelimeler = new List<string>();
        Kelimeler?.Listele(ref kelimeler); // Kelimeler sıralanır
        var dengeliAgac = DengeliAgacOlustur(kelimeler, 0, kelimeler.Count - 1); // Dengeli ağaç oluşturulur
        return dengeliAgac?.DerinlikHesapla() ?? 0; // Dengeli ağacın derinliği döndürülür
    }

    // Sıralı kelimelerle dengeli bir ikili ağaç oluşturur
    private Kelime DengeliAgacOlustur(List<string> isimler, int sol, int sag)
    {
        if (sol > sag) return null; // Alt sınır üst sınırdan büyükse alt ağaç yok demektir

        int orta = (sol + sag) / 2; // Orta eleman seçilir
        Kelime kok = new Kelime(isimler[orta]); // Yeni düğüm oluşturulur
        kok.Sol = DengeliAgacOlustur(isimler, sol, orta - 1); // Sol alt ağaç oluşturulur
        kok.Sag = DengeliAgacOlustur(isimler, orta + 1, sag); // Sağ alt ağaç oluşturulur

        return kok; // Dengeli ağaç döndürülür
    }
}

class Baliklar
{
    // Balik sınıfının listesini tutar
    public List<Balik> BalikListesi { get; set; }

    // Yapıcı metod BalikListesini başlatır
    public Baliklar()
    {
        BalikListesi = new List<Balik>();
    }

    // Yeni bir balık ekler
    public void BalikEkle(Balik balik)
    {
        BalikListesi.Add(balik);
    }

    // Balıkları adlarına göre sıralar ve listeler
    public void Listele()
    {
        // Balıkları adlarına göre sıralar
        BalikListesi.Sort((b1, b2) => string.Compare(b1.Ad, b2.Ad));
        // Sıralı balıkları yazdırır
        foreach (var balik in BalikListesi)
        {
            balik.Listele();
            Console.WriteLine();
        }
    }

    // Belirli bir aralıkta balık isimlerini listeler
    public void BalikIsimleriniListele(char basHarf, char sonHarf)
    {
        Console.WriteLine($"'{basHarf}' ile '{sonHarf}' arasındaki balık isimleri:");
        // Balıkları kontrol eder ve adı verilen aralıkta olanları yazdırır
        foreach (var balik in BalikListesi)
        {
            if (balik.Ad[0] >= basHarf && balik.Ad[0] <= sonHarf)
                Console.WriteLine(balik.Ad);
        }
    }

    // Dosyadan veri okur ve balık listesine ekler
    public void DosyadanVeriOku(string dosyaYolu)
    {
        // Dosyadaki tüm satırları okur
        string[] satirlar = File.ReadAllLines(dosyaYolu);
        Balik currentBalik = null;

        foreach (var satir in satirlar)
        {
            if (string.IsNullOrWhiteSpace(satir)) continue; // Boş satırları atlar

            if (satir.StartsWith("*"))
            {
                // Eğer bir balık ismi bitmişse ve yeni balık başlıyorsa önceki balığı ekler
                if (currentBalik != null) BalikEkle(currentBalik);
                currentBalik = null;
            }
            else if (currentBalik == null)
            {
                // Yeni balık ismi başladığında balık nesnesi oluşturulur
                currentBalik = new Balik(satir.Trim());
            }
            else
            {
                // Balığa ait kelimeleri satırlardan alıp ekler
                string[] kelimeler = satir.Split(new[] { ' ', ',', '.', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var kelime in kelimeler)
                {
                    currentBalik.KelimeEkle(kelime);
                }
            }
        }

        // Son balığı ekler
        if (currentBalik != null) BalikEkle(currentBalik);
    }

    // Balıklardan dengeli bir ağaç oluşturur
    public Kelime DengeliAgacOlustur()
    {
        List<string> balikIsimleri = new List<string>();
        // Balıkların isimlerini listeye ekler
        foreach (var balik in BalikListesi)
        {
            balikIsimleri.Add(balik.Ad);
        }
        // İsimleri sıralar
        balikIsimleri.Sort();
        // Dengeli ağaç oluşturur ve döndürür
        return DengeliAgacOlustur(balikIsimleri, 0, balikIsimleri.Count - 1);
    }

    // Sıralı isimlerle dengeli ağaç oluşturan yardımcı metod
    private Kelime DengeliAgacOlustur(List<string> isimler, int sol, int sag)
    {
        if (sol > sag) return null; // Alt sınır üst sınırdan büyükse, ağaçta daha fazla düğüm yok

        int orta = (sol + sag) / 2; // Orta elemanı seçer
        Kelime kok = new Kelime(isimler[orta]); // Kök düğümünü oluşturur
        kok.Sol = DengeliAgacOlustur(isimler, sol, orta - 1); // Sol alt ağaç oluşturur
        kok.Sag = DengeliAgacOlustur(isimler, orta + 1, sag); // Sağ alt ağaç oluşturur

        return kok; // Dengeli ağacı döndürür
    }

    // Dengeli ağacı in order sırasına göre yazdırır
    public void YazdirDengeliAgac(Kelime kok)
    {
        if (kok == null)
        {
            Console.WriteLine("Dengeli ağaç boş.");
            return;
        }

        Console.WriteLine("Dengeli ağaç in-order yazdırılıyor:");
        YazdirInOrder(kok); // In order sırasıyla yazdırır
    }

    // In order sırasına göre ağacı yazdırır
    private void YazdirInOrder(Kelime kok)
    {
        if (kok == null) return; // Eğer ağaç boşsa geri dön
        YazdirInOrder(kok.Sol); // Sol alt ağacı yazdırır
        Console.WriteLine(kok.KelimeDegeri); // Kök düğümünü yazdırır
        YazdirInOrder(kok.Sag); // Sağ alt ağacı yazdırır
    }

    // Tüm balıklardan dengeli bir ağaç oluşturur
    public Kelime TumBaliklardanDengeliAgacOlustur()
    {
        List<string> balikAdlari = new List<string>();

        // Balık isimlerini listeye ekler
        foreach (var balik in BalikListesi)
        {
            balikAdlari.Add(balik.Ad);
        }

        // İsimleri sıralar
        balikAdlari.Sort();

        // Tüm balık isimleriyle dengeli ağaç oluşturur
        return TumBaliklarDengeliAgac(balikAdlari, 0, balikAdlari.Count - 1);
    }

    // Tüm balıklar için dengeli ağaç oluşturan yardımcı metod
    private Kelime TumBaliklarDengeliAgac(List<string> adlar, int sol, int sag)
    {
        if (sol > sag) return null; // Alt sınır üst sınırdan büyükse ağaçta daha fazla düğüm yoktur

        int orta = (sol + sag) / 2; // Orta elemanı seçer
        Kelime kok = new Kelime(adlar[orta]); // Kök düğümünü oluşturur

        kok.Sol = TumBaliklarDengeliAgac(adlar, sol, orta - 1); // Sol alt ağaç oluşturur
        kok.Sag = TumBaliklarDengeliAgac(adlar, orta + 1, sag); // Sağ alt ağaç oluşturur

        return kok; // Dengeli ağacı döndürür
    }
}


class MaxHeap
{
    private List<Balik> heap;

    public MaxHeap()
    {
        heap = new List<Balik>();
    }

    public void Insert(Balik balik)
    {
        heap.Add(balik);
        int currentIndex = heap.Count - 1;

        // Heap propertyi sağlamak için yukarı doğru sift işlemi yapıyoruz
        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;
            if (string.Compare(heap[currentIndex].Ad, heap[parentIndex].Ad) > 0)
            {
                // Eğer şu anki balık adı üstteki balık adından büyükse yer değiştir
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    public Balik ExtractMax()
    {
        if (heap.Count == 0)
            return null;

        // En büyük öğeyi almak
        Balik maxBalik = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);

        // Heap propertyi sağlamak için aşağı doğru sift işlemi yapıyoruz
        Heapify(0);

        return maxBalik;
    }

    // Heap veri yapısını düzenleyen sınıf
    private void Heapify(int index)
    {
        // Sol ve sağ çocukların indekslerini hesapla
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int largest = index; // Başlangıçta en büyük eleman kök elemandır

        // Sol çocuğun daha büyük olup olmadığını kontrol et
        if (leftChild < heap.Count && string.Compare(heap[leftChild].Ad, heap[largest].Ad) > 0)
        {
            largest = leftChild; // Sol çocuk daha büyükse largestı sol çocuğa ata
        }

        // Sağ çocuğun daha büyük olup olmadığını kontrol et
        if (rightChild < heap.Count && string.Compare(heap[rightChild].Ad, heap[largest].Ad) > 0)
        {
            largest = rightChild; // Sağ çocuk daha büyükse largestı sağ çocuğa ata
        }

        // Eğer en büyük eleman kök değilse yer değiştir
        if (largest != index)
        {
            Swap(index, largest); // Elemanları takas et
            Heapify(largest); // Takas sonrası ağaç yapısını yeniden düzenle
        }
    }

    // İki elemanın yerlerini değiştirir
    private void Swap(int i, int j)
    {
        Balik temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }

    // Heapteki tüm balıkları yazdırır
    public void PrintHeap()
    {
        foreach (var balik in heap)
        {
            Console.WriteLine($"Balık Adı: {balik.Ad}");
        }
    }

    // Heapteki eleman sayısını döndürür
    public int Count => heap.Count;
}

// Bubble Sort algoritmasıyla sıralama yapan sınıf
class BubbleSort
{
    // Diziyi sıralar
    public void Sort(int[] arr)
    {
        int n = arr.Length;

        // Diziyi sıralamak için dış döngü
        for (int i = 0; i < n - 1; i++)
        {
            // İç döngü ile ardışık elemanları karşılaştırır ve yer değiştirir
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Elemanları takas et
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

// Shell Sort algoritmasıyla sıralama yapan sınıf
class ShellSort
{
    // Diziyi sıralar
    public void Sort(int[] arr)
    {
        int n = arr.Length;
        // İlk gap değeri dizinin yarısıdır
        int gap = n / 2;

        // Gap değeri sıfır olana kadar devam eder
        while (gap > 0)
        {
            // Gap kullanarak diziyi sıralar
            for (int i = gap; i < n; i++)
            {
                int temp = arr[i];
                int j = i;

                // Gap mesafesinde sıralama yapar
                while (j >= gap && arr[j - gap] > temp)
                {
                    arr[j] = arr[j - gap];
                    j -= gap;
                }
                arr[j] = temp; // Elemanı doğru konuma yerleştirir
            }
            gap /= 2; // Gapi yarıya indirir
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Baliklar baliklar = new Baliklar();
        string dosyaYolu = "baliklar.txt";

        // Dosyadan veri okuyup balıkları listeye ekleme
        baliklar.DosyadanVeriOku(dosyaYolu);

        // Kelime listeleri çıktısı
        Console.WriteLine("Balıklar ve Kelimeleri:");
        Console.WriteLine("========================");
        foreach (var balik in baliklar.BalikListesi)
        {
            Console.WriteLine($"Balık Adı: {balik.Ad}");
            if (balik.Kelimeler != null)
            {
                List<string> kelimeler = new List<string>();
                balik.Kelimeler.Listele(ref kelimeler);
                Console.WriteLine($"Kelimeler: {string.Join(", ", kelimeler)}");
            }
            else
            {
                Console.WriteLine("Kelimeler: (Yok)");
            }
            Console.WriteLine(); // Boşluk bırak
        }

        // Ayrı bölümde derinlik düğüm sayısı ve dengeli derinlik bilgileri çıktısı
        Console.WriteLine("\nBalıklar ve Kelime Ağacı Bilgileri:");
        Console.WriteLine("===================================");
        foreach (var balik in baliklar.BalikListesi)
        {
            Console.WriteLine($"Balık: {balik.Ad}, Derinlik: {balik.KelimeAgaciDerinligi()}, Düğüm Sayısı: {balik.KelimeAgaciDugumSayisi()}, Dengeli Derinlik: {baliklar.DengeliAgacOlustur()?.DerinlikHesapla() ?? 0}");
        }



        // Belirli harf aralığındaki balık isimlerini listeleme
        Console.Write("Baş harfini girin: ");
        char basHarf = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();
        Console.Write("Son harfini girin: ");
        char sonHarf = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        baliklar.BalikIsimleriniListele(basHarf, sonHarf);

        // Tüm balık isimlerinden dengeli ağaç oluşturma
        Console.WriteLine("\nTüm Balıkların Dengeli Ağacı:");
        Kelime dengeliKok = baliklar.TumBaliklardanDengeliAgacOlustur();
        baliklar.YazdirDengeliAgac(dengeliKok);

        // 2a: Balık Adına Göre Hash Table Oluşturma
        Dictionary<string, Balik> balikHashTable = new Dictionary<string, Balik>();
        foreach (var balik in baliklar.BalikListesi)
        {
            balikHashTable[balik.Ad] = balik;
        }

        Console.WriteLine("\nBalık Hash Tablosu oluşturuldu.");
        Console.WriteLine("=================================");

        // Hash Tablosundaki Balıkları Listeleme
        foreach (var kvp in balikHashTable)
        {
            Console.WriteLine($"Balık Adı: {kvp.Key}");
        }

        // 2b: Hash Tablosunda Balık Bilgisini Güncelleme
        Console.Write("\nGüncellemek istediğiniz balığın adını girin: ");
        string guncellenecekBalikAdi = Console.ReadLine();

        if (balikHashTable.ContainsKey(guncellenecekBalikAdi))
        {
            Balik guncellenecekBalik = balikHashTable[guncellenecekBalikAdi];

            // Güncelleme öncesi bilgileri göster
            Console.WriteLine("\nGüncellemeden Önce:");
            Console.WriteLine($"Balık Adı: {guncellenecekBalik.Ad}");
            List<string> mevcutKelimeler = new List<string>();
            guncellenecekBalik.Kelimeler?.Listele(ref mevcutKelimeler);
            Console.WriteLine($"Kelimeler: {string.Join(", ", mevcutKelimeler)}");

            Console.WriteLine("\nYeni paragrafı girin:");
            string yeniParagraf = Console.ReadLine();

            // Yeni paragraftaki kelimeleri kelime ağacına ekleme
            guncellenecekBalik.Kelimeler = null; // Mevcut kelime ağacını sıfırla
            string[] yeniKelimeler = yeniParagraf.Split(new[] { ' ', ',', '.', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var kelime in yeniKelimeler)
            {
                guncellenecekBalik.KelimeEkle(kelime);
            }

            // Güncelleme sonrası bilgileri göster
            Console.WriteLine("\nGüncellemeden Sonra:");
            Console.WriteLine($"Balık Adı: {guncellenecekBalik.Ad}");
            List<string> guncelKelimeler = new List<string>();
            guncellenecekBalik.Kelimeler?.Listele(ref guncelKelimeler);
            Console.WriteLine($"Kelimeler: {string.Join(", ", guncelKelimeler)}");
        }
        else
        {
            Console.WriteLine("Bu isimde bir balık bulunamadı.");
        }

        // Güncellenmiş Hash Tablosunu Göster
        Console.WriteLine("\nGüncellenmiş Balık Hash Tablosu:");
        Console.WriteLine("=================================");
        foreach (var kvp in balikHashTable)
        {
            Console.WriteLine($"Balık Adı: {kvp.Key}");
            List<string> kelimeler = new List<string>();
            kvp.Value.Kelimeler?.Listele(ref kelimeler);
            Console.WriteLine($"Kelimeler: {string.Join(", ", kelimeler)}");
            Console.WriteLine(); // Balıklar arasına boşluk eklenir
        }

        // Max Heap oluşturuluyor
        MaxHeap maxHeap = new MaxHeap();

        // Balıkları Max Heape ekleme
        foreach (var balik in baliklar.BalikListesi)
        {
            maxHeap.Insert(balik);
        }

        // Max Heapten ilk 3 balığı çekip tüm bilgilerini listeleme
        Console.WriteLine("Max Heap'ten çıkarılan ilk 3 balık:");
        Console.WriteLine("====================================");

        for (int i = 0; i < 3 && maxHeap.Count > 0; i++)
        {
            Balik maxBalik = maxHeap.ExtractMax();
            if (maxBalik != null)
            {
                Console.WriteLine($"Balık Adı: {maxBalik.Ad}");
                if (maxBalik.Kelimeler != null)
                {
                    List<string> kelimeler = new List<string>();
                    maxBalik.Kelimeler.Listele(ref kelimeler);
                    Console.WriteLine($"Kelimeler: {string.Join(", ", kelimeler)}");
                }
                else
                {
                    Console.WriteLine("Kelimeler: (Yok)");
                }
                Console.WriteLine(); // Boşluk bırak
            }
        }

        // Arrayleri oluşturuyorum
        int[] orijinalArray = new int[100];
        int[] testArrayi = new int[100];
        Random random = new Random();

        for (int i = 0; i < orijinalArray.Length; i++)
        {
            orijinalArray[i] = random.Next(1, 1001);
        }

        Stopwatch stopwatch = new Stopwatch();

        // Bubble Sort kısmı
        stopwatch.Start();
        for (int i = 0; i < 10000000; i++)
        {
            Array.Copy(orijinalArray, testArrayi, orijinalArray.Length);
            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(testArrayi);
        }
        stopwatch.Stop();
        double bubbleSortTime = stopwatch.Elapsed.TotalSeconds;  // Zaman hesaplama

        // Shell Sort kısmı
        stopwatch.Restart();
        for (int i = 0; i < 10000000; i++)
        {
            Array.Copy(orijinalArray, testArrayi, orijinalArray.Length);
            ShellSort shellSort = new ShellSort();
            shellSort.Sort(testArrayi);
        }
        stopwatch.Stop();
        double shellSortTime = stopwatch.Elapsed.TotalSeconds;  // Zaman hesaplama

        // Zamanları yazdırma
        Console.WriteLine("Bubble Sort - Süre: " + bubbleSortTime + " saniye");
        Console.WriteLine("Shell Sort - Süre: " + shellSortTime + " saniye");

        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

}