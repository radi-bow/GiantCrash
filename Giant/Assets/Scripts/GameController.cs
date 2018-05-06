using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject toolBar;
    [SerializeField] private GameObject endUI;

	// Use this for initialization
	void Start () {
        startUI.SetActive(true);
        toolBar.SetActive(false);
        endUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeToGame()
    {
        startUI.SetActive(false);
        toolBar.SetActive(true);
        endUI.SetActive(false);
    }

    public void ChangeToEnd()
    {
        startUI.SetActive(false);
        toolBar.SetActive(false);
        endUI.SetActive(true);
    }

    public void ChangeToStart()
    {
        startUI.SetActive(true);
        toolBar.SetActive(false);
        endUI.SetActive(false);
    }
}
