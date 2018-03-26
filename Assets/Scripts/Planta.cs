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

	// colher planta
	public bool isMadura;
	public int totalColheita;     // total de itens coletados da planta
	public int _itemColetado;     // alterar para outro tipo de objeto
	public bool isColher;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		_mySprite = gameObject.GetComponent<SpriteRenderer> ();
		_player = GameObject.FindGameObjectWithTag ("Player");
		_thisTimer= _player.GetComponent<Timer> ();

		lifeTime = diaPlantacao;

		diaAtual = _thisTimer.dia;
		mesAtual = _thisTimer.mes;

		isMadura = false;
			
	}
	
	// Update is called once per frame
	void Update () {
		// meses - 1
		// mesplantacao -1

		if (_thisTimer.mes != mesAtual) {
			novaData = true;
			lifeTime++;
			mesAtual = _thisTimer.mes;
		} else if (diaAtual != _thisTimer.dia) {

			lifeTime++;
			diaAtual = _thisTimer.dia;
		}


		if (lifeTime == daysToGrow) {
			_mySprite.sprite = lastForm;
		}



		if(Input.GetKeyDown(KeyCode.E) && isColher){
			GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> ().corn += totalColheita;    // alterear para outras plantas
			Destroy (gameObject);
		}




	}

	public void updatePlanta(){
		lifeTime++;
		if (lifeTime == daysToGrow) {
			_mySprite.sprite = lastForm;
			isMadura = true;
		}
	}


	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.tag);
		if(col.tag == "Player" && isMadura){
			isColher = true;
		}
	}

}