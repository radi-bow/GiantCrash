using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;

public class NumberButtonController : MonoBehaviour {
    private PillarManager pillarManager;

    // Use this for initialization
    void Start()
    {
        pillarManager = GameObject.Find("PillarManager").GetComponent<PillarManager>();
        GetComponent<CompoundButtonText>().Text = (pillarManager.pillarNum + 1).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        var button = GetComponent<CompoundButton>();
        button.OnButtonPressed += ButtonPressed;
    }

    private void OnDisable()
    {
        var button = GetComponent<CompoundButton>();
        button.OnButtonPressed -= ButtonPressed;
    }

    private void ButtonPressed(GameObject obj)
    {
        pillarManager.pillarNum++;
        if (pillarManager.pillarNum == 9)
        {
            pillarManager.pillarNum = 0;
        }
        GetComponent<CompoundButtonText>().Text = (pillarManager.pillarNum + 1).ToString();
    }
}
