using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    public bool IsPaused;
    public GameObject PanelPause;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
          if (Input.GetKeyDown(KeyCode.Joystick1Button7))
          {
              if (IsPaused == false)
              {
                  IsPaused = true;
                  PanelPause.SetActive(true);
              }
              else
              {
                  IsPaused = false;
                  PanelPause.SetActive(false);
              }
              
          }
	}

}
