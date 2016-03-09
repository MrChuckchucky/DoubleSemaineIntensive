using UnityEngine;
using System.Collections;

public class TrailRendererScript : MonoBehaviour 
{
	public TrailRenderer trailAttacks;

	// Use this for initialization
	void Start () 
	{
		trailAttacks.enabled = false;
	}
	
	public void TrailRendererOn ()
	{
		trailAttacks.enabled = true;
	}

	public void TrailRendererOff ()
	{
		trailAttacks.enabled = false;
	}
}
