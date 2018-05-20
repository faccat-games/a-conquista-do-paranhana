using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjudaTela : MonoBehaviour {

    // Use this for initialization

    private GameObject HelpCanvas;

	private Player _player;
    private string _playername;

	public Text texto;
	void Start () {
        HelpCanvas = gameObject.transform.GetChild(0).gameObject;
        _player = GameObject.FindWithTag ("Player").GetComponent<Player>();
		
        PlayerData _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        _playername = _playerData.playerName + " " + _playerData.playerSurname;

        EventManager.StartListening ("mostrarAjudaTela", CreatePanel);
	}

	// Update is called once per frame
	void Update () {

	}


	public void CreatePanel (string value) {
        value = value.Replace("%player%", _playername);
        _player.Paused = true;
        HelpCanvas.SetActive (true);
		texto.text = value;
		//HelpPanel.GetComponent<Text> ().text = value;
	}

	public void FecharPanel(){
		_player.Paused = false;
        HelpCanvas.SetActive(false);
		/*if (!isInicio) {
			if (ProximoAno != 0) {
				_timer.SetNewYear (ProximoAno);
			}
			isInicio = true;
			_isInicio = false;
			//isInicio = true;
		}*/
	}

	void OnDestroy () {
        EventManager.StopListening ("mostrarAjudaTela", CreatePanel);
	}
}
