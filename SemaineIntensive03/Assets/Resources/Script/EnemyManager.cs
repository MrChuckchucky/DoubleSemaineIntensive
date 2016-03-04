﻿using UnityEngine;
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
    public int hitChanceHeavy;

    [Header("Sneaky Settings")]
	public float lifeMaxSneaky;
	public float rangeSneaky;
	public float damageSneaky;
	public float speedSneaky;
	public float CDSneaky;
    public int hitChanceSneaky;

    [Header("Sniper Settings")]
	public float lifeMaxSniper;
	public float rangeSniper;
	public float damageSniper;
	public float speedSniper;
	public float CDSniper;
    public int hitChanceSniper;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetClass(EnemyType EClass, out float life, out float range, out float damage, out float speed, out float CD, out int HC)
	{
		life = range = damage = speed = CD = HC = 0;
		switch(EClass)
		{
			case EnemyType.HEAVY:
				life = lifeMaxHeavy;
				range = rangeHeavy;
				damage = damageHeavy;
				speed = speedHeavy;
				CD = CDHeavy;
                HC = hitChanceHeavy;
			break;
			case EnemyType.SNEAKY:
				life = lifeMaxSneaky;
				range = rangeSneaky;
				damage = damageSneaky;
				speed = speedSneaky;
				CD = CDSneaky;
                HC = hitChanceSneaky;
                break;
			case EnemyType.SNIPER:
				life = lifeMaxSniper;
				range = rangeSniper;
				damage = damageSniper;
				speed = speedSniper;
				CD = CDSniper;
                HC = hitChanceSniper;
                break;
		}
	}
}
