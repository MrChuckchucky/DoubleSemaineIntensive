using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public int ID;
    public Vector3 destination;
    public float stunDurationMin;
    public float stunDurationMax;
    public float rotation;
    public GameObject Player;
    public bool playerDetected;

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
	// Use this for initialization
	void Start ()
    {
        canMove = true;
        isMoving = false;
        temp = GameObject.FindGameObjectsWithTag("NavigationPoint");
        NavigationPoints = new GameObject[temp.Length];
        playerDetected = false;
        index = 0;
        foreach(GameObject navpoint in temp)
        {
            int[] IDS = navpoint.GetComponent<NavigationPointScript>().ID;
            bool valid = false;
            foreach (int id in IDS)
            {
                if(id == ID)
                {
                    valid = true;
                    break;
                }
            }
            if(valid)
            {
                NavigationPoints[index] = navpoint;
                index++;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!playerDetected)
        {
            patrol();
        }
        else
        {
            chase();
        }
	}

    void patrol()
    {
        if (!isMoving && canMove)
        {
            int rand = Random.Range(0, index);
            destination = NavigationPoints[rand].transform.position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
            isMoving = true;
        }
        else if (canMove)
        {
            if ((transform.position.x + transform.position.z) - (destination.x + destination.z) <= 1 && (destination.x + destination.z) - (transform.position.x + transform.position.z) <= 1)
            {
                GetComponent<NavMeshAgent>().SetDestination(transform.position);
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
                //Debug.Log(rotationDestination);
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
        if ((transform.position.x + transform.position.z) - (destination.x + destination.z) <= 1 && (destination.x + destination.z) - (transform.position.x + transform.position.z) <= 1)
        {

        }
        destination = Player.transform.position;
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }
}
