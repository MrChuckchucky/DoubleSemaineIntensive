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
    public float distanceShoot;
    public float sprint;
    public float vision;
    public bool patrouilleRandom;
    public float stunDuration;
    public bool isStun;
    public bool reachtotem;

    private float stunStart;
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

	float currentCD = 0;

    private int indexpatrol;
    // Use this for initialization
    void Start ()
    {
        indexpatrol = 0;
        Emanage = GameObject.FindObjectOfType<EnemyManager>();
		Emanage.SetClass(EType, out life, out range, out damage, out speed, out CDMax);
        layerMask = 1 << 8;
        walk = GetComponent<NavMeshAgent>().speed;
        observation = GetComponent<NavMeshAgent>().angularSpeed;
        canMove = true;
        isMoving = false;
        PlayerDetected = false;
        if(patrouilleRandom)
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
                        break;
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
	
	// Update is called once per frame
	void Update ()
    {
		currentCD -= Time.deltaTime;
        if(!isStun)
        {
            PlayerDetected = PlayerDetection();
            if (!PlayerDetected)
            {
                if(reachtotem)
                {
                    reachTotem();
                }
                else
                {
                    if (!totemDetected)
                    {
                        totemDetected = totemDetection();
                        if (patrouilleRandom)
                        {
                            Randompatrol();
                        }
                        else
                        {
                            patrol();
                        }
                    }
                    else
                    {
                        cloche();
                    }
                }
            }
            else
            {
                chase();
            }
            GetComponent<NavMeshAgent>().SetDestination(destination);
            stunStart = Time.time;
        }
        else
        {
            destination = new Vector3(Mathf.Round(transform.position.x * 10) / 10, Mathf.Round(transform.position.y * 10) / 10, Mathf.Round(transform.position.z * 10) / 10);
            GetComponent<NavMeshAgent>().SetDestination(destination);
            if (stunStart + stunDuration <= Time.time)
            {
                isStun = false;
            }
        }
    }

	public void takeDamage(float dmg)
	{
		life -= dmg;
		if (life <= 0) {Destroy (this.gameObject);}
	}

    bool PlayerDetection()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        float distance = Mathf.Abs((Player.transform.position.x - transform.position.x) + (Player.transform.position.z - transform.position.z));
        if (distance > vision)
        {
            return false;
        }
        Vector3 forward = Vector3.Normalize(transform.TransformDirection(Vector3.forward));
        Vector3 toOther = Vector3.Normalize(Player.transform.position - transform.position);
        if(Vector3.Dot(forward, toOther) < 0.4 || Vector3.Dot(forward, toOther) > 1.6f)
        {
            return false;
        }
        if (Physics.Linecast(transform.position, Player.transform.position, out hit, layerMask))
        {
            return false;
        }
        return true;
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
            float distance = Mathf.Abs((totem.transform.position.x - transform.position.x) + (totem.transform.position.z - transform.position.z));
            if (distance > vision)
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
            if (Mathf.Abs(transform.position.x - destination.x) <= 1 && Mathf.Abs(transform.position.z - destination.z) <= 1)
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
                destination = transform.position;
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
            if (Mathf.Abs(transform.position.x - destination.x) <= 1 && Mathf.Abs(transform.position.z - destination.z) <= 1)
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
                destination = transform.position;
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
        if (Mathf.Abs(transform.position.x - destination.x) <= distanceShoot && Mathf.Abs(transform.position.z - destination.z) <= distanceShoot)
        {
            destination = new Vector3(Mathf.Round(transform.position.x * 10) / 10, Mathf.Round(transform.position.y * 10) / 10, Mathf.Round(transform.position.z * 10) / 10);
        }
    }
    void cloche()
    {
        GetComponent<NavMeshAgent>().speed = sprint;
        GameObject cloche = GameObject.FindGameObjectWithTag("Cloche");
        destination = cloche.transform.position;
        transform.LookAt(destination);
        if (Mathf.Abs(transform.position.x - destination.x) <= 2 && Mathf.Abs(transform.position.z - destination.z) <= 2)
        {
            cloche.GetComponent<ClocheScript>().totemSpotted = totemSpotted;
            cloche.GetComponent<ClocheScript>().isActive = true;
        }
    }
    void reachTotem()
    {
        GetComponent<NavMeshAgent>().speed = sprint;
        destination = totemSpotted.transform.position;
        if (Mathf.Abs(transform.position.x - destination.x) <= 2 && Mathf.Abs(transform.position.z - destination.z) <= 2)
        {
            destination = new Vector3(Mathf.Round(transform.position.x * 10) / 10, Mathf.Round(transform.position.y * 10) / 10, Mathf.Round(transform.position.z * 10) / 10);
            totemSpotted.GetComponent<TotemScript>().dysActive = true;
        }
    }
    void death()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach(GameObject spawner in spawners)
        {
            if(spawner.GetComponent<SpawnScript>().ID == ID)
            {
                spawner.GetComponent<SpawnScript>().spawnStart = Time.time;
                spawner.GetComponent<SpawnScript>().isActive = true;
            }
        }
    }
}
