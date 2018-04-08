using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData : MonoBehaviour {

	public string playerName;
	public string playerSurname;    // esse campo deve ser modificado caso o sobrenome indique uma habilidade do personagem
	private int _money;

	public Dictionary<string, int> items = new Dictionary<string, int> ();

	private int _woodLog;
	private int _corn;
	private int _cornSeeds;    //item 0

	public int itemHand;   // item em uso pelo jogador   seleção por id   // 0 nenhum, 1 cornseeds;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public string moneyFormatted {
		get { return "R" + _money.ToString() + "$000"; }
	}
	public int money
	{
		get {return _money;}
		set {_money = value;}
	}


	public int cornSeeds
	{
		get {return _cornSeeds;}
		set {_cornSeeds = value;}
	}

	public int corn
	{
		get {return _corn;}
		set {_corn = value;}
	}

	public int woodLog
	{
		get {return _woodLog;}
		set {_woodLog = value;}
	}
		

	public bool IsResource(string name) {
		return (this.GetType ().GetProperty (name) != null) ? true : false;
	}

	public string GetResourceAsString(string name) {
		var obj_property = this.GetType ().GetProperty (name);
		if (obj_property != null) {
			return Convert.ToString(obj_property.GetValue(this, null));
		} else {
			return "";
		}
	}

	public int GetResource(string name) {
		var obj_property = this.GetType ().GetProperty (name);
		if (obj_property != null) {
			return Convert.ToInt32(obj_property.GetValue(this, null));
		} else {
			return 0;
		}
	}

	public void SetResource(string name, int value) {
		var obj_property = this.GetType ().GetProperty (name);
		if (obj_property != null) {
			obj_property.SetValue (this, value, null);
		}
	}

	public void RemoveResource(string name) {
		if (IsResource (name)) {
			SetResource (name, 0);
		}
	}

	public int GetItem(string name) {
		if (items.ContainsKey (name)) {
			return items [name];
		} else {
			return 0;
		}
	}

	public string GetItemAsString(string name) {
		if (items.ContainsKey (name)) {
			return Convert.ToString(items [name]);
		} else {
			return "";
		}
	}

	public void RemoveItem(string name) {
		items.Remove (name);
	}

	public bool IsItem(string name) {
		return (items.ContainsKey (name)) ? true : false; 
	}

	public void SetItem(string name, int value) {
		if (items.ContainsKey (name)) {
			items [name] = value;
		} else {
			items.Add (name, value);
		}
	}

}
