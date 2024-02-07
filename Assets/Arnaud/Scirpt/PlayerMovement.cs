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
    //float footstepSpeed = 0.3f;
    
    
    private CURRENT_TERRAIN currentTerrain;
    private CURRENT_TERRAIN previousTerrain;
    private FMOD.Studio.EventInstance Footsteps;
    private FMOD.Studio.EventInstance AmbiantEnviro;
    public GameObject player;
    
    //son Ambiant

    public GameObject SonOutside;
    public GameObject SonTuto;
    public GameObject SonMine;


    
    
    


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
    public LayerMask postit;
    public LayerMask postit2;
    public LayerMask postit3;
    public LayerMask postit4;
    public LayerMask lore;

    public GameObject Lore;
    private bool Loreb = false;


  

    public Transform groundCheck;
    public float groundDistance = 0.1f ;
    public float LocationDistance = 20f ;

    public LayerMask groundMaskSteel;
    public LayerMask groundMaskSnow;
    public LayerMask groundMaskConcrete;
    public LayerMask groundMaskCarpet;


    public string tagMineName;
    public string tagTutoName;
    public string tagExterieurName;
    

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
    private bool rayHitPostit;
    

    Vector3 velocity;

    public TextMeshProUGUI textPickup;
    public TextMeshProUGUI TextePostit;
    public TextMeshProUGUI TextePostit2;
    public TextMeshProUGUI TextePostit3;
    public TextMeshProUGUI TextePostit4;

    


    public Door door;
    public PorteForage porteForage;

    public GameObject Postit1;
    public GameObject Postit2;
    public GameObject Postit3;


    

    
    
    private void Start()
    {
        SonOutside.SetActive(false);
        SonTuto.SetActive(false);
        SonMine.SetActive(false);
    }

    
   
    void Update()
    {

        RaycastHit hitTag;
        

       //UpdateSound();
       

        isGroundedSteel = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskSteel);
        isGroundedSnow = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskSnow);
        isGroundedConcrete = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskConcrete);
        isGroundedCarpet = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskCarpet);



        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hitTag, LocationDistance))
        {
            if(hitTag.transform.gameObject.tag == "Exterieur")
            {
                SonOutside.SetActive(true);
            }
            else
            {
                SonOutside.SetActive(false);
            }
            
        }

       
       
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hitTag, LocationDistance))
        {
            if(hitTag.transform.gameObject.tag == "Tuto")
            {
                SonTuto.SetActive(true);
            }
            else
            {
                SonTuto.SetActive(false);
            }
        }

       
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hitTag, LocationDistance))
        {
            if(hitTag.transform.gameObject.tag == "Mine")
            {
                SonMine.SetActive(true);
            }
            else
            {
                SonMine.SetActive(false);
            }
        }

        if(isGroundedCarpet || isGroundedConcrete || isGroundedSnow || isGroundedSteel)
        {
            IsGrounded = true;   
        }
        else
        {
            IsGrounded = false;
        }

        if(IsGrounded && velocity.y < 0)
        {
            
            velocity.y = -2;
            
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        

        if(Input.GetButtonDown("Jump") && IsGrounded)
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }    


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        isCrouching = false;

        isBlocked = Physics.CheckSphere(headCheck.position, headDistance, headMask);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 )
        {
            IsWalking = true;
            //Debug.Log("Player Movement IsWalking");
            
        }
        else
        {
            IsWalking = false;
        }

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
            scale.y = 0.5f;
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

            textPickup.text = "Carte magnetique bleue necessaire";
            
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

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, postit))
        {
            TextePostit.text = "Clique gauche pour recuperer morceau du code";
            if(Input.GetMouseButtonDown(0))
            {
             Postit1.SetActive(true);
            }
           
        }
        else
        {
            TextePostit.text = "";
        }

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, postit2))
        {
            TextePostit2.text = "Clique gauche pour recuperer morceau du code";
            if(Input.GetMouseButtonDown(0))
            {
             Postit2.SetActive(true);
            } 
        }
        else
        {
            TextePostit2.text = "";

        }
        
        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, postit3))
        {
            TextePostit3.text = "Clique gauche pour recuperer morceau du code";
            if(Input.GetMouseButtonDown(0))
            {
             Postit3.SetActive(true);
            } 
        }
        else
        {
            TextePostit3.text = "";
        }


        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, postit4))
        {
            TextePostit4.text = "J'ai laisse 3 post-its avec les chiffres qui composent le code dans le stockage et le laboratoire."; 
        }
        else
        {
            TextePostit4.text = "";
        }

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, lore))
        {
            Debug.Log("Raycast LORE");
            TextePostit3.text = "Clique gauche pour lire";

            if(Input.GetMouseButtonDown(0))
            {
             Lore.SetActive(true);
            } 

            if (Input.GetMouseButtonUp(0))
            {
            Lore.SetActive(false);
            }
        }
        else
        {
            TextePostit3.text = "";
            Lore.SetActive(false);
        }
        

        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);
        }

        controller.Move(move * crouchSpeed * Time.deltaTime);


        DetermineTerrain();

        if (IsGrounded && IsWalking)
        {
            
            PLAYBACK_STATE playbackState;
            Footsteps.getPlaybackState(out playbackState);

            
             if(playbackState.Equals(PLAYBACK_STATE.STOPPED) || currentTerrain != previousTerrain)
             {
                Footsteps.stop(STOP_MODE.ALLOWFADEOUT);
                SelectAndPlayFootsteps();
                previousTerrain = currentTerrain;   
             }
               
            

            

        }
        else
        {
            
            Footsteps.stop(STOP_MODE.ALLOWFADEOUT);
            
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
                //PlayAmbiantEnviro(0);
                break;
                
            case CURRENT_TERRAIN.CONCRETE:
                PlayFootstep(2);
                //PlayAmbiantEnviro(3);
                break;
                
            case CURRENT_TERRAIN.CARPET:
                PlayFootstep(3);
                //PlayAmbiantEnviro(2);
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