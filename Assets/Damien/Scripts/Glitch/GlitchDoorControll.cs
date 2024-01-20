using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlitchDoorControll : MonoBehaviour
{
    public GameObject Glitchy;
    
    public float _GlitchTimeRemaining;
    public bool glitchHappened = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Glitchy.SetActive(false);
    }
    private IEnumerator Glitched()
    {
        Debug.Log("glichedappele");
            Glitchy.SetActive(true);
            yield return new WaitForSeconds(_GlitchTimeRemaining);
            Glitchy.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        

        if(Inventory.instance.HasObject("Manivelle") == true && glitchHappened == false)
        {
            Debug.Log("manivellerecup");
             StartCoroutine("Glitched");
            glitchHappened = true;
        }

       
    }
   
}
