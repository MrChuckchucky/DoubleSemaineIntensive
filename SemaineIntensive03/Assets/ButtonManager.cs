using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public GameObject NewGame;
    public GameObject Quit;
    public bool OneButtonAtATime;

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	        if (Input.GetAxis("LeftJoystickHorizontal") > 0.3f || Input.GetAxis("LeftJoystickHorizontal") < -0.3f)
            {
                if (OneButtonAtATime == false) 
                {
                    if (NewGame.GetComponent<Button>().interactable)
                    {
                        NewGame.GetComponent<Button>().interactable = false;
                        Quit.GetComponent<Button>().interactable = true;
                        OneButtonAtATime = true;
                    }
                    else
                    {
                        NewGame.GetComponent<Button>().interactable = true;
                        Quit.GetComponent<Button>().interactable = false;
                        OneButtonAtATime = true;
                    }
                }
                
            }
            else
            {
                OneButtonAtATime = false;
            }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (NewGame.GetComponent<Button>().interactable)
            {
                ButtonNewGame();
                //Debug.Log("a");
            }
            else
            {
                ButtonQuitGame();
            }
        }
	}

    public void ButtonNewGame ()
    {
        Application.LoadLevel(1);
    }

    public void ButtonQuitGame()
    {
        Application.Quit();
    }
}
