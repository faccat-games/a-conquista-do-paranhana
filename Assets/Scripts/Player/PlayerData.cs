using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public string playerName;
	public string playerSurname;    // esse campo deve ser modificado caso o sobrenome indique uma habilidade do personagem
	public float playerMoney;



	public bool hasAxe;          // tem machado?
	public bool hasHoe;          // tem arado ?

	public int _woodLog;

	public int _corn;
	public int _cornSeeds;    //item 0


	public int itemHand;   // item em uso pelo jogador   seleção por id   // 0 nenhum, 1 cornseeds;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
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

}
