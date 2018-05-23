using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Planta : MonoBehaviour {

	public GameObject _player;
	public PlayerData _playerData;
	//public Timer _thisTimer;

	public int lifeTime;    

	public int daysToGrow;

	public Sprite midForm;
	public Sprite lastForm;

	public SpriteRenderer _spritePlanta;

	public int diaPlantacao;


	// colher planta
	public bool isMadura = false;
	public int totalColheita;     // total de itens coletados da planta
	public int _itemColetado;     // alterar para outro tipo de objeto
	public bool isColher = false;
    public string colherMsg;

	void Start () {

		_spritePlanta = gameObject.GetComponent<SpriteRenderer> ();
		_player = GameObject.FindGameObjectWithTag ("Player");
		_playerData = GameObject.Find("PlayerData").GetComponent<PlayerData> ();   
		EventManager.StartListening ("newDayCicle", UpdateLifeTime);
		//lifeTime = diaPlantacao;
	}

	void UpdateLifeTime(string value) {
		//bool newDay = value == "true";
		if (Convert.ToBoolean(value)) {
			lifeTime++;
		}
	}

	void Update () {

		if (!isMadura) {
			switch (Convert.ToInt32(Math.Floor (((double) 2 / (double)daysToGrow) * (double)lifeTime))) {
			case 1:
				_spritePlanta.sprite = midForm;
				transform.localPosition = new Vector3(0, 0.2f, 0);
				break;
			case 2:
				_spritePlanta.sprite = lastForm;
				transform.localPosition = new Vector3(0, 0.6f, 0);
				isMadura = true;
				break;			
			}
		}

		/*if (lifeTime == daysToGrow) {
			_spritePlanta.sprite = lastForm;
			isMadura = true;
		}*/
			
        if (Input.GetKeyDown(KeyCode.Space) && isColher){
			_playerData.SetResource("corn",_playerData.GetResource("corn") + totalColheita);    // alterear para outras plantas
			//Destroy(gameObject);
            Destroy(transform.parent.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log (col.tag);
		if(col.tag == "Player" && isMadura){
			isColher = true;
            EventManager.TriggerEvent("newPlayerDialog", colherMsg);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		//Debug.Log (col.tag);
		if(col.tag == "Player" && isMadura){
			isColher = false;
		}
	}

}