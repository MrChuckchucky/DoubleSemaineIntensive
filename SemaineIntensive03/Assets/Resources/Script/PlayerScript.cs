using UnityEngine;
using DarkTonic.MasterAudio;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	public GameObject musicManager;

	GameObject swaped;
	//Color swapedColor;
	RaycastHit hit;
	GameObject lastHit = null;
	int layerMask = 1 << 8; //layer 8 = Obstacle
	GameObject[] AllTotems;
	bool choosingTotem = false;
	bool startChoose = false;
	bool axisChoose = false;
	int indexTot = 0;

	bool isIdling;
	bool isWalking;
	bool isRunning;
	bool isMoonWalking;
	bool isMoonRunning;
	int shootIndic;

	[HideInInspector]
	public EnemyManager Emanage;
	[HideInInspector]
	public EnemyManager.EnemyType EType;

    float rotation = 4;

	[Header("Settings by EnnemyScript")]
	public float maxLife;
	public float againstSupPercent;
	public float againstSamePercent;
	public float againstLessPercent;	
	public float life;
	public float range;
	public float damage;
	public float speed;
	public float CDMax;
	public int nbMunitions;
    public int HC;
    public float distanceAlert;

	float rotationSpeed = 100;
	float rangeSwap = 10;
	float dispShotgun = 1.75f;
    
	float CDBlood = 0;
	public float currentCD = 0;
    bool isTurning;
    Vector3 angleTurn;
    Vector3 angleTurnShaman;
    int rotationDirection;
    float swapStart;
    float swapDelay = 1;
    bool isSwaping;
    float deathStart;
    float deathDelay = 1f;
    public bool isDying;
	bool isPaused;
    // Use this for initialization
    void Start ()
    {
		musicManager = GameObject.FindGameObjectWithTag ("MusicManager");
		isIdling = isRunning = isWalking = isMoonWalking = isMoonRunning = isSwaping = isDying = false;
        this.gameObject.transform.FindChild("Head").gameObject.SetActive(true);
        this.gameObject.transform.FindChild("Head").GetComponent<Animator>().SetTrigger("Idle");
        AllTotems = GameObject.FindGameObjectsWithTag ("Totem");
		//this.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
		this.gameObject.GetComponent<EnemyScript> ().enabled = false;
		this.gameObject.GetComponent<NavMeshObstacle> ().enabled = true;
		//this.gameObject.GetComponentInChildren<test> ().gameObject.GetComponent<MeshRenderer> ().enabled = false;
		EType = this.gameObject.GetComponent<EnemyScript> ().EType;
		againstLessPercent = this.gameObject.GetComponent<EnemyScript> ().againstLessPercent; 
		againstSamePercent = this.gameObject.GetComponent<EnemyScript> ().againstSamePercent; 
		againstSupPercent = this.gameObject.GetComponent<EnemyScript> ().againstSupPercent; 
		Emanage = GameObject.FindObjectOfType<EnemyManager> ();
		Emanage.SetClass (EType, out life, out range, out damage, out speed, out CDMax, out nbMunitions, out HC, out distanceAlert);
		maxLife = life;
		isTurning = false;
		if (testSprite () == false) 
		{
			Spriting ();
		}

		if (EType == EnemyManager.EnemyType.HEAVY) {
			musicManager.GetComponent<MusicManager> ().HeavyVariation ();
		}
		if (EType == EnemyManager.EnemyType.SNEAKY) {
			musicManager.GetComponent<MusicManager> ().SneakyVariation ();
		}
		if (EType == EnemyManager.EnemyType.SNIPER) {
			musicManager.GetComponent<MusicManager> ().SniperVariation ();
		}

		GameObject.FindObjectOfType<lifewings> ().reset ();
    }

	bool testSprite()
	{
		bool HeavyDistOK = this.gameObject.transform.FindChild ("HeavyDist").GetComponent<SpriteRenderer> ().enabled;
		bool SneakyDistOK = this.gameObject.transform.FindChild ("SneakyDist").GetComponent<SpriteRenderer> ().enabled;
		bool SniperDistOK = this.gameObject.transform.FindChild ("SniperDist").GetComponent<SpriteRenderer> ().enabled;
		if (!HeavyDistOK && !SneakyDistOK && !SniperDistOK) {return false;}
		return true;
	}

	void Spriting()
	{
		switch(EType)
		{
		case EnemyManager.EnemyType.HEAVY:
			this.gameObject.transform.FindChild ("HeavyDist").GetComponent<SpriteRenderer> ().enabled = true;
			transform.FindChild("Brisk_Prefab").gameObject.SetActive(false);
			transform.FindChild("Sniper_Prefab").gameObject.SetActive(false);
			break;
		case EnemyManager.EnemyType.SNIPER:
			this.gameObject.transform.FindChild ("SniperDist").GetComponent<SpriteRenderer> ().enabled = true;
			transform.FindChild("Brisk_Prefab").gameObject.SetActive(false);
			transform.FindChild("Heavy_Prefab").gameObject.SetActive(false);
			break;
		case EnemyManager.EnemyType.SNEAKY:
			this.gameObject.transform.FindChild ("SneakyDist").GetComponent<SpriteRenderer> ().enabled = true;
			transform.FindChild("Heavy_Prefab").gameObject.SetActive(false);
			transform.FindChild("Sniper_Prefab").gameObject.SetActive(false);
			break;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		angleTurnShaman = transform.eulerAngles;
		isPaused = GameObject.Find ("Managers").GetComponent<PauseManager> ().IsPaused;
		if (isPaused == false) {
			if (CDBlood > 0) {
				CDBlood -= Time.deltaTime;
			} else {
				this.gameObject.transform.FindChild ("FX_Blood").gameObject.SetActive(false);
			}
			if (isDying && deathDelay + deathStart <= Time.time) {
				trueDeath ();
			}
			if (isSwaping)
			{
				swapStart += Time.deltaTime;
				if (swapStart >= swapDelay)
				{
					Swap();
				}
			}
			if (isTurning) {
				if (Mathf.Abs (transform.eulerAngles.y - angleTurn.y) > rotation * 3) {
					transform.eulerAngles += new Vector3 (0, rotation * rotationDirection * 1.1f, 0);
				} else {
					isTurning = false;
					RectifyAngle ();
					//Camera.main.GetComponent<UnityStandardAssets.ImageEffects.CameraMotionBlur> ().enabled = false;
				}
			}
			Camera.main.transform.LookAt (this.gameObject.transform);
			currentCD -= Time.deltaTime;
			CamCheck ();
			//CheckInput ();
			if (choosingTotem) {
				chooseDest ();
			} else {
				checkTotem ();
				if (!isSwaping && !isDying && !isTurning) {
					CheckJoystickInput ();
				}
				CheckFire ();
			}
			if (Mathf.Abs (transform.FindChild ("Head").eulerAngles.y - angleTurnShaman.y) > rotation * 3) {
				//transform.eulerAngles += new Vector3(0, rotation * rotationDirection, 0);
			}
			switch (EType) {
			case EnemyManager.EnemyType.HEAVY:
				switch (shootIndic) {
				case -2:
					if (!isMoonRunning) {
						isMoonRunning = true;
						isMoonWalking = false;
						isIdling = false;
						isWalking = false;
						isRunning = false;
						transform.FindChild ("Heavy_Prefab").GetComponent<Animator> ().SetTrigger ("Reverse Run");
					}
					break;
				case -1:
					if (!isMoonWalking) {
						isMoonWalking = true;
						isIdling = false;
						isWalking = false;
						isRunning = false;
						transform.FindChild ("Heavy_Prefab").GetComponent<Animator> ().SetTrigger ("Reverse Walk");
					}
					break;
				case 0:
					if (!isIdling) {
						isIdling = true;
						isWalking = false;
						isRunning = false;
						isMoonWalking = false;
						isMoonRunning = false;
						int random = Random.Range (0, 2);
						if (random == 0) {
							transform.FindChild ("Heavy_Prefab").GetComponent<Animator> ().SetTrigger ("Idle 1");
						} else {
							transform.FindChild ("Heavy_Prefab").GetComponent<Animator> ().SetTrigger ("Idle 2");
						}
					}
					break;
				case 1:
					if (!isWalking) {
						isWalking = true;
						isIdling = false;
						isRunning = false;
						isMoonWalking = false;
						isMoonRunning = false;
						transform.FindChild ("Heavy_Prefab").GetComponent<Animator> ().SetTrigger ("Walk");
					}
					break;
				case 2:
					if (!isRunning) {
						isRunning = true;
						isIdling = false;
						isWalking = false;
						isMoonWalking = false;
						isMoonRunning = false;
						transform.FindChild ("Heavy_Prefab").GetComponent<Animator> ().SetTrigger ("Run");
					}
					break;
				}
				break;
			case EnemyManager.EnemyType.SNEAKY:
				switch (shootIndic) {
				case -2:
					if (!isMoonRunning) {
						isMoonRunning = true;
						isMoonWalking = false;
						isIdling = false;
						isWalking = false;
						isRunning = false;
						transform.FindChild ("Brisk_Prefab").GetComponent<Animator> ().SetTrigger ("Reverse Run");
					}
					break;
				case -1:
					if (!isMoonWalking) {
						isMoonWalking = true;
						isIdling = false;
						isWalking = false;
						isRunning = false;
						isMoonRunning = false;
						transform.FindChild ("Brisk_Prefab").GetComponent<Animator> ().SetTrigger ("Reverse Walk");
					}
					break;
				case 0:
					if (!isIdling) {
						isIdling = true;
						isWalking = false;
						isRunning = false;
						isMoonWalking = false;
						isMoonRunning = false;
						transform.FindChild ("Brisk_Prefab").GetComponent<Animator> ().SetTrigger ("Idle");
					}
					break;
				case 1:
					if (!isWalking) {
						isWalking = true;
						isIdling = false;
						isRunning = false;
						isMoonWalking = false;
						isMoonRunning = false;
						int random = Random.Range (0, 2);
						if (random == 0) {
							transform.FindChild ("Brisk_Prefab").GetComponent<Animator> ().SetTrigger ("Walk 1");
						} else {
							transform.FindChild ("Brisk_Prefab").GetComponent<Animator> ().SetTrigger ("Walk 2");
						}
					}
					break;
				case 2:
					if (!isRunning) {
						isRunning = true;
						isIdling = false;
						isWalking = false;
						isMoonWalking = false;
						isMoonRunning = false;
						transform.FindChild ("Brisk_Prefab").GetComponent<Animator> ().SetTrigger ("Run");
					}
					break;
				}
				break;
			case EnemyManager.EnemyType.SNIPER:
				switch (shootIndic) {
				case -2:
					if (!isMoonRunning) {
						isMoonRunning = true;
						isMoonWalking = false;
						isIdling = false;
						isWalking = false;
						isRunning = false;
						transform.FindChild ("Sniper_Prefab").GetComponent<Animator> ().SetTrigger ("Reverse Run");
					}
					break;
				case -1:
					if (!isMoonWalking) {
						isMoonWalking = true;
						isIdling = false;
						isWalking = false;
						isRunning = false;
						isMoonRunning = false;
						transform.FindChild ("Sniper_Prefab").GetComponent<Animator> ().SetTrigger ("Reverse Walk");
					}
					break;
				case 0:
					if (!isIdling) {
						isIdling = true;
						isWalking = false;
						isRunning = false;
						isMoonWalking = false;
						isMoonRunning = false;
						transform.FindChild ("Sniper_Prefab").GetComponent<Animator> ().SetTrigger ("Idle");
					}
					break;
				case 1:
					if (!isWalking) {
						isWalking = true;
						isIdling = false;
						isRunning = false;
						isMoonWalking = false;
						isMoonRunning = false;
						transform.FindChild ("Sniper_Prefab").GetComponent<Animator> ().SetTrigger ("Walk");
					}
					break;
				case 2:
					if (!isRunning) {
						isRunning = true;
						isIdling = false;
						isWalking = false;
						isMoonWalking = false;
						isMoonRunning = false;
						transform.FindChild ("Sniper_Prefab").GetComponent<Animator> ().SetTrigger ("Run");
					}
					break;
				}
				break;
			}
		}
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

		mat.SetFloat("_Mode", 4f);
		mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
		mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
		mat.SetInt("_ZWrite", 0);
		mat.DisableKeyword("_ALPHATEST_ON");
		mat.EnableKeyword("_ALPHABLEND_ON");
		mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
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
		//LJV = 0; //Lock sides

		float RJH = Input.GetAxis ("RightJoystickHorizontal");

		float TL = Input.GetAxis ("TriggerLeft");
		float TR = Input.GetAxis ("TriggerRight");

		//float RJV = Input.GetAxis ("RightJoystickVertical");

		Vector3 rotation = new Vector3(0,RJH,0);
		this.gameObject.transform.Rotate (rotation * rotationSpeed * Time.deltaTime);

		Vector3 camFor = Camera.main.transform.forward;
		camFor.y = 0;
		Vector3 camRight = Camera.main.transform.right;

		this.gameObject.transform.position += camFor * speed * Time.deltaTime * LJH;
		this.gameObject.transform.position += camRight * speed * Time.deltaTime * LJV;

		if (LJV != 0 || LJH != 0) {
			this.GetComponent<AudioSource> ().volume = 1;
		} else {
			this.GetComponent<AudioSource> ().volume = 0;
		}
		if(LJV == 0 && LJH == 0)
		{
			shootIndic = 0;
		}
		else if(LJV <= 0.5f && LJH <= 0.5f)
		{
			shootIndic = 1;
			if (LJH < 0)
			{
				shootIndic = -1;
				if (LJH < -0.5f)
				{
					shootIndic = -2;
				}
			}
		}
		else
		{
			shootIndic = 2;
		}

        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && !isTurning)
		{
			//Camera.main.GetComponent<UnityStandardAssets.ImageEffects.CameraMotionBlur> ().enabled = true;
			angleTurn = new Vector3(0,transform.eulerAngles.y + 90,0);
            angleTurn = new Vector3(0, Mathf.Round(angleTurn.y / 90) * 90 % 360, 0);
            rotationDirection = 1;
            isTurning = true;
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button4) && !isTurning)
        {
			//Camera.main.GetComponent<UnityStandardAssets.ImageEffects.CameraMotionBlur> ().enabled = true;
            angleTurn = new Vector3(0, (transform.eulerAngles.y - 90 + 360) % 360, 0);
            angleTurn = new Vector3(0, Mathf.Round(angleTurn.y / 90) * 90 % 360, 0);
            rotationDirection = -1;
            isTurning = true;
		}
		if (TL > 0)
		{
			CheckSwap ();
		}
		if (TL == 0)
        {
			Time.timeScale = 1;
			//Time.fixedDeltaTime = 1;
			if (swaped != null) 
			{
				MasterAudio.FireCustomEvent ("SwapSFX", this.transform.position);
				this.gameObject.transform.FindChild("Head").GetComponent<Animator>().SetTrigger("Swap");
				swapStart = 0;
				isSwaping = true;
			}
        }
        if (TR > 0) {Fire ();}
		//if (Input.GetKeyDown (KeyCode.Joystick1Button2)) {takeDamage (20);}
		//if (Input.GetKeyDown (KeyCode.Joystick1Button3)) {TPTotem ();}
	}

	float Percent(EnemyManager.EnemyType type)
	{
		if (EType == type) {return againstSamePercent;}
		switch(type)
		{
			case EnemyManager.EnemyType.HEAVY:
				switch(EType)
				{
					case EnemyManager.EnemyType.HEAVY:
						return againstSamePercent;
					case EnemyManager.EnemyType.SNIPER:
						return againstSupPercent;
					case EnemyManager.EnemyType.SNEAKY:
						return againstLessPercent;
				}
			break;

			case EnemyManager.EnemyType.SNIPER:
				switch(EType)
				{
					case EnemyManager.EnemyType.HEAVY:
						return againstLessPercent;
					case EnemyManager.EnemyType.SNIPER:
						return againstSamePercent;
					case EnemyManager.EnemyType.SNEAKY:
						return againstSupPercent;
				}
			break;

			case EnemyManager.EnemyType.SNEAKY:
			switch(EType)
				{
					case EnemyManager.EnemyType.HEAVY:
						return againstSupPercent;
					case EnemyManager.EnemyType.SNIPER:
						return againstLessPercent;
					case EnemyManager.EnemyType.SNEAKY:
						return againstSamePercent;
				}
			break;
		}
		return againstSamePercent;
	}

	public void takeDamage(float dmg, EnemyManager.EnemyType type)
	{
        //ParticleSystem blood = Instantiate(Resources.Load("Particules/Blood"), transform.position, transform.rotation) as ParticleSystem;
		this.gameObject.transform.FindChild ("FX_Blood").gameObject.SetActive(true);
		CDBlood = 2;
		MasterAudio.FireCustomEvent ("HitSFX", this.transform.position);
		life -= dmg * Percent(type);
		if (life <= 0 && !isDying) {Death ();}
	}

	void Death()
    {
		switch (EType)
		{
		case EnemyManager.EnemyType.HEAVY:
			transform.FindChild("Heavy_Prefab").GetComponent<Animator>().SetTrigger("Death");
			break;
		case EnemyManager.EnemyType.SNEAKY:
			transform.FindChild("Brisk_Prefab").GetComponent<Animator>().SetTrigger("Death");
			break;
		case EnemyManager.EnemyType.SNIPER:
			transform.FindChild("Sniper_Prefab").GetComponent<Animator>().SetTrigger("Death");
			break;
		}

		MasterAudio.FireCustomEvent ("DeathSFX", this.transform.position);
        this.gameObject.transform.FindChild("Head").GetComponent<Animator>().SetTrigger("Death");
        deathStart = Time.time;
        isDying = true;
		GameObject.FindObjectOfType<fadeManager> ().startFadeDeath (deathDelay);
    }
    void trueDeath()
    {
        checkFreeTotem();
        this.gameObject.GetComponent<EnemyScript>().enabled = true;
		Destroy(this.gameObject.GetComponent<PlayerScript>());
		Destroy(this.gameObject);
    }

	void checkFreeTotem()
	{
		GameObject chooseTotem = null;
		GameObject farTotem = null;
		float distMax = 0;
		float distRet = 9999;
		foreach (GameObject totem in AllTotems)
		{
			float dist = Vector3.Distance (this.gameObject.transform.position, totem.transform.parent.position);
			if (dist < distRet && totem.GetComponent<TotemScript>().dysActive == false && totem.GetComponent<TotemScript>().isActive) {chooseTotem = totem;}
			if (dist > distMax && totem.GetComponent<TotemScript>().isActive) {farTotem = totem;}
		}
		if (chooseTotem) {SpawnAndPossess (chooseTotem);}
		else if (farTotem) {SpawnAndPossess (farTotem);} 
	}

	void TPTotem()
	{
		GameObject closeTotem = null;
		float distMax = 9999;
		foreach (GameObject totem in AllTotems)
		{
			float dist = Vector3.Distance (this.gameObject.transform.position, totem.transform.parent.position);
			if (dist < totem.GetComponent<TotemScript>().distance && dist < distMax && totem.GetComponent<TotemScript>().isActive) {closeTotem = totem;}
		}
		if (closeTotem) 
		{
			this.gameObject.transform.position = closeTotem.transform.position;
			choosingTotem = true;
		} 
	}

	void chooseDest()
	{
		float LJV = Input.GetAxis ("LeftJoystickVertical");
		if(LJV != 0)
		{
			if(axisChoose == false)
			{
				startChoose = true;
				if (LJV < 0) 
				{
					indexTot--;
					if(indexTot < 0){ indexTot = AllTotems.Length-1;}
					while (!AllTotems [indexTot].GetComponent<TotemScript> ().isActive) 
					{
						indexTot--;
						if(indexTot < 0){ indexTot = AllTotems.Length-1;}
					}
				} 
				else if (LJV > 0) 
				{
					indexTot++;
					if(indexTot > AllTotems.Length-1){indexTot = 0;}
					while (!AllTotems [indexTot].GetComponent<TotemScript> ().isActive) 
					{
						indexTot++;
						if(indexTot > AllTotems.Length-1){indexTot = 0;}
					}
				}
				axisChoose = true;
			}
		}
		if(LJV == 0)
		{
			axisChoose = false;
		}    

		if (AllTotems [indexTot].GetComponent<TotemScript> ().isActive && startChoose) {this.gameObject.transform.position = AllTotems [indexTot].transform.parent.position;}
		if (Input.GetKeyDown (KeyCode.Joystick1Button3)) {choosingTotem = false;startChoose = false;}

	}

	void SpawnAndPossess(GameObject totem)
	{
		GameObject newEnn = Resources.Load ("Prefabs/Player") as GameObject;
		Vector3 totPos = totem.transform.position;
		//totPos.y = 2;
		GameObject Enemy = Instantiate(newEnn, totPos, Quaternion.identity) as GameObject;
		Enemy.GetComponent<EnemyScript>().ID = 0;
		Enemy.GetComponent<EnemyScript>().patrouilleRandom = true;
		int rand = Random.Range(1, 4);
		switch(rand)
		{
		case 1:
			Enemy.GetComponent<EnemyScript>().EType = EnemyManager.EnemyType.HEAVY;
			break;
		case 2:
			Enemy.GetComponent<EnemyScript>().EType = EnemyManager.EnemyType.SNEAKY;
			break;
		case 3:
			Enemy.GetComponent<EnemyScript>().EType = EnemyManager.EnemyType.SNIPER;
			break;
		}
	}

	void checkTotem()
	{
		foreach (GameObject totem in AllTotems)
		{
			float dist = Vector3.Distance (this.gameObject.transform.position, totem.transform.parent.position);
			if (dist < totem.GetComponent<TotemScript>().distance)
            {
				totem.GetComponent<TotemScript> ().loadTotem ();
                //angleTurnShaman = Vector3.Angle(transform.FindChild("Head").forward, transform.FindChild("Head").LookAt(new Vector3(totem.transform.position.x, transform.FindChild("Head").position.y, totem.transform.position.z));
            } 
			else {totem.GetComponent<TotemScript> ().deloadTotem ();}
		}
	}

	GameObject oldSwaped = null;

	void CheckSwap()
	{
		Time.timeScale = 0.2f;
		//Time.fixedDeltaTime = 0.5f;
		if (swaped) 
		{
			//swaped.GetComponent<Renderer> ().material.color = Color.white;
			bool isOK = true;
			ParticleSystem[] swapFx = GameObject.FindObjectsOfType<ParticleSystem>();
			foreach (ParticleSystem go in swapFx) 
			{
				if (go.gameObject.transform.parent && go.gameObject.transform.parent.tag == "FXSwap")
				{
					if (go.IsAlive() == true) 
					{
						isOK = false;
					}
				}
			}
			if (isOK) 
			{
				Destroy (GameObject.FindGameObjectWithTag ("FXSwap"));
				oldSwaped = null;
			}
			//swaped.GetComponent<Renderer> ().material.color = swapedColor;
			swaped = null;
		}
		Debug.DrawRay (this.gameObject.transform.position, this.gameObject.transform.forward, Color.red, 10);
		if (Physics.Raycast(this.gameObject.transform.position,  this.gameObject.transform.forward, out hit, rangeSwap)) 
		{
			if (hit.collider.tag == "Swapable") 
			{
				swaped = hit.collider.gameObject;
				//swapedColor = swaped.GetComponent<Renderer> ().material.color;
				//swaped.GetComponent<Renderer> ().material.color = Color.green;
				if (oldSwaped != swaped) 
				{
					oldSwaped = swaped;
					GameObject swapFX = Resources.Load ("FX/FX_Swap") as GameObject;
					GameObject go = Instantiate (swapFX, swaped.transform.position,Quaternion.identity) as GameObject;
					go.transform.parent = swaped.transform;
				}
			}
		}
	}

	void Swap()
    {
        this.gameObject.tag = "Swapable";
        swaped.tag = "Player";
        //Debug.Log("yo");

		Vector3 pos = Camera.main.transform.localPosition;

		Camera.main.transform.parent = swaped.transform;

		Vector3 newPos = swaped.transform.position;
		//newPos.x = 0;
		newPos.y += 9;
		newPos.z -= 13;
		Camera.main.transform.position = newPos;

		Camera.main.transform.localPosition = pos;

		swaped.AddComponent<PlayerScript>();

		SwitchPos (this.gameObject, swaped);
		//this.gameObject.GetComponent<Renderer> ().material.color = Color.white;
		switch(EType)
		{
		case EnemyManager.EnemyType.HEAVY:
			transform.FindChild("Heavy_Prefab").GetComponent<Animator>().SetTrigger("Stun");
			break;
		case EnemyManager.EnemyType.SNEAKY:
			transform.FindChild("Brisk_Prefab").GetComponent<Animator>().SetTrigger("Stun");
			break;
		case EnemyManager.EnemyType.SNIPER:
			transform.FindChild("Sniper_Prefab").GetComponent<Animator>().SetTrigger("Stun");
			break;
		}

		this.gameObject.transform.FindChild ("Head").gameObject.SetActive(false);
		this.gameObject.GetComponent<EnemyScript> ().enabled = true;
        this.gameObject.GetComponent<EnemyScript> ().isStun = true;
        this.gameObject.GetComponent<NavMeshObstacle>().enabled = false;
        this.gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		//this.gameObject.GetComponentInChildren<test> ().gameObject.GetComponent<MeshRenderer> ().enabled = true;


		float rectY = (Mathf.Round( swaped.transform.eulerAngles.y / 90) * 90) % 360;
		Vector3 rectVec = new Vector3 (0,rectY,0);
		swaped.transform.eulerAngles = rectVec;
		Destroy (this.gameObject.GetComponent<PlayerScript>());		
	}

	void SwitchPos(GameObject GO1, GameObject GO2)
	{
		Vector3 Pos1 = GO1.transform.position;
		Vector3 Pos2 = GO2.transform.position;
		Quaternion Rot1 = GO1.transform.rotation;
		Quaternion Rot2 = GO2.transform.rotation;
		GO1.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GO2.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GO1.transform.position = Pos2;
		GO1.transform.rotation = Rot2;
		GO2.transform.position = Pos1;
		GO2.transform.rotation = Rot1;
	}

	GameObject fired = null;
	void CheckFire()
	{
		if (fired) 
		{
			//fired.GetComponent<Renderer> ().material.color = Color.white;
			fired = null;
		}
		if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, range)) 
		{
			if (hit.collider.tag == "Swapable") 
			{
				fired = hit.collider.gameObject;
				//fired.GetComponent<Renderer> ().material.color = Color.red;
			}
		}
	}

	void Fire()
    {
		if (nbMunitions == 0) {
			EmptyWeapon ();
		}


        if (currentCD < 0 && nbMunitions > 0)
        {
            //Debug.Log("fire");
            GameObject smoke = Instantiate(Resources.Load("Particules/Shoot"), transform.position, transform.rotation) as GameObject;
            Destroy(smoke, 1);
            nbMunitions--;
			if (EType == EnemyManager.EnemyType.SNIPER) 
			{
				MasterAudio.FireCustomEvent ("SniperFireSFX", this.transform.position);
				switch(shootIndic)
				{
				case 0:
					transform.FindChild("Sniper_Prefab").GetComponent<Animator>().SetTrigger("StaticShoot");
					break;
				case 1:
					transform.FindChild("Sniper_Prefab").GetComponent<Animator>().SetTrigger("Walk&Gun");
					break;
				case 2:
					transform.FindChild("Sniper_Prefab").GetComponent<Animator>().SetTrigger("Run&Gun");
					break;
				}
				if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, range)) 
				{
					if (hit.collider.tag == "Swapable") 
					{
                        //Debug.Log("hit");
						hit.collider.gameObject.GetComponent<EnemyScript> ().takeDamage (damage, EType);
					}
				}
			}
			else 
			{
				if (EType == EnemyManager.EnemyType.HEAVY)
				{
					MasterAudio.FireCustomEvent ("HeavyFireSFX", this.transform.position);
					switch (shootIndic)
					{
					case 0:
						transform.FindChild("Heavy_Prefab").GetComponent<Animator>().SetTrigger("StaticShoot");
						break;
					case 1:
						transform.FindChild("Heavy_Prefab").GetComponent<Animator>().SetTrigger("Walk&Gun");
						break;
					case 2:
						transform.FindChild("Heavy_Prefab").GetComponent<Animator>().SetTrigger("Run&Gun");
						break;
					}
				}
				if (EType == EnemyManager.EnemyType.SNEAKY)
				{
					MasterAudio.FireCustomEvent ("SneakyFireSFX", this.transform.position);
					int random = Random.Range(0, 2);
					if(random == 0)
					{
						transform.FindChild("Brisk_Prefab").GetComponent<Animator>().SetTrigger("Attack 1");
					}
					else
					{
						transform.FindChild("Brisk_Prefab").GetComponent<Animator>().SetTrigger("Attack 2");
					}
				}

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
                                //Debug.Log("hit");
								RH.collider.gameObject.GetComponent<EnemyScript> ().takeDamage (damage, EType);
							}
						}
					}
				}
			}
			currentCD = CDMax;
		}
	}

	//USELESS FOR NOW
	void EmptyWeapon () {
		MasterAudio.FireCustomEvent ("EmptyWeaponSFX", this.transform.position);
	}


	void CheckInput()
	{
		if (Input.GetKey (KeyCode.Z)) {DoMovement ("up");}
		if (Input.GetKey (KeyCode.Q)) {DoMovement ("left");}
		if (Input.GetKey (KeyCode.S)) {DoMovement ("down");}
		if (Input.GetKey (KeyCode.D)) {DoMovement ("right");}
		//if (Input.GetKeyDown (KeyCode.Space)) {Fire();}
		//if (Input.GetButtonDown("Fire1")) {CheckSwap ();}
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
