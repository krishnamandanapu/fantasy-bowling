using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score_UI : MonoBehaviour
{
    public GameObject pinManager;
    public TMP_Text text;
    private pinManagerScript test;

    // Start is called before the first frame update
    void Start()
    { 
        text.text = "Total Pins:\n10";
        test = pinManager.GetComponent<pinManagerScript>();
    }

    /*public*/ void Update/*Score*/()
    {
        if (test == null)
        {
            text.text = "pinManager is gone???";
            return;
        }
        //int knocked = test.CountPinsDown();
        int total = test.countTotalPins();

        //countPinsDown not working as intended and I'm not sure how to fix it at this point -Gonzalo
        //text.text = "Pins Left:\n" + (total - knocked).ToString() + " / " + total.ToString();
        text.text = "Total Pins:\n" + total.ToString();
    }
}
