using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PassaDeFase : MonoBehaviour {

	//private Movimento _mov;
	private GameObject _player;
	//public GameObject playerStart;   // posicao de saida
	private PlayerData _data;
	//private Timer _timer; 

	//public int scenarioExit;    // qual entrada do cenario

	public string CondicaoNome;
	public int CondicaoValor;
	public bool proximaFase = false;
	public bool checkCondition = true;
	private Balao _balao; 
	//private int nextAno;
	//public string playerMessage = "O tempo parece passar tão rápido.";
	//public int tempoPadrao = 30;
	//public int tempoAvancado = 30000;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag ("Player");
		_balao = _player.GetComponentInChildren<Balao> ();
		//_timer = _player.GetComponent<Timer> ();
		_data = GameObject.Find("PlayerData").GetComponent<PlayerData> (); 
		//_mov= _player.GetComponent<Movimento> ();

		//if (_mov.exit==scenarioExit){
		//	_player.transform.position = playerStart.transform.position;
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (checkCondition && _balao != null && !_balao.MostrarBalao) {
			if (!proximaFase && _data.IsResource (CondicaoNome)) {
				if (_data.GetResource (CondicaoNome) >= CondicaoValor) {
					proximaFase = true;
					//EventManager.TriggerEvent ("newPlayerDialog",playerMessage);
					//_mov.isMove = false;
					//_timer.Velocidade = tempoAvancado;
					//nextAno = Convert.ToInt32(_timer.CurrentAno) + 1;
					//EventManager.TriggerEvent ("finalFase","Recurso - "+CondicaoNome+" é maior ou igual a "+CondicaoValor);
				}
			} else if (!proximaFase && _data.IsItem (CondicaoNome)) {
				if (_data.GetItem (CondicaoNome) >= CondicaoValor) {
					proximaFase = true;
					//EventManager.TriggerEvent ("newPlayerDialog",playerMessage);
					//_mov.isMove = false;
					//_timer.Velocidade = tempoAvancado;
					//nextAno = Convert.ToInt32(_timer.CurrentAno) + 1;
					//EventManager.TriggerEvent ("finalFase","Item - "+CondicaoNome+" é maior ou igual a "+CondicaoValor);
				}
			}
			/*if (proximaFase) {				
				//if (nextAno == Convert.ToInt32 (_timer.CurrentAno)) {
					nextEvent = false;		
					proximaFase = false;
					_mov.isMove = true;
					//_timer.Velocidade = tempoPadrao;
					if (playerStart) {
						_player.transform.position = playerStart.transform.position;
					}
				//} 
			}*/
		}
	}
}
