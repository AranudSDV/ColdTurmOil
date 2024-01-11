using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvent : MonoBehaviour
{
    [field: Header("Ambiant win SFX")]

    [field: SerializeField] public EventReference AmbiantSFX { get; private set; }

    [field: Header("Item pickup")]

    [field: SerializeField] public EventReference itempickupSound { get; private set; }





    [field: Header("Metal Door Open SFX")]

    [field: SerializeField] public EventReference OpenDoorSound { get; private set; }

    [field: Header("Metal Door close SFX")]

    [field: SerializeField] public EventReference CloseDoorSound { get; private set; }

    [field: Header("Son Monstre")]

    [field: SerializeField] public EventReference MonsterPoursuiterSound { get; private set; }

    [field: Header("Enclanchament Manivelle")]

    [field: SerializeField] public EventReference ManvilleSound { get; private set; }

    [field: Header("Forage Door Open SFX")]

    [field: SerializeField] public EventReference OpenDoorForageSound { get; private set; }

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
