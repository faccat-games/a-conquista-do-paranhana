using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaItem : MonoBehaviour {

	public PlayerData _data;
	public int itemCode;

	// Use this for initialization
	void Start () {
		_data = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BotaoItem(){
		_data.itemHand = itemCode;
	}
}
