using UnityEngine;
using UnityEngine.SceneManagement; // Sahneyi yeniden yüklemek için

public class SoruKutusu : MonoBehaviour
{
    public GameObject soruPaneli; // Az önce yarattýðýmýz Panel
    public GameObject oyuncu;     // Karakterimiz

    // Oyuncu görünmez kutuya çarpýnca çalýþýr
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoruSor();
        }
    }

    void SoruSor()
    {
        soruPaneli.SetActive(true); // Paneli aç
        Time.timeScale = 0f; // Oyunu dondur (Zamaný durdur)

        // Mouse imlecini serbest býrak (Týklayabilmek için)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Bu fonksiyonu DOÐRU butonuna baðlayacaðýz
    public void DogruCevap()
    {
        Time.timeScale = 1f; // Zamaný tekrar baþlat
        soruPaneli.SetActive(false); // Paneli kapat

        // Mouse'u tekrar kilitle (Oyuna devam etmek için)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Soruyu bir daha sormamasý için bu kutuyu yok et
        Destroy(gameObject);
    }

    // Bu fonksiyonu YANLIÞ butonuna baðlayacaðýz
    public void YanlisCevap()
    {
        Time.timeScale = 1f;
        // Yanlýþ bilinirse bölüm yeniden baþlasýn (Ceza)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}