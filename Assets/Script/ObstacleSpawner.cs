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
    GameObject spawn1, spawn2, spawn3;
    // Start is called before the first frame update
    void Start()
    {
        cone = (GameObject)Instantiate(Resources.Load("LP_Cone"));
        post = (GameObject)Instantiate(Resources.Load("Post"));

        spawn1 = gameObject.transform.GetChild(0).gameObject;
        spawn2 = gameObject.transform.GetChild(1).gameObject;
        spawn3 = gameObject.transform.GetChild(2).gameObject;
        Instantiate(cone, spawn1.transform.position, Quaternion.identity);
        Instantiate(cone, spawn2.transform.position, Quaternion.identity);
        Instantiate(cone, spawn3.transform.position, Quaternion.identity);
        // parentSpawner = GameObject.FindGameObjectWithTag("Spawner");


        /*  for(int i = 0; i < 3; i++)
          {
              spawnPoints[i] = gameObject.transform.GetChild(i).gameObject;
              Instantiate(cone,spawnPoints[i].transform.position,Quaternion.identity);
          }
        */



    }

    
}
