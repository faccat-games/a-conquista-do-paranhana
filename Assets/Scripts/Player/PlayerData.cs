using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public string playerName;
	public string playerSurname;    // esse campo deve ser modificado caso o sobrenome indique uma habilidade do personagem
	public float playerMoney;



	public bool hasAxe;          // tem machado?
	public bool hasHoe;          // tem arado ?

	public int woodLog;

	public int corn;
	public int cornSeeds;    //item 0


	public int itemHand;   // item em uso pelo jogador   seleção por id   // 0 nenhum, 1 cornseeds;





	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
