using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicPinScript : MonoBehaviour
{
    public GameObject exp;
    public AudioClip audio;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Podium" && other.gameObject.tag != "Floor")
        {
            AudioSource.PlayClipAtPoint(audio, gameObject.transform.position);
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, (float)0.5);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Left Hand" || other.gameObject.tag == "Right Hand")
        {
            AudioSource.PlayClipAtPoint(audio, gameObject.transform.position);
            GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
            Destroy(_exp, (float)0.5);
            Destroy(gameObject);
        }
    }
}
