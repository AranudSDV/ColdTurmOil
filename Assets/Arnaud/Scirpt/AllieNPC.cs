using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllieNPC : MonoBehaviour
{
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject newPosNPC1;
    public GameObject newPosNPC2;
    public bool NPC1IsMoving = false;
    public bool NPC2IsMoving = false;
    public bool NPC1IsRotating = false;
    public bool NPC2IsRotating = false;
    public bool PlayerInTrigger;
    public Collider TriggerDepart;
    public GameObject VoixNPC;
    

    [SerializeField] private float speedUp = 5f;

    private float diffXNPC1;
    private float diffYNPC1;
    private float diffZNPC1;
    private float diffNPC1;
    private bool NPC1HasMoved = false;
    
    

    private float diffXNPC2;
    private float diffYNPC2;
    private float diffZNPC2;
    private float diffNPC2;
    private bool NPC2HasMoved = false;

    public GameObject TexteNpc;
    public GameObject TexteNpc2;
    

    
    


    void Start()
    {
        NPC1IsRotating = true;
        NPC2IsRotating = true;
    }

    
    void Update()
    {
        if(NPC1IsRotating == true)
        {
            NPC1.transform.rotation = Quaternion.Lerp(NPC1.transform.rotation, Quaternion.Euler(0f, 100f, 0), Time.deltaTime);
        }
        if (NPC1IsMoving == true) 
        {
            NPC1.transform.position = Vector3.MoveTowards(NPC1.transform.position, newPosNPC1.transform.position, speedUp * Time.deltaTime);

            NPC1.GetComponent<animationsoldier>().Animation = true;
        }

        float diffXNPC1 = NPC1.transform.position.x - newPosNPC1.transform.position.x; 
        float diffYNPC1 = NPC1.transform.position.y - newPosNPC1.transform.position.y; 
        float diffZNPC1 = NPC1.transform.position.z - newPosNPC1.transform.position.z; 
        float diffNPC1 = diffXNPC1 + diffYNPC1 + diffZNPC1; 

        if(diffNPC1 == 0)
        {
            NPC1HasMoved = true;
            NPC1.GetComponent<animationsoldier>().Animation = false;


             
        }

        if (NPC1HasMoved == true) 
        {
            NPC1IsMoving = false; 
        }

        //NPC2
         if(NPC2IsRotating == true)
        {
            NPC2.transform.rotation = Quaternion.Lerp(NPC2.transform.rotation, Quaternion.Euler(0f, 100f, 0), Time.deltaTime);
        }

        if (NPC2IsMoving == true) 
        {
            NPC2.transform.position = Vector3.MoveTowards(NPC2.transform.position, newPosNPC2.transform.position, speedUp * Time.deltaTime);
            NPC2.GetComponent<animationsoldier>().Animation = true;

        }

        float diffXNPC2 = NPC2.transform.position.x - newPosNPC2.transform.position.x; 
        float diffYNPC2 = NPC2.transform.position.y - newPosNPC2.transform.position.y; 
        float diffZNPC2 = NPC2.transform.position.z - newPosNPC2.transform.position.z; 
        float diffNPC2 = diffXNPC2 + diffYNPC2 + diffZNPC2; 

        if(diffNPC2 == 0)
        {
            NPC2HasMoved = true;
            NPC2.GetComponent<animationsoldier>().Animation = false;
            VoixNPC.SetActive(true);
            
        }

        if (NPC2HasMoved == true) 
        {
            NPC2IsMoving = false; 
            StartCoroutine(TexteNPC());
        }
    }

    IEnumerator TexteNPC()
    {
        TexteNpc.SetActive(true);
        yield return new WaitForSeconds(5);
        Destroy(TexteNpc);
        TexteNpc2.SetActive(true);
        yield return new WaitForSeconds(6);
         Destroy(TexteNpc2);
    }

    
}
