using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlayerDataToText : MonoBehaviour {
	public PlayerData _data;
	private Text _text;
	public string Propriedade = "";
	// Use this for initialization
	void Start () {
		_data = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
		_text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		var obj_property = _data.GetType ().GetProperty (Propriedade);
		if (obj_property != null) {
			_text.text = Convert.ToString(obj_property.GetValue(_data, null));
		}
	}
}
