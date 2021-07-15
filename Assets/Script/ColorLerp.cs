using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    MeshRenderer cubeMeshRenderer;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] mycolor;
    int colorIndex = 0;
    float t = 0f;
    int len;
    // Start is called before the first frame update
    void Start()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        cubeMeshRenderer.material.color = Color.Lerp(cubeMeshRenderer.material.color, mycolor[colorIndex], lerpTime*Time.deltaTime);
        Debug.Log("Applied");
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        
            Debug.Log("If");
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        
    }
}
