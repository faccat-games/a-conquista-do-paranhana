using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class InteracaoNPC : MonoBehaviour {
	//public bool isTalk;
	public GameObject talkBalloon;
	public string[] phrases;
	//public Text phrasesText;
	private int indexPhrase;
	private Text talkText;

    public bool Interagir = true;

    public string NomeRecurso;
    public int QtdRecurso = 0;
    public string NomeItem;
    public int QtdItem = 0;
    public string[] interacaoPhrases;

	//public string TextoHoe;
	//public string TextoAxe;
	//public string TextoSeeds;
	//public string TextoItem;

	public string TextoPlayer;
       	
	//public bool itemGived = false;
	


	//public Movimento _playerMov;
	private PlayerData _playerData;
	private Player _player;

	//private string[] talkPlayer = new string[4];

	private Ajuda _ajuda;

	//private bool isVisible;

    private string _dialog;
    private int _oriPhrasesLength;
    //private Inventario _inventario;

    private bool _interactingWithPlayer = false;

	void Start(){
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
		//_playerMov = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movimento> ();
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> ();
		//_timer = GameObject.FindGameObjectWithTag ("Player").GetComponent<Timer> ();
		_ajuda = GetComponent<Ajuda> ();
        //talkText = GetComponentInChildren<Text> ();
        //_inventario = _player.GetComponent<Inventario>();
        talkText = talkBalloon.GetComponentInChildren<Text>();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			//itemGived = false;
			indexPhrase = 0;
            InteractingWithPlayer = true;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			//itemGived = false;
			indexPhrase = 0;
            InteractingWithPlayer = false;
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
		
    public void AddDialog(string msg) {
        _oriPhrasesLength = phrases.Length;
        phrases[phrases.Length] = msg;
    }

    public bool InteractingWithPlayer
    {
        get { return _interactingWithPlayer; }
        set { _interactingWithPlayer = value; }
    }

	void Update(){ 

        if (!_interactingWithPlayer) {
            return;
        }
        /*
        isVisible = GetComponent<SpriteRenderer> ().color.a.Equals(0.0f) ? false : true; 

		if (!isVisible) {
            _player.Paused = false;
			//talkText = talkBalloon.GetComponentInChildren<Text> ();
			talkText.text = "";
			talkBalloon.SetActive (false);
			indexPhrase = 0;
            InteractingWithPlayer = false;
		}*/

        if (Interagir) {
            if (InteractingWithPlayer && Input.GetKeyDown (KeyCode.Space) && indexPhrase <= interacaoPhrases.Length - 1) {
				talkBalloon.SetActive (true);
				//talkText = talkBalloon.GetComponentInChildren<Text> ();
                _player.Paused = true;
                _dialog = interacaoPhrases [indexPhrase];
                talkText.text = RemChar(_dialog);
				indexPhrase++;
				EventManager.TriggerEvent ("newPlayerDialog","");
            } else if (InteractingWithPlayer && Input.GetKeyDown (KeyCode.Space) && indexPhrase >= interacaoPhrases.Length - 1) {
                    _player.Paused = false;					
					talkText.text = "";
					talkBalloon.SetActive (false);

                    Interagir = false;
					
                    if (NomeItem != "" && QtdItem > 0) {
						_playerData.SetItem (NomeItem, _playerData.GetItem (NomeItem) + QtdItem);
                        QtdItem = 0;
                        //_inventario.AddItem(NomeItem);
                        //_inventario.SetValue(NomeItem, _playerData.GetItem(NomeItem));
					}

                    if (NomeRecurso != "" && QtdRecurso > 0) {						
						_playerData.SetResource (NomeRecurso, _playerData.GetResource (NomeRecurso) + QtdRecurso);
                        QtdRecurso = 0;
					}

					//talkPlayer = talkPlayer.Where(val => !String.IsNullOrEmpty(val)).ToArray();	
					if (TextoPlayer != "") {
						if (_ajuda) {
							_ajuda.Interagir = false;
						}
						EventManager.TriggerEvent ("newPlayerDialog",TextoPlayer);
					}
					//itemGived = true;
				}
			
		} else {
			
            if (InteractingWithPlayer && Input.GetKeyDown (KeyCode.Space) && indexPhrase <= phrases.Length - 1) {
                _player.Paused = true;
				talkBalloon.SetActive (true);
				
                _dialog = phrases [indexPhrase];
                talkText.text = RemChar(_dialog);
				indexPhrase++;
				EventManager.TriggerEvent ("newPlayerDialog","");

                if (indexPhrase == _oriPhrasesLength && _oriPhrasesLength > 0) {
                    phrases.Take(phrases.Count() - 1).ToArray();
                }

            } else if (InteractingWithPlayer && Input.GetKeyDown (KeyCode.Space) && indexPhrase >= phrases.Length - 1) {
                _player.Paused = false;
				//talkText = talkBalloon.GetComponentInChildren<Text> ();
				talkText.text = "";
				talkBalloon.SetActive (false);
			}

		}

	}
}