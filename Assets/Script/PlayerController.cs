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
    bool isGrounded;
    public LayerMask groundLayer;
    public float jumpForce = 5f;
    private const float doubleTapTime = 2f;
    public float bounds = 5;
    public SphereCollider col;
    private float lastTapTime=0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {

            

            lastMousePos = Input.mousePosition;
            
            float timeSinceLastTap = Time.time - lastTapTime;

            
            Debug.Log("lastLapTime"+ lastTapTime);
            Debug.Log("timeSinceLapTime" + timeSinceLastTap);
            

            if (isGrounded && (timeSinceLastTap<doubleTapTime))
            {
               Jump();
                isGrounded = false;
            }
            lastTapTime = Time.time;

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
    void Jump()
    {
        Vector3 vectory = new Vector3(0, jumpForce, 0);
        rb.AddForce(vectory, ForceMode.Impulse);
    }

   private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayer);


       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}
