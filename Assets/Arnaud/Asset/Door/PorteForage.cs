using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteForage : MonoBehaviour
{
    public GameObject plateform;
    public GameObject newPos;
    public GameObject plateform2;
    public GameObject newPos2;
    public bool plateformIsMoving = false;
    public bool plateform2IsMoving = false;
    public bool rayHit2 = false;
    public bool rayHit = false;
    [SerializeField] private float speedUp = 5f;
    private float diffX;
    private float diffY;
    private float diffZ;
    private float diff;
    private float diffX2;
    private float diffY2;
    private float diffZ2;
    private float diff2;
    private bool plateformHasMoved = false;
    private bool plateform2HasMoved = false;
    //Initialization

    void Update()
    {
        //La plateforme se deplace 
        if (plateformIsMoving == true) 
        {
        {
            plateform.transform.position = Vector3.MoveTowards(plateform.transform.position, newPos.transform.position, speedUp * Time.deltaTime); 
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

        }





        if (plateform2IsMoving == true)
        {

        {
            plateform2.transform.position = Vector3.MoveTowards(plateform2.transform.position, newPos.transform.position, speedUp * Time.deltaTime); 
        }

        
        float diffX2 = plateform2.transform.position.x - newPos.transform.position.x; 
        float diffY2 = plateform2.transform.position.y - newPos.transform.position.y; 
        float diffZ2 = plateform2.transform.position.z - newPos.transform.position.z; 
        float diff2 = diffX2 + diffY2 + diffZ2; 
        if(diff2 == 0)
        {
            plateform2HasMoved = true; 
        }
        if (plateform2HasMoved == true) 
        {
            plateform2IsMoving = false; 
        }
        
        }

        if(Inventory.instance.HasObject("Blue Card") == true && Input.GetMouseButtonDown(0) && rayHit2 == true)
            {
                plateformIsMoving = true;
                plateform2IsMoving = true;
                
                Debug.Log("scitp porte marche");
            }
    }
}
