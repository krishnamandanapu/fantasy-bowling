using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    float power;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObjectToMove.transform.position = new Vector3(x, y, z);
        /*
        if (Input.GetKeyDown(KeyCode.Space)){
            transform.position += new Vector3(0, 0, 1);
        }
        */
        if (Input.GetKeyDown(KeyCode.Space))//Input.GetKeyDown(KeyCode.Return)
             rb.AddForce(Vector3.forward * power);
    }
}
