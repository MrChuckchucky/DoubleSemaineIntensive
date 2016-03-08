using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [Header("String")]
    [Multiline(20)]
    public string text;
    public string[] textArray;

    [Header("Typewriting")]
    //Peut être proposer différentes vitesses de lecture ??
    public float letterPause = 0.05f;

    [Header("Wait")]
    public float waitExclamation = 0.5f;
    public float waitQuestion = 1f;
    public float waitDots = 3f;

    [Header("Wait")]
    bool validation;
    IEnumerator Jumptotext;
    IEnumerator Typerwrite;

    // Use this for initialization
    void Start()
    {
       // text = "We are dead. The white men took our land, our women, our cities.... and our world ?# \n\nWe are nothing but memories, whitering shadows before the dawn of a new day. ?# \n\nBut remember. We are dead, not forgotten. ?# \n\nLegends whispers the name of the one who will avenge us ?# \n\nChenoo ! The Soul Eating Monster ! ?# \n\nBack from the dead, he will bring doom upon their cities, calling our Ancestral Totems by his side ?# !! \n\nHe will make his the body of our foes, swapping their mind for his (LT), using their weapon to defeat their own kind (RT) ?# \n\nHe does not fear death, for only its host will cease to be. ?# !! As long as the Totems are here, his destruction will know no end. ?# \n\n.... ?# \n\nYour time has come, Chenoo. Go forth and bring chaos to this world.";
        StartCoroutine("Typewriting", text);
    }
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (validation)
            {
                Application.LoadLevel(2);
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
        textToType = text.Remove(0, GetComponent<Text>().text.Length);
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

                yield return new WaitForSeconds(waitQuestion);
                waitQuestion = 1;
                letterPause = 0.05f;

            }
           
            else if (array.Contains("!!"))
            {
                GetComponent<Text>().text = "";
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

}
