using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPillarController : MonoBehaviour {
    public Material mat;
    private Material prevMat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSelectedPillarMaterial(GameObject obj)
    {
        Color prevColor = obj.GetComponent<Renderer>().material.color;
        prevMat = obj.GetComponent<Renderer>().material;
        obj.GetComponent<Renderer>().material = mat;
        obj.GetComponent<Renderer>().material.SetColor("_BaseColor", prevColor);
        obj.GetComponent<Renderer>().material.SetVector("_Position", obj.transform.position);
    }

    public void ResetSelectedPillarMaterial(GameObject obj)
    {
        obj.GetComponent<Renderer>().material = prevMat;
    }
}
