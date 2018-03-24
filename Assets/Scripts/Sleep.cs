using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour {

	public bool toSleep;
	public Timer _newDay;

	//Impedir movimento
	public Movimento _movimento;

	// menu dormir
	public GameObject menuDormir;

	//fade
	public Image _fadeImage;

	// Use this for initialization
	void Start () {
		_newDay = GameObject.FindGameObjectWithTag ("Player").GetComponent<Timer> ();
		_movimento = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movimento> ();
		_fadeImage = GameObject.FindGameObjectWithTag ("SleepPanel").GetComponent<Image> ();


	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player") {
			Debug.Log ("cama");
			toSleep = true;
			_fadeImage = GameObject.Find ("SleepPanel").GetComponent<Image> ();
		}

	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			toSleep = false;
		}
	}

	void FixedUpdate(){

		if (toSleep && Input.GetKeyDown (KeyCode.E)) {

			AbreMenuDormir ();
			}
	}


	public void AbreMenuDormir(){
		menuDormir.SetActive (true);

		_movimento.isMove = false;

	}


	public void ConfirmaDormir(){

		StartCoroutine(Fade());

		menuDormir.SetActive (false);

	}

	public void CancelaDormir(){
		menuDormir.SetActive (false);
		_movimento.isMove = true;

	}


	void fadeIn(){
		_fadeImage.CrossFadeAlpha (4.0f, 2.5f, false);

	}
	void fadeOut(){

		_fadeImage.CrossFadeAlpha (0.0f, 2.5f, false);

	}

	IEnumerator Fade()
	{

		yield return new WaitForSeconds(2);
		fadeOut();
		yield return new WaitForSeconds(2);
		fadeIn();
		_movimento.isMove = true;
	}




}
