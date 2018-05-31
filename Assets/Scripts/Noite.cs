using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Noite : MonoBehaviour {

	private DateTime currentDateTime;
	public GameObject background;
	public bool isNoite = false;
	private bool _isNoite = false;
	public GameObject iconeLua;
    public GameObject torch;

	void Start () {
		EventManager.StartListening ("newDayCicle", UpdateBackground);
		//imageBackground = GetComponent<Image> ();
		//iconeLua = GetComponentInChildren<Image> ();
	}

	void Update () {
	}

	void UpdateBackground(string value) {
	
		/*currentDateTime = DateTime.Parse(value);
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
			*/
		isNoite = (Boolean.Parse (value)) ? false : true;
		if (isNoite != _isNoite) {
			background.GetComponent<Image> ().color = new Color (0.0f, 0.0f, 0.0f, (isNoite) ? 0.50f : 0.0f);
			iconeLua.SetActive (isNoite);
            torch.SetActive(isNoite);
			_isNoite = isNoite;
		}
	}

	void OnDestroy () {
		EventManager.StopListening ("newDayCicle", UpdateBackground);
	}
}
