using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public int ID;
    public Vector3 destination;
    public float patrolDurationMin;
    public float patrolDurationMax;
    public float rotation;
    public bool PlayerDetected;
    public bool totemDetected;
    public float sprint;
    public bool patrouilleRandom;
    public float stunDuration;
    public bool isStun;
    public bool reachtotem;

    private bool setNavRand;
    public float stunStart;
    private float walk;
    private float observation;
    private bool isMoving;
    private bool canMove;
    private float patrolStart;
    private float patrolDuration;
    private float rotationStart;
    public float rotationDuration;
    public GameObject[] temp;
    public GameObject[] NavigationPoints;
    private float rotationDestination;
    private int index;
    private GameObject Player;
    private int layerMask;
    private RaycastHit hit;
    public GameObject totemSpotted;

    EnemyManager Emanage;

	[Header("Enemy Settings")]
	public EnemyManager.EnemyType EType;

	public float life;
	public float range;
	public float damage;
	public float speed;
	public float CDMax;
	public int nbMunitions;
    public int HC;
    public float distanceAlert;

    float currentCD = 0;

    private int indexpatrol;
    float dispShotgun = 1.5f;

	bool isPaused;
    // Use this for initialization
    void Start ()
    {
        setNavRand = false;
		Coloring ();
        indexpatrol = 0;
        Emanage = GameObject.FindObjectOfType<EnemyManager>();
		Emanage.SetClass(EType, out life, out range, out damage, out speed, out CDMax, out nbMunitions, out HC, out distanceAlert);
		this.gameObject.transform.FindChild ("Head").gameObject.SetActive(false);
        layerMask = 1 << 8;
        walk = GetComponent<NavMeshAgent>().speed;
        observation = GetComponent<NavMeshAgent>().angularSpeed;
        canMove = true;
        isMoving = false;
        PlayerDetected = false;
	}

	void Coloring()
	{
		switch(EType)
		{
			case EnemyManager.EnemyType.HEAVY:
				this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				this.gameObject.transform.FindChild ("HeavyO").GetComponent<Renderer> ().enabled = true;
			break;
			case EnemyManager.EnemyType.SNIPER:
				this.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				this.gameObject.transform.FindChild ("SniperO").GetComponent<Renderer> ().enabled = true;
			break;
			case EnemyManager.EnemyType.SNEAKY:
				this.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
				this.gameObject.transform.FindChild ("SneakyO").GetComponent<Renderer> ().enabled = true;
			break;
		}
	}

	// Update is called once per frame
	void Update ()
    {
		isPaused = GameObject.Find ("Managers").GetComponent<PauseManager> ().IsPaused;
		if (isPaused == false) 
		{
			if (!setNavRand)
			{
                setNavRand = true;
				setNavigationPoints ();
			}
			currentCD -= Time.deltaTime;
			if (!isStun) 
			{
				PlayerDetected = PlayerDetection ();
				if (!PlayerDetected) 
				{
					if (reachtotem) 
					{
						reachTotem ();
					} 
					else 
					{
						if (!totemDetected) 
						{
							totemDetected = totemDetection ();
							if (patrouilleRandom) 
							{
								Randompatrol ();
							} 
							else 
							{
								patrol ();
							}
						} 
						else 
						{
							cloche ();
						}
					}
				} 
				else 
				{
					chase ();
				}
				GetComponent<NavMeshAgent> ().SetDestination (destination);
				stunStart = 0;
			} 
			else 
			{
                stunStart += Time.deltaTime;
				destination = new Vector3 (Mathf.Round (transform.position.x * 10) / 10, Mathf.Round (transform.position.y * 10) / 10, Mathf.Round (transform.position.z * 10) / 10);
				GetComponent<NavMeshAgent> ().SetDestination (destination);
				if (stunStart <= stunDuration)
                {
					isStun = false;
				}
			}
		} 
		else 
		{
			Vector3 pos = new Vector3 (Mathf.Round (transform.position.x * 10) / 10, Mathf.Round (transform.position.y * 10) / 10, Mathf.Round (transform.position.z * 10) / 10);
			GetComponent<NavMeshAgent> ().SetDestination (pos);
		}
    }

	public void takeDamage(float dmg)
	{
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Swapable");
        foreach(GameObject ally in allies)
        {
            float distance = Vector3.Distance(transform.position, ally.transform.position);
            if(distance <= distanceAlert)
            {
                ally.GetComponent<EnemyScript>().PlayerDetected = true;
                ally.GetComponent<EnemyScript>().destination = GameObject.FindGameObjectWithTag("Player").transform.position;
            }
        }
		life -= dmg;
		if (life <= 0)
        {
            death();
        }
	}

    void setNavigationPoints()
    {
        if (patrouilleRandom)
        {
            temp = GameObject.FindGameObjectsWithTag("NavigationPoint");
            NavigationPoints = new GameObject[temp.Length];
            index = 0;
            foreach (GameObject navpoint in temp)
            {
                int[] IDS = navpoint.GetComponent<NavigationPointScript>().ID;
                bool valid = false;
                foreach (int id in IDS)
                {
                    if (id == ID)
                    {
                        valid = true;
                    }
                }
                if (valid)
                {
                    NavigationPoints[index] = navpoint;
                    index++;
                }
            }
        }
    }
    bool PlayerDetection()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player)
        {
            float distance = Vector3.Distance(Player.transform.position, transform.position);
            if (distance > distanceAlert)
            {
                return false;
            }
            Vector3 forward = Vector3.Normalize(transform.TransformDirection(Vector3.forward));
            Vector3 toOther = Vector3.Normalize(Player.transform.position - transform.position);
            if (Vector3.Dot(forward, toOther) < 0.4 || Vector3.Dot(forward, toOther) > 1.6f)
            {
                return false;
            }
            if (Physics.Linecast(transform.position, Player.transform.position, out hit, layerMask))
            {
                return false;
            }
            return true;
        }
        return false;
    }
    bool totemDetection()
    {
        GameObject[] totems = GameObject.FindGameObjectsWithTag("Totem");
        foreach(GameObject totem in totems)
        {
            if(totem.GetComponent<TotemScript>().isActive == false)
            {
                continue;
            }
            float distance = Vector3.Distance(totem.transform.position, transform.position);
            if (distance > distanceAlert)
            {
                continue;
            }
            Vector3 forward = Vector3.Normalize(transform.TransformDirection(Vector3.forward));
            Vector3 toOther = Vector3.Normalize(totem.transform.position - transform.position);
            if (Vector3.Dot(forward, toOther) < 0.4 || Vector3.Dot(forward, toOther) > 1.6f)
            {
                continue;
            }
            if (Physics.Linecast(transform.position, totem.transform.position, out hit, layerMask))
            {
                continue;
            }
            totemSpotted = totem;
            return true;
        }
        return false;
    }
    void Randompatrol()
    {
        GetComponent<NavMeshAgent>().speed = walk;
        GetComponent<NavMeshAgent>().angularSpeed = observation;
        if (!isMoving && canMove)
        {
            int rand = Random.Range(0, index);
            destination = NavigationPoints[rand].transform.position;
            isMoving = true;
        }
        else if (canMove)
        {
            if (Vector3.Distance(transform.position, destination) <= 2)
            {
                isMoving = false;
                canMove = false;
                patrolStart = Time.time;
                patrolDuration = Random.Range(patrolDurationMin, patrolDurationMax);
                float rot = transform.eulerAngles.y;
                rot /= 90;
                rot = Mathf.Round(rot);
                rot *= 90;
                rotationStart = Time.time;
                rotationDestination = rot;
                destination = new Vector3(Mathf.Round(transform.position.x * 10) / 10, Mathf.Round(transform.position.y * 10) / 10, Mathf.Round(transform.position.z * 10) / 10);
            }
        }
        if (!canMove)
        {
            if (rotationStart + rotationDuration <= Time.time)
            {
                rotationStart = Time.time;
                rotationDestination = transform.eulerAngles.y;
                rotationDestination /= 90;
                rotationDestination = Mathf.Round(rotationDestination);
                rotationDestination *= 90;
                rotationDestination += 90;
                rotationDestination = rotationDestination % 360;
            }
            else
            {
                if (rotationDestination - transform.eulerAngles.y >= 1 || transform.eulerAngles.y - rotationDestination >= 1)
                {
                    transform.eulerAngles += new Vector3(0, rotation, 0);
                    transform.eulerAngles = new Vector3(0, Mathf.Round(transform.eulerAngles.y) % 360, 0);
                }
            }
        }
        if (patrolStart + patrolDuration <= Time.time)
        {
            canMove = true;
        }
    }
    void patrol()
    {
        GetComponent<NavMeshAgent>().speed = walk;
        GetComponent<NavMeshAgent>().angularSpeed = observation;
        if (!isMoving && canMove)
        {
            if(indexpatrol == NavigationPoints.Length)
            {
                indexpatrol = 0;
            }
            destination = NavigationPoints[indexpatrol].transform.position;
            isMoving = true;
            indexpatrol++;
        }
        else if (canMove)
        {
            if (Vector3.Distance(transform.position, destination) <= 2)
            {
                isMoving = false;
                canMove = false;
                patrolStart = Time.time;
                patrolDuration = Random.Range(patrolDurationMin, patrolDurationMax);
                float rot = transform.eulerAngles.y;
                rot /= 90;
                rot = Mathf.Round(rot);
                rot *= 90;
                rotationStart = Time.time;
                rotationDestination = rot;
                destination = new Vector3(Mathf.Round(transform.position.x * 10) / 10, Mathf.Round(transform.position.y * 10) / 10, Mathf.Round(transform.position.z * 10) / 10);
            }
        }
        if (!canMove)
        {
            if (rotationStart + rotationDuration <= Time.time)
            {
                rotationStart = Time.time;
                rotationDestination = transform.eulerAngles.y;
                rotationDestination /= 90;
                rotationDestination = Mathf.Round(rotationDestination);
                rotationDestination *= 90;
                rotationDestination += 90;
                rotationDestination = rotationDestination % 360;
            }
            else
            {
                if (rotationDestination - transform.eulerAngles.y >= 1 || transform.eulerAngles.y - rotationDestination >= 1)
                {
                    transform.eulerAngles += new Vector3(0, rotation, 0);
                    transform.eulerAngles = new Vector3(0, Mathf.Round(transform.eulerAngles.y) % 360, 0);
                }
            }
        }
        if (patrolStart + patrolDuration <= Time.time)
        {
            canMove = true;
        }
    }
    void chase()
    {
        GetComponent<NavMeshAgent>().speed = sprint;
        destination = Player.transform.position;
        transform.LookAt(destination);
        if (Vector3.Distance(transform.position, destination) <= range)
        {
            destination = new Vector3(Mathf.Round(transform.position.x * 10) / 10, Mathf.Round(transform.position.y * 10) / 10, Mathf.Round(transform.position.z * 10) / 10);
            Fire();
        }
    }
    void cloche()
    {
        GetComponent<NavMeshAgent>().speed = sprint;
        GameObject cloche = GameObject.FindGameObjectWithTag("Cloche");
        destination = cloche.transform.position;
        transform.LookAt(destination);
        if (Vector3.Distance(transform.position, destination) <= 2)
        {
            cloche.GetComponent<ClocheScript>().totemSpotted = totemSpotted;
            cloche.GetComponent<ClocheScript>().isActive = true;
        }
    }
    void reachTotem()
    {
        GetComponent<NavMeshAgent>().speed = sprint;
        destination = totemSpotted.transform.position;
        if (Vector3.Distance(transform.position, destination) <= totemSpotted.GetComponent<TotemScript>().distance - 1)
        {
            destination = new Vector3(Mathf.Round(transform.position.x * 10) / 10, Mathf.Round(transform.position.y * 10) / 10, Mathf.Round(transform.position.z * 10) / 10);
            totemSpotted.GetComponent<TotemScript>().dysActive = true;
        }
    }
    void Fire()
    {
        if (currentCD < 0)
        {
            GameObject smoke = Instantiate(Resources.Load("Particules/Shoot"), transform.position, transform.rotation) as GameObject;
            Destroy(smoke, 1);
            int chance = Random.Range(0, 101);
            if(chance < HC)
            {
                if (EType != EnemyManager.EnemyType.HEAVY)
                {
                    if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, range))
                    {
                        if (hit.collider.tag == "Player")
                        {
                            hit.collider.gameObject.GetComponent<PlayerScript>().takeDamage(damage);
                        }
                    }
                }
                else
                {
                    GameObject targets = GameObject.FindGameObjectWithTag("Player");
                    RaycastHit[] inSphere = Physics.SphereCastAll(this.gameObject.transform.position, dispShotgun, this.gameObject.transform.forward, range);
                    float dist = Vector3.Distance(this.gameObject.transform.position, targets.transform.position);
                    if (dist < range)
                    {
                        foreach (RaycastHit RH in inSphere)
                        {
                            if (RH.collider.gameObject == targets)
                            {
                                RH.collider.gameObject.GetComponent<PlayerScript>().takeDamage(damage);
                            }
                        }
                    }
                }
            }
            currentCD = CDMax;
        }
    }
    public void death()
    {
        Destroy(this.gameObject);
    }
}
