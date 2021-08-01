using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    private static int obstacleCount = 2;
    private static int spawnCounts = 3;
  
   // private GameObject[] obstacles = new GameObject[obstacleCount] ;
    private GameObject[] spawnPoints = new GameObject[spawnCounts];
    GameObject parentSpawner;
    GameObject cone;
    GameObject post;
    GameObject spawn1, spawn2, spawn3;
    int postCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        cone = (GameObject)Resources.Load("LP_Cone");
        post = (GameObject)Resources.Load("Post");

       /* spawn1 = gameObject.transform.GetChild(0).gameObject;
        spawn2 = gameObject.transform.GetChild(1).gameObject;
        spawn3 = gameObject.transform.GetChild(2).gameObject;
        Instantiate(cone, spawn1.transform.position, Quaternion.identity);
        Instantiate(cone, spawn2.transform.position, Quaternion.identity);
        Instantiate(cone, spawn3.transform.position, Quaternion.identity);
        // parentSpawner = GameObject.FindGameObjectWithTag("Spawner");
       */

            
          for(int i = 0; i < spawnCounts; i++)
          {
            
              spawnPoints[i] = gameObject.transform.GetChild(i).gameObject;
            //Random.state = System.DateTime.Now.Millisecond;
            int Randomize = Random.Range(1,5);
           // Debug.Log("RAnodmize"+Randomize);
            bool rndbool=Random.value > 0.5; 
            
            if (!rndbool)
            {


                Instantiate(cone, spawnPoints[i].transform.position, Quaternion.identity);
            }
            if(rndbool && postCount==0)
            {
                Instantiate(post, spawnPoints[i].transform.position, Quaternion.identity);
                postCount = 1;
            }
            else
            {
                Instantiate(cone, spawnPoints[i].transform.position, Quaternion.identity);
            }
          }
        



    }

    
}
