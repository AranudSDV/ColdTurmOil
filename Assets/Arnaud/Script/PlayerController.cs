using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask LayerMask;
    [SerializeField] private Camera cam;
    public ItemPickup itempickup;


    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Jumping")]

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float stratYscale;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    void Start()
    {
        //cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

        stratYscale = transform.localScale.y;


    }

    private void Update()
    {

        

        //GROUND CHECK
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.4f, Color.red);

        MyInput();
        SpeedControl();
        StateHandler();

        //HANDLE DRAG
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

       if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1, LayerMask))
            {
                //ItemPickup itempickup = hit.collider.GetComponent<ItemPickup>();
                itempickup.PickUp();

            }
        }
        
       
    }

    private void FixedUpdate()
    {
        Moveplayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //WHEN TO JUMP
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            jump();

            Invoke(nameof(ResteJump), jumpCooldown);
        }

        //START COURCH
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        //STOP CROUCHING
        if (Input.GetKeyUp(crouchKey))
        {
           transform.localScale = new Vector3(transform.localScale.x, stratYscale, transform.localScale.z); 
        }
    }

    private void StateHandler()
    {
        //MODE - CROUCHING
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }

        //MODE - SPRINTING
        else if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        //MODE - WALKING
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        //MODE - AIR
        else
        {
            state = MovementState.air;
        }

    
    }


    private void Moveplayer()
    {
        //CALCULATE MOVEMENT DIRECTION
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //ON GROUND
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        
        //IN AIR
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //LIMIT VELOCITY
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void jump()
    {
        //RESET Y VELOCITY
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResteJump()
    {
        readyToJump = true;
    }
    
    
}
