using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarManager : MonoBehaviour {
    public int colorNum;
    public int pillarNum;
    public GameObject[] pillars;
    public bool[] pillarsState = new bool[36];

	// Use this for initialization
	void Start () {
        colorNum = 0;
        pillarNum = 0;
        for(int i = 0; i < 36; i++)
        {
            pillarsState[i] = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		RemovePillar(2,8);
	}

    public void RemovePillar(int color, int num)
    {
        if (pillarsState[GetColorPillarNum(color,num)])
        {
            pillars[GetColorPillarNum(color, num)].GetComponent<RemovePillar>().Removed();
            pillarsState[GetColorPillarNum(color,num)] = false;
        }
    }

    private int GetColorPillarNum(int color, int num)
    {
        return color * 9 + num;
    }
}
