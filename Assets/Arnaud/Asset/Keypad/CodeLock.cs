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

    public GameObject Door;
    public GameObject Door2;

    public TextMeshProUGUI TextCode;
    public Image imageBack;
    public Image imageBackWin;
    public bool doorIsOpening;

    public GameObject postit1;
    public GameObject postit2;
    public GameObject postit3;

    

    void Start()
    {
        codeLength = code.Length;
        imageBack.color = new Color(0f, 0f, 0f, 0f);
        imageBackWin.color = new Color(0f, 0f, 0f, 0f);
        
    }

    
    

    void CheckCode()
    {
        if(attemptedCode == code)
        {
            doorIsOpening = true;
            StartCoroutine(WinImage());
            postit1.SetActive(false);
            postit2.SetActive(false);
            postit3.SetActive(false);
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

    IEnumerator WinImage()
    {
        imageBackWin.color = new Color(0f, 1f, 0f, 0.5f);
        yield return new WaitForSeconds(4);
         imageBackWin.color = new Color(0f, 0f, 0f, 0f);
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


    void Update()
    {
        TextCode.text = attemptedCode;

        if (doorIsOpening == true)
        {
            Door.transform.Translate (Vector3.forward * Time.deltaTime * 5);
            Door2.transform.Translate (Vector3.forward * Time.deltaTime * 5);
        }

        if (Door.transform.position.y > 7f)
        {
            doorIsOpening = false;
        }
    }
    
        
    
}
