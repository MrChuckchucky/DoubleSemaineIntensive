using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public bool IsPaused;
    public GameObject PanelPause;

    public GameObject Quit;
    public GameObject Controls;
    public GameObject ControlPanel;

    bool OneButtonAtATime;
    bool IsInPanel;

	// Use this for initialization
	void Start () {
        Controls.GetComponent<Animator>().SetBool("IsAnimating", false);
	}
	
	// Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (IsPaused == false)
            {
                IsPaused = true;
                PanelPause.SetActive(true);
                Controls.GetComponent<Animator>().SetBool("IsAnimating", true);
                Controls.GetComponent<Button>().interactable = true;
                Quit.GetComponent<Animator>().SetBool("IsAnimating", false);
            }
            else
            {
                IsPaused = false;
                PanelPause.SetActive(false);
            }

        }

        if (Input.GetAxis("LeftJoystickVertical") < -0.3f || Input.GetAxis("LeftJoystickVertical") > 0.3f)
        {
            if (IsPaused && !OneButtonAtATime)
            {
                if (Controls.GetComponent<Button>().interactable)
                {
                    Quit.GetComponent<Button>().interactable = true;
                    Controls.GetComponent<Button>().interactable = false;
                    OneButtonAtATime = true;
                    Quit.GetComponent<Animator>().SetBool("IsAnimating", true);
                    Controls.GetComponent<Animator>().SetBool("IsAnimating", false);
                }
                else
                {
                    Controls.GetComponent<Button>().interactable = true;
                    Quit.GetComponent<Button>().interactable = false;
                    OneButtonAtATime = true;
                    Controls.GetComponent<Animator>().SetBool("IsAnimating", true);
                    Quit.GetComponent<Animator>().SetBool("IsAnimating", false);
                }

            }
        }
        else
        {
            OneButtonAtATime = false;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && !IsInPanel)
        {
            if (Controls.GetComponent<Button>().interactable)
            {
                ControlsButton();
                //Debug.Log("a");
            }
            else
            {
                ButtonQuitGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && IsInPanel)
        {
            ControlPanel.SetActive(false);
            IsInPanel = false;
        }
    }

    public void ButtonQuitGame()
    {
        Application.Quit();
    }

    public void ControlsButton()
    {
        ControlPanel.SetActive(true);
        IsInPanel = true;
    }

}
