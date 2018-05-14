using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;

public class PillarManager : MonoBehaviour {
    public int colorNum;
    public int pillarNum;
    public GameObject[] pillars;
    public bool[] pillarsState = new bool[36];

    private int prevPillarNum;
    private Color prevColor;
    private SelectedPillarController selectedPillarController;
    public bool isGo;

    public GameObject numberButton;
    public GameObject colorButton;

    public AudioSource buttonSE;

	// Use this for initialization
	void Start () {
        colorNum = 0;
        pillarNum = 0;
        for(int i = 0; i < 36; i++)
        {
            pillarsState[i] = true;
        }
        selectedPillarController = GameObject.Find("SelectedPillarController").GetComponent<SelectedPillarController>();
        selectedPillarController.SetSelectedPillarMaterial(pillars[GetColorPillarNum(colorNum, pillarNum)]);
    }

    // Update is called once per frame
    void Update() {
        int nowPillarNum = GetColorPillarNum(colorNum, pillarNum);
        if (prevPillarNum != nowPillarNum)
        {
            selectedPillarController.ResetSelectedPillarMaterial(pillars[prevPillarNum]);
            selectedPillarController.SetSelectedPillarMaterial(pillars[nowPillarNum]);
        }

        if (isGo)
        {
            isGo = false;
            if (pillarsState[nowPillarNum])
            {
                RemovePillar(colorNum, pillarNum);
            }
        }

        prevPillarNum = nowPillarNum;
	}

    public void RemovePillar(int color, int num)
    {
        if (pillarsState[GetColorPillarNum(color,num)])
        {
            pillars[GetColorPillarNum(color, num)].GetComponent<RemovePillar>().Removed();
            pillars[GetColorPillarNum(color, num)].GetComponent<AudioSource>().Play();
            pillarsState[GetColorPillarNum(color,num)] = false;
        }
    }

    public void ResetPillars()
    {
        for (int i = 0; i < 36; i++)
        {
            if (!pillarsState[i])
            {
                pillars[i].SetActive(true);
                Vector3 pos = pillars[i].transform.position;
                pos.y += 1.00f;
                pillars[i].transform.position = pos;
                pillarsState[i] = true;
            }
        }
    }

    private int GetColorPillarNum(int color, int num)
    {
        return color * 9 + num;
    }

    void GameGo()
    {
        isGo = true;
    }

    void SelectOne()
    {
        pillarNum = 0;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectTwo()
    {
        pillarNum = 1;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectThree()
    {
        pillarNum = 2;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectFour()
    {
        pillarNum = 3;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectFive()
    {
        pillarNum = 4;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectSix()
    {
        pillarNum = 5;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectSeven()
    {
        pillarNum = 6;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectEight()
    {
        pillarNum = 7;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectNine()
    {
        pillarNum = 8;
        buttonSE.Play();
        numberButton.GetComponent<CompoundButtonText>().Text = (pillarNum + 1).ToString();
    }

    void SelectYellow()
    {
        colorNum = 0;
        buttonSE.Play();
        //colorButton.GetComponent<CompoundButtonMesh>().Profile = colorButton.GetComponent<ColorButtonController>().profile[colorNum];
        colorButton.GetComponent<CompoundButtonText>().Text = "yellow";
    }

    void SelectBlue()
    {
        colorNum = 1;
        buttonSE.Play();
        //colorButton.GetComponent<CompoundButtonMesh>().Profile = colorButton.GetComponent<ColorButtonController>().profile[colorNum];
        colorButton.GetComponent<CompoundButtonText>().Text = "blue";
    }

    void SelectRed()
    {
        colorNum = 2;
        buttonSE.Play();
        //colorButton.GetComponent<CompoundButtonMesh>().Profile = colorButton.GetComponent<ColorButtonController>().profile[colorNum];
        colorButton.GetComponent<CompoundButtonText>().Text = "red";
    }

    void SelectGreen()
    {
        colorNum = 3;
        buttonSE.Play();
        //colorButton.GetComponent<CompoundButtonMesh>().Profile = colorButton.GetComponent<ColorButtonController>().profile[colorNum];
        colorButton.GetComponent<CompoundButtonText>().Text = "green";
    }
}
