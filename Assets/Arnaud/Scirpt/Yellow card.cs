using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellowcard : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    private float diffX;
    private float diffY;
    private float diffZ;
    private float diff;
    private bool cardHasMoved = false;
    public bool cardIsMoving = false;
    public GameObject newPosCard;
    public GameObject Card;
   
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (cardIsMoving == true) 
    {
      Card.transform.position = Vector3.MoveTowards(Card.transform.position, newPosCard.transform.position, speed * Time.deltaTime); 
    }

        
    float diffX = Card.transform.position.x - newPosCard.transform.position.x; 
    float diffY = Card.transform.position.y - newPosCard.transform.position.y; 
    float diffZ = Card.transform.position.z - newPosCard.transform.position.z; 
    float diff = diffX + diffY + diffZ; 
    if(diff == 0)
    {
      cardHasMoved = true; 
    }
    if (cardHasMoved == true) 
    {
      cardIsMoving = false; 
    }
    }
}
