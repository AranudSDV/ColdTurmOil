using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeLock : MonoBehaviour
{

    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    public Transform toOpen;

    public TextMeshProUGUI TextCode;
    public Image imageBack;

    

    void Start()
    {
        codeLength = code.Length;
        imageBack.color = new Color(0f, 0f, 0f, 0f);

        
    }

    void Update()
    {
        TextCode.text = attemptedCode;
    }

    void CheckCode()
    {
        if(attemptedCode == code)
        {

            StartCoroutine(Open());

            

        }
        if(attemptedCode != code)
        {
            Debug.Log("Wrong Code");
            StartCoroutine(backToNormal());
            
        }
    }

    IEnumerator backToNormal()
    {
        imageBack.color = new Color(1f, 0f, 0f, 0.5f);
        yield return new WaitForSeconds(4);
         imageBack.color = new Color(0f, 0f, 0f, 0f);
    }

    IEnumerator Open()
    {
        toOpen.Rotate(new Vector3(0,90,0), Space.World);

        yield return new WaitForSeconds(4);

        toOpen.Rotate(new Vector3(0,-90,0), Space.World);
    }


    public void SetValue (string value)
    {
        placeInCode++;

        if(placeInCode <= codeLength)
        {
            attemptedCode += value;
        }

        if(placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
