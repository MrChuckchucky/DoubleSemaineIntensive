using UnityEngine;
using System.Collections;

public class Son : MonoBehaviour {
    
    public AudioSource[] Array1;
    public AudioSource MusiqueSource;
    public AudioSource ParoleSource;
    int Numberspeech;

    public AudioClip Phrase1;
    public AudioClip Phrase2;
    public AudioClip Phrase3;
    public AudioClip Phrase4;
    public AudioClip Phrase5;
    public AudioClip Phrase6;
    public AudioClip Phrase7;
    public AudioClip Phrase8;
    public AudioClip Phrase9;
    public AudioClip Phrase10;

    public AudioClip Musique;

	// Use this for initialization
	void Start () {
        MusiqueSource.clip = Musique;
        ParoleSource.clip = Phrase1;
        ParoleSource.Play();
        MusiqueSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
