using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour {

	public bool toSleep;
	private Timer _timer;
	public string mensagemAcordar = "";

	//Impedir movimento
	private Player _player;

	// menu dormir
	public GameObject menuDormir;

	//fade
	//private Image _fadeImage;
	private SleepPanel _sleepPanel;

	// Use this for initialization
	void Start () {
		_timer = GameObject.FindGameObjectWithTag ("Player").GetComponent<Timer> ();
		//_mov = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movimento> ();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
		_sleepPanel = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<SleepPanel> ();
		//_fadeImage = _sleepPanel.GetComponentInChildren<Image> ();
	}

	// Update is called once per frame
	void Update () {				
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player") {
			//Debug.Log ("cama");
			toSleep = true;
			//_fadeImage = GameObject.Find ("SleepPanel").GetComponent<Image> ();
		}

	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			toSleep = false;
		}
	}

	void FixedUpdate(){
        if (toSleep && !_player.Paused && Input.GetKeyDown (KeyCode.Space)) {
			AbreMenuDormir ();
		}
	}

	public void AbreMenuDormir(){
		EventManager.TriggerEvent ("newPlayerDialog","");
		menuDormir.SetActive (true);
        _player.Paused = true;
	}


	public void ConfirmaDormir(){
		StartCoroutine(Fade());
		menuDormir.SetActive (false);
	}

	public void CancelaDormir(){
		menuDormir.SetActive (false);
        _player.Paused = false;
	}


	void fadeIn(){
		_sleepPanel.SetFadeIn (2.5f);
		//_fadeImage.CrossFadeAlpha (4.0f, 2.5f, false);

	}
	void fadeOut(){
		_sleepPanel.SetFadeOut (2.5f);
		//_fadeImage.CrossFadeAlpha (0.0f, 2.5f, false);
	}

	IEnumerator Fade()
	{
		fadeOut();
		yield return new WaitForSeconds(2);
		fadeIn();
        //yield return new WaitForSeconds(2);
        _player.Paused = false;
		_timer.SetNextDay ();
		EventManager.TriggerEvent ("newPlayerDialog",mensagemAcordar);
	}




}
