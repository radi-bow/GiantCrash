using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarManager : MonoBehaviour {
    public int colorNum;
    public int pillarNum;
    public GameObject[] pillars;
    public bool[] pillarsState = new bool[36];

    private int prevPillarNum;
    private Color prevColor;
    private SelectedPillarController selectedPillarController;
    public bool isGo;

	// Use this for initialization
	void Start () {
        colorNum = 0;
        pillarNum = 0;
        for(int i = 0; i < 36; i++)
        {
            pillarsState[i] = true;
        }
        //prevColor = pillars[GetColorPillarNum(colorNum, pillarNum)].GetComponent<Renderer>().material.color;
        //pillars[GetColorPillarNum(colorNum, pillarNum)].GetComponent<Renderer>().material.color = Color.white;
        selectedPillarController = GameObject.Find("SelectedPillarController").GetComponent<SelectedPillarController>();
        selectedPillarController.SetSelectedPillarMaterial(pillars[GetColorPillarNum(colorNum, pillarNum)]);
    }

    // Update is called once per frame
    void Update() {
        int nowPillarNum = GetColorPillarNum(colorNum, pillarNum);
        if (prevPillarNum != nowPillarNum)
        {
            //pillars[prevPillarNum].GetComponent<Renderer>().material.color = prevColor;
            //prevColor = pillars[nowPillarNum].GetComponent<Renderer>().material.color;
            //pillars[nowPillarNum].GetComponent<Renderer>().material.color = Color.white;
            selectedPillarController.ResetSelectedPillarMaterial(pillars[prevPillarNum]);
            selectedPillarController.SetSelectedPillarMaterial(pillars[nowPillarNum]);
        }
        if (isGo && pillarsState[nowPillarNum])//goのclickを受け取ったら
        {
            isGo = false;
            RemovePillar(colorNum, pillarNum);
        }

        prevPillarNum = nowPillarNum;
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
