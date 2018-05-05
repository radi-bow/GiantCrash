using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;

public class NumberButtonController : MonoBehaviour {
    private PillarManager pillarManager;
    private float time;

    // Use this for initialization
    void Start()
    {
        pillarManager = GameObject.Find("PillarManager").GetComponent<PillarManager>();
        GetComponent<CompoundButtonText>().Text = (pillarManager.pillarNum + 1).ToString();
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
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
        if(time > 1.0f)
        {
            time = 0.0f;
            pillarManager.pillarNum++;
            if (pillarManager.pillarNum == 9)
            {
                pillarManager.pillarNum = 0;
            }
            GetComponent<CompoundButtonText>().Text = (pillarManager.pillarNum + 1).ToString();
        }
    }
}
