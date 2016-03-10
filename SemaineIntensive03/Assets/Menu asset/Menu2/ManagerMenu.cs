using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerMenu : MonoBehaviour {

    bool OneButtonAtATime;
    public GameObject ImageChenoo;
    public GameObject ImageIndien;
    public GameObject ImageCowboy;
    public GameObject ImageEliot;

    public GameObject NewGame;
    public GameObject Quit;
    public GameObject Credits;
    public GameObject Controls;

    public GameObject ControlPanel;
    public GameObject CreditPanel;
    public GameObject PanelNoir;
    public GameObject CreditImage;

    public float movepanel;
    Vector3 PanelPosInit;
    public int WHosHere;
    bool IsInPanel;

	// Use this for initialization
	void Start () {
        WHosHere = 1;
        IsInPanel = false;
        PanelPosInit = CreditImage.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.JoystickButton0) && !IsInPanel)
        {
            switch (WHosHere)
            {
                case 1:
                    StartCoroutine(Fondu());
                    break;
                case 2:
                    ControlPanel.SetActive(true);
                    IsInPanel = true;
                    break;
                case 3:
                    CreditPanel.SetActive(true);
                    IsInPanel = true;
                    CreditImage.transform.position = PanelPosInit;
                    break;
                case 4:
                    Application.Quit();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1) && IsInPanel)
        {
            ControlPanel.SetActive(false);
            IsInPanel = false;
            CreditPanel.SetActive(false);
        }
        if (IsInPanel && WHosHere == 3)
        {
            if (Input.GetAxis("RightJoystickVertical") > 0.2f)
            {
                Vector3 PanelPos;
                PanelPos = CreditImage.transform.position;
                movepanel += 2;
                PanelPos.y = PanelPosInit.y + movepanel;
                CreditImage.transform.position = PanelPos;
                if (movepanel > 147)
                {
                    movepanel = 147;
                }
            }
            else if (Input.GetAxis("RightJoystickVertical") < -0.2f)
            {
                Vector3 PanelPos;
                PanelPos = CreditImage.transform.position;
                if (movepanel <= 0)
                {
                    movepanel = 0;
                }
                else
                {
                    movepanel -= 2;
                }
                PanelPos.y = PanelPosInit.y + movepanel;
                CreditImage.transform.position = PanelPos;
               
            }
        }
        if (Input.GetAxis("LeftJoystickVertical") > 0.3f)
        {
            if (OneButtonAtATime == false)
            {
                OneButtonAtATime = true;
                switch (WHosHere)
                {
                    case 1 :
                        ImageChenoo.GetComponent<Animation>().Play("AnimationExit");
                        ImageIndien.GetComponent<Animation>().Play("AnimationEnter");
                        NewGame.GetComponent<Animation>().Play("AnimationTextEnter");
                        Controls.GetComponent<Animation>().Play("AnimationTextExit");
                        WHosHere++;
                        break;
                    case 2 :
                        ImageIndien.GetComponent<Animation>().Play("AnimationExit");
                        ImageEliot.GetComponent<Animation>().Play("AnimationEnter");
                        Controls.GetComponent<Animation>().Play("AnimationTextEnter");
                        Credits.GetComponent<Animation>().Play("AnimationTextExit");
                        WHosHere++;
                        break;
                    case 3 :
                        ImageEliot.GetComponent<Animation>().Play("AnimationExit");
                        ImageCowboy.GetComponent<Animation>().Play("AnimationEnter");
                        Credits.GetComponent<Animation>().Play("AnimationTextEnter");
                        Quit.GetComponent<Animation>().Play("AnimationTextExit");
                        WHosHere++;
                        break;
                    case 4:
                        ImageCowboy.GetComponent<Animation>().Play("AnimationExit");
                        ImageChenoo.GetComponent<Animation>().Play("AnimationEnter");
                        Quit.GetComponent<Animation>().Play("AnimationTextEnter");
                        NewGame.GetComponent<Animation>().Play("AnimationTextExit");
                        WHosHere = 1;
                        break;
                }
                //Debug.Log(WHosHere);
                StartCoroutine(timer());
            }

        }
        else if (Input.GetAxis("LeftJoystickVertical") < -0.3f)
        {
            if (OneButtonAtATime == false)
            {
                OneButtonAtATime = true;
                switch (WHosHere)
                {
                    case 1 :
                        ImageChenoo.GetComponent<Animation>().Play("AnimationEnter2");
                        ImageCowboy.GetComponent<Animation>().Play("AnimationExit2");
                        NewGame.GetComponent<Animation>().Play("AnimationTextExitGauche");
                        Quit.GetComponent<Animation>().Play("AnimationTextEnterGauche");
                        WHosHere = 4;
                        break;
                    case 2 :
                        ImageIndien.GetComponent<Animation>().Play("AnimationEnter2");
                        ImageChenoo.GetComponent<Animation>().Play("AnimationExit2");
                        Controls.GetComponent<Animation>().Play("AnimationTextExitGauche");
                        NewGame.GetComponent<Animation>().Play("AnimationTextEnterGauche");
                        WHosHere --;
                        break;
                    case 3 :
                        ImageEliot.GetComponent<Animation>().Play("AnimationEnter2");
                        ImageIndien.GetComponent<Animation>().Play("AnimationExit2");
                        Credits.GetComponent<Animation>().Play("AnimationTextExitGauche");
                        Controls.GetComponent<Animation>().Play("AnimationTextEnterGauche");
                        WHosHere --;
                        break;
                    case 4:
                        //Debug.Log("c");
                        ImageCowboy.GetComponent<Animation>().Play("AnimationEnter2");
                        ImageEliot.GetComponent<Animation>().Play("AnimationExit2");
                        Quit.GetComponent<Animation>().Play("AnimationTextExitGauche");
                        Credits.GetComponent<Animation>().Play("AnimationTextEnterGauche");
                        WHosHere --;
                        break;
                }
                //Debug.Log(WHosHere);
                StartCoroutine(timer());
            }
        }
        else
        {
        }
	}

    IEnumerator timer ()
    {
        yield return new WaitForSeconds(0.3f);
        OneButtonAtATime = false;
    }

    IEnumerator Fondu()
    {
        float x = 0;
        while (x < 1)
        {
            x += 0.02f;
            PanelNoir.GetComponent<Image>().color = new Color(0f, 0f, 0f, x);
            yield return new WaitForEndOfFrame();
        }
        //Debug.Log("a");
        Application.LoadLevel(1);

    }
}
