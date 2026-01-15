using UnityEngine;
using UnityEngine.SceneManagement;

public class BitisKupKontrol : MonoBehaviour
{
    [Header("Sahne Ayarlarý")]
    [Tooltip("Eðer boþ býrakýrsanýz Build Settings listesindeki bir sonraki sahneye geçer.")]
    public string sonrakiSahneAdi;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bir obje kübe girdi: " + other.name + " Etiketi: " + other.tag);
        // Karakterin Tag'inin "Player" olduðundan emin ol
        if (other.CompareTag("Player") || other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Labirent bitti! Yeni sahneye geçiliyor...");

            // Sahne geçiþinden hemen önce zamaný normale döndür (eðer donma varsa)
            Time.timeScale = 1f;

            // Sahne ismine göre geçiþ yap
            if (!string.IsNullOrEmpty(sonrakiSahneAdi))
            {
                SceneManager.LoadScene(sonrakiSahneAdi);
            }
            else
            {
                // Ýsim verilmemiþse listedeki sýraya (index) göre geçiþ yap
                int mevcutSahneIndex = SceneManager.GetActiveScene().buildIndex;

                // Eðer son sahnede deðilsek bir sonrakine geç
                if (mevcutSahneIndex < SceneManager.sceneCountInBuildSettings - 1)
                {
                    SceneManager.LoadScene(mevcutSahneIndex + 1);
                }
                else
                {
                    Debug.Log("Oyun bitti, baþa dönülüyor!");
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}