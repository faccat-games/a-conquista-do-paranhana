using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetal : MonoBehaviour {

	public Timer _timer;
	public Sleep _sleep;

	public SpriteRenderer mySprite;

	public int tempoPlantio;


	//    fases de maturação da planta
	public int broto;
	public int planta;
	public int madura;

	//   sprites das fases
	public Sprite brotoSprite;
	public Sprite plantaSprite;
	public Sprite maduraSprite;



	// Use this for initialization
	void Start () {
		tempoPlantio = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (_sleep.fadein) {
			if (tempoPlantio < planta) {
				mySprite.sprite = brotoSprite;
			}
			// outras fases da planta
		}
		
	}
}
