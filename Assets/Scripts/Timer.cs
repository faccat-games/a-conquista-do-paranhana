using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	//public Text Tempo;
	//public float segundos, minutos, horas;
	//public Text Data;
	public int ano = 1846, mes = 3, dia = 10, hora = 6;
	private int _ano;

	private DateTime dateTime;

	//public GameObject _noitePanel;
	//public Image _noiteColor;
	public float Velocidade = 50.0f;
	public bool isNoite = false;
	private string _timestamp;


	//	public GameObject _fundo; 
	//	public GameObject _cor;

	// Use this for initialization
	void Start () {
		//_noitePanel = GameObject.Find ("Noite");
		//_noiteColor = _noitePanel.GetComponent<Image> ();
		//GameObject YearEventPanel = GameObject.Find("YearEventPanel");
		dateTime = new DateTime(ano, mes, dia, hora, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		dateTime = dateTime.AddMinutes(Time.deltaTime * Velocidade * 1000);
		dia = dateTime.Day;
		mes = dateTime.Month;
		ano = dateTime.Year;
		// noite
		int hora = Int32.Parse(dateTime.ToString("HH"));
		if (hora < 6 && hora >= 19 && !isNoite) {
			//_noiteColor.color = new Color (0f, 0f, 0f, .5f);
			isNoite = true;
			EventManager.TriggerEvent ("newDay", isNoite.ToString());
		}
		// dia
		if (hora >= 6 && hora < 19 && isNoite) {
			//_noiteColor.color = new Color (0f, 0f, 0f, 0f);
			isNoite = false;
			EventManager.TriggerEvent ("newDay", isNoite.ToString());
		}
		//Tempo.text = dateTime.ToString ("HH:mm:ss");
		//Data.text = dateTime.ToString ("F", new System.Globalization.CultureInfo ("pt-BR"));

		_timestamp = dateTime.ToString ("F", new System.Globalization.CultureInfo ("pt-BR"));
		Debug.Log (_timestamp);
		EventManager.TriggerEvent ("timeUpdate", _timestamp);
		if (ano != _ano) {
			_ano = ano;
			EventManager.TriggerEvent ("newYear", _ano.ToString ());
		}
	}
} 