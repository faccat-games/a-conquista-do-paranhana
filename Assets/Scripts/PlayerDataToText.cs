using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerDataToText : MonoBehaviour {
	public PlayerData _data;
	private Text _text;
	public string Propriedade = "";

	void Start () {
		_data = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
		_text = GetComponent<Text> ();
	}
	
	void Update () {
		_text.text = (_data.IsResource (Propriedade)) ? _data.GetResourceAsString (Propriedade) : _data.GetItemAsString (Propriedade);
	}
}
