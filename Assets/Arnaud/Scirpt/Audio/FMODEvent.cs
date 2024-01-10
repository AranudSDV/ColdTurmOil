using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvent : MonoBehaviour
{
    [field: Header("Metal Door Open SFX")]

    [field: SerializeField] public EventReference OpenDoorSound { get; private set; }

    [field: Header("Player SFX")]

    [field: SerializeField] public EventReference playerFootsteps { get; private set; }

    public static FMODEvent instance { get; private set; }

    private void Awake()
    {
        if (instance  != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }
        instance = this;
    }
}
