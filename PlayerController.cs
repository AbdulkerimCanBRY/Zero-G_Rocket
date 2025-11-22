using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float yerCekimiGucu = 3f;
    
    private bool oyunBitti = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

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
        oyunBitti = true;
        Time.timeScale = 0;
    }
}