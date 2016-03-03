﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public int ID;
    public Vector3 destination;
    public float stunDurationMin;
    public float stunDurationMax;
    public float rotation;
    public bool PlayerDetected;
    public float distanceshoot;
    public float sprint;
    public float observationSprint;
    public float vision;
    public bool patrouilleRandom;

    private float walk;
    private float observation;
    private bool isMoving;
    private bool canMove;
    private float stunStart;
    private float stunDuration;
    private float rotationStart;
    public float rotationDuration;
    public GameObject[] temp;
    public GameObject[] NavigationPoints;
    private float rotationDestination;
    private int index;
    private GameObject Player;
    private int layerMask;
    private RaycastHit hit;

	EnemyManager Emanage;

	[Header("Enemy Settings")]
	public EnemyManager.EnemyType EType;

	public float life = 0;
	public float range;
	public float damage;
	public float speed;

    private int indexpatrol;
    // Use this for initialization
    void Start ()
    {
        indexpatrol = 0;
        Emanage = GameObject.FindObjectOfType<EnemyManager>();
        Emanage.SetClass(EType, out life, out range, out damage, out speed);
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
        PlayerDetected = PlayerDetection();
        if(!PlayerDetected)
        {
            if(patrouilleRandom)
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
            chase();
        }
        GetComponent<NavMeshAgent>().SetDestination(destination);
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
                stunStart = Time.time;
                stunDuration = Random.Range(stunDurationMin, stunDurationMax);
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
        if (stunStart + stunDuration <= Time.time)
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
            Debug.Log(destination);
            isMoving = true;
            indexpatrol++;
        }
        else if (canMove)
        {
            if (Mathf.Abs(transform.position.x - destination.x) <= 1 && Mathf.Abs(transform.position.z - destination.z) <= 1)
            {
                isMoving = false;
                canMove = false;
                stunStart = Time.time;
                stunDuration = Random.Range(stunDurationMin, stunDurationMax);
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
        if (stunStart + stunDuration <= Time.time)
        {
            canMove = true;
        }
    }
    void chase()
    {
        GetComponent<NavMeshAgent>().speed = sprint;
        destination = Player.transform.position;
        transform.LookAt(destination);
    }
}