using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
  public Collider Plaque;
  public GameObject truc;
  public GameObject newPos;
  public GameObject trappe;
  public GameObject positionMob;
  public GameObject SoundMonster;
    
  public bool objectIsMoving = false;
  public bool playerinzone;

    
    

  [SerializeField] private float speedUp = 5f;
  private float diffX;
  private float diffY;
  private float diffZ;
  private float diff;
  private bool objectHasMoved = false;

  public GameObject newPos2;
  public bool objectIsMoving2 = false;
  private float diffX2;
  private float diffY2;
  private float diffZ2;
  private float diff2;
  private bool objectHasMoved2 = false;

  public GameObject newPos3;
  public bool objectIsMoving3 = false;
  private float diffX3;
  private float diffY3;
  private float diffZ3;
  private float diff3;
  private bool objectHasMoved3 = false;

  public GameObject newPosPlaque;
  public bool plaqueIsMoving = false;
  private float diffXPlaque;
  private float diffYPlaque;
  private float diffZPlaque;
  private float diffPlaque;
  private bool objectHasMovedPlaque = false;
  public GameObject Door;


  void Update()
  {

    
         
    if (objectIsMoving == true) 
    {
      truc.transform.position = Vector3.MoveTowards(truc.transform.position, newPos.transform.position, speedUp * Time.deltaTime); 

      Door.transform.Translate (Vector3.up * Time.deltaTime * 5);

      SoundMonster.SetActive(true);
    }

        
    float diffX = truc.transform.position.x - newPos.transform.position.x; 
    float diffY = truc.transform.position.y - newPos.transform.position.y; 
    float diffZ = truc.transform.position.z - newPos.transform.position.z; 
    float diff = diffX + diffY + diffZ; 
    if(diff == 0)
    {
      objectHasMoved = true; 
      
      objectIsMoving2 = true;
    }
    if (objectHasMoved == true) 
    {
      objectIsMoving = false; 
    }

      //position22222222222222222
      if (objectIsMoving2 == true) 
      {
        truc.transform.position = Vector3.MoveTowards(truc.transform.position, newPos2.transform.position, speedUp * Time.deltaTime); 
      }

        
      float diffX2 = truc.transform.position.x - newPos2.transform.position.x; 
      float diffY2 = truc.transform.position.y - newPos2.transform.position.y; 
      float diffZ2 = truc.transform.position.z - newPos2.transform.position.z; 
      float diff2 = diffX2 + diffY2 + diffZ2; 
      if(diff2 == 0)
      {
        objectHasMoved2 = true; 
        
        objectIsMoving3 = true;
      }
      if (objectHasMoved2 == true) 
      {
        objectIsMoving2 = false; 
      }

      //POSITION333333333333
      if (objectIsMoving3 == true) 
      {
        truc.transform.position = Vector3.MoveTowards(truc.transform.position, newPos3.transform.position, speedUp * Time.deltaTime); 
      }

        
      float diffX3 = truc.transform.position.x - newPos3.transform.position.x; 
      float diffY3 = truc.transform.position.y - newPos3.transform.position.y; 
      float diffZ3 = truc.transform.position.z - newPos3.transform.position.z; 
      float diff3 = diffX3 + diffY3 + diffZ3; 
      
      if(diff3 == 0)
      {

        objectHasMoved3 = true; 
        
      }
      if (objectHasMoved3 == true) 
      {
        objectIsMoving3 = false; 
      }

      if (plaqueIsMoving == true) 
      {
        trappe.transform.position = Vector3.MoveTowards(trappe.transform.position, newPosPlaque.transform.position, speedUp * Time.deltaTime); 
      }

        
      float diffXPlaque = trappe.transform.position.x - newPosPlaque.transform.position.x; 
      float diffYPlaque = trappe.transform.position.y - newPosPlaque.transform.position.y; 
      float diffZPlaque = trappe.transform.position.z - newPosPlaque.transform.position.z; 
      float diffPlaque = diffXPlaque + diffYPlaque + diffZPlaque; 
      if(diffPlaque == 0)
      {
        objectHasMovedPlaque = true; 
        
      }
      if (objectHasMovedPlaque == true) 
      {
        plaqueIsMoving = false; 
      }


      if ( objectHasMoved3 == true)
      {
        Destroy(truc);
      }
    }    
     
  private void OnTriggerEnter (Collider Plaque)
  {
    /*if( objectIsMoving == false)
    {
      AudioManager.instance.PlayOneShot(FMODEvent.instance.MonsterPoursuiterSound, positionMob.transform.position);
    }
    */
    objectIsMoving = true;
    Debug.Log("PlaqueDepression");
    if( plaqueIsMoving == false)
    {
      AudioManager.instance.PlayOneShot(FMODEvent.instance.CloseDoorSound, this.transform.position);
    }
    plaqueIsMoving = true;
  }

}
