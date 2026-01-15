using UnityEngine;

public class AyakSesiKontrol : MonoBehaviour
{
    private AudioSource sesKaynagi;
    private CharacterController kontrolcu;

    void Start()
    {
        // Karakterin üzerindeki bileþenleri buluyoruz
        sesKaynagi = GetComponent<AudioSource>();
        kontrolcu = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Karakter yerde mi ve hýzý 0.1'den büyük mü? (Yani hareket ediyor mu?)
        if (kontrolcu.isGrounded && kontrolcu.velocity.magnitude > 0.1f)
        {
            // Eðer ses þu an çalmýyorsa çalmaya baþla
            if (!sesKaynagi.isPlaying)
            {
                sesKaynagi.Play();
            }
        }
        else
        {
            // Karakter durduysa sesi durdur
            if (sesKaynagi.isPlaying)
            {
                sesKaynagi.Stop();
            }
        }
    }
}