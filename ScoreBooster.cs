using UnityEngine;
using UnityEngine.UI;

public class PuanArtirici : MonoBehaviour
{
    public AudioClip puanSesi;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject yaziObjesi = GameObject.Find("SkorYazisi");
            Text yazi = yaziObjesi.GetComponent<Text>();
            int puan = int.Parse(yazi.text);
            puan++;
            yazi.text = puan.ToString();

            AudioSource kusunSesi = other.gameObject.GetComponent<AudioSource>();
            
            if (puanSesi != null && kusunSesi != null)
            {
                kusunSesi.PlayOneShot(puanSesi);
            }
        }
    }
}