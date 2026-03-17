# 🎱 Unity Oyun Programlama - Fizik Temelleri

Bu proje, Unity oyun motoru kullanılarak fiziğin dört temel kavramını (Uzay, Madde, Hareket ve Zaman) kapsayan bir bilardo simülasyonudur.

## 🛠️ Proje Detayları
* **Geliştirici:** Arif Emre Selvi
* **Bölüm:** Yönetim Bilişim Sistemleri 2. Sınıf
* **Oyun Motoru:** Unity
* **Konsept:** Fizik Temelli Bilardo Oyunu

## ⚙️ Mekanikler
* **Kuş Bakışı Kamera:** Oyuncuya tam hakimiyet sağlayan üst açı (Top-Down) kamera sistemi.
* **Gelişmiş Istaka Kontrolü:** Yön tuşlarıyla beyaz top etrafında yörüngesel hareket.
* **Kuvvet Uygulama (Force):** Space tuşuna basılı tutma süresine göre dinamik vuruş gücü.
* **Fizik Optimizasyonu:** Hızlı giden topların masadan çıkmaması için görünmez bariyerler.

## 💻 Öne Çıkan Kod Blokları (Delik Yok Etme)
```csharp
void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("delik")) {
        // Hedef top deliğe girince yok edilir
        Destroy(gameObject);
    }
}
```
## 📺 Proje Tanıtım Videosu
[![Unity Oyun Programlama - Çarpışma Etkileşimi](https://img.youtube.com/watch?v=sQvjR9IG9yM/hqdefault.jpg)](https://www.youtube.com/watch?v=sQvjR9IG9yM)