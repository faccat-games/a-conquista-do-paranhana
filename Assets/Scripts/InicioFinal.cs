using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InicioFinal : MonoBehaviour {

	public bool isInicio = true;
	private bool _isInicio = false;
	[TextArea(3,10)]
	public string TextoInicio= "";
	[TextArea(3,10)]
	public string TextoFinal = "";
	public int ProximoAno = 0;
	public GameObject HelpPanel; 
	public Text texto;
	//private string _texto; 

	// Use this for initialization

	private Movimento _mov;
	private Timer _timer;
	private GameObject _player;
	private PassaDeFase _passdefase;
	private Vector3 posicaoInicial;

	void Start () {
		//HelpPanel.SetActive (true);
		//HelpPanel.GetComponent<Text> ().text = TextoInicio;
		//isInicio = false;
		_player = GameObject.FindWithTag ("Player");
		_mov = _player.GetComponent<Movimento> ();
		_timer = _player.GetComponent<Timer> ();
		_passdefase = GetComponent<PassaDeFase> ();
		//Debug.Log ("Não achou");			
		//EventManager.StartListening ("passaFase", FinalFase);
		//CreatePanel(TextoInicio);
	}
		
	// Update is called once per frame
	void Update () {
		if (_isInicio != isInicio) {
			if (isInicio) {
				_isInicio = isInicio;			
				CreatePanel (TextoInicio);			
				posicaoInicial = _player.transform.position;
			} else {
				_isInicio = isInicio;
				CreatePanel (TextoFinal);
				_player.transform.position = posicaoInicial;
			}
		}
			
		if (_passdefase.proximaFase) {
			_passdefase.checkCondition = _passdefase.proximaFase = false;
			//GetComponent<PassaDeFase> ().proximaFase = false;
			isInicio = false;
		}


		//if (HelpPanel.activeSelf == true) {
		//	PauseGame (true);
		//}
	}

	public void PauseGame(bool paused = true) {
		_mov.isMove = !paused;
		_timer.isPaused = paused;
	}

	public void CreatePanel (string value) {
		PauseGame (true);
		HelpPanel.SetActive (true);
		texto.text = value;
		//HelpPanel.GetComponent<Text> ().text = value;	
	}

	public void FecharPanel(){		
		PauseGame (false);
		HelpPanel.SetActive(false);
		if (!isInicio) {
			if (ProximoAno != 0) {
				_timer.SetNewYear (ProximoAno);
			}
			isInicio = true;
			_isInicio = false;
			//isInicio = true;
		}
	}
		
}
