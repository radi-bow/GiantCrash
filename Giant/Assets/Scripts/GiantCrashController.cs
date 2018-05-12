using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantCrashController : MonoBehaviour {
    public AudioSource crash;

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
        AudioSource audio = Instantiate(crash, gameObject.transform);
        audio.Play();
        yield return new WaitForSeconds(3.0f);
        Destroy(audio);
        Destroy(GameObject.Find("Giant(Clone)"));
        gameController.ChangeToEnd();
    }
}
