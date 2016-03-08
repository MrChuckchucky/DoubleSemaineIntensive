using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public GameObject NewGame;
    public GameObject Quit;
    public GameObject PanelNoir;
    public bool OneButtonAtATime;

	// Use this for initialization
	void Start () {
        Quit.GetComponent<Animator>().SetBool("IsAnimating", false);
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
                        NewGame.GetComponent<Animator>().SetBool("IsAnimating", false);
                        Quit.GetComponent<Animator>().SetBool("IsAnimating", true);
                    }
                    else
                    {
                        NewGame.GetComponent<Button>().interactable = true;
                        Quit.GetComponent<Button>().interactable = false;
                        OneButtonAtATime = true;
                        NewGame.GetComponent<Animator>().SetBool("IsAnimating", true);
                        Quit.GetComponent<Animator>().SetBool("IsAnimating", false);
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
        StartCoroutine("Fondu");
        
    }

    public void ButtonQuitGame()
    {
        Application.Quit();
    }

    IEnumerator Fondu()
    {
        float x = 0;
        while ( x < 1)
        {
            x += 0.02f;
            PanelNoir.GetComponent<Image>().color = new Color(0f, 0f, 0f, x);
            yield return new WaitForEndOfFrame();
        }
        //Debug.Log("a");
        Application.LoadLevel(1);

    }
}
