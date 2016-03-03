using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public enum EnemyType
	{
		HEAVY,
		SNEAKY,
		SNIPER
	}

	[Header("Heavy Settings")]
	public float lifeMaxHeavy;
	public float rangeHeavy;
	public float damageHeavy;
	public float speedHeavy;

	[Header("Sneaky Settings")]
	public float lifeMaxSneaky;
	public float rangeSneaky;
	public float damageSneaky;
	public float speedSneaky;

	[Header("Sniper Settings")]
	public float lifeMaxSniper;
	public float rangeSniper;
	public float damageSniper;
	public float speedSniper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetClass(EnemyType EClass, out float life, out float range, out float damage, out float speed)
	{
		life = range = damage = speed = 0;
		switch(EClass)
		{
			case EnemyType.HEAVY:
				life = lifeMaxHeavy;
				range = rangeHeavy;
				damage = damageHeavy;
				speed = speedHeavy;
			break;
			case EnemyType.SNEAKY:
				life = lifeMaxSneaky;
				range = rangeSneaky;
				damage = damageSneaky;
				speed = speedSneaky;
			break;
			case EnemyType.SNIPER:
				life = lifeMaxSniper;
				range = rangeSniper;
				damage = damageSniper;
				speed = speedSniper;
			break;
		}
	}
}
