using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podium : MonoBehaviour
{

    public GameObject NormalBallPrefab;
    public GameObject NormalPinBallPrefab;
    public GameObject MetalPinBallPrefab;
    public GameObject MagicPinBallPrefab;
    public GameObject BombPinBallPrefab;
    public GameObject MetalBallPrefab;
    public GameObject IceBallPrefab;
    public GameObject CubeBallPrefab;
    public GameObject effect;
    private GameObject TheObject;
    private GameObject currPrefab;
    private int ballType = 0;
    private bool respawnFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        createObject();
    }

    void setBall()
    {
        if (ballType == 0)
        {
            currPrefab = NormalBallPrefab;
        }

        if (ballType == 1)
        {
            currPrefab = NormalPinBallPrefab;
        }

        if (ballType == 2)
        {
            currPrefab = MetalPinBallPrefab;
        }

        if (ballType == 3)
        {
            currPrefab = MagicPinBallPrefab;
        }

        if (ballType == 4)
        {
            currPrefab = BombPinBallPrefab;
        }

        if (ballType == 5)
        {
            currPrefab = MetalBallPrefab;
        }

        if (ballType == 6)
        {
            currPrefab = IceBallPrefab;
        }

        if (ballType == 7)
        {
            currPrefab = CubeBallPrefab;
        }
    } 

    public void setBallType(int index)
    {
        ballType = index;
        Destroy(TheObject);
    }

    void createObject()
    {
        if (!respawnFlag)
        {
            return;
        }

        setBall();
        Vector3 curr_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        TheObject = Instantiate(currPrefab, curr_pos, Quaternion.identity);
        animate();
    }

    void animate()
    {
        GameObject _effect = Instantiate(effect, transform.position, transform.rotation);
        Destroy(_effect, (float)0.5);
    }

    // Update is called once per frame
    void Update()
    {
        if (TheObject == null) { createObject(); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            respawnFlag = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            respawnFlag = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            respawnFlag = true;
        }
    }
}
