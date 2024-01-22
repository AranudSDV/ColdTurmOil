using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunelMonster2 : MonoBehaviour
{
[SerializeField] private float speedUpMonster = 5f;
    public GameObject Monster;
    public GameObject Tout;
    
    public bool MonsterIsMoving2 = false;
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
        if (MonsterIsMoving2 == true) 
        {
            Debug.Log("MOnster2");
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
            MonsterIsMoving2 = false;

            Destroy(Tout);
            
        }

       
    }
}
