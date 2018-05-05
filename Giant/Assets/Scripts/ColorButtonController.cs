using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;

public class ColorButtonController : MonoBehaviour {
    public ButtonMeshProfile[] profile;
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
        GetComponent<CompoundButtonMesh>().Profile = profile[pillarManager.colorNum];
        pillarManager.colorNum++;
        Debug.Log(pillarManager.colorNum);
        if (pillarManager.colorNum == 4)
        {
            pillarManager.colorNum = 0;
        }
    }
}
