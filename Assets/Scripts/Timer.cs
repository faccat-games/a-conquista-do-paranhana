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

	private int _hora;

	private DateTime dateTime;

	//public GameObject _noitePanel;
	//public Image _noiteColor;
	public float Velocidade = 50.0f;

	public string _currentTime;


	public bool newDay = true;
	private bool _newDay = false;



	// Use this for initialization
	void Start () {
		//_noitePanel = GameObject.Find ("Noite");
		//_noiteColor = _noitePanel.GetComponent<Image> ();
		//GameObject YearEventPanel = GameObject.Find("YearEventPanel");
		dateTime = new DateTime(ano, mes, dia, hora, 0, 0);
	}

	public DateTime currentDateTime
	{
		get
		{
			//Some other code
			return dateTime;
		}
	}
	// Update is called once per frame
	void Update () {
		dateTime = dateTime.AddMinutes(Time.deltaTime * Velocidade);

		//Tempo.text = dateTime.ToString ("HH:mm:ss");
		//Data.text = dateTime.ToString ("F", new System.Globalization.CultureInfo ("pt-BR"));

		//_timestamp = dateTime.ToString ("F", new System.Globalization.CultureInfo ("pt-BR"));
		_currentTime = dateTime.ToString();

		//Debug.Log (dateTime.ToString ("F", new System.Globalization.CultureInfo ("pt-BR")));

		if (_hora != dateTime.Hour) {
			EventManager.TriggerEvent ("timeUpdate", _currentTime);
			_hora = dateTime.Hour;

			if (_hora < 6 || _hora >= 19) {
				newDay = false;
			}
			// dia
			if (_hora >= 6 && _hora < 19) {			
				newDay = true;
			}

			if (newDay != _newDay) {
				EventManager.TriggerEvent ("newDayCicle", newDay.ToString());
				_newDay = newDay;
			}
		}
		/*if (ano != _ano) {
			_ano = ano;
			EventManager.TriggerEvent ("newYear", _ano.ToString ());
		}*/
	}
} 