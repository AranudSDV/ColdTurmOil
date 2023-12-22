using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public string value;

    public CodeLock codeLock;
    
    void Update()
    {

    }

    public void CheckHitObj()
    {
        

        if(codeLock != null)
        {
            
            codeLock.SetValue(name);
        }

        
    }
}
