using UnityEngine;

public class Uretici : MonoBehaviour
{
    public GameObject boruKalibi;
    public float sureSayaci = 2f;
    private float zaman;

    void Update()
    {
        if (zaman <= 0)
        {
            BoruUret();
            zaman = sureSayaci;
        }
        else
        {
            zaman -= Time.deltaTime;
        }
    }

    void BoruUret()
    {
        float rastgeleY = Random.Range(-2f, 2f);
        
        Vector3 yeniKonum = new Vector3(transform.position.x, rastgeleY, 0);

        Instantiate(boruKalibi, yeniKonum, Quaternion.identity);
    }
}