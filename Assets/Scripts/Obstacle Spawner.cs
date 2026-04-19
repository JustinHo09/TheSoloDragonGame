using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] airObstacles;
    public GameObject[] groundObstacles;
    public GameObject[] locations;

    private float difficultyTimer;
    private int difficulty;
    private float spawnTimer;
    private int  minOb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        difficulty = 1;
        minOb = 1;
    }

    // Update is called once per frame
    void Update()
    {
        difficultyTimer = Time.time;
        if (difficultyTimer >= 60 * difficulty) {
            difficulty++;
            minOb++;
            if(minOb >= locations.Length)
            {
                minOb = locations.Length - 1;
            }
        }
        spawnTimer = Time.time;
        if (spawnTimer >= 1.6f - difficulty / 10.0f)
        {
            int rand = Random.Range(minOb,locations.Length);
            // make a random amount of obstacles
            for (int i = 0; minOb < rand; i++)
            {
                int loc = Random.Range(0, locations.Length);
                if (loc == 0)
                {
                    int ground = Random.Range(0, groundObstacles.Length);
                    Instantiate(groundObstacles[ground],locations[loc].transform.position,Quaternion.identity);
                }
                else
                {
                    int air = Random.Range(0, airObstacles.Length);
                    Instantiate(airObstacles[air],locations[loc].transform.position,Quaternion.identity);
                }
                //Instantiate a random object at a random location
            }
            spawnTimer = 0.0f;
        }
    }
}
