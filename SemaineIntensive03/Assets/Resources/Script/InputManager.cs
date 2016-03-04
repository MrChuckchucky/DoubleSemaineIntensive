using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	float degreeCam = 90;
	RaycastHit hit;
	GameObject lastHit = null;
	float speedShake = 3;
	float degreeShakeMax = 10;
	int layerMask = 1 << 8; //layer 8 = Obstacle
	bool camFix = true;
	string stateShake = "one";

	EnemyManager Emanage;

	EnemyManager.EnemyType EType;

	public float life;
	public float range;
	public float damage;
	public float speed;
	public float CDMax;
	public int nbMunitions;
    public int HC;

	float dispShotgun = 2;
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
		Emanage.SetClass (EType, out life, out range, out damage, out speed, out CDMax, out nbMunitions, out HC);
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentCD -= Time.deltaTime;
		CamCheck ();
		//ScreenShake ();
		CheckInput ();
		if (camFix) {Camera.main.transform.LookAt (this.gameObject.transform);}
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
		if (Input.GetKeyDown (KeyCode.Space)) {Fire();}
		if (Input.GetButtonDown("Fire1")) {CheckSwap ();}
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			//Camera.main.transform.LookAt(this.gameObject.transform);
			this.gameObject.transform.Rotate(-Vector3.up * degreeCam);
			//Camera.main.transform.Translate(Vector3.right * speed * Time.deltaTime);
			Camera.main.transform.position = (Camera.main.transform.position - this.gameObject.transform.position).normalized * 16 + this.gameObject.transform.position;
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,9,Camera.main.transform.position.z);
		}
		if (Input.GetKeyDown (KeyCode.E))
		{
			//Camera.main.transform.LookAt(this.gameObject.transform);
			this.gameObject.transform.Rotate(Vector3.up * degreeCam);
			//Camera.main.transform.Translate(-Vector3.right * speed *  Time.deltaTime);
			Camera.main.transform.position = (Camera.main.transform.position - this.gameObject.transform.position).normalized * 16 + this.gameObject.transform.position;
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,9,Camera.main.transform.position.z);
		}
	}

	public void takeDamage(float dmg)
	{
		life -= dmg;
		if (life <= 0) {Destroy (this.gameObject);}
	}
		
	void Fire()
	{
		if (currentCD < 0 && nbMunitions > 0) 
		{
			nbMunitions--;
			Vector3 dir = Camera.main.transform.forward;
			Vector3 vision = this.gameObject.transform.position;
			if (EType != EnemyManager.EnemyType.HEAVY) 
			{
				if (dir.x == 0 && dir.z > 0) 
				{
					vision.z += range;
					Debug.DrawLine (this.gameObject.transform.position, vision, Color.red);
					if (Physics.Linecast (this.gameObject.transform.position, vision, out hit)) {
						if (hit.collider.tag == "Swapable") {
							hit.collider.gameObject.GetComponent<EnemyScript> ().takeDamage (damage);
						}
					}
				}
				else if (dir.x == 0 && dir.z < 0) 
				{
					vision.z -= range;
					Debug.DrawLine (this.gameObject.transform.position, vision, Color.yellow);
					if (Physics.Linecast (this.gameObject.transform.position, vision, out hit)) {
						if (hit.collider.tag == "Swapable") {
							hit.collider.gameObject.GetComponent<EnemyScript> ().takeDamage (damage);
						}
					}
				}
				else if (dir.x > 0) 
				{
					vision.x += range;
					Debug.DrawLine (this.gameObject.transform.position, vision, Color.blue);
					if (Physics.Linecast (this.gameObject.transform.position, vision, out hit)) {
						if (hit.collider.tag == "Swapable") {
							hit.collider.gameObject.GetComponent<EnemyScript> ().takeDamage (damage);
						}
					}
				}
				else if (dir.x < 0) 
				{
					vision.x -= range;
					Debug.DrawLine (this.gameObject.transform.position, vision, Color.green);
					if (Physics.Linecast (this.gameObject.transform.position, vision, out hit)) {
						if (hit.collider.tag == "Swapable") {
							hit.collider.gameObject.GetComponent<EnemyScript> ().takeDamage (damage);
						}
					}
				}
			}
			else 
			{
				GameObject[] targets = GameObject.FindGameObjectsWithTag ("Swapable");
				foreach (GameObject go in targets) 
				{
					float dist = Vector3.Distance (this.gameObject.transform.position, go.transform.position);
					if (dist < range) 
					{
						Vector3 goPos = go.transform.position;
						float minDistX = goPos.x - dispShotgun;
						float maxDistX = goPos.x + dispShotgun;
						float minDistZ = goPos.z - dispShotgun;
						float maxDistZ = goPos.z + dispShotgun;
						if (dir.x == 0 && dir.z > 0) 
						{
							if (goPos.x > minDistX && goPos.x < maxDistX) 
							{
								Debug.Log ("shoot front");
								go.GetComponent<EnemyScript> ().takeDamage (damage);
							}
						}
						else if (dir.x == 0 && dir.z < 0) 
						{
							if (goPos.x > minDistX && goPos.x < maxDistX) 
							{
								Debug.Log ("shoot back");
								go.GetComponent<EnemyScript> ().takeDamage (damage);
							}
						}
						else if (dir.x > 0) 
						{
							if (goPos.z > minDistZ && goPos.z < maxDistZ) 
							{
								Debug.Log ("shoot right");
								go.GetComponent<EnemyScript> ().takeDamage (damage);
							}
						}
						else if (dir.x < 0) 
						{
							if (goPos.z > minDistZ && goPos.z < maxDistZ) 
							{
								Debug.Log ("shoot left");
								go.GetComponent<EnemyScript> ().takeDamage (damage);
							}
						}
					}
				}
			}
			//currentCD = CDMax;
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

		Vector3 pos = Camera.main.transform.localPosition;
		//Vector3 rot = Camera.main.transform.localEulerAngles;
		//Debug.Log ("initpos : " + pos);
		//Debug.Log ("initrot : " + rot);

		Camera.main.transform.parent = newPlayer.transform;


		Vector3 newPos = newPlayer.transform.position;
		//newPos.x = 0;
		newPos.y += 9;
		newPos.z -= 13;
		Camera.main.transform.position = newPos;

		Camera.main.transform.localPosition = pos;
		//Camera.main.transform.localEulerAngles = rot;
		//Debug.Log ("finalpos : " + Camera.main.transform.localPosition);
		//Debug.Log ("finalrot : " + Camera.main.transform.localEulerAngles);

		newPlayer.AddComponent<InputManager> ();

		SwitchPos (this.gameObject, newPlayer);
		this.gameObject.GetComponent<Renderer> ().material.color = Color.white;	
		this.gameObject.GetComponent<EnemyScript> ().enabled = true;
		//this.gameObject.GetComponent<EnemyScript> ().isStun = true;
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		this.gameObject.GetComponent<NavMeshObstacle> ().enabled = false;
		this.gameObject.GetComponentInChildren<test> ().gameObject.GetComponent<MeshRenderer> ().enabled = true;


		float rectY = (Mathf.Round( newPlayer.transform.eulerAngles.y / 90) * 90) % 360;
		Vector3 rectVec = new Vector3 (0,rectY,0);
		newPlayer.transform.eulerAngles = rectVec;

		Destroy (this.gameObject.GetComponent<InputManager>());		
	}

	void SwitchPos(GameObject GO1, GameObject GO2)
	{
		Vector3 Pos1 = GO1.transform.position;
		Vector3 Pos2 = GO2.transform.position;
		GO1.transform.position = Pos2;
		GO2.transform.position = Pos1;
	}

	void ScreenShake()
	{
		if (stateShake == "one") 
		{
			Camera.main.transform.Rotate(0,0,speedShake);
			Camera.main.transform.position -= new Vector3(0,0,speedShake*10) * Time.deltaTime;
			if (Camera.main.transform.eulerAngles.z > degreeShakeMax) {stateShake = "two";}
		}
		else if (stateShake == "two") 
		{
			Camera.main.transform.Rotate(0,0,-speedShake);
			Camera.main.transform.position += new Vector3(0,0,speedShake*10) * Time.deltaTime;
			if (Camera.main.transform.eulerAngles.z < 360-degreeShakeMax && Camera.main.transform.eulerAngles.z > degreeShakeMax) {stateShake = "three";}
		}
		else if (stateShake == "three") 
		{
			Camera.main.transform.Rotate(0,0,speedShake);
			if (Camera.main.transform.eulerAngles.z < degreeShakeMax) {camFix = true;}
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
