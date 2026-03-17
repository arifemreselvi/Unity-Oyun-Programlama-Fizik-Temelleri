# 🎱 Unity Oyun Programlama - Fizik Temelleri

Bu proje, Unity oyun motoru kullanılarak fiziğin dört temel kavramını (Uzay, Madde, Hareket ve Zaman) kapsayan bir bilardo simülasyonudur.

## 🛠️ Proje Detayları
* **Geliştirici:** Arif Emre Selvi
* **Bölüm:** Yönetim Bilişim Sistemleri 2. Sınıf
* **Oyun Motoru:** Unity
* **Konsept:** Fizik Temelli Bilardo Oyunu

## ⚙️ Teknik Özellikler ve Mekanikler
* **Kuş Bakışı Kamera:** Oyuncuya tam hakimiyet sağlayan üst açı (Top-Down) kamera sistemi.
* **Gelişmiş Istaka Kontrolü:** Yön tuşlarıyla beyaz top etrafında yörüngesel hareket.
* **Kuvvet Uygulama (Force):** Space tuşuna basılı tutma süresine göre dinamik vuruş gücü ve ıstaka gerilme animasyonu.
* **Çarpışma ve Yok Etme:** Hedef topların "delik" tag'ine sahip objelerle teması anında sahneden silinmesi.
* **Fizik Optimizasyonu:** Hızlı giden topların masadan çıkmaması için mesh renderer'ı kapalı görünmez bariyerler.

## 💻 Öne Çıkan Kod Blokları 
(Delik Yok Etme)
```csharp
void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("delik")) {
        Destroy(gameObject);
    }
}
```
(Isteka Kontrol)
```csharp
public Rigidbody beyazTop;

public float donmeHizi = 20f;

public float yaklasmaHizi = 3f;

private float vurmaGucu = 0f;

private bool vurulacakMi = false;

private float cekilmeMiktari = 0f;


void Start()

{

GetComponent<Collider>().isTrigger = true;

}


void Update()

{

float donme = Input.GetAxis("Horizontal");

transform.RotateAround(beyazTop.position, Vector3.up, donme * donmeHizi * Time.deltaTime);


transform.LookAt(beyazTop.position);

transform.Rotate(90, 0, 0);


float yaklasma = Input.GetAxis("Vertical");

transform.Translate(Vector3.up * yaklasma * yaklasmaHizi * Time.deltaTime);


if (Input.GetKey(KeyCode.Space))

{

if (vurmaGucu < 100f)

{

vurmaGucu += 50f * Time.deltaTime;

float cekilme = 2f * Time.deltaTime;

transform.Translate(Vector3.down * cekilme);

cekilmeMiktari += cekilme;

}

}


if (Input.GetKeyUp(KeyCode.Space))

{

vurulacakMi = true;

transform.Translate(Vector3.up * (cekilmeMiktari + 1.2f));

cekilmeMiktari = 0f;

}

}


void FixedUpdate()

{

if (vurulacakMi)

{

// lowkey mesafe sınırını 10f yaptık ki geriden vurunca da işlesin

float mesafe = Vector3.Distance(transform.position, beyazTop.position);

if (mesafe < 10f)

{

Vector3 vurusYonu = (beyazTop.position - transform.position).normalized;

vurusYonu.y = 0;

beyazTop.AddForce(vurusYonu * vurmaGucu, ForceMode.Impulse);

}

vurmaGucu = 0f;

vurulacakMi = false;

}

}

} 
```
## 📺 Proje Tanıtım Videosu
[![Unity Oyun Programlama - Çarpışma Etkileşimi](https://i.ytimg.com/vi/sQvjR9IG9yM/hqdefault.jpg?sqp=-oaymwE2CNACELwBSFXyq4qpAygIARUAAIhCGAFwAcABBvABAfgB1AaAAuADigIMCAAQARhcIFwoXDAP&rs=AOn4CLC4-yOgGD_DIDECd4AC8x87PlCBXQ)](https://www.youtube.com/watch?v=sQvjR9IG9yM&t=6s)
