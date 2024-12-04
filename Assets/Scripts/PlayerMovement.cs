using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private Camera cam;
    public float speed = 5f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public bool isGrounded;
    public bool sprinting;
    public Transform groundCheck;
    public float groundDistance;
    //specify layers to use in a raycast
    public LayerMask groundMask;
    public float jumpHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //returns true if there are any colliders overlapping the sphere 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime); //move the character
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 *gravity); 
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Crouch();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            Uncrouch();
        }
        
    }
    public void Sprint()
    {
        sprinting = !sprinting;
        if(sprinting) speed = 8;
        else speed = 5;
    }

    public void Crouch()
    {
        
    }
    public void Uncrouch()
    {
        
    }
}
