using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionaItem : MonoBehaviour {

	public PlayerData _data;
	public int itemCode;
	//public Text counter;

	// Use this for initialization
	void Start () {
		_data = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (itemCode == 1) {
	//		counter.text = _data.cornSeeds.ToString();
	//	}
	}

	public void BotaoItem(){
		_data.itemHand = itemCode;
	}
}
