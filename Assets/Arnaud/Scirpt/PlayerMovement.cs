using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMOD.Studio;

public class PlayerMovement : MonoBehaviour
{
    //son pied
    
    private enum CURRENT_TERRAIN { STEEL, SNOW, CONCRETE, CARPET};
    public float timer = 0.0f;
    [SerializeField]
    float footstepSpeed = 0.3f;
    
    private CURRENT_TERRAIN currentTerrain;
    private FMOD.Studio.EventInstance Footsteps;
    public GameObject player;
    public bool footstepsound = false;
    //son pied
    


    public CharacterController controller;

    public float speed = 5f;
    public float sprintSpeed = 7f;
    public float crouchSpeed = 1f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    
    
    public ItemPickup itempickup;
    public LayerMask itemMask;
    public LayerMask codeMask;
    public LayerMask LecteurMask;
    public LayerMask LecteurForage;
    public LayerMask LecteurBoutton;
    public LayerMask LecteurYellow;
    public LayerMask Pipe;
  

    public Transform groundCheck;
    public float groundDistance = 0.1f ;

    public LayerMask groundMaskSteel;
    public LayerMask groundMaskSnow;
    public LayerMask groundMaskConcrete;
    public LayerMask groundMaskCarpet;

    public bool IsWalking = false;
    public bool isGroundedSteel = false;
    public bool isGroundedSnow = false;
    public bool isGroundedConcrete = false;
    public bool isGroundedCarpet = false;
    public bool IsGrounded = false;

    public GameObject icamera;
    public float rangePickUp;

    public Transform headCheck;
    public float headDistance = 2f;
    public LayerMask headMask;


    public bool isBlocked = false;
    public bool isCrouching;
    public bool itemInrange;

    private bool rayHit3;
    private bool rayHitPipe;
    

    Vector3 velocity;

    public TextMeshProUGUI textPickup;


    public BouttonDoor bouttonDoor;
    public Door door;
    public PorteForage porteForage;

    //audio
    //private EventInstance footsteps;
    
    private void Start()
    {
        

    }

    
   
    void Update()
    {

       //UpdateSound();

        isGroundedSteel = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskSteel);
        isGroundedSnow = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskSnow);
        isGroundedConcrete = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskConcrete);
        isGroundedCarpet = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskCarpet);

        if(isGroundedCarpet || isGroundedConcrete || isGroundedSnow || isGroundedSteel)
        {
            IsGrounded = true;
            
        }

        if(velocity.y < 0 && IsGrounded)
        {
            
            velocity.y = -2f;
            
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 )
        {
            IsWalking = true;
            Debug.Log("Player Movement IsWalking");
            
        }
        else
        {
            IsWalking = false;
            
        }

        

        if(Input.GetButtonDown("Jump") && IsGrounded)
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }    


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        isCrouching = false;

        isBlocked = Physics.CheckSphere(headCheck.position, headDistance, headMask);

        //Crouch
        if(Input.GetKey(KeyCode.F))
        {
            isCrouching = true;
            
        }

        if(isBlocked == true)
        {
            isCrouching = true;
        }

        
        if (isCrouching == true)
        {
            controller.Move(move * crouchSpeed * Time.deltaTime);
            Vector3 scale = gameObject.GetComponent<Collider>().transform.localScale;
            scale.y *= 0.5f;
            gameObject.GetComponent<Collider>().transform.localScale = scale;
        }


        if (isCrouching == false)
        {
            Vector3 scale = gameObject.GetComponent<Collider>().transform.localScale;
            scale.y = 1f;
            gameObject.GetComponent<Collider>().transform.localScale = scale;
            controller.Move(move * speed * Time.deltaTime);
        }
        

        
        

        RaycastHit hit;
        

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, itemMask))
        {

            //itempickup.PickUp();
            if(Input.GetMouseButtonDown(0))
            {
                hit.transform.GetComponent<ItemPickup>().PickUp();
                AudioManager.instance.PlayOneShot(FMODEvent.instance.itempickupSound, this.transform.position);

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
            
            if(Input.GetMouseButtonDown(0))
            {
             hit.transform.GetComponent<Door>().rayHit = true;
            }

            else
            {
             hit.transform.GetComponent<Door>().rayHit = false;
            }
            
        }

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, LecteurYellow))
        {
            
            if(Input.GetMouseButtonDown(0))
            {
             hit.transform.GetComponent<LastEpreuve>().rayHitCard = true;
            }

            else
            {
             hit.transform.GetComponent<LastEpreuve>().rayHitCard = false;
            }
            
        }

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, LecteurBoutton))
        {
            
            if(Input.GetMouseButtonDown(0))
            {
             //Debug.Log("raycastbouttonM");
             hit.transform.GetComponent<BouttonDoor>().rayHitt = true;
            }

            else
            {
             hit.transform.GetComponent<BouttonDoor>().rayHitt = false;
            }
            
        }

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, LecteurForage))
        {
        
           if(Input.GetMouseButtonDown(0))
           {
             hit.transform.GetComponent<PorteForage>().rayHit2 = true;
           }

           else
           {
             hit.transform.GetComponent<PorteForage>().rayHit2 = false;
           }

        }  


            
        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, Pipe))
        {
        
           if(Input.GetMouseButtonDown(0))
           {
             hit.transform.GetComponent<PipeScript>().rayHitPipe = true;
             //Debug.Log("RayHit Player script " + hit.transform.name);
           }
           else 
           {
             hit.transform.GetComponent<PipeScript>().rayHitPipe = false;
           }
           

        }  
            
        
        
        

        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);
        }

        controller.Move(move * speed * Time.deltaTime);

        //son pied

        if(IsGrounded)
        {
            Debug.Log("PlayerFootSteps Isgrounded");
        }

        DetermineTerrain();

        if (IsGrounded && IsWalking)
        {
            
            PLAYBACK_STATE playbackState;
            Footsteps.getPlaybackState(out playbackState);

            //if (timer > footstepSpeed)
            //{
                if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
                {
                 SelectAndPlayFootsteps();
                 Debug.Log("playbakc state ");
                 footstepsound = true;
                }
                //timer = 0.0f;
            //}

            //timer += Time.deltaTime;

        }
        else
        {
            footstepsound = false;
            Debug.Log("Foot steps false");
            //Footsteps.stop();
        }
        
        



    }
    

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(this.transform.position, Vector3.down, 5f);

        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Steel"))
            {
                currentTerrain = CURRENT_TERRAIN.STEEL;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Snow"))
            {
                currentTerrain = CURRENT_TERRAIN.SNOW;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Concrete"))
            {
                currentTerrain = CURRENT_TERRAIN.CONCRETE;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Carpet"))
            {
                currentTerrain = CURRENT_TERRAIN.CARPET;
                break;
            }
        }
    }

    public void SelectAndPlayFootsteps()
    {
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.STEEL:

                PlayFootstep(0);
                break;
                
            case CURRENT_TERRAIN.SNOW:

                PlayFootstep(1);
                break;
                
            case CURRENT_TERRAIN.CONCRETE:
                PlayFootstep(2);
                break;
                
            case CURRENT_TERRAIN.CARPET:
                PlayFootstep(3);
                break;
                
        }
    }

    private void PlayFootstep(int terrain)
    {
        Footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/character/Footsteps");
        Footsteps.setParameterByName("Terrain", terrain);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Footsteps, transform, false);
        Footsteps.start();
        Footsteps.release();
        
    }

}