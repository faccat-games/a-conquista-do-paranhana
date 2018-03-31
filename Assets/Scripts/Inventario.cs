using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Inventario : MonoBehaviour {

	public GameObject panelInventario;
	public PlayerData _playerData;
	//private Timer _timer;
	//private DateTime currentDateTime;
	public GameObject axeItem;
	public GameObject hoeItem;
	public Text DataTexto;
	public Text HoraTexto;
	public Text PlayerNome;

	private Timer _timer;
	public bool isMenuOpen;

	public int activeItem;    // verificar os indices em playerData

	// Use this for initialization
	void Start () {
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> ();   
		_timer = gameObject.GetComponentInParent<Timer> ();
		//EventManager.StartListening ("timeUpdate", UpdateTimer);

	}

	void UpdateTimer(string value) {
		//currentDateTime = DateTime.Parse(value);
		//(dateTime.ToString ("D", new System.Globalization.CultureInfo ("pt-BR")));
	}
	
	// Update is called once per frame
	void Update () {

		DataTexto.text = _timer.currentDateTime.ToString ("D", new System.Globalization.CultureInfo ("pt-BR"));
		HoraTexto.text = _timer.currentDateTime.ToString ("HH:mm");

		if(Input.GetKeyDown(KeyCode.Tab ) && isMenuOpen ==false){
			Time.timeScale = 0;
			isMenuOpen = true;


		} else 	if(Input.GetKeyDown(KeyCode.Tab ) && isMenuOpen ==true){
					Time.timeScale = 1;
					isMenuOpen = false;
				}
		AbreInventario ();		
	}

	void AbreInventario(){
		if (isMenuOpen) {
			panelInventario.SetActive (true);

			if (_playerData.hasHoe == false) {
				hoeItem.SetActive (false);
			} else {
				hoeItem.SetActive (true);
			}


			if (_playerData.hasAxe == false) {
				axeItem.SetActive (false);
			} else {
				axeItem.SetActive (true);
			}
			
		} else panelInventario.SetActive (false);			
	}
}