using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnTile();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnTile()
    {
      GameObject temp =   Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

}
