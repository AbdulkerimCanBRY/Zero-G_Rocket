using UnityEngine;

public class ArkaPlanKaydirma : MonoBehaviour
{
    public float hiz = 2f;
    public float kacResimVar = 3f;
    
    private float resimGenisligi;

    void Start()
    {
        resimGenisligi = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * hiz * Time.deltaTime);

        if (transform.position.x < -resimGenisligi)
        {
            float sicramaMesafesi = resimGenisligi * kacResimVar;
            
            Vector3 yeniKonum = new Vector3(transform.position.x + sicramaMesafesi - 4f, transform.position.y, transform.position.z);
            transform.position = yeniKonum;
        }
    }
}