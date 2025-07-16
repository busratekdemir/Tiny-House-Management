# Tiny House Management

Tiny House Management, kullanıcıların tiny house (küçük ev) ilanlarını yönetebildiği, rezervasyon yapabildiği, ev sahipleri ve kiracılar için ayrı paneller sunan, çok katmanlı mimari ile geliştirilmiş bir rezervasyon ve yönetim sistemidir.
Proje, C#, .NET Windows Forms, ADO.NET ve MSSQL kullanılarak geliştirilmiştir.

## Özellikler

* **Çok Katmanlı Mimari:**
  Proje; Data, Business ve UI olmak üzere üç ana katmandan oluşur.

* **Rol Bazlı Giriş:**

  * **Admin:** Kullanıcı, ev ve rezervasyon yönetimi, yorum onaylama ve istatistik raporlarını görüntüleme.
  * **Ev Sahibi:** İlan ekleme/güncelleme/silme, ilan gelirlerini görüntüleme.
  * **Kiracı:** Ev arama, rezervasyon yapma, mevcut rezervasyonları görüntüleme, yorum ekleme.

* **Rezervasyon Sistemi:**
  Kullanıcılar uygun evleri arayarak rezervasyon yapabilir. Rezervasyonlar çatışma (çakışma) kontrolü ile yönetilir.

* **Yorum ve Puanlama:**
  Kiracılar kaldıkları evlere puan verip yorum yapabilir, admin onayından sonra yorumlar yayınlanır.

* **Canlı Grafikler ve Raporlama:**
  Admin panelinde kullanıcı sayısı, rezervasyon sayısı, toplam gelir gibi istatistikler canlı grafiklerle gösterilir.

* **Güvenli Giriş ve Kayıt:**
  Parolalar güvenli şekilde hash’lenerek saklanır.

## Kullanılan Teknolojiler

* C# (.NET 6.0/8.0)
* Windows Forms (WinForms)
* MSSQL Server
* ADO.NET
* Katmanlı Mimari
* LiveCharts (İstatistikler için)
* Git ve GitHub (Versiyon kontrolü)

## Kurulum ve Çalıştırma

1. **Projeyi klonlayın:**

   ```bash
   git clone https://github.com/busratekdemir/Tiny-House-Management.git
   ```

2. **Visual Studio ile açın.**

3. **Bağımlılıkları yükleyin:**
   Proje içinde gerekli NuGet paketlerini yükleyin (`Microsoft.Data.SqlClient`, `LiveCharts.WinForms` vs.)

4. **Veritabanı bağlantı ayarlarını yapın:**

   * `App.config` dosyasındaki `connectionString` kısmını kendi MSSQL sunucunuza göre güncelleyin.
   * Gerekli tabloları ve stored procedure’leri SSMS ile oluşturun (dökümantasyon ya da `sql` klasöründe scriptler var).

5. **Projeyi build edip çalıştırın.**

## Ekran Görüntüleri

> Buraya birkaç ekran görüntüsü ekleyebilirsiniz.
> `![Admin Panel](screenshots/admin_panel.png)`
> `![Ev Sahibi Paneli](screenshots/owner_panel.png)`
> `![Kiracı Paneli](screenshots/tenant_panel.png)`

## Katkıda Bulunmak

Pull request’ler ve issue’lar için her zaman açıktır! Hataları veya önerileri GitHub üzerinden paylaşabilirsiniz.

## Lisans

Bu proje MIT lisansı ile lisanslanmıştır.

---

## Proje Ekibi ve Hakkında

**Proje Ekibi:**

* Büşra Tekdemir
* Hasan Yiğit Akbulut
* Ozan Korkmaz

Manisa Celal Bayar Üniversitesi, Yazılım Mühendisliği 2. sınıf öğrencileriyiz.

**Ders Adı:** Veritabanı Sistemlerine Giriş

Tiny House Management projesi, Veritabanı Sistemlerine Giriş dersi dönem projesi olarak geliştirilmiştir ve gerçek dünya ihtiyaçlarına uygun olarak tasarlanmıştır.

Proje sahibi: [Büşra Tekdemir](https://github.com/busratekdemir)
