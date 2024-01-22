using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunelMonster : MonoBehaviour
{
    [SerializeField] private float speedUpMonster = 5f;
    public GameObject Monster;
    public GameObject Tructunel;
    
    
    public bool MonsterIsMoving = false;
    private bool Monster2HasMoved = false;
    private float diffXMonster2;
    private float diffYMonster2;
    private float diffZMonster2;
    private float diffMonster2;
    public GameObject newPosMonster2;


    


    void Start()
    {
        Monster.SetActive(false); 
    }

    void Update()
    {
        if (MonsterIsMoving == true) 
        {
            Monster.SetActive(true); 
            Monster.transform.position = Vector3.MoveTowards(Monster.transform.position, newPosMonster2.transform.position, speedUpMonster * Time.deltaTime); 
            
        }

     
        float diffXMonster2 = Monster.transform.position.x - newPosMonster2.transform.position.x; 
        float diffYMonster2 = Monster.transform.position.y - newPosMonster2.transform.position.y; 
        float diffZMonster2 = Monster.transform.position.z - newPosMonster2.transform.position.z; 
        float diffMonster2 = diffXMonster2 + diffYMonster2 + diffZMonster2; 

        if(diffMonster2 == 0)
        {
            Monster2HasMoved = true; 
        }

         if (Monster2HasMoved == true) 
        {
            MonsterIsMoving = false;  
            Tructunel.GetComponent<TunelMonster2>().MonsterIsMoving2 = true;
            Monster.SetActive(false); 
            
        }

       
    }
}
