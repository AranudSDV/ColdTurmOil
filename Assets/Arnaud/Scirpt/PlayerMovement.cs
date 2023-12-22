using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 7f;
    public float sprintSpeed = 10f;
    public float crouchSpeed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    
    
    public ItemPickup itempickup;
    public LayerMask itemMask;
    public LayerMask codeMask;
    public LayerMask LecteurMask;

    

    public Transform groundCheck;
    public float groundDistance =0.4f;
    public LayerMask groundMask;
    public GameObject icamera;
    public float rangePickUp;

    bool isGrounded;
    bool isCrouching;
    bool itemInrange;

    Vector3 velocity;

    public TextMeshProUGUI textPickup;

    private Door door;
    
    void Start()
    {
        
    }

   
    void Update()
    {

       

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        isCrouching = false;


        if (isCrouching == false)
        {
            Vector3 scale = gameObject.GetComponent<Collider>().transform.localScale;
            scale.y = 1f;
            gameObject.GetComponent<Collider>().transform.localScale = scale;
        }
        //Crouch
        if(Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            controller.Move(move * crouchSpeed * Time.deltaTime);
            Vector3 scale = gameObject.GetComponent<Collider>().transform.localScale;
            scale.y *= 0.5f;
            gameObject.GetComponent<Collider>().transform.localScale = scale;
        }

        RaycastHit hit;
        

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, itemMask))
        {

            //itempickup.PickUp();
            if(Input.GetMouseButtonDown(0))
            {
                hit.transform.GetComponent<ItemPickup>().PickUp();
            }
            
            textPickup.text = "Ramassez " + hit.transform.name;

        }

        else
        {
            textPickup.text = "";
        }

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, codeMask))
        {

            //itempickup.PickUp();
            if(Input.GetMouseButtonDown(0))
            {
                hit.transform.GetComponent<Keypad>().CheckHitObj();
            }
            

            
        }

        
        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, LecteurMask))
        {
            
            if(Inventory.instance.HasObject("Blue Card") == true && Input.GetMouseButtonDown(0))
            {
                hit.transform.GetComponent<Door>().plateformIsMoving = true;
                //door.plateformIsMoving = true; //la plateforme se deplace
                Debug.Log("scitp porte marche");
            }
        }
        

        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);
        }

    }
}