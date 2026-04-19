using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed*Time.deltaTime, transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("invis"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().updateScore(200);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Left"))
        {
            Destroy(gameObject);
        }
    }
    
}
