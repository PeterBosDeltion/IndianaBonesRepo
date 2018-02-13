using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBoundaryCalculator : MonoBehaviour {
    public Vector3 leftSideBound;
    public Vector3 rightSideBound;

    public float xOffset;

    private GameObject raycaster;
	// Use this for initialization
	void Start () {
        CalculateBounds();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CalculateBounds()
    {
        foreach (Transform t in transform)
        {
            if(t.tag == "Raycaster")
            {
                raycaster = t.gameObject;
            }
        }

        Vector3 emptyPos = raycaster.transform.position;

        RaycastHit hit;
        if (Physics.Raycast(emptyPos, transform.right, out hit, 99))
        {
            rightSideBound = new Vector3(hit.transform.position.x - xOffset, hit.transform.position.y, hit.transform.position.z);

        }

        if (Physics.Raycast(emptyPos, -transform.right, out hit, 99))
        {
            leftSideBound = new Vector3(hit.transform.position.x + xOffset, hit.transform.position.y, hit.transform.position.z);

        }
    }
}
