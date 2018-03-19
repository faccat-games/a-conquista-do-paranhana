using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteracaoNPC : MonoBehaviour {
	private bool isTalk;
	public GameObject talkBalloon;
	public string[] phrases;
	public Text phrasesText;
	public int indexPhrase;
	public Text talkText;

	public bool giveHoe;
	public bool giveAxe;


	public bool isItemGiver;
	public string[] itemPhrases;


	public Movimento _playerMov;
	public PlayerData _playerData;

	void Start(){
		_playerMov = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movimento> ();
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> ();
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
				_playerMov.isMove = false;
				phrasesText.text = itemPhrases [indexPhrase];
				talkBalloon.SetActive (true);
				indexPhrase++;
				}else if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase >= itemPhrases.Length - 1) {
				    _playerMov.isMove = true;
					talkBalloon.SetActive (false);
					talkText = talkBalloon.GetComponentInChildren<Text> ();
					talkText.text = "";
					isItemGiver = false;
					if (giveHoe) {
						_playerData.hasHoe = true;
					}
					if (giveAxe) {
						_playerData.hasAxe = true;
					}

				}
			
		} else {


			if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase <= phrases.Length - 1) {
				_playerMov.isMove = false;
				phrasesText.text = phrases [indexPhrase];
				talkBalloon.SetActive (true);
				indexPhrase++;
			} else if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase >= phrases.Length - 1) {
				_playerMov.isMove = true;
				talkBalloon.SetActive (false);
				talkText = talkBalloon.GetComponentInChildren<Text> ();
				talkText.text = "";


			}

		}

	}
}