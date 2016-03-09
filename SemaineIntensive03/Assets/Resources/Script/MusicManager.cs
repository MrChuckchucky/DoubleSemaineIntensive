using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioSource heavyVariation;
	public AudioSource sneakyVariation;
	public AudioSource sniperVariation;

	public void HeavyVariation () {
		heavyVariation.volume = 0.1f;
		sneakyVariation.volume = 0;
		sniperVariation.volume = 0;
	}

	public void SneakyVariation () {
		heavyVariation.volume = 0;
		sneakyVariation.volume = 0.1f;
		sniperVariation.volume = 0;
	}

	public void SniperVariation () {
		heavyVariation.volume = 0;
		sneakyVariation.volume = 0;
		sniperVariation.volume = 0.1f;
	}
}
