using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePillar : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Removed()
    {
        StartCoroutine("Remove");
    }

    IEnumerator Remove()
    {
        int count = 0;
        while(count < 50)
        {
            Vector3 pos = this.transform.position;
            pos.y -= 0.05f;
            this.transform.position = pos;
            count++;
            yield return new WaitForSeconds(0.05f);
        }
        this.gameObject.SetActive(false);
    }
}
