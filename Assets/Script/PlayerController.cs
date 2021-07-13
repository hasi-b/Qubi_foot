using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public Vector3 lastMousePos;
    public float sensitivity = .16f,clampdelta = 42f;

    public float bounds = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }


        if (Input.GetMouseButton(0))
        {
            Vector3 vector = lastMousePos - Input.mousePosition;
            lastMousePos = Input.mousePosition;
            vector = new Vector3(vector.x, 0, 0);
            Vector3 moveforce = Vector3.ClampMagnitude(vector, clampdelta);
            rb.AddForce(Vector3.forward * 2 + (-moveforce * sensitivity - rb.velocity / 5), ForceMode.VelocityChange);

        }
    }
}
