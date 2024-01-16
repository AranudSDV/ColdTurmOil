using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationsoldier : MonoBehaviour {

    private Animator anim;
    public bool Animation = false;

    // Start is called before the first frame update
    void Start () {
        anim = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update() {

        if(Animation == true)
        {
            anim.SetBool("run", true);
            Debug.Log(" animation npc");
        }

        else
        {

            anim.SetBool("run", false);
        }
        
    }
}
