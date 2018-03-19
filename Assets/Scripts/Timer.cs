using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text Tempo;
	public float segundos, minutos, horas;
	public Text Data;
	public int dia, meses, anos;

	public GameObject _noitePanel;
	public Image _noiteColor;

	public bool isNoite;

	public GameObject yearEventPanel;


	//	public GameObject _fundo; 
	//	public GameObject _cor;

	// Use this for initialization
	void Start () {
		isNoite = false;
		_noitePanel = GameObject.Find ("Noite");
		_noiteColor = _noitePanel.GetComponent<Image> ();
		//GameObject YearEventPanel = GameObject.Find("YearEventPanel");
		yearEventPanel.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		segundos += Time.deltaTime * 50;
		Tempo.text = horas.ToString("00") + ":" + minutos.ToString ("00") + ":" + segundos.ToString ("00");
		if (segundos >= 60) {
			minutos++;
			segundos = 0;
		} else if (minutos >= 60) {
			horas++;
			minutos = 0;
		} else if (horas >= 24) {
			horas = 0;
		}

		// noite
		if (horas >= 19 && !isNoite ) {
			_noiteColor.color = new Color (0f, 0f, 0f, .5f);
			isNoite = true;
		}
		// dia
		if (horas ==6 && isNoite ) {
			_noiteColor.color = new Color (0f, 0f, 0f, 0f);
			isNoite = false;
		}

		Data.text = dia.ToString ("Dia 00") + meses.ToString ("  Mês 00") + anos.ToString ("  Ano 0000");
		if (horas >= 24) {
			dia++;
		} if (dia > 31) {
			meses++;
			dia = 1;
		}
	}
} 