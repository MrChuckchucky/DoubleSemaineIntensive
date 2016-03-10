using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour
{
    public float maxSize;
    public float growFactor;
    public float waitTime;

    public GameObject VictoryUI;

    void Start()
    {
        StartCoroutine(Scale());
        VictoryUI.SetActive(true);
		StartCoroutine(WaitAnim());
    }

    IEnumerator Scale()
    {
        float timer = 0;

        while (true)
        {
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }

	IEnumerator WaitAnim() {
		yield return new WaitForSeconds (8);
		Application.LoadLevel(0);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Joystick1Button7)) {
			// Retour au menu
			Application.LoadLevel(0);
		}
	}
}
