using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float yerCekimiGucu = 3f;
    private bool oyunBitti = false;
    
    private bool oyunBasladi = false;
    public GameObject baslamaYazisi;
    public Uretici ureticiScripti; 

    public AudioClip ziplamaSesi;
    public AudioClip olmeSesi;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1; 
        
        rb.gravityScale = 0; 
        baslamaYazisi.SetActive(true); 
        ureticiScripti.enabled = false; 
        oyunBasladi = false;
    }

    void Update()
    {
        if (oyunBitti == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return; 
        }

        if (oyunBasladi == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Baslat();
            }
            return; 
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.gravityScale *= -1;
            
            if (ziplamaSesi != null) audioSource.PlayOneShot(ziplamaSesi);
        }

        if (transform.position.y > 10 || transform.position.y < -10)
        {
            OyunuDurdur();
        }
    }

    void Baslat()
    {
        oyunBasladi = true;
        baslamaYazisi.SetActive(false); 
        ureticiScripti.enabled = true;  
        rb.gravityScale = yerCekimiGucu; 
        
        if (ziplamaSesi != null) audioSource.PlayOneShot(ziplamaSesi);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OyunuDurdur();
    }

    void OyunuDurdur()
    {
        if (oyunBitti == false && olmeSesi != null)
        {
             audioSource.PlayOneShot(olmeSesi);
        }

        oyunBitti = true; 
        Time.timeScale = 0; 
    }
}