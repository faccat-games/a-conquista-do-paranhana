using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour {

	public GameObject helpPanel;

	private Movimento _mov;
	private Timer _timer;
	private GameObject _player;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag ("Player");
		_mov = _player.GetComponent<Movimento> ();
		_timer = _player.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (helpPanel.activeSelf == true) {
			_mov.isMove = false;
			_timer.isPaused = true;
		}
	}

	public void FecharPanel(){
		_mov.isMove = true;
		_timer.isPaused = false;
		helpPanel.SetActive(false);
	}
}
