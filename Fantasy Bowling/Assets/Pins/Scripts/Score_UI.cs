using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score_UI : MonoBehaviour
{
        //public UnityEngine.UI.Text Score;
public UnityEngine.UI.Text Score;
public UnityEngine.UI.Text Total_Pins;
public int score_var;
public int pins;
    // Start is called before the first frame update
    void Start()
    { 
        // initialized both the variables
        score_var = 0;
        pins = 10;
        Score.text = "Score = 0";
        Total_Pins.text = "Total Pins = 10";
    }

    // Update is called once per frame
    void Update()
    {
        //updated variables
        //please change the value to be updated
        score_var++;
        pins++;
        Score.text = "Score = " + score_var.ToString(); 
        Total_Pins.text = "Total Pins = " + pins.ToString(); 
    }
}
