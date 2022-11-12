using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float x_shift = (float)-0.44;
    private float z_shift = 1;

    public int formation = 2;

    public float[][] xs = new float[4][];
    public float[][] zs = new float[4][];
    public bool[][] bools = new bool[4][];
    public Transform pos;

    //[SerializeField]
    public GameObject pinPrefab;
    //public GameObject MetalPrefab;
    //public GameObject WaterPrefab;

    void Start()
    {
        //initlize the x's
        for (int i = 0; i < 4; i++)
        {
            xs[i] = new float[4];
            for (int j = 0; j < 4; j++)
            {
                //just small bullshit
                float indent = 0;
                if (i % 2 != 0 && formation != 2 && formation != 3) { indent = (float)0.1; } //if rows 1 or 3 (not 0 or 2)
                xs[i][j] = (float)((indent + (0.2 * j)));
            }
        }

        //initlize the z's
        for (int i = 0; i < 4; i++)
        {
            zs[i] = new float[4];
            for (int j = 0; j < 4; j++)
            {
                zs[i][j] = (float)((0.2 * i));
            }
        }


        //1.normal
        if (formation == 1)
        {
            bools[0] = new bool[] { false, false, true, false };
            bools[1] = new bool[] { false, true, true, false };
            bools[2] = new bool[] { false, true, true, true };
            bools[3] = new bool[] { true, true, true, true };
        }

        //2.circle
        if (formation == 2)
        {
            bools[0] = new bool[] { false, true, true, false };
            bools[1] = new bool[] { true, true, true, true };
            bools[2] = new bool[] { true, true, true, true };
            bools[3] = new bool[] { false, true, true, false };
        }

        //3.square
        if (formation == 3)
        {
            for (int i = 0; i < 4; i++)
            {
                bools[i] = new bool[4];
                for (int j = 0; j < 4; j++)
                {
                    bools[i][j] = true;
                }
            }
        }

        //4.upside pyramid
        if (formation == 4)
        {
            bools[0] = new bool[] { true, true, true, true };
            bools[1] = new bool[] { true, true, true, false };
            bools[2] = new bool[] { false, true, true, false };
            bools[3] = new bool[] { false, true, false, false };
        }

        //5.line
        if (formation == 5)
        {
            bools[0] = new bool[] { false, false, false, false };
            bools[1] = new bool[] { false, false, false, false };
            bools[2] = new bool[] { false, false, false, false };
            bools[3] = new bool[] { true, true, true, true };
        }

        //6.single
        if (formation == 6)
        {
            bools[0] = new bool[] { false, false, true, false };
            bools[1] = new bool[] { false, false, false, false };
            bools[2] = new bool[] { false, false, false, false };
            bools[3] = new bool[] { false, false, false, false };
        }

        //spawn shit
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bools[i][j] == false) { continue; }
                Vector3 curr_pos = new Vector3(pos.position.x + xs[i][j] + x_shift, pos.position.y + (float)0.19, (pos.position.z / 4) + zs[i][j] + z_shift);
                //Debug.Log("Hello: " + curr_pos);
                Instantiate(pinPrefab, curr_pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
