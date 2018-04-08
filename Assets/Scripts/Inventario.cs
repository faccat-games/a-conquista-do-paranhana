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
	public GameObject farinhaItem;
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
		if (PlayerNome != null) {			
			PlayerNome.text = _playerData.playerName + " " + _playerData.playerSurname;
		}
	}

	void UpdateTimer(string value) {
		//currentDateTime = DateTime.Parse(value);
		//(dateTime.ToString ("D", new System.Globalization.CultureInfo ("pt-BR")));
	}
	
	// Update is called once per frame
	void Update () {
		if (DataTexto != null) {
			DataTexto.text = _timer.currentDateTime.ToString ("D", new System.Globalization.CultureInfo ("pt-BR"));
		}
		if (HoraTexto != null) {
			HoraTexto.text = _timer.currentDateTime.ToString ("HH:mm");
		}

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

			if (farinhaItem != null) {
				if (_playerData.GetItem("Farinha") > 0) {
					farinhaItem.SetActive (true);
					farinhaItem.GetComponent<Text>().text = _playerData.GetItem("Farinha") +" x " + "Farinha";
				} else {
					farinhaItem.SetActive (false);
				}
			}
			if (axeItem != null) {				
				axeItem.SetActive (_playerData.IsItem("Machado"));				
			}
			if (hoeItem != null) {				
				hoeItem.SetActive (_playerData.IsItem("Enxada"));
			}
			
		} else panelInventario.SetActive (false);			
	}


	/*public void AddItem( GameObject item )
	{
		if ( item == null || item.GetComponent<TeamSelectItem>() == null )
			return;

		item.transform.SetParent( Grid.transform );
		item.transform.localScale = autoLocalScale;
		item.transform.localPosition = Vector3.zero;
	}*/
}