using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Buttons;

public class ColorButtonController : MonoBehaviour {
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
        if(time > 1.0f)
        {
            time = 0.0f;
            buttonSE.Play();
            pillarManager.colorNum++;
            if (pillarManager.colorNum == 4)
            {
                pillarManager.colorNum = 0;
            }
            //GetComponent<CompoundButtonMesh>().Profile = profile[pillarManager.colorNum];
            switch (pillarManager.colorNum)
            {
                case 0:
                    GetComponent<CompoundButtonText>().Text = "黄色";
                    break;

                case 1:
                    GetComponent<CompoundButtonText>().Text = "青";
                    break;

                case 2:
                    GetComponent<CompoundButtonText>().Text = "赤";
                    break;

                case 3:
                    GetComponent<CompoundButtonText>().Text = "緑";
                    break;
            }
        }
    }
}
