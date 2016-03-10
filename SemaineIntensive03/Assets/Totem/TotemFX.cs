using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TotemFX : MonoBehaviour 
{
	public float moveDurationActivated;

	public float moveDurationHit;
	public float timeBeforeActivated;

	[Range (0, 1)]
	public float createdAnimTime;

	private ParticleSystem particlesDirt;

	private GameObject activatedFX;
	private GameObject createdFX;
	private GameObject destroyedFX;
	private GameObject hitFX;

	private Animator animatorTotem;

	private float activatedYPosition;
	private float hitYPosition;

	private bool totemActivated = false;

	// Use this for initialization
	void Start () 
	{
		DOTween.Init ();

		activatedFX = transform.parent.GetChild (1).gameObject;
		createdFX = transform.parent.GetChild (2).gameObject;
		destroyedFX = transform.parent.GetChild (3).gameObject;
		hitFX = transform.parent.GetChild (4).gameObject;

		particlesDirt = createdFX.transform.GetChild (4).gameObject.GetComponent<ParticleSystem> ();

		activatedYPosition = activatedFX.transform.localPosition.y;
		hitYPosition = hitFX.transform.localPosition.y;

		animatorTotem = GetComponent<Animator> ();

		activatedFX.SetActive (false);
		createdFX.SetActive (false);
		destroyedFX.SetActive (false);
		hitFX.SetActive (false);

		animatorTotem.Play("Totem_Created", -1, 0);
		animatorTotem.StartPlayback ();
	}

	void Update ()
	{
		if(!totemActivated)
		{
			if(createdAnimTime == 0)
			{
				createdFX.SetActive (false);

				if(hitFX.activeSelf == true)
					hitFX.transform.DOLocalMoveY (-11, moveDurationActivated);

				if(activatedFX.activeSelf == true)
					activatedFX.transform.DOLocalMoveY (-11, moveDurationActivated);
			}

			if(createdAnimTime > 0 && createdAnimTime < 1)
			{
				animatorTotem.Play("Totem_Created", -1, createdAnimTime);
				createdFX.SetActive (true);
				particlesDirt.Emit (1);
			}

			if(createdAnimTime >= 1 && activatedFX.activeSelf == false)
			{
				//Debug.Log ("Bite");
				totemActivated = true;
				animatorTotem.enabled = false;
				animatorTotem.enabled = true;
				animatorTotem.StopPlayback ();
				animatorTotem.SetTrigger ("Totem_Activated");
				//animatorTotem.Play("Totem_Activated", -1, 0);

			}
		}


	}
	
	public void Activated ()
	{
		//Debug.Log ("Bite2");

		if(hitFX.activeSelf == true)
		{
			StartCoroutine (DeactivateHit ());
		}

		if(activatedFX.activeSelf == false)
			activatedFX.transform.localPosition = new Vector3 (0, -11, 0);
		
		activatedFX.SetActive (true);
		activatedFX.transform.DOLocalMoveY (activatedYPosition, moveDurationActivated).SetId("FX");
	}

	IEnumerator DeactivateHit ()
	{
		Tween mytween = hitFX.transform.DOLocalMoveY (-11, moveDurationActivated).SetId("FX");

		yield return mytween.WaitForCompletion ();

		hitFX.SetActive (false);
	}

	public void Created ()
	{
		activatedFX.SetActive (false);
		createdFX.SetActive (false);
		destroyedFX.SetActive (false);
		hitFX.SetActive (false);

		if(createdAnimTime > 0)
			createdFX.SetActive (true);
	}

	public void Destroyed ()
	{
		DOTween.Pause("FX");

		if(hitFX.activeSelf == true)
			hitFX.transform.DOLocalMoveY (-11, moveDurationActivated);

		if(activatedFX.activeSelf == true)
			activatedFX.transform.DOLocalMoveY (-11, moveDurationActivated);

		createdFX.SetActive (false);

		destroyedFX.SetActive (false);
		destroyedFX.SetActive (true);

		StartCoroutine (Reset ());
	}

	IEnumerator Reset ()
	{
		yield return new WaitForSeconds (4.5f);

		createdAnimTime = 0;
		animatorTotem.Play ("Totem_Destroyed");
		//animatorTotem.Play("Totem_Created", -1, 0);
		//animatorTotem.StartPlayback ();
		totemActivated = false;
	}

	public void Hit ()
	{
		hitFX.transform.localPosition = new Vector3 (0, hitYPosition, 0);

		activatedFX.SetActive (false);
		createdFX.SetActive (false);

		hitFX.SetActive (true);
	}
}
