using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinSpawner : MonoBehaviour
{
    private float x_shift = (float)-0.44;
    private float z_shift = 8;

    public int formation = 1;

    public float[][] xs = new float[4][];
    public float[][] zs = new float[4][];
    public bool[][] bools = new bool[4][];
    public int[][] pinTypes = new int[4][];

    //[SerializeField]
    public GameObject NormalPinPrefab;//1
    public GameObject MetalPinPrefab;//2
    public GameObject MagicPinPrefab;//3
    public GameObject BombPinPrefab;//4
    public bool NormalPinsBool;
    public bool MetalPinsBool;
    public bool MagicPinsBool;
    public bool BombPinsBool;

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

        //5.Horizontal line
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

        //7.vertical line
        if (formation == 7)
        {
            bools[0] = new bool[] { false, true, false, false };
            bools[1] = new bool[] { false, true, false, false };
            bools[2] = new bool[] { false, true, false, false };
            bools[3] = new bool[] { false, true, false, false };
        }

        //determind pin types **************************************************************
        //count types
        int variants = 0;
        if (NormalPinsBool) {variants++;}
        if (MetalPinsBool) {variants++;}
        if (MagicPinsBool) {variants++;}
        if (BombPinsBool) {variants++;}
        Debug.Log("variants count: " + variants);
        //make options array
        int[] typeOptions = new int[variants];
        GameObject[] objTypes = {NormalPinPrefab, MetalPinPrefab, MagicPinPrefab, BombPinPrefab};
        int index = 0;
        if (NormalPinsBool) {typeOptions[index] = 1; index++;}
        if (MetalPinsBool) {typeOptions[index] = 2; index++;}
        if (MagicPinsBool) {typeOptions[index] = 3; index++;}
        if (BombPinsBool) {typeOptions[index] = 4; index++;}
        //print selected options
        Debug.Log("Pins...");
        for (int j = 0; j < index; j++) { 
            Debug.Log(typeOptions[j]);
        }
        //randomize selection
        System.Random random = new System.Random();
        for (int i = 0; i < 4; i++){
            pinTypes[i] = new int[4];
            for (int j = 0; j < 4; j++)
            {
                pinTypes[i][j] = typeOptions[random.Next(0, typeOptions.Length)];
            }
        }

        Debug.Log("problem yet?");

        //spawn time
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bools[i][j] == false) { continue; }
                Vector3 curr_pos = new Vector3(xs[i][j] + x_shift, (float)0.19, zs[i][j] + z_shift);
                //Debug.Log("Hello: " + curr_pos);
                GameObject curr_type = objTypes[pinTypes[i][j]-1];
                Instantiate(curr_type, curr_pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
