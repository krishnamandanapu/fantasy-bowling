using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    private float timer = 2.5f;
    private float checkTimer = 5.0f;
    public GameObject obj;
    private Score_UI temp;

    void Start()
    {
        temp = obj.GetComponent<Score_UI>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (timer <= 0.0f)
            {
                Destroy(other);
                timer = 2.5f;
                //temp.UpdateScore();
            }

            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other);
            timer = 2.5f;
            //temp.UpdateScore();
        }
    }

    void Update()
    {
        if (checkTimer <= 0.0f)
        {
            checkTimer = 5.0f;
            //temp.UpdateScore();
        }

        checkTimer -= Time.deltaTime; 
    }
}
