using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LevitationSpiritScript : MonoBehaviour 
{
    [Header("Levitation")]
    public float levitationHeight;
    public float upSpeed;
    public float downSpeed;
    public Ease easeType;

	[Header("Death")]
	public float deathLevitationHeight = 1.5f;
	public float deathDuration = 1.5f;
	public Ease easeTypeDeath = Ease.InOutQuad;

	// Use this for initialization
	void Start () 
	{
		DOTween.Init ();
	}

	public void Death ()
	{
		DOTween.Pause ("Levitation");
		transform.DOLocalMoveY (transform.position.y + deathLevitationHeight, deathDuration).SetEase (easeTypeDeath);
	}

	public void LevitationVoid ()
	{
		DOTween.Pause ("Levitation");
		StartCoroutine (Levitation ());
	}

	IEnumerator Levitation ()
	{
		Tween mytween = transform.DOLocalMoveY (transform.position.y + levitationHeight, upSpeed).SetEase(easeType).SetId("Levitation");

		yield return mytween.WaitForCompletion ();

		mytween = transform.DOLocalMoveY (transform.position.y - levitationHeight, downSpeed).SetEase(easeType).SetId("Levitation");

		yield return mytween.WaitForCompletion ();
	}
}
