using UnityEngine;
using System.Collections;

public class newPlayerMoveScript : MonoBehaviour {

	RaycastHit hit;
	GameObject swaped;
	float rangeSwap = 10000000;
	float speed = 10;
	float rotationSpeed = 40;
	float range = 5;
	//Vector3 lastDir;
	// Use this for initialization
	void Start () {
	}

	void RectifyAngle()
	{
		float rectY = (Mathf.Round( this.gameObject.transform.eulerAngles.y / 90) * 90) % 360;
		Vector3 rectVec = new Vector3 (0,rectY,0);
		this.gameObject.transform.eulerAngles = rectVec;
	}

	void CheckJoystickInput()
	{
		float LJH = Input.GetAxis ("LeftJoystickHorizontal");
		float LJV = Input.GetAxis ("LeftJoystickVertical");
		float RJH = Input.GetAxis ("RightJoystickHorizontal");
		//float RJV = Input.GetAxis ("RightJoystickVertical");

		Vector3 rotation = new Vector3(0,RJH,0);
		this.gameObject.transform.Rotate (rotation * rotationSpeed * Time.deltaTime);

		Vector3 camFor = Camera.main.transform.forward;
		camFor.y = 0;
		Vector3 camRight = Camera.main.transform.right;

		this.gameObject.transform.position += camFor * speed * Time.deltaTime * LJH;
		this.gameObject.transform.position += camRight * speed * Time.deltaTime * LJV;

		if (Input.GetKeyDown(KeyCode.Joystick1Button5))
		{
			Vector3 angleTurn = new Vector3(0,90,0);
			this.gameObject.transform.Rotate (angleTurn);
			RectifyAngle ();
			//Camera.main.transform.RotateAround (this.gameObject.transform.position,this.gameObject.transform.up,-90);
			/*Debug.Log ("Cam = " + Camera.main.transform.eulerAngles);
			Vector3 camAngle = Camera.main.transform.eulerAngles;
			camAngle.x = 0;
			//this.gameObject.transform.eulerAngles = camAngle;
			Debug.Log ("Perso = " + this.gameObject.transform.eulerAngles);*/
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button4))
		{
			Vector3 angleTurn = new Vector3(0,-90,0);
			this.gameObject.transform.Rotate (angleTurn);
			RectifyAngle ();
			//Camera.main.transform.RotateAround (this.gameObject.transform.position,this.gameObject.transform.up,90);
			/*Debug.Log (Camera.main.transform.eulerAngles);
			Vector3 camAngle = Camera.main.transform.eulerAngles;
			camAngle.x = 0;
			this.gameObject.transform.eulerAngles = camAngle;
			Debug.Log ("Perso = " + this.gameObject.transform.eulerAngles);*/
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button0) && swaped != null) {Swap ();}
	}

	// Update is called once per frame
	void Update () {
		Camera.main.transform.LookAt (this.gameObject.transform);

		CheckJoystickInput ();

		CheckSwap ();
		
	}

	void CheckSwap()
	{
		if (swaped) {swaped.GetComponent<Renderer> ().material.color = Color.white;}
		if (Physics.Raycast(this.gameObject.transform.position,  this.gameObject.transform.forward, out hit)) 
		{
			if (hit.collider.tag == "Swapable") 
			{
				swaped = hit.collider.gameObject;
				swaped.GetComponent<Renderer> ().material.color = Color.green;
			}
		}
	}

	void Swap()
	{
		this.gameObject.tag = "Swapable";
		swaped.tag = "Player";

		Vector3 pos = Camera.main.transform.localPosition;

		Camera.main.transform.parent = swaped.transform;

		Vector3 newPos = swaped.transform.position;
		//newPos.x = 0;
		newPos.y += 9;
		newPos.z -= 13;
		Camera.main.transform.position = newPos;

		Camera.main.transform.localPosition = pos;

		swaped.AddComponent<InputManager> ();

		SwitchPos (this.gameObject, swaped);
		this.gameObject.GetComponent<Renderer> ().material.color = Color.white;	
		this.gameObject.GetComponent<EnemyScript> ().enabled = true;
		//this.gameObject.GetComponent<EnemyScript> ().isStun = true;
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		this.gameObject.GetComponent<NavMeshObstacle> ().enabled = false;
		this.gameObject.GetComponentInChildren<test> ().gameObject.GetComponent<MeshRenderer> ().enabled = true;


		float rectY = (Mathf.Round( swaped.transform.eulerAngles.y / 90) * 90) % 360;
		Vector3 rectVec = new Vector3 (0,rectY,0);
		swaped.transform.eulerAngles = rectVec;

		Destroy (this.gameObject.GetComponent<InputManager>());		
	}

	void SwitchPos(GameObject GO1, GameObject GO2)
	{
		Vector3 Pos1 = GO1.transform.position;
		Vector3 Pos2 = GO2.transform.position;
		GO1.transform.position = Pos2;
		GO2.transform.position = Pos1;
	}
}
