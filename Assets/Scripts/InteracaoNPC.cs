using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class InteracaoNPC : MonoBehaviour {
	private bool isTalk;
	public GameObject talkBalloon;
	public string[] phrases;
	//public Text phrasesText;
	public int indexPhrase;
	private Text talkText;

	public bool giveHoe;
	public bool giveAxe;
	public bool giveSeeds;

	public string TextoHoe;
	public string TextoAxe;
	public string TextoSeeds;


	public bool isItemGiver;
	public string[] itemPhrases;


	public Movimento _playerMov;
	public PlayerData _playerData;

	private string[] talkPlayer = new string[3];

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
			indexPhrase = 0;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTalk = false;
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

					if (giveHoe) {
						_playerData.hasHoe = true;
						talkPlayer [0] = TextoHoe;
					}
					if (giveAxe) {
						_playerData.hasAxe = true;
						talkPlayer [1] = TextoAxe;
					}
					if (giveSeeds) {
						_playerData.cornSeeds += 5;    /// ALTERAR
						talkPlayer [2] = TextoSeeds;
					}

					talkPlayer = talkPlayer.Where(val => !String.IsNullOrEmpty(val)).ToArray();	
					if (talkPlayer.Length > 0) {
						if (_ajuda) {
							_ajuda.Interagir = false;
						}
						EventManager.TriggerEvent ("newPlayerDialog",String.Join("\n", talkPlayer));
					}
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