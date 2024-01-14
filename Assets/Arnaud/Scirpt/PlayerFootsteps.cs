using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;


public class PlayerFootsteps : MonoBehaviour
{
    
    /*private enum CURRENT_TERRAIN { STEEL, SNOW, CONCRETE, CARPET};

    public bool IsGrounded = false;
    public bool IsWalking = false;

    float timer = 0.0f;
    


    [SerializeField]
    float footstepSpeed = 0.3f;
    
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance Footsteps;
    public GameObject player;

   
    
    private void Update()
    {
        
        if(IsGrounded)
        {
            Debug.Log("PlayerFootSteps Isgrounded");
        }

        DetermineTerrain();

        if (IsWalking == true && IsGrounded == true)
        {
            PLAYBACK_STATE playbackState;
            Footsteps.getPlaybackState(out playbackState);
            if (timer > footstepSpeed)
            {
                if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
                {
                 SelectAndPlayFootsteps();
                }
                timer = 0.0f;
            }

            timer += Time.deltaTime;
        }
    }

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(player.transform.position, Vector3.down, 5f);

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

    public void SelectAndPlayFootsteps()
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
        Footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/character/Footsteps");
        Footsteps.setParameterByName("Terrain", terrain);
        Footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Footsteps.start();
        Footsteps.release();
    }
    */

    /*private void UpdateSound()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 )
        {
            if(isGrounded)
            {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);
            if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }
            }
        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
        
    }

    */
    
}
