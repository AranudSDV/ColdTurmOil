using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;
    
    

    void Start()
    {
        
        
     StartCoroutine(countdownToStart());

    }

    IEnumerator countdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "Auto Destruction";

    }

}
