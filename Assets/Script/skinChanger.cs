using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinChanger : MonoBehaviour
{
    public int testint= 0;
    public static int skinCount = 3;
    private int mat_ID;
    public Material[] materials = new Material[skinCount];
    Material[] finalMat = new Material[2];
    public GameObject player;
    MeshRenderer ms;
    Renderer rs;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GOOOT"+PlayerPrefs.GetInt("Skin Number"));

         getmaterialID(PlayerPrefs.GetInt("Skin Number"));

        ms = GetComponent<MeshRenderer>();

       // getmaterialID(testint);
        assignMaterial(mat_ID);


    }

    public void getmaterialID(int i)
    {
        mat_ID = i;
    }

    private void assignMaterial(int i)
    {
        // player.GetComponent<MeshRenderer>().materials[0] = materials[i];

        finalMat[0] = materials[i];
        finalMat[1] = ms.materials[1];
        ms.materials = finalMat;
        Debug.Log("Player MAt"+ms.materials[0]);
        Debug.Log("Material Name: "+materials[i].name);
    }

    private void Update()
    {
       
    }

    // Update is called once per frame

}
