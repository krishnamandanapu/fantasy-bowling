using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPinScript : MonoBehaviour
{
    public GameObject exp;
    public float expForce, radius;

    /*
    private GameObject pinSpawnerRef;
    private int my_i, my_j;
    */

    /*
    public void setUp(int i, int j)
    {
        //Debug.Log("yoo");
        pinSpawnerRef = GameObject.Find("PinSpawnerObj");
        my_i = i;
        my_j = j;
        Debug.Log("my_i:" + my_i + ",my_j:" + my_j);
        Debug.Log("pinSpawnerRef: " + pinSpawnerRef);
    }
    */

    private void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.tag != "Floor")
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, 3);
            Destroy(gameObject);

        //KnockBack method didn't work, so I'm doing the knock back effect here
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            if (rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }

            //Debug.Log("pinSpawnerRef: " + pinSpawnerRef);
            //this.pinSpawnerRef.GetComponent<pinManagerScript>().UpdateScoreAndFormation(my_i, my_j);
        }
    }
}
