using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;

public class ChangeColor : MonoBehaviour {
    public int colorNum;
    public ButtonMeshProfile[] profile;
    public AudioSource buttonSE;

    private PillarManager pillarManager;
    private float time;
    // Use this for initialization
    void Start () {
        pillarManager = GameObject.Find("PillarManager").GetComponent<PillarManager>();
        //GetComponent<CompoundButtonMesh>().Profile = profile[pillarManager.colorNum];
        time = 0.0f;
    }
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
        if (time > 1.0f)
        {
            time = 0.0f;
            buttonSE.Play();
            pillarManager.colorNum = colorNum;

            //GetComponent<CompoundButtonMesh>().Profile = profile[pillarManager.colorNum];
        }
    }
}
