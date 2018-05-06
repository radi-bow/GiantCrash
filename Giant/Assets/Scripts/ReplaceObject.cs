using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

public class ReplaceObject : MonoBehaviour, IInputClickHandler{
    public static bool placing = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (placing)
        {
            SpatialMappingManager.Instance.DrawVisualMeshes = true;
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, SpatialMappingManager.Instance.LayerMask))
            {
                // Move this object's parent object to
                // where the raycast hit the Spatial Mapping mesh.
                this.transform.parent.position = hitInfo.point;

                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                this.transform.parent.rotation = toQuat;
            }
        }
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        // On each Select gesture, toggle whether the user is in placing mode.
        if (GameObject.Find("StartUI") == null && GameObject.Find("ToolBar") == null && GameObject.Find("EndBar") == null)
        {
            placing = !placing;
            SpatialMappingManager.Instance.DrawVisualMeshes = false;
            GameObject.Find("GameController").GetComponent<GameController>().ChangeToStart();
        }

        // If the user is in placing mode, display the spatial mapping mesh.
        /*if (placing)
        {
            SpatialMappingManager.Instance.DrawVisualMeshes = true;
        }*/
        // If the user is not in placing mode, hide the spatial mapping mesh.
        /*else
        {
            SpatialMappingManager.Instance.DrawVisualMeshes = false;
            GameObject.Find("GameController").GetComponent<GameController>().ChangeToStart();
        }*/
    }
}
