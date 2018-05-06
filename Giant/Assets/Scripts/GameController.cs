using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject toolBar;
    [SerializeField] private GameObject endUI;

    public GameObject giant;
    public GameObject pillars;

    private PillarManager pillarManager;

	// Use this for initialization
	void Start () {
        startUI.SetActive(true);
        toolBar.SetActive(false);
        endUI.SetActive(false);
        pillarManager = GameObject.Find("PillarManager").GetComponent<PillarManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeToGame()
    {
        Vector3 pos = pillars.transform.position;
        Instantiate(giant,new Vector3(pos.x,pos.y + 1.0f,pos.z),pillars.transform.rotation);
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
        pillarManager.ResetPillars();
        startUI.SetActive(true);
        toolBar.SetActive(false);
        endUI.SetActive(false);
    }
}
