using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour {

	public GameObject helpPanel;

	public Movimento _mov;

	public GameObject _player;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag ("Player");
		_mov= _player.GetComponent<Movimento> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (helpPanel.activeSelf == true) {
			_mov.isMove = false;
		}
	}

	public void FecharPanel(){
		_mov.isMove = true;
		helpPanel.SetActive(false);
	}
}
