# 👻 GHOST CURSOR & HUNTER (HAYALET VE AVCI)

> **C# ve Win32 API ile Geliştirilmiş Şaka ve Sistem Yönetimi Aracı**

Bu proje, **C#** ve **Windows API (Win32 API)** kullanılarak sistem kaynaklarının (fare imleçlerinin) nasıl manipüle edilebileceğini gösteren, eğitim amaçlı geliştirilmiş bir uygulamadır.

---

## 🎯 PROJENİN AMACI

1.  **Hayalet (Ghost):** Windows API kullanarak fare imlecini sistem genelinde **görünmez** yapmak.
2.  **Avcı (Hunter):** Bozulan sistem ayarlarını tetikleyerek imleci **geri getirmek**.

*Bu proje; DLL Import, Bellek Yönetimi ve Sistem Çağrıları konularını öğrenmek için tasarlanmıştır.*

---

## 🚀 ÖZELLİKLER

* ✅ **Win32 API Entegrasyonu:** `user32.dll` kütüphanesi ile çekirdek erişimi.
* ✅ **Görünmez Çalışma:** Form arayüzü olmadan (No-GUI) arka planda çalışma mantığı.
* ✅ **Global Etki:** Sadece program içinde değil, tüm Windows genelinde etki etme.
* ✅ **Acil Durum Kurtarıcısı:** Tek tuşla sistemi fabrika ayarlarına döndüren onarıcı modül.

---

## 🛠️ KULLANILAN TEKNOLOJİLER

| Teknoloji | Açıklama |
| :--- | :--- |
| **Dil** | C# |
| **Framework** | .NET Framework 4.7.2+ |
| **Platform** | Windows Forms (WinForms) |
| **Kütüphane** | `user32.dll` (Windows API) |

---

## 📂 PROJE DETAYLARI VE KODLAR

### 1️⃣ Hayalet Modülü (Virüs/Şaka)
Bu modül çalıştığında ekrana hiçbir şey gelmez. Arka planda `SetSystemCursor` fonksiyonunu kullanarak Windows'un standart imleçlerini şeffaf bir görselle değiştirir.

**Örnek Kod Yapısı:**
```csharp
[DllImport("user32.dll")]
static extern bool SetSystemCursor(IntPtr hcur, uint id);

// İmleci değiştiren fonksiyon çağrısı
SetSystemCursor(hIcon, 32512); // 32512 = Normal Ok
