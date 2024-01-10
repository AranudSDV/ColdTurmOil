using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{

    
    
    public GameObject plateform;
    public GameObject newPos;
    public bool plateformIsMoving = false;
    public bool rayHit = false;
    [SerializeField] private float speedUp = 5f;
    private float diffX;
    private float diffY;
    private float diffZ;
    private float diff;
    private bool plateformHasMoved = false;
    public string objectNeeded;

    public Renderer rend;

    void start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update()
    {
        //La plateforme se deplace 
        if (plateformIsMoving == true) 
        {
            plateform.transform.position = Vector3.MoveTowards(plateform.transform.position, newPos.transform.position, speedUp * Time.deltaTime); 

            rend.enabled = true;

            
        }

        //Calcule de coordonees 
        //Est-ce que la plateforme est en position?
        float diffX = plateform.transform.position.x - newPos.transform.position.x; //Est-ce que la position en x est la meme?
        float diffY = plateform.transform.position.y - newPos.transform.position.y; //Est-ce que la position en y est la meme?
        float diffZ = plateform.transform.position.z - newPos.transform.position.z; //Est-ce que la position en z est la meme?
        float diff = diffX + diffY + diffZ; //Est-ce que les coordonnees sont les memes?
        if(diff == 0)
        {
            plateformHasMoved = true; //La plateform est arrive a la destination
        }
        if (plateformHasMoved == true) //Si la plateforme se situe a la position
        {
            plateformIsMoving = false; //La plateforme ne se deplace plus
        }

        if(Inventory.instance.HasObject(objectNeeded) == true && rayHit == true)
            {
                if(plateformIsMoving == false)
                {
                    AudioManager.instance.PlayOneShot(FMODEvent.instance.OpenDoorSound, this.transform.position);
                }
                plateformIsMoving = true;
                //door.plateformIsMoving = true; //la plateforme se deplace
                Debug.Log("scitp porte marche");
                
                
            }
    }

 
}
