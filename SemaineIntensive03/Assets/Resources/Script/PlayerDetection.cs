using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour
{
    public GameObject player;

    private Vector3 viewPos;
    private Camera cam;
    private Plane[] planes;
    private Collider anObjCollider;
    // Use this for initialization
    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        viewPos = gameObject.GetComponent<Camera>().WorldToViewportPoint(player.transform.position);
        if (viewPos.x <= 1 && viewPos.x >= 0 && Mathf.Abs((player.transform.position.x + player.transform.position.z) - (transform.position.x + transform.position.z)) <= this.GetComponent<Camera>().farClipPlane)
        {
            gameObject.transform.parent.GetComponent<EnemyScript>().Player = player;
            gameObject.transform.parent.GetComponent<EnemyScript>().playerDetected = true;
        }
        else
        {
            gameObject.transform.parent.GetComponent<EnemyScript>().playerDetected = false;
        }
    }
}