using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Noite : MonoBehaviour {

	private DateTime currentDateTime;
	private Image imageBackground;
	public bool isNoite = false;
	private bool _isNoite = false;

	void Start () {
		EventManager.StartListening ("timeUpdate", UpdateBackground);
		imageBackground = gameObject.GetComponent<Image> ();
	}

	void Update () {
	}

	void UpdateBackground(string value) {
	
		currentDateTime = DateTime.Parse(value);
		// noite
		int hora = Int32.Parse(currentDateTime.ToString("HH"));

		if (hora < 6 || hora >= 19) {
			isNoite = true;
		}
		// dia
		if (hora >= 6 && hora < 19) {			
			isNoite = false;
		}

		if (isNoite != _isNoite) {
			EventManager.TriggerEvent ("newDayCicle", isNoite.ToString());
			imageBackground.color = new Color (0.0f, 0.0f, 0.0f, (isNoite) ? 0.10f : 0.0f);
			_isNoite = isNoite;
		}
			
	}

	void OnDestroy () {
		EventManager.StopListening ("timeUpdate", UpdateBackground);
	}
}
