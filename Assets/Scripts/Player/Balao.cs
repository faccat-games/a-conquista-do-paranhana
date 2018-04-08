using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balao : MonoBehaviour {
	private GameObject BalaoPanel;
	private Text BalaoText;
	public bool MostrarBalao = false;
	public float BalaoTempo = 5.0f;
	private float timer;

	void Start () {		
		EventManager.StartListening ("newPlayerDialog", UpdateBalao);
		BalaoPanel = gameObject.transform.GetChild (0).gameObject;
		BalaoText = BalaoPanel.transform.GetChild (0).gameObject.GetComponent<Text> ();
	}
		
	void Update () {	
			
		if (MostrarBalao) {
			timer -= Time.deltaTime;
			if (timer <= 0.0f) {
				MostrarBalao = false;
			}
		} else {
			timer = BalaoTempo;
		}
		BalaoPanel.SetActive (MostrarBalao);
	}

	void UpdateBalao (string value) {
		//Debug.Log ("Dialog:" + value);
		MostrarBalao = (value == "") ? false : true;
		if (MostrarBalao) {
			timer = BalaoTempo;
		}
		BalaoText.text = value;			
	}

	void OnDestroy () {
		EventManager.StopListening ("newPlayerDialog", UpdateBalao);
	}
}
