using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTIle : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            groundSpawner.spawnTile();
            Debug.Log("Spawned");
            Destroy(gameObject, 2);
            Debug.Log("Previous Destroyed");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
