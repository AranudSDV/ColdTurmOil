using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class PlayerFootsteps : MonoBehaviour
{/*

    float footstepSpeed = 0.3f;

    public GameObject groundCheck;
    public float groundDistance = 0.4f;

    private enum CURRENT_TERRAIN { STEEL, SNOW, CONCRETE, CARPET};

    public GameObject controller;

    


    [SerializeField]
    float timer = 0.0f;
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance footsteps;

    

    private void Awake()
    {
        controller = GetComponentInParent<CharacterController>();
    }
    

    
    private void Update()
    {
        DetermineTerrain();

        if (controller.IsWalking && controller.IsGrounded)
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
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("snow"))
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

            case CURRENT_TERRAIN.SNOW:
                PlayFootstep(1);

            case CURRENT_TERRAIN.CONCRETE:
                PlayFootstep(2);
            
            case CURRENT_TERRAIN.CARPET:
                PlayFootstep(3);

        }
    }

    private void PlayFootstep(int terrain)
    {
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        footsteps.setParameterByName("Terrain, terrain");
        footsteps.set3DAttributes(FMODUnity.RunTimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }
    */
}
