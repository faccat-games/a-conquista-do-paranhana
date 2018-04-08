using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class InteracaoNPC : MonoBehaviour {
	public bool isTalk;
	public GameObject talkBalloon;
	public string[] phrases;
	//public Text phrasesText;
	public int indexPhrase;
	private Text talkText;

	//public bool giveHoe;
	//public bool giveAxe;
	//public bool giveSeeds;
	public bool giveRecurso;
	public bool giveItem;

	//public string TextoHoe;
	//public string TextoAxe;
	//public string TextoSeeds;
	//public string TextoItem;

	public string TextoPlayer;

	public string NomeRecurso;

	public string NomeItem;


	public int QtdRecurso = 0;

	public int QtdItem = 1;

	public bool isItemGiver;
	//public bool itemGived = false;
	public string[] itemPhrases;


	public Movimento _playerMov;
	public PlayerData _playerData;

	//private string[] talkPlayer = new string[4];

	private Ajuda _ajuda;


	void Start(){
		_playerMov = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movimento> ();
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> ();
		_ajuda = GetComponent<Ajuda> ();
		//talkText = GetComponentInChildren<Text> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTalk = true;
			//itemGived = false;
			indexPhrase = 0;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTalk = false;
			//itemGived = false;
			indexPhrase = 0;
		}
	}
		
	void Update(){ 

		if (isItemGiver) {
			if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase <= itemPhrases.Length - 1) {
				talkBalloon.SetActive (true);
				talkText = talkBalloon.GetComponentInChildren<Text> ();
				_playerMov.isMove = false;
				talkText.text = itemPhrases [indexPhrase];
				indexPhrase++;
				EventManager.TriggerEvent ("newPlayerDialog","");
				} else if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase >= itemPhrases.Length - 1) {
				    _playerMov.isMove = true;
					
					talkText.text = "";
					talkBalloon.SetActive (false);
					
					isItemGiver = false;					
									
					if (giveItem) {
						_playerData.SetItem (NomeItem, _playerData.GetItem (NomeItem) + QtdItem);													
					}

					if (giveRecurso) {						
						_playerData.SetResource (NomeRecurso, _playerData.GetResource (NomeRecurso) + QtdRecurso);
					}

					//talkPlayer = talkPlayer.Where(val => !String.IsNullOrEmpty(val)).ToArray();	
					if (TextoPlayer != null) {
						if (_ajuda) {
							_ajuda.Interagir = false;
						}
						EventManager.TriggerEvent ("newPlayerDialog",TextoPlayer);
					}
					//itemGived = true;
				}
			
		} else {
			
			if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase <= phrases.Length - 1) {
				_playerMov.isMove = false;
				talkBalloon.SetActive (true);
				talkText = talkBalloon.GetComponentInChildren<Text> ();
				talkText.text = phrases [indexPhrase];
				indexPhrase++;
				EventManager.TriggerEvent ("newPlayerDialog","");
			} else if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase >= phrases.Length - 1) {
				_playerMov.isMove = true;
				talkText = talkBalloon.GetComponentInChildren<Text> ();
				talkText.text = "";
				talkBalloon.SetActive (false);
			}

		}

	}
}