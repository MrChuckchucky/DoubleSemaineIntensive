using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour {

    Vector3 lastPosition;

    public GameObject FX_FootSteps;

    // Use this for initialization
    void Start () {
        lastPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (lastPosition == transform.position)
        {
            FX_FootSteps.SetActive(false);
            
        } else if (lastPosition != transform.position)
        {
            FX_FootSteps.SetActive(true);
        }
        lastPosition = transform.position;
    }
}
