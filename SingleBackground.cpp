using UnityEngine;

public class TekliArkaPlan : MonoBehaviour
{
    public float hiz = 0.5f; 
    
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float offset = Time.time * hiz;
        

        mat.mainTextureOffset = new Vector2(offset, 0);
    }
}