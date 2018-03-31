using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteracaoNPC : MonoBehaviour {
	private bool isTalk;
	public GameObject talkBalloon;
	public string[] phrases;
	//public Text phrasesText;
	public int indexPhrase;
	public Text talkText;

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

	void Start(){
		_playerMov = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movimento> ();
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> ();
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
				_playerMov.isMove = false;
				talkText.text = itemPhrases [indexPhrase];
				talkBalloon.SetActive (true);
				indexPhrase++;
				EventManager.TriggerEvent ("newPlayerDialog","");
				} else if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase >= itemPhrases.Length - 1) {
				    _playerMov.isMove = true;
					talkBalloon.SetActive (false);
					talkText = talkBalloon.GetComponentInChildren<Text> ();
					talkText.text = "";
					isItemGiver = false;
					if (giveHoe) {
						_playerData.hasHoe = true;
						GetComponent<Ajuda> ().Interagir = false;
						EventManager.TriggerEvent ("newPlayerDialog",TextoHoe);
					}
					if (giveAxe) {
						_playerData.hasAxe = true;
						GetComponent<Ajuda> ().Interagir = false;
						EventManager.TriggerEvent ("newPlayerDialog",TextoAxe);
					}
					if (giveSeeds) {
						_playerData.cornSeeds += 5;    /// ALTERAR
						GetComponent<Ajuda> ().Interagir = false;
						EventManager.TriggerEvent ("newPlayerDialog",TextoSeeds);
					}

				}
			
		} else {


			if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase <= phrases.Length - 1) {
				_playerMov.isMove = false;
				talkText.text = phrases [indexPhrase];
				talkBalloon.SetActive (true);
				indexPhrase++;
				EventManager.TriggerEvent ("newPlayerDialog","");
			} else if (isTalk && Input.GetKeyDown (KeyCode.E) && indexPhrase >= phrases.Length - 1) {
				_playerMov.isMove = true;
				talkBalloon.SetActive (false);
				talkText = talkBalloon.GetComponentInChildren<Text> ();
				talkText.text = "";


			}

		}

	}
}