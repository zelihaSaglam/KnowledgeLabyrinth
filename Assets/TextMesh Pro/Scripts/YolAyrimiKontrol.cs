using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class YolAyrimiKontrol : MonoBehaviour
{
    [Header("Soru Ayarlarý")]
    [TextArea(3, 10)]
    public string soruMetni;
    public string[] siklar = new string[4];
    public int dogruCevapIndexi; // 0, 1, 2 veya 3

    [Header("Kapýlar")]
    public GameObject dogruYolKapisi;
    public GameObject yanlisYolKapisi;

    [Header("UI Referanslarý")]
    public GameObject soruPaneli;
    public TextMeshProUGUI soruText;
    public Button[] cevapButonlari;

    [Header("Ses Ayarlarý")]
    public AudioSource soruMuzigi; // Soru Paneline eklediðin AudioSource'u buraya sürükle

    private bool soruSorulduMu = false;

    private void OnTriggerEnter(Collider other)
    {
        // Karakterin ana objesinin tag'ini kontrol eder
        if (other.transform.root.CompareTag("Player") && !soruSorulduMu)
        {
            Debug.Log("Oyuncu algýlandý, soru getiriliyor...");
            SoruGetir();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Oyuncu küpten çýktýðýnda, tekrar girdiðinde panelin açýlmasýna izin ver
        if (other.transform.root.CompareTag("Player"))
        {
            soruSorulduMu = false;
        }
    }

    void SoruGetir()
    {
        soruSorulduMu = true;
        soruPaneli.SetActive(true);
        soruText.text = soruMetni;

        // --- SES VE OYUN DURDURMA ---
        if (soruMuzigi != null) soruMuzigi.Play();
        Time.timeScale = 0f; // Oyunu duraklat (Ayak seslerini de keser)

        // Fareyi serbest býrak
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        for (int i = 0; i < cevapButonlari.Length; i++)
        {
            int index = i;
            cevapButonlari[i].GetComponentInChildren<TextMeshProUGUI>().text = siklar[i];
            cevapButonlari[i].onClick.RemoveAllListeners();
            cevapButonlari[i].onClick.AddListener(() => CevapVer(index));
        }
    }

    public void CevapVer(int secilenIndex)
    {
        // --- SES VE OYUNU DEVAM ETTÝRME ---
        if (soruMuzigi != null) soruMuzigi.Stop();
        Time.timeScale = 1f; // Oyunu devam ettir

        if (secilenIndex == dogruCevapIndexi)
        {
            Debug.Log("Doðru cevap! Yol açýldý.");
            KapiKontrol(dogruYolKapisi, false);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Yanlýþ cevap! Diðer yol açýldý.");
            KapiKontrol(yanlisYolKapisi, false);
        }

        // Paneli kapat ve fareyi tekrar oyuna kilitle
        soruPaneli.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void KapiKontrol(GameObject kapi, bool durum)
    {
        if (kapi != null)
        {
            kapi.SetActive(durum);
        }
    }
}