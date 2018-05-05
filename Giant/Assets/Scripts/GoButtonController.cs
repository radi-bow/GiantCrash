using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;

public class GoButtonController : MonoBehaviour {
    private PillarManager pillarManager;
    // Use this for initialization
    void Start () {
        pillarManager = GameObject.Find("PillarManager").GetComponent<PillarManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
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
        pillarManager.isGo = true;
    }
}
