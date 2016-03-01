using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public float speed = 10;
	RaycastHit hit;
	GameObject lastHit = null;
	Vector3 centerPointScreen;
	Vector3 centerPointWorld;
	int layerMask = 1 << 8; //layer 8 = Obstacle

	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<Renderer> ().material.color = Color.red;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CamCheck ();
		CheckInput ();
		//centerPointScreen =  new Vector3(Screen.width/2.0f, Screen.height/2.0f, Camera.main.nearClipPlane);
		//centerPointWorld =  Camera.main.ScreenToWorldPoint(centerPointScreen);
		Camera.main.transform.LookAt(this.gameObject.transform);
		//Debug.Log ("CPW = " + centerPointWorld);
		//Debug.Log ("Player = " + this.gameObject.transform.position);
	}

	void CamCheck()
	{
		//int layerMask = 1 << 8; //layer 8 = Obstacle
		if (lastHit != null){SetOpacity (lastHit, 1);}
		if (Physics.Linecast (Camera.main.transform.position, this.gameObject.transform.position, out hit, layerMask))
		{
			lastHit = hit.collider.gameObject;
			SetOpacity (lastHit, 0.5f);
		}
	}

	void SetOpacity(GameObject obj, float opacity)
	{
		Material mat = obj.GetComponent<MeshRenderer> ().material;

		//mat.SetFloat("_Mode", 4f);
		mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
		mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
		//mat.SetInt("_ZWrite", 0);
		//mat.DisableKeyword("_ALPHATEST_ON");
		mat.EnableKeyword("_ALPHABLEND_ON");
		//mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
		mat.renderQueue = 3000;

		Color newCol = mat.GetColor ("_Color");
		newCol.a = opacity;
		mat.SetColor("_Color", newCol);
	}

	void CheckInput()
	{
		if (Input.GetKey (KeyCode.Z)) {DoMovement ("up");}
		if (Input.GetKey (KeyCode.Q)) {DoMovement ("left");}
		if (Input.GetKey (KeyCode.S)) {DoMovement ("down");}
		if (Input.GetKey (KeyCode.D)) {DoMovement ("right");}
		if (Input.GetButtonDown("Fire1")) {CheckSwap ();}

		if (Input.GetKey (KeyCode.A)) 
		{
			//Camera.main.transform.LookAt(this.gameObject.transform);
			Camera.main.transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.E))
		{
			//Camera.main.transform.LookAt(this.gameObject.transform);
			Camera.main.transform.Translate(-Vector3.right * speed *  Time.deltaTime);
		}
	}

	void CheckSwap()
	{
		Ray ray;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		GameObject selected = null;
		if (Physics.Raycast (ray, out hit)){selected = hit.collider.gameObject;}
		if (selected && selected.tag == "Swapable") 
		{
			if (Physics.Linecast (this.gameObject.transform.position, selected.transform.position, out hit)) 
			{
				if (hit.collider.gameObject == selected) 
				{
					Swap (hit.collider.gameObject);
				} 
			}
		}
	}

	void Swap(GameObject newPlayer)
	{
		this.gameObject.tag = "Swapable";
		newPlayer.tag = "Player";
		Quaternion rot = Camera.main.transform.rotation;
		Debug.Log ("initrot : " + rot);
		Camera.main.transform.parent = newPlayer.transform;
		Vector3 newPos = newPlayer.transform.position;
		//newPos.x = 0;
		newPos.y += 10;
		newPos.z -= 10;
		Camera.main.transform.position = newPos;
		Camera.main.transform.rotation = rot;
		Debug.Log ("finalrot : " + Camera.main.transform.rotation);
		newPlayer.AddComponent<InputManager> ();
		this.gameObject.GetComponent<Renderer> ().material.color = Color.white;	
		Destroy (this.gameObject.GetComponent<InputManager>());
	}

	void DoMovement(string dir)
	{
		Vector3 forward = Camera.main.transform.forward;
		Vector3 right = Camera.main.transform.right;
		forward.y = right.y = 0;
		switch (dir) 
		{
			case "up":
				this.gameObject.transform.position += forward * speed * Time.deltaTime;
				//Camera.main.transform.position+= forward * speed * Time.deltaTime;
				break;
			case "right":
				this.gameObject.transform.position += right * speed * Time.deltaTime;
				//Camera.main.transform.position += right * speed * Time.deltaTime;
				break;
			case "down":
				this.gameObject.transform.position -= forward * speed * Time.deltaTime;
				//Camera.main.transform.position -= forward * speed * Time.deltaTime;
				break;
			case "left":
				this.gameObject.transform.position -= right * speed * Time.deltaTime;
				//Camera.main.transform.position -= right * speed * Time.deltaTime;
				break;
		}
	}
}
