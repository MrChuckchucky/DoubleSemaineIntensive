using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
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
    private GameObject[] NavigationPoints;
    private float rotationDestination;
	// Use this for initialization
	void Start ()
    {
        canMove = true;
        isMoving = false;
        NavigationPoints = GameObject.FindGameObjectsWithTag("NavigationPoint");
        playerDetected = false;
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
            int rand = Random.Range(0, NavigationPoints.Length - 1);
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
                Debug.Log(rotationDestination);
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
