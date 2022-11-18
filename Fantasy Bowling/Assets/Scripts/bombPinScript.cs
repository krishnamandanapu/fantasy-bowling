using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPinScript : MonoBehaviour
{
    public GameObject exp;
    public float expForce, radius;

    private void OnCollisionEnter(Collision other)
    {
       if ((this.gameObject.tag == "Ball" && other.gameObject.tag != "Podium"))
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

            return;
        }

       if (other.gameObject.tag != "Floor" && other.gameObject.tag != "Podium")
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
        }
    }
}
