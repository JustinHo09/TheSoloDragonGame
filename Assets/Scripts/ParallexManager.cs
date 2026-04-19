using UnityEngine;

public class ParallexManager : MonoBehaviour
{
    
    public float speed;

    private Material bg;
    
    private float currentOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bg = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        currentOffset += speed * Time.deltaTime;
    bg.mainTextureOffset = new Vector2(currentOffset, 0.0f);
    }
}
