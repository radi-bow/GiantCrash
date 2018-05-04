using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePillar : MonoBehaviour {
    public bool isRemoved;

	// Use this for initialization
	void Start () {
        isRemoved = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isRemoved)
        {
            isRemoved = true;
            Selected();
        }
	}

    public void Selected()
    {
        StartCoroutine("Remove");
    }

    IEnumerator Remove()
    {
        float scale = this.transform.localScale.y;
        float count = scale;
        while(count > 0.0f)
        {
            Vector3 pos = this.transform.position;
            pos.y -= 0.01f;
            this.transform.position = pos;
            count -= 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
