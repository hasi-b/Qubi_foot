using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private static int obstacleCount = 2;
    [SerializeField]
   // private GameObject[] obstacles = new GameObject[obstacleCount] ;
    private GameObject[] spawnPoints;
    GameObject parentSpawner;
    GameObject cone;
    GameObject post;
    
    // Start is called before the first frame update
    void Start()
    {
        cone = (GameObject)Instantiate(Resources.Load("LP_Cone"));
        post = (GameObject)Instantiate(Resources.Load("Post"));
        parentSpawner = GameObject.FindGameObjectWithTag("Spawner");

        for(int i = 0; i < 3; i++)
        {
            spawnPoints[i] = 
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
