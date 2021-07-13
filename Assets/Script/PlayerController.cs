using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public Vector3 lastMousePos;
    public float sensitivity = .16f,clampdelta = 42f,clampforwardSpeed=14f;
    Vector3 steer;
    Vector3 forwardSpeed;


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
             steer = (-moveforce * sensitivity - rb.velocity/25);
           

        }
        else
        {
            steer = Vector3.zero;
        }
        
        rb.AddForce(Vector3.forward +steer , ForceMode.VelocityChange);
        if (rb.velocity.magnitude > clampforwardSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, clampforwardSpeed);
        }


    }
}
