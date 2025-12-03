using UnityEngine;
using UnityEngine.UI;

public class PuanArtirici : MonoBehaviour
{
    public AudioClip puanSesi; 

    void Start()
    {
        RekoruGuncelle();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject skorObjesi = GameObject.Find("SkorYazisi");
            Text skorText = skorObjesi.GetComponent<Text>();
            
            int anlikPuan = int.Parse(skorText.text);
            anlikPuan++;
            skorText.text = anlikPuan.ToString();

            int eskiRekor = PlayerPrefs.GetInt("Rekor", 0);

            if (anlikPuan > eskiRekor)
            {
                PlayerPrefs.SetInt("Rekor", anlikPuan);
                
                RekoruGuncelle();
            }

            AudioSource kusunSesi = other.gameObject.GetComponent<AudioSource>();
            if (puanSesi != null && kusunSesi != null)
            {
                kusunSesi.PlayOneShot(puanSesi);
            }
        }
    }

    void RekoruGuncelle()
    {
        GameObject rekorObjesi = GameObject.Find("RekorYazisi");
        if (rekorObjesi != null)
        {
            int rekor = PlayerPrefs.GetInt("Rekor", 0);
            rekorObjesi.GetComponent<Text>().text = "Record score: " + rekor;
        }
    }
}