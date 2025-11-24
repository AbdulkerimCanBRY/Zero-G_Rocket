using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float yerCekimiGucu = 3f;
    private bool oyunBitti = false;

    public AudioClip ziplamaSesi;
    public AudioClip olmeSesi;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1; 
        rb.gravityScale = yerCekimiGucu;
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.gravityScale *= -1;
            
            if (ziplamaSesi != null) 
            {
                audioSource.PlayOneShot(ziplamaSesi);
            }
        }

        if (transform.position.y > 10 || transform.position.y < -10)
        {
            OyunuDurdur();
        }
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