using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planta : MonoBehaviour {

	public GameObject _player;
	public Timer _thisTimer;

	public int lifeTime;    

	public int daysToGrow;

	public Sprite lastForm;

	public SpriteRenderer _mySprite;

	public int diaPlantacao;
	public int mesPlantacao;

	public bool novaData;

	int mesAtual;
	int diaAtual;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		_mySprite = gameObject.GetComponent<SpriteRenderer> ();
		_player = GameObject.FindGameObjectWithTag ("Player");
		_thisTimer= _player.GetComponent<Timer> ();

		lifeTime = diaPlantacao;

		diaAtual = _thisTimer.dia;
		mesAtual = _thisTimer.meses;
			
	}
	
	// Update is called once per frame
	void Update () {
		// meses - 1
		// mesplantacao -1

		if (_thisTimer.meses != mesAtual) {
			novaData = true;
			lifeTime++;
			mesAtual = _thisTimer.meses;
		} else if (diaAtual != _thisTimer.dia) {

			lifeTime++;
			diaAtual = _thisTimer.dia;
		}


		if (lifeTime == daysToGrow) {
			_mySprite.sprite = lastForm;
		}




	}

	public void updatePlanta(){
		lifeTime++;
		if (lifeTime == daysToGrow) {
			_mySprite.sprite = lastForm;
		}
	}
}