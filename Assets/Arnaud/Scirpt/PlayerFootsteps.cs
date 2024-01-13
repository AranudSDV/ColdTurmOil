using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFootsteps : MonoBehaviour
{
    
    

    public GameObject groundCheck;
    

    private enum CURRENT_TERRAIN { STEEL, SNOW, CONCRETE, CARPET};


    public bool IsGrounded = false;
    public bool IsWalking = false;

    float timer = 0.0f;
    


    [SerializeField]
    float footstepSpeed = 0.3f;
    
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance footsteps;

   
    
    private void Update()
    {
        
        if(IsGrounded)
        {
            Debug.Log("PlayerFootSteps Isgrounded");
        }

        DetermineTerrain();

        if (IsWalking && IsGrounded)
        {
            if (timer > footstepSpeed)
            {
                SelectAndPlayFootstep();
                timer = 0.0f;
            }

            timer += Time.deltaTime;
        }
    }

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(transform.position, Vector3.down, 5f);

        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Steel"))
            {
                currentTerrain = CURRENT_TERRAIN.STEEL;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Snow"))
            {
                currentTerrain = CURRENT_TERRAIN.SNOW;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Concrete"))
            {
                currentTerrain = CURRENT_TERRAIN.CONCRETE;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Carpet"))
            {
                currentTerrain = CURRENT_TERRAIN.CARPET;
                break;
            }
        }
    }

    public void SelectAndPlayFootstep()
    {
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.STEEL:
                PlayFootstep(0);
                break;
            case CURRENT_TERRAIN.SNOW:
                PlayFootstep(1);
                break;
            case CURRENT_TERRAIN.CONCRETE:
                PlayFootstep(2);
                break;
            case CURRENT_TERRAIN.CARPET:
                PlayFootstep(3);
                break;
        }
    }

     private void PlayFootstep(int terrain)
    {
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/footsteps");
        footsteps.setParameterByName("Terrain", terrain);
        footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }
    
    
}
