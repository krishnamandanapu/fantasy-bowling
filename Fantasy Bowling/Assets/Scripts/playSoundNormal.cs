using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundNormal : MonoBehaviour
{
    public AudioSource audio;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Podium" && other.gameObject.tag != "Floor")
        {
            audio.Play();
        }
    }
}
