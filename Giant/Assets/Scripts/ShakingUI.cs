using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingUI : MonoBehaviour {
    private float time;

    public float ampDist;
    public float ampTime;
	// Use this for initialization
	void Start () {
        time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        
        Vector3 pos = this.transform.localPosition;
        pos.y += ampDist * Mathf.Sin(ampTime * time);
        this.transform.localPosition = pos;
	}
}
