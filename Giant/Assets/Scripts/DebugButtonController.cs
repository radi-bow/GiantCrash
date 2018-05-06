using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;

public class DebugButtonController : MonoBehaviour {
    private float time;

    // Use this for initialization
    void Start () {
        time = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
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
        if (time > 1.0f)
        {
            time = 0.0f;
            ReplaceObject.placing = true;
            GameObject.Find("StartUI").SetActive(false);
        }
    }
}
