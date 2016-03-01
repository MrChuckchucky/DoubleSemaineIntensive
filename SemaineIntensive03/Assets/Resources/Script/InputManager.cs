using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public float speed;
	RaycastHit hit;
	GameObject lastHit = null;

	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<Renderer> ().material.color = Color.red;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CamCheck ();
		if (Input.GetKey (KeyCode.Z)) {MoveFront ();}
		if (Input.GetKey (KeyCode.Q)) {MoveLeft ();}
		if (Input.GetKey (KeyCode.S)) {MoveBack ();}
		if (Input.GetKey (KeyCode.D)) {MoveRight ();}
	}

	void CamCheck()
	{
		int layerMask = 1 << 8;
		if (lastHit != null) 
		{
			Color newCol = lastHit.GetComponent<MeshRenderer> ().material.GetColor ("_Color");
			newCol.a = 1;
			lastHit.GetComponent<MeshRenderer> ().material.SetColor("_Color", newCol);
		}
		if (Physics.Linecast (Camera.main.transform.position, this.gameObject.transform.position, out hit, layerMask)) 
		{
			lastHit = hit.collider.gameObject;
			Material mat = lastHit.GetComponent<MeshRenderer> ().material;

			//mat.SetFloat("_Mode", 4f);
			mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			//mat.SetInt("_ZWrite", 0);
			//mat.DisableKeyword("_ALPHATEST_ON");
			mat.EnableKeyword("_ALPHABLEND_ON");
			//mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			mat.renderQueue = 3000;

			Color newCol = mat.GetColor ("_Color");
			newCol.a = 0.5f;
			mat.SetColor("_Color", newCol);
		}
	}

	void MoveFront()
	{
		Vector3 move = Camera.main.transform.forward;
		move.y = 0;
		this.gameObject.transform.position += move * speed * Time.deltaTime;
	}

	void MoveRight()
	{
		Vector3 move = Camera.main.transform.right;
		move.y = 0;
		this.gameObject.transform.position += move * speed * Time.deltaTime;
	}

	void MoveLeft()
	{
		Vector3 move = Camera.main.transform.right;
		move.y = 0;
		this.gameObject.transform.position -= move * speed * Time.deltaTime;
	}

	void MoveBack()
	{
		Vector3 move = Camera.main.transform.forward;
		move.y = 0;
		this.gameObject.transform.position -= move * speed * Time.deltaTime;
	}
}
