using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicPinScript : MonoBehaviour
{
    public GameObject exp;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Floor")
        {
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, (float)0.5);
            Destroy(gameObject);
        }
    }
}
