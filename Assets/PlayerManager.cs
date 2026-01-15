using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 respawnPoint; // En son kaydedilen konum
    private CharacterController charController; // Karakterin hareket bileþeni

    void Start()
    {
        // Oyun baþladýðýnda ilk konumu kaydet
        respawnPoint = transform.position;
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Eðer karakter çok aþaðý düþerse (Y ekseni -10'un altýna inerse)
        if (transform.position.y < -10f)
        {
            Respawn();
        }
    }

    // Bu fonksiyonu Checkpoint objeleri çaðýracak
    public void SetRespawnPoint(Vector3 newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("Checkpoint Kaydedildi!");
    }

    void Respawn()
    {
        // Unity'de CharacterController'ý ýþýnlamak için önce kapatýp sonra açmak gerekir
        // Aksi takdirde fizik motoru karakteri eski yerine geri çekebilir.
        Physics.SyncTransforms();
        charController.enabled = false;
        transform.position = respawnPoint;
        charController.enabled = true;
    }
}