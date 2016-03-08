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
	public float CDHeavy;
	public int nbMunitionsHeavy;
    public int hitChanceHeavy;
    public float distanceAlertHeavy;

    [Header("Sneaky Settings")]
	public float lifeMaxSneaky;
	public float rangeSneaky;
	public float damageSneaky;
	public float speedSneaky;
	public float CDSneaky;
	public int nbMunitionsSneaky;
    public int hitChanceSneaky;
    public float distanceAlertSneaky;

    [Header("Sniper Settings")]
	public float lifeMaxSniper;
	public float rangeSniper;
	public float damageSniper;
	public float speedSniper;
	public float CDSniper;
	public int nbMunitionsSniper;
    public int hitChanceSniper;
    public float distanceAlertSniper;

	[Header("Percent Settings")]
	public float againstSupPercent;
	public float againstSamePercent;
	public float againstLessPercent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
	public void SetClass(EnemyType EClass, out float life, out float range, out float damage, out float speed, out float CD, out int nbMuni, out int HC, out float distanceAlert)
	{
		life = range = damage = speed = CD = nbMuni = HC = 0;
        distanceAlert = 0;
		switch(EClass)
		{
			case EnemyType.HEAVY:
				life = lifeMaxHeavy;
				range = rangeHeavy;
				damage = damageHeavy;
				speed = speedHeavy;
				CD = CDHeavy;
				nbMuni = nbMunitionsHeavy;
                HC = hitChanceHeavy;
                distanceAlert = distanceAlertHeavy;
			break;
			case EnemyType.SNEAKY:
				life = lifeMaxSneaky;
				range = rangeSneaky;
				damage = damageSneaky;
				speed = speedSneaky;
				CD = CDSneaky;
				nbMuni = nbMunitionsSneaky;
                HC = hitChanceSneaky;
                distanceAlert = distanceAlertSneaky;
                break;
			case EnemyType.SNIPER:
				life = lifeMaxSniper;
				range = rangeSniper;
				damage = damageSniper;
				speed = speedSniper;
				CD = CDSniper;
				nbMuni = nbMunitionsSniper;
                HC = hitChanceSniper;
                distanceAlert = distanceAlertSniper;
                break;
		}
	}
}
