using UnityEngine;
using System.Collections;

public class MunitionUI : MonoBehaviour {


	public UnityEngine.Sprite zero; 
	public UnityEngine.Sprite un; 
	public UnityEngine.Sprite deux; 
	public UnityEngine.Sprite trois; 
	public UnityEngine.Sprite quatre; 
	public UnityEngine.Sprite cinq; 
	public UnityEngine.Sprite six; 
	public UnityEngine.Sprite sept; 
	public UnityEngine.Sprite huit; 
	public UnityEngine.Sprite neuf; 


	public UnityEngine.UI.Image carabineIcone;
	public UnityEngine.UI.Image carabineIconeCharge;

	public UnityEngine.UI.Image knifeIcone;
	public UnityEngine.UI.Image knifeIconeCharge;


	public UnityEngine.UI.Image shotgunIcone;
	public UnityEngine.UI.Image shotgunIconeBar;

	public UnityEngine.UI.Image carabineIconeMunition;
	public UnityEngine.UI.Image shotgunIconeMunition;


	public UnityEngine.UI.Image munitionShow;


	// Update is called once per frame
	void Update () {
		PlayerScript P = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

		if(P.EType == EnemyManager.EnemyType.HEAVY) { // pour le moment ! 
			carabineIcone.gameObject.SetActive(false);
			knifeIcone.gameObject.SetActive(false);
			shotgunIcone.gameObject.SetActive(true);
			carabineIconeCharge.gameObject.SetActive(true);
			shotgunIconeBar.gameObject.SetActive(false);
			shotgunIconeMunition.gameObject.SetActive(true);
			carabineIconeMunition.gameObject.SetActive(false);

			carabineIconeCharge.gameObject.SetActive(true);
			knifeIconeCharge.gameObject.SetActive(false);
			shotgunIconeBar.gameObject.SetActive(false);


			carabineIconeCharge.fillAmount = 1f - P.currentCD / P.CDMax; 



			munitionShow.gameObject.SetActive(true);

			if(P.nbMunitions == 0)
				carabineIconeCharge.fillAmount = 0;


			if(P.nbMunitions == 0)
				munitionShow.sprite = zero;
			if(P.nbMunitions == 1)
				munitionShow.sprite = un;

			if(P.nbMunitions == 2)
				
				munitionShow.sprite = deux;

			if(P.nbMunitions == 3)
				
				munitionShow.sprite = trois;
			if(P.nbMunitions == 4)
				
				munitionShow.sprite = quatre;
			if(P.nbMunitions == 5)
				
				munitionShow.sprite = cinq;
			if(P.nbMunitions == 6)
				
				munitionShow.sprite = six;
			if(P.nbMunitions == 7)
				
				munitionShow.sprite = sept;
			if(P.nbMunitions == 8)
				
				munitionShow.sprite = huit;
			if(P.nbMunitions == 9)
				
				munitionShow.sprite = neuf;
		}




		if(P.EType == EnemyManager.EnemyType.SNEAKY) { // pour le moment ! 
			shotgunIconeBar.gameObject.SetActive(false);
			carabineIcone.gameObject.SetActive(false);
			knifeIcone.gameObject.SetActive(true);
			shotgunIcone.gameObject.SetActive(false);
			carabineIconeCharge.gameObject.SetActive(false);

			shotgunIconeMunition.gameObject.SetActive(false);
			carabineIconeMunition.gameObject.SetActive(false);

			carabineIconeCharge.gameObject.SetActive(false);
			knifeIconeCharge.gameObject.SetActive(true);



			knifeIconeCharge.fillAmount = 1f - P.currentCD / P.CDMax; 

			if(P.nbMunitions == 0)
				carabineIconeCharge.fillAmount = 0;


			munitionShow.gameObject.SetActive(false);


		}


		if(P.EType == EnemyManager.EnemyType.SNIPER) { // pour le moment ! 
			carabineIcone.gameObject.SetActive(true);
			knifeIcone.gameObject.SetActive(false);
			shotgunIcone.gameObject.SetActive(false);
			carabineIconeCharge.gameObject.SetActive(false);
			knifeIconeCharge.gameObject.SetActive(false);


			shotgunIconeMunition.gameObject.SetActive(false);
			carabineIconeMunition.gameObject.SetActive(true);

			shotgunIconeBar.gameObject.SetActive(true);

			shotgunIconeBar.fillAmount = 1f - P.currentCD / P.CDMax; 



			munitionShow.gameObject.SetActive(true);

			if(P.nbMunitions == 0)
				carabineIconeCharge.fillAmount = 0;


			if(P.nbMunitions == 0)
				munitionShow.sprite = zero;
			if(P.nbMunitions == 1)
				munitionShow.sprite = un;

			if(P.nbMunitions == 2)

				munitionShow.sprite = deux;

			if(P.nbMunitions == 3)

				munitionShow.sprite = trois;
			if(P.nbMunitions == 4)

				munitionShow.sprite = quatre;
			if(P.nbMunitions == 5)

				munitionShow.sprite = cinq;
			if(P.nbMunitions == 6)

				munitionShow.sprite = six;
			if(P.nbMunitions == 7)

				munitionShow.sprite = sept;
			if(P.nbMunitions == 8)

				munitionShow.sprite = huit;
			if(P.nbMunitions == 9)

				munitionShow.sprite = neuf;
		}


	}
}
