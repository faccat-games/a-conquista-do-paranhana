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


	//public Movimento _playerMov;
	public PlayerData _playerData;
	private Player _player;

	//private string[] talkPlayer = new string[4];

	private Ajuda _ajuda;

	private bool isVisible;

    private string _dialog;

	void Start(){
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
		//_playerMov = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movimento> ();
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> ();
		//_timer = GameObject.FindGameObjectWithTag ("Player").GetComponent<Timer> ();
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

    string RemChar(string val) {
        if (val.Length > 0 && val[0].ToString() == "=")
        {
            val = val.Remove(0, 1);
            EventManager.TriggerEvent("newDiaryEntry", "- " + val);
        }
        return val;
    }
		
	void Update(){ 
        isVisible = GetComponent<SpriteRenderer> ().color.a.Equals(0.0f) ? false : true; 

		if (!isVisible) {
            _player.Paused = false;
			talkText = talkBalloon.GetComponentInChildren<Text> ();
			talkText.text = "";
			talkBalloon.SetActive (false);
			indexPhrase = 0;
			isTalk = false;
		}

		if (isItemGiver) {
            if (isTalk && Input.GetKeyDown (KeyCode.Space) && indexPhrase <= itemPhrases.Length - 1) {
				talkBalloon.SetActive (true);
				talkText = talkBalloon.GetComponentInChildren<Text> ();
                _player.Paused = true;
                _dialog = itemPhrases [indexPhrase];
                talkText.text = RemChar(_dialog);
				indexPhrase++;
				EventManager.TriggerEvent ("newPlayerDialog","");
            } else if (isTalk && Input.GetKeyDown (KeyCode.Space) && indexPhrase >= itemPhrases.Length - 1) {
                    _player.Paused = false;					
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
			
            if (isTalk && Input.GetKeyDown (KeyCode.Space) && indexPhrase <= phrases.Length - 1) {
                _player.Paused = true;
				talkBalloon.SetActive (true);
				talkText = talkBalloon.GetComponentInChildren<Text> ();
                _dialog = phrases [indexPhrase];
                talkText.text = RemChar(_dialog);
				indexPhrase++;
				EventManager.TriggerEvent ("newPlayerDialog","");
            } else if (isTalk && Input.GetKeyDown (KeyCode.Space) && indexPhrase >= phrases.Length - 1) {
                _player.Paused = false;
				talkText = talkBalloon.GetComponentInChildren<Text> ();
				talkText.text = "";
				talkBalloon.SetActive (false);
			}

		}

	}
}