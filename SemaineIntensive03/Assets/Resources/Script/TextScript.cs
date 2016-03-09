using UnityEngine;
using System.Collections;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
    [Header("String")]
    [Multiline(20)]
    public string text;
    public string[] textArray;

    [Header("Typewriting")]
    //Peut être proposer différentes vitesses de lecture ??
    public float letterPause = 0.05f;

    [Header("Wait")]
    public float waitExclamation = 0.5f;
    public float waitQuestion = 0f;
    public float waitDots = 3f;

    [Header("Wait")]
    bool validation;
    IEnumerator Jumptotext;
    IEnumerator Typerwrite;
    bool GoesOn;
    bool Stop;

    int Numberspeech;
    public GameObject ParoleSon;

    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Panel;
    // Use this for initialization
    void Start()
    {
       // text = "We are dead. The white men took our land, our women, our cities.... and our world ?# \n\nWe are nothing but memories, whitering shadows before the dawn of a new day. ?# \n\nBut remember. We are dead, not forgotten. ?# \n\nLegends whispers the name of the one who will avenge us ?# \n\nChenoo ! The Soul Eating Monster ! ?# \n\nBack from the dead, he will bring doom upon their cities, calling our Ancestral Totems by his side ?# !! \n\nHe will make his the body of our foes, swapping their mind for his (LT), using their weapon to defeat their own kind (RT) ?# \n\nHe does not fear death, for only its host will cease to be. ?# !! As long as the Totems are here, his destruction will know no end. ?# \n\n.... ?# \n\nYour time has come, Chenoo. Go forth and bring chaos to this world.";
        StartCoroutine("Typewriting", text);
        Numberspeech = 1;
        Image1.SetActive(true);
        StartCoroutine(Fondu(Image1));

    }
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (validation)
            {
                StartCoroutine(Fondu(Panel));
            }
            else if (Stop)
            {
                GoesOn = true;
            }
            else
            {
                waitQuestion = 0;
                letterPause = 0;
            }
        }

    }

    IEnumerator Typewriting(string textToType)
    {
        //Debug.Log("b");
        textToType = text.Remove(0, GetComponent<Text>().text.Length -1);
        textArray = textToType.Split(" "[0]);

        foreach (string array in textArray)
        {
            //Debug.Log (array.Length);

            if (array.Contains("?#"))
            {
                string substring = array.Replace("?#", "");
                //Debug.Log(substring);

                

                if (GetComponent<Text>().text != "")
                    GetComponent<Text>().text += " ";

                
                foreach (char letter in substring.ToCharArray())
                {
                    GetComponent<Text>().text += letter;
                    yield return new WaitForSeconds(letterPause);
                }

                //yield return new WaitForSeconds(waitQuestion);
                waitQuestion = 1;
                letterPause = 0.05f;
                switch (Numberspeech)
                {
                    case 1:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase2;
                        ParoleSon.GetComponent<Son>().ParoleSource.volume = 0.7f;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        break;
                    case 2:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase3;
                        ParoleSon.GetComponent<Son>().ParoleSource.volume = 0.6f;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        break;
                    case 3:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase4;
                        ParoleSon.GetComponent<Son>().ParoleSource.volume = 0.8f;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        Image2.SetActive(true);
                        StartCoroutine(AntiFondu(Image1));
                        StartCoroutine(Fondu(Image2));
                        break;
                    case 4:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase5;
                        ParoleSon.GetComponent<Son>().ParoleSource.volume = 0.6f;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        break;
                    case 5:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase6;
                        ParoleSon.GetComponent<Son>().ParoleSource.volume = 0.7f;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        break;
                    case 6:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase7;
                        ParoleSon.GetComponent<Son>().ParoleSource.volume = 0.6f;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        break;
                    case 7:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase8;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        Image3.SetActive(true);
                        StartCoroutine(AntiFondu(Image2));
                        StartCoroutine(Fondu(Image3));
                        break;
                    case 8:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase9;
                        ParoleSon.GetComponent<Son>().ParoleSource.volume = 1.0f;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        break;
                    case 9:
                        ParoleSon.GetComponent<Son>().ParoleSource.clip = ParoleSon.GetComponent<Son>().Phrase10;
                        ParoleSon.GetComponent<Son>().ParoleSource.volume = 0.9f;
                        ParoleSon.GetComponent<Son>().ParoleSource.Play();
                        break;

                }
                Numberspeech++;
                yield return null;
            }
           
            else if (array.Contains("!!"))
            {
                GetComponent<Text>().text = "";
            }
            else if (array.Contains("//"))
            {
                Stop = true;
                while (!GoesOn)
                {
                    yield return new WaitForEndOfFrame();
                }
                GoesOn = false;
                Stop = false;
            }

            else
            {
                if (GetComponent<Text>().text != "")
                    GetComponent<Text>().text += " ";

                foreach (char letter in array.ToCharArray())
                {
                    GetComponent<Text>().text += letter;
                    yield return new WaitForSeconds(letterPause);
                }
            }

        }
        validation = true;
        yield return null;
    }

    IEnumerator Fondu(GameObject PanelNoir)
    {
        yield return new WaitForSeconds(0.4f);
        float x = 0;
        while (x < 1)
        {
            x += 0.01f;
            if (PanelNoir != Panel) PanelNoir.GetComponent<Image>().color = new Color(255f, 255f, 255f, x);
            else PanelNoir.GetComponent<Image>().color = new Color(0f, 0f, 0f, x);
            yield return new WaitForEndOfFrame();
        }
        if (PanelNoir == Panel)
        {
            yield return new WaitForSeconds(1);
            Application.LoadLevel(2);
        }
    }

    IEnumerator AntiFondu(GameObject PanelNoir)
    {
        float x = 1;
        while (x > 0)
        {
            x -= 0.04f;
            PanelNoir.GetComponent<Image>().color = new Color(255f, 255f, 255f, x);
            yield return new WaitForEndOfFrame();
        }
    }

}
