using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour { 
    public GameObject obj;
    public Transform head;

    public void SpawnObject()
    {
        GameObject newObject = Instantiate(obj, head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * 2, Quaternion.identity);
    }
}
