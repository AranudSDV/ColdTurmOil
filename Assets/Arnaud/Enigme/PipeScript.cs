using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = { 0,90,180,270 };

    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;

    int PossibleRots = 1;

    GameManager gameManager;

    public bool rayHitPipe = false;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Start()
    {
        PossibleRots = correctRotation.Length;
        
        if(PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && rayHitPipe == true)
        {
            Debug.Log("je sais pas");
        }

        if (rayHitPipe == true)
        {
            Debug.Log("rayhit pipescirpt ok");
            transform.Rotate(new Vector3(0, 0, 90));

            if (PossibleRots > 1)
            {
                if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && isPlaced == false)
                {
                    isPlaced = true;
                    gameManager.correctMove();
                }
                else if (isPlaced == true)
                {
                    isPlaced = false;
                    gameManager.wrongMove();
                }
            }
            else
            {
                if (transform.eulerAngles.z == correctRotation[0] && isPlaced == false)
                {
                    isPlaced = true;
                    gameManager.correctMove();
                }
                else if (isPlaced == true)
                {
                    isPlaced = false;
                    gameManager.wrongMove();
                }
            }
        }
        

       

        
    }
    
    /*

   private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && isPlaced == false)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0] && isPlaced == false)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
    }
    */
    
}
