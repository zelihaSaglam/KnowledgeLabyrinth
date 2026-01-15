using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    private static MuzikKontrol instance;

    void Awake()
    {
        // Eðer bu objeden zaten bir tane varsa (örneðin 2. sahneden 1. sahneye döndüysen)
        // Ýkinci gelen kopyayý yok et ki müzikler üst üste binmesin.
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        // Bu objenin sahneler arasý geçiþte silinmesini engeller
        DontDestroyOnLoad(gameObject);
    }
}