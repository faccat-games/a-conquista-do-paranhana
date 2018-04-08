using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sleep_OLD : MonoBehaviour {

	/*public bool toSleep;
	public Timer _newDay;

	//Impedir movimento
	public bool podemover;
	public Movimento _movimento;

	//Heal
	public Image CurrentHealth;
	public Text RatioText;

	private float heatlh = 100;


	//fade
	public Image _fade;
	public bool fadein;
	private IEnumerator coroutine;


	// menu dormir
	public GameObject menuDormir;





	//starta setando o alpha em 0 
	void Start (){

		_newDay = GameObject.FindGameObjectWithTag ("Player").GetComponent<Timer> ();
		_fade = GameObject.Find ("PanelSleep").GetComponent<Image> ();
		_movimento = GameObject.FindGameObjectWithTag ("Player").GetComponent<Movimento> ();
		podemover = true;

		toSleep = false;
		_fade.canvasRenderer.SetAlpha(0.0f);
		fadein = true;
		_fade.GetComponent <Image> ().enabled = false;




	}
	//termina o turno e atualiza a barra de vida
	void FixedUpdate(){

		if (toSleep && Input.GetKeyDown (KeyCode.E)) {

			AbreMenuDormir ();

		}
		if (podemover == false) {
			_movimento.walkSpeed = 0;
		} else {
			_movimento.walkSpeed = 5;
		}

	}


	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player") {
			Debug.Log ("cama");
			toSleep = true;
		}

	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			toSleep = false;
		}
	}

	public void EndTurn(){
		_newDay.dia++;
		_newDay.horas = 5.00f;
		_newDay.minutos = 0f;
		_newDay.segundos = 0f;
	}

	//Heal
	private void UpdateHealthbar(){
		float ratio = heatlh; 
		//CurrentHealth.rectTransform.localScale = new Vector3 (ratio, 1, 1);
	
//		RatioText.text = (  ratio ).ToString () + '%';
		Debug.Log ("curou! " + ratio);
	}
	//enumerador
	private IEnumerator waitForSeconds(float waitTime)
	{
		while (fadein == true)
		{
			fadeIn ();
			yield return new WaitForSeconds(waitTime);

			fadeOut ();
			yield return new WaitForSeconds (waitTime);
			_fade.GetComponent <Image> ().enabled = false;
		}

	}
	//fade 
	void fadeIn(){
		_fade.CrossFadeAlpha (4.0f, 2.5f, false);	
		_fade.GetComponent <Image> ().enabled = true;
		Debug.Log ("deu");
	}
	void fadeOut(){		
		_fade.CrossFadeAlpha (0.0f, 2.5f, false);

		podemover = true;

		Debug.Log ("nao deu");
		fadein = false;
	}



	public void AbreMenuDormir(){
		menuDormir.SetActive (true);

		podemover = false;

	}


	public void ConfirmaDormir(){


		EndTurn ();
		coroutine = waitForSeconds(1.5f);
		StartCoroutine(coroutine);
		UpdateHealthbar ();
		fadein = true;
		menuDormir.SetActive (false);

	}

	public void CancelaDormir(){
		menuDormir.SetActive (false);
	}
*/


}









