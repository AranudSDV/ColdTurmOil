using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LastEpreuve : MonoBehaviour
{
    public GameObject porte;
    public GameObject newPos;
    public bool porteIsMoving = false;
    public bool rayHitCard = false;
    [SerializeField] private float speedUp = 5f;
    private float diffX;
    private float diffY;
    private float diffZ;
    private float diff;
    private bool porteHasMoved = false;
    public string objectNeeded;

    public Renderer rend;
    public GameObject time;


    

    void start()
    {
        
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        
    }

    void Update()
    {
        //La plateforme se deplace 
        if (porteIsMoving == true) 
        {
            porte.transform.position = Vector3.MoveTowards(porte.transform.position, newPos.transform.position, speedUp * Time.deltaTime); 

            rend.enabled = true;

            time.SetActive(true);

            
        }

     
        float diffX = porte.transform.position.x - newPos.transform.position.x; 
        float diffY = porte.transform.position.y - newPos.transform.position.y; 
        float diffZ = porte.transform.position.z - newPos.transform.position.z; 
        float diff = diffX + diffY + diffZ; 
        if(diff == 0)
        {
            porteHasMoved = true; 
        }
        if (porteHasMoved == true) 
        {
            porteIsMoving = false; 
        }

        if(Inventory.instance.HasObject(objectNeeded) == true && rayHitCard == true)
        {
            

            if(porteIsMoving == false)
            {
                AudioManager.instance.PlayOneShot(FMODEvent.instance.OpenDoorSound, porte.transform.position);
                AudioManager.instance.PlayOneShot(FMODEvent.instance.AutodestructionSound, this.transform.position);
            }

            porteIsMoving = true;

            
                
        }
    }

    
}
