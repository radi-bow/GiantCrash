using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCrashController : MonoBehaviour {
    private GameController gameController;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Giant")
        {
            StartCoroutine("WaitAndGoEnd",other.gameObject);
        }
    }

    IEnumerator WaitAndGoEnd(GameObject gameObject)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(GameObject.Find("Giant(Clone)"));
        gameController.ChangeToEnd();
    }
}
