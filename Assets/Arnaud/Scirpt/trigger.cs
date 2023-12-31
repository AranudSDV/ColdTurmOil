using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
  public Collider Plaque;
    public GameObject truc;
    public GameObject newPos;
    
    public bool objectIsMoving = false;
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


    void Update()
    {
         
      if (objectIsMoving == true) 
      {
        truc.transform.position = Vector3.MoveTowards(truc.transform.position, newPos.transform.position, speedUp * Time.deltaTime); 
      }

        
      float diffX = truc.transform.position.x - newPos.transform.position.x; 
      float diffY = truc.transform.position.y - newPos.transform.position.y; 
      float diffZ = truc.transform.position.z - newPos.transform.position.z; 
      float diff = diffX + diffY + diffZ; 
      if(diff == 0)
      {
        objectHasMoved = true; 
        //Destroy(gameObject);
        //Destroy(truc);
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
        //Destroy(gameObject);
        //Destroy(truc);
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
        Destroy(gameObject);
        Destroy(truc);
      }
      if (objectHasMoved3 == true) 
      {
        objectIsMoving3 = false; 
      }
    }    
     
    private void OnTriggerEnter (Collider Plaque)
    {
      objectIsMoving = true;
      Debug.Log("PlaqueDepression");
    }

    void DestroyGameObject()
    {
      Destroy(gameObject);
    }
}
