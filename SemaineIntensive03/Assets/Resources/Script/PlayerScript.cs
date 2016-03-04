using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	float rotationSpeed = 40;
	GameObject swaped;
	float rangeSwap = 10;
	RaycastHit hit;
	GameObject lastHit = null;
	int layerMask = 1 << 8; //layer 8 = Obstacle

	EnemyManager Emanage;

	EnemyManager.EnemyType EType;

	public float life;
	public float range;
	public float damage;
	public float speed;
	public float CDMax;

	float dispShotgun = 1.5f;
	int nbMunitions = 10;
	float currentCD = 0;

	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		this.gameObject.GetComponent<EnemyScript> ().enabled = false;
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
		this.gameObject.GetComponent<NavMeshObstacle> ().enabled = true;
		this.gameObject.GetComponentInChildren<test> ().gameObject.GetComponent<MeshRenderer> ().enabled = false;
		EType = this.gameObject.GetComponent<EnemyScript> ().EType;
		Emanage = GameObject.FindObjectOfType<EnemyManager> ();
		Emanage.SetClass (EType, out life, out range, out damage, out speed, out CDMax);
	}

	// Update is called once per frame
	void Update () 
	{
		Camera.main.transform.LookAt (this.gameObject.transform);
		currentCD -= Time.deltaTime;
		CamCheck ();
		//CheckInput ();
		CheckJoystickInput ();
		CheckSwap ();
		CheckFire ();
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
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button4))
		{
			Vector3 angleTurn = new Vector3(0,-90,0);
			this.gameObject.transform.Rotate (angleTurn);
			RectifyAngle ();
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button0) && swaped != null) {Swap ();}
		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) {Fire ();}
	}

	public void takeDamage(float dmg)
	{
		life -= dmg;
		if (life <= 0) {Destroy (this.gameObject);}
	}

	void CheckSwap()
	{
		if (swaped) 
		{
			//swaped.GetComponent<Renderer> ().material.color = Color.white;
			swaped = null;
		}
		if (Physics.Raycast(this.gameObject.transform.position,  this.gameObject.transform.forward, out hit, rangeSwap)) 
		{
			if (hit.collider.tag == "Swapable") 
			{
				swaped = hit.collider.gameObject;
				//swaped.GetComponent<Renderer> ().material.color = Color.green;
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

		swaped.AddComponent<PlayerScript> ();

		SwitchPos (this.gameObject, swaped);
		this.gameObject.GetComponent<Renderer> ().material.color = Color.white;	
		this.gameObject.GetComponent<EnemyScript> ().enabled = true;
		this.gameObject.GetComponent<EnemyScript> ().isStun = true;
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		this.gameObject.GetComponent<NavMeshObstacle> ().enabled = false;
		this.gameObject.GetComponentInChildren<test> ().gameObject.GetComponent<MeshRenderer> ().enabled = true;


		float rectY = (Mathf.Round( swaped.transform.eulerAngles.y / 90) * 90) % 360;
		Vector3 rectVec = new Vector3 (0,rectY,0);
		swaped.transform.eulerAngles = rectVec;

		Destroy (this.gameObject.GetComponent<PlayerScript>());		
	}

	void SwitchPos(GameObject GO1, GameObject GO2)
	{
		Vector3 Pos1 = GO1.transform.position;
		Vector3 Pos2 = GO2.transform.position;
		GO1.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GO2.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GO1.transform.position = Pos2;
		GO2.transform.position = Pos1;
	}

	GameObject fired = null;
	void CheckFire()
	{
		if (fired) 
		{
			fired.GetComponent<Renderer> ().material.color = Color.white;
			fired = null;
		}
		if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, range)) 
		{
			if (hit.collider.tag == "Swapable") 
			{
				fired = hit.collider.gameObject;
				fired.GetComponent<Renderer> ().material.color = Color.red;
			}
		}
	}

	void Fire()
	{
		if (currentCD < 0 && nbMunitions > 0) 
		{
			nbMunitions--;
			if (EType != EnemyManager.EnemyType.HEAVY) 
			{
				if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, range)) 
				{
					if (hit.collider.tag == "Swapable") 
					{
						hit.collider.gameObject.GetComponent<EnemyScript> ().takeDamage (damage);
					}
				}
			}
			else 
			{
				GameObject[] targets = GameObject.FindGameObjectsWithTag ("Swapable");
				RaycastHit[] inSphere = Physics.SphereCastAll(this.gameObject.transform.position, dispShotgun, this.gameObject.transform.forward, range);
				foreach (GameObject go in targets) 
				{
					float dist = Vector3.Distance (this.gameObject.transform.position, go.transform.position);
					if (dist < range) 
					{
						foreach(RaycastHit RH in inSphere)
						{
								if(RH.collider.gameObject == go)
								{
									RH.collider.gameObject.GetComponent<EnemyScript> ().takeDamage (damage);
								}
						}
					}
				}
			}
			currentCD = CDMax;
		}
	}

	//USELESS FOR NOW

	void CheckInput()
	{
		if (Input.GetKey (KeyCode.Z)) {DoMovement ("up");}
		if (Input.GetKey (KeyCode.Q)) {DoMovement ("left");}
		if (Input.GetKey (KeyCode.S)) {DoMovement ("down");}
		if (Input.GetKey (KeyCode.D)) {DoMovement ("right");}
		if (Input.GetKeyDown (KeyCode.Space)) {Fire();}
		if (Input.GetButtonDown("Fire1")) {CheckSwap ();}
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			//Camera.main.transform.LookAt(this.gameObject.transform);
			this.gameObject.transform.Rotate(-Vector3.up * 90);
			//Camera.main.transform.Translate(Vector3.right * speed * Time.deltaTime);
			Camera.main.transform.position = (Camera.main.transform.position - this.gameObject.transform.position).normalized * 16 + this.gameObject.transform.position;
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,9,Camera.main.transform.position.z);
		}
		if (Input.GetKeyDown (KeyCode.E))
		{
			//Camera.main.transform.LookAt(this.gameObject.transform);
			this.gameObject.transform.Rotate(Vector3.up * 90);
			//Camera.main.transform.Translate(-Vector3.right * speed *  Time.deltaTime);
			Camera.main.transform.position = (Camera.main.transform.position - this.gameObject.transform.position).normalized * 16 + this.gameObject.transform.position;
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,9,Camera.main.transform.position.z);
		}
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
