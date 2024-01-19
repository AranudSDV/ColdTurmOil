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
    private bool rayHitPostit;
    

    Vector3 velocity;

    public TextMeshProUGUI textPickup;
    public TextMeshProUGUI TextePostit;
    public TextMeshProUGUI TextePostit2;
    public TextMeshProUGUI TextePostit3;
    public TextMeshProUGUI TextePostit4;

    public Door door;
    public PorteForage porteForage;

    
    
    private void Start()
    {
        SonOutside.SetActive(false);
        SonTuto.SetActive(false);
        SonMine.SetActive(false);
    }

    
   
    void Update()
    {

       //UpdateSound();

        isGroundedSteel = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskSteel);
        isGroundedSnow = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskSnow);
        isGroundedConcrete = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskConcrete);
        isGroundedCarpet = Physics.CheckSphere(groundCheck.position, groundDistance, groundMaskCarpet);

        if(isGroundedSnow)
        {
            SonOutside.SetActive(true);
        }
        else
        {
            SonOutside.SetActive(false);
        }

        if(isGroundedCarpet)
        {
            SonTuto.SetActive(true);
        }
        else
        {
            SonTuto.SetActive(false);
        }

        if(isGroundedConcrete)
        {
            SonMine.SetActive(true);
        }
        else
        {
            SonMine.SetActive(false);
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

            textPickup.text = "Carte magnetique bleu necessaire";
            
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
             Debug.Log("Script player porte forage");
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
            TextePostit.text = "Le premier chiffre du code est 3"; 
        }
        else
        {
            TextePostit.text = "";
        }

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, postit2))
        {
            TextePostit2.text = "Le Deuxieme chiffre du code est 6"; 
        }
        else
        {
            TextePostit2.text = "";

        }if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, postit3))
        {
            TextePostit3.text = "Le Troisieme chiffre du code est 9"; 
        }
        else
        {
            TextePostit3.text = "";
        }

        if (Physics.Raycast(icamera.transform.position, icamera.transform.TransformDirection(Vector3.forward), out hit, rangePickUp, postit4))
        {
            TextePostit4.text = "J'ai laisse 3 postits avec les chiffres qui compose le code dans le stocakge et le laboratoire"; 
        }
        else
        {
            TextePostit4.text = "";
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

            //if (timer > footstepSpeed)
            //{
                if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
                {
                 SelectAndPlayFootsteps();
                 //SelectAndPlayEnviro();
                 
                 
                }
                //timer = 0.0f;
            //}

            //timer += Time.deltaTime;

        }
        else
        {
            
            Footsteps.stop(STOP_MODE.ALLOWFADEOUT);
            //AmbiantEnviro.stop(STOP_MODE.ALLOWFADEOUT);
        }

        /*AmbiantEnviro.getPlaybackState(out playbackState);

        if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {      
            SelectAndPlayEnviro();      
        }
       else
        {
            AmbiantEnviro.stop(STOP_MODE.ALLOWFADEOUT);
        }
        */


        
        



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
 

    /*private void PlayAmbiantEnviro(int terrain)
    {
        AmbiantEnviro = FMODUnity.RuntimeManager.CreateInstance("event:/character/AmbiantEnviro");
        AmbiantEnviro.setParameterByName("IsBlizzard", terrain);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(AmbiantEnviro, transform, false);
        AmbiantEnviro.start();
        AmbiantEnviro.release();
        
    }
    */
    
    
}