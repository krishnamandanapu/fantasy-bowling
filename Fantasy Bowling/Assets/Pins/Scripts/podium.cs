using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podium : MonoBehaviour
{

    public GameObject ObjectPrefab;
    private GameObject TheObject;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        //initlize the object
        //Debug.Log("Start");
        createObject();
    }

    /*
    void resetObject()
    {
        Debug.Log("Reset");
    }
    */

    void createObject()
    {
        //Debug.Log("Create");
        Vector3 curr_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        TheObject = Instantiate(ObjectPrefab, curr_pos, Quaternion.identity);
        animate();
    }

    void animate()
    {
        //Debug.Log("animate");
        GameObject _effect = Instantiate(effect, transform.position, transform.rotation);
        Destroy(_effect, (float)0.5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Destroy(TheObject);
        }

        if (TheObject == null) { createObject(); }
    }
}
