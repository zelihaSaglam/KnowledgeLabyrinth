using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYoneticisi : MonoBehaviour
{
    // Bir sonraki sahneye geçer
    public void SonrakiSahneyeGec()
    {
        // Önemli: Yeni sahne donuk baþlamasýn diye zamaný akýtýyoruz
        Time.timeScale = 1f;

        int mevcutSahneIndex = SceneManager.GetActiveScene().buildIndex;
        int toplamSahneSayisi = SceneManager.sceneCountInBuildSettings;

        // Eðer bir sonraki sahne varsa geçiþ yap
        if (mevcutSahneIndex + 1 < toplamSahneSayisi)
        {
            SceneManager.LoadScene(mevcutSahneIndex + 1);
        }
        else
        {
            Debug.Log("Zaten son sahnedesiniz!");
            // Ýstersen burada SceneManager.LoadScene(0); diyerek menüye döndürebilirsin.
        }
    }

    // Ýsme göre sahne yükler
    public void SahneYukle(string sahneAdi)
    {
        Time.timeScale = 1f; // Zamaný sýfýrla
        SceneManager.LoadScene(sahneAdi);
    }

    // Oyunu kapatýr
    public void OyunuKapat()
    {
        Application.Quit();
        Debug.Log("Oyun kapatýldý.");
    }
}