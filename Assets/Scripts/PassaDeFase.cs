using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PassaDeFase : MonoBehaviour {

	private Movimento _mov;
	private GameObject _player;
	public GameObject playerStart;   // posicao de saida
	private PlayerData _data;
	private Timer _timer; 

	//public int scenarioExit;    // qual entrada do cenario

	public string CondicaoNome;
	public int CondicaoValor;
	private bool next = false;
	public bool nextEvent = true;
	private int nextAno;
	public string playerMessage = "O tempo parece passar tão rápido.";
	public int tempoPadrao = 30;
	public int tempoAvancado = 30000;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag ("Player");
		_timer = _player.GetComponent<Timer> ();
		_data = GameObject.Find("PlayerData").GetComponent<PlayerData> (); 
		_mov= _player.GetComponent<Movimento> ();

		//if (_mov.exit==scenarioExit){
		//	_player.transform.position = playerStart.transform.position;
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (nextEvent) {
			if (!next && _data.IsResource (CondicaoNome)) {
				if (_data.GetResource (CondicaoNome) >= CondicaoValor) {
					next = true;
					EventManager.TriggerEvent ("newPlayerDialog",playerMessage);
					_mov.isMove = false;
					_timer.Velocidade = tempoAvancado;
					nextAno = Convert.ToInt32(_timer.CurrentAno) + 1;
				}
			} else if (!next && _data.IsItem (CondicaoNome)) {
				if (_data.GetItem (CondicaoNome) >= CondicaoValor) {
					next = true;
					EventManager.TriggerEvent ("newPlayerDialog",playerMessage);
					_mov.isMove = false;
					_timer.Velocidade = tempoAvancado;
					nextAno = Convert.ToInt32(_timer.CurrentAno) + 1;
				}
			}
			if (next) {				
				if (nextAno == Convert.ToInt32 (_timer.CurrentAno)) {
					nextEvent = false;		
					next = false;
					_mov.isMove = true;
					_timer.Velocidade = tempoPadrao;
					if (playerStart) {
						_player.transform.position = playerStart.transform.position;
					}
				} 
			}
		}
	}
}
