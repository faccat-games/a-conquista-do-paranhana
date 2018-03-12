using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoGold : MonoBehaviour {
	public bool isTake;
	public bool vAction;
	public SpriteRenderer sr2;
	public Sprite sTronco;
	public AudioSource _audio;
	public PlayerData _playerData;

	void Awake(){

		_playerData = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
		if (_playerData.hasAxe == true) {
			Debug.Log ("TEM MACHADO");
			vAction = true;
		}
	}

	void Start () {
		sr2 = GetComponent<SpriteRenderer> ();
		_audio = GetComponent<AudioSource>();

	
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTake = true;

		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTake = false;
		}
	}

	void FixedUpdate(){
		if (isTake && Input.GetKeyDown (KeyCode.E)&& vAction) {
			sr2.sprite = sTronco;
			_playerData.woodLog += 10;

			vAction = false;
			_audio.Play();
		}
	}
}