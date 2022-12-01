using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pinManagerScript : MonoBehaviour
{
    private GameObject[] pins = new GameObject[16];
    private bool allDownFlag = false;

    private float x_shift = (float) -0.445;
    private float z_shift = 1;

    public int formation = 1;

    //public Text Score_text;
    //public GameObject Score_text2;

    public float[][] xs = new float[4][];
    public float[][] zs = new float[4][];
    public bool[][] bools = new bool[4][];
    public Transform pos;
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



    int Dissapearing_pins_count;
    GameObject[] NonDissapearing_pins;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        allDownFlag = false;

        for (int i = 0; i < 16; i++)
        {
            if (pins[i] == null)
            {
                continue;
            }

            Destroy(pins[i]);
        }

        //initlize the x's
        for (int i = 0; i < 4; i++)
        {
            xs[i] = new float[4];
            for (int j = 0; j < 4; j++)
            {
                //just small stuff
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
            x_shift = (float)-0.445;
            z_shift = 1;
            bools[0] = new bool[] { false, false, true, false };
            bools[1] = new bool[] { false, true, true, false };
            bools[2] = new bool[] { false, true, true, true };
            bools[3] = new bool[] { true, true, true, true };
        }

        //2.circle
        if (formation == 2)
        {
            x_shift = (float) -0.35;
            z_shift = (float) 1.15;
            bools[0] = new bool[] { false, true, true, false };
            bools[1] = new bool[] { true, true, true, true };
            bools[2] = new bool[] { true, true, true, true };
            bools[3] = new bool[] { false, true, true, false };
        }

        //3.square
        if (formation == 3)
        {
            x_shift = (float) -0.35;
            z_shift = (float) 1.15;

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
            x_shift = (float) -0.345;
            z_shift = (float) 1.15;

            bools[0] = new bool[] { true, true, true, true };
            bools[1] = new bool[] { true, true, true, false };
            bools[2] = new bool[] { false, true, true, false };
            bools[3] = new bool[] { false, true, false, false };
        }

        //5.Horizontal line
        if (formation == 5)
        {
            x_shift = (float) -0.445;
            z_shift = 1;
            bools[0] = new bool[] { false, false, false, false };
            bools[1] = new bool[] { false, false, false, false };
            bools[2] = new bool[] { false, false, false, false };
            bools[3] = new bool[] { true, true, true, true };
        }

        //6.single
        if (formation == 6)
        {
            x_shift = (float) -0.44;
            z_shift = (float) 1.25;
            bools[0] = new bool[] { false, false, true, false };
            bools[1] = new bool[] { false, false, false, false };
            bools[2] = new bool[] { false, false, false, false };
            bools[3] = new bool[] { false, false, false, false };
        }

        //7.vertical line
        if (formation == 7)
        {
            x_shift = (float) -0.295;
            z_shift = 1;
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
        //Debug.Log("variants count: " + variants);
        //make options array
        int[] typeOptions = new int[variants];
        GameObject[] objTypes = {NormalPinPrefab, MetalPinPrefab, MagicPinPrefab, BombPinPrefab};
        int index = 0;
        if (NormalPinsBool) {typeOptions[index] = 1; index++;}
        if (MetalPinsBool) {typeOptions[index] = 2; index++;}
        if (MagicPinsBool) {typeOptions[index] = 3; index++;}
        if (BombPinsBool) {typeOptions[index] = 4; index++;}
        //print selected options
        //Debug.Log("Pins...");

        /*for (int j = 0; j < index; j++) { 
            Debug.Log(typeOptions[j]);
        }*/

        for (int j = 0; j < index; j++) { 
            //Debug.Log(typeOptions[j]);
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


        //Debug.Log("problem yet?");

        int count = 0;



        //spawn time
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bools[i][j] == false) { continue; }
                Vector3 curr_pos = new Vector3(pos.position.x + xs[i][j] + x_shift, pos.position.y + (float)0.19, (pos.position.z / 4) + zs[i][j] + z_shift);
                //Debug.Log("Hello: " + curr_pos);
                GameObject curr_type = objTypes[pinTypes[i][j]-1];

                pins[count] = Instantiate(curr_type, curr_pos, Quaternion.identity);
                count++;

                //Instantiate(curr_type, curr_pos, Quaternion.identity);

                //if its a bomb
                //curr_type.GetComponent<bombPinScript>().setUp(i, j);

            }
        }
        Dissapearing_pins_count = GameObject.FindGameObjectsWithTag("Dissapearing").Length;
        NonDissapearing_pins = GameObject.FindGameObjectsWithTag("NonDissapearing");
        //Debug.Log("NonDissapearing_pins count: " + NonDissapearing_pins.Length);
    }


    public void flipNormalPin()
    {
        NormalPinsBool = !NormalPinsBool;
        Spawn();
    }

    public void setFormationType(int index)
    {
        formation = index + 1;
        Spawn();
    }

    public void flipMetalPin()
    {
        MetalPinsBool = !MetalPinsBool;
        Spawn();
    }

    public void flipMagicPin()
    {
        MagicPinsBool = !MagicPinsBool;
        Spawn();
    }

    public void flipBombPin()
    {
        BombPinsBool = !BombPinsBool;
        Spawn();
    }

    /*
    public void UpdateScoreAndFormation(int i, int j)
    {
        //roundScore++;
        bools[i][j] = false;
        //Debug.Log("roundScore: " + roundScore);
    }
    */

    //figure this out
    public int CountPinsDown()
    {
        if (allDownFlag)
        {
            return countTotalPins();
        }

        int score = 0;
        for (int i = 0; i < NonDissapearing_pins.Length; i++)
        {
            if (NonDissapearing_pins[i] == null)
            {
                continue;
            }

            if (
                ((NonDissapearing_pins[i].transform.eulerAngles.z > 5 && NonDissapearing_pins[i].transform.eulerAngles.z < 355) || (NonDissapearing_pins[i].transform.position.y < 0))
                    && NonDissapearing_pins[i].activeSelf)
            {
                score++;
                NonDissapearing_pins[i].SetActive(false);
            }
        }
        score += Dissapearing_pins_count - GameObject.FindGameObjectsWithTag("Dissapearing").Length;

        if (score == countTotalPins())
        {
            allDownFlag = true;
        }

        return score;
        //Debug.Log("Score: " + score);
        //Score_text.text = "55";
        //Score_text2.GetComponent<Text>().Text = "55";
    }

    public int countTotalPins()
    {
        if (!NormalPinsBool  && !MetalPinsBool && !MagicPinsBool && !BombPinsBool)
        {
            return 0;
        }

        if (formation == 1 || formation == 4)
        {
            return 10;
        }
        else if (formation == 2)
        {
            return 12;
        }
        else if (formation == 3)
        {
            return 16;
        }
        else if (formation == 5 || formation == 7)
        {
            return 4;
        }
        else if (formation == 6)
        {
            return 1;
        }

        return -1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CountPinsDown();
        }

    }
}

