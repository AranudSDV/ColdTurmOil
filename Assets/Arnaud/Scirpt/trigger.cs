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
          Destroy(gameObject);
          Destroy(truc);
        }
        if (objectHasMoved == true) 
        {
          objectIsMoving = false; 
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
