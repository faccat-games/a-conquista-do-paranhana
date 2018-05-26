using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoArvore : MonoBehaviour {
	public bool isTake;
	public bool vAction;
	//public SpriteRenderer sr2;
	//public Sprite sTronco;
	public AudioSource _audio;
	public PlayerData _playerData;

	void Awake(){


	}

	void Start () {
		//sr2 = GetComponent<SpriteRenderer> ();
		_audio = GetComponent<AudioSource>();

	
	}
	void OnTriggerEnter2D (Collider2D other) {
		_playerData = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
		if (_playerData.IsItem("Machado")) {
			vAction = true;
		}
		if (other.gameObject.tag == "Player") {
			isTake = true;

		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTake = false;
		}
	}

	void Update(){
        if (isTake && Input.GetKeyDown (KeyCode.Space)&& vAction) {
			//sr2.sprite = sTronco;		
			_playerData.SetResource("Madeira",_playerData.GetResource("Madeira") + 10);
			GetComponent<Arvore>().isCortada = true;
			GetComponent<Ajuda> ().Interagir = false;
			vAction = false;
			_audio.Play();
		}
	}
}