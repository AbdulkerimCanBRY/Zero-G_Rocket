using UnityEngine;
public class BoruHareketi : MonoBehaviour
{
    public float hiz = 3f;
    void Update()
    {
        transform.Translate(Vector3.left * hiz * Time.deltaTime);
        
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}