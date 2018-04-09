using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteracaoNPCNoite : MonoBehaviour {

	private bool isNoite = false;
	private bool _isNoite = false;
	private Vector3 _oriScale;

	// Use this for initialization
	void Start () {
		EventManager.StartListening ("newDayCicle", UpdateBackground);
		_oriScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateBackground(string value) {
		isNoite = (Boolean.Parse (value)) ? false : true;
		if (isNoite != _isNoite) {
			//background.GetComponent<Image> ().color = new Color (0.0f, 0.0f, 0.0f, (isNoite) ? 0.50f : 0.0f);
			//iconeLua.SetActive (isNoite);
			GetComponent<SpriteRenderer>().color = new Color (255.0f, 255.0f, 255.0f, (isNoite) ? 0.0f : 1.0f);
			transform.localScale = (isNoite) ? Vector3.zero : _oriScale;
			_isNoite = isNoite;
		}
	}

	void OnDestroy () {
		EventManager.StopListening ("newDayCicle", UpdateBackground);
	}
}
