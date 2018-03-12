using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour {

	public int exit;
	public GameObject talkBalloon;
	public GameObject shopPanel;
	public GameObject painelFade;

	public bool isMove;

	public Animator myAnimator;
	public SpriteRenderer mySprite;
	bool isFlip;

	public string thisScene;

	public GameObject terraArada;
	public PlayerData _data;

	public bool overPlow;

	void Start(){
		DontDestroyOnLoad (this);


		myAnimator = GetComponent<Animator> ();
		mySprite = GetComponent<SpriteRenderer> ();
		_data = GameObject.Find("PlayerData").GetComponent<PlayerData> ();

//		Debug.Log (exit);
		talkBalloon = GameObject.Find ("Balao");
		shopPanel = GameObject.Find ("Panel");

		Debug.Log (talkBalloon.GetComponent<Image>().enabled);
		Debug.Log (shopPanel.GetComponent<Image>().enabled);
		Debug.Log (painelFade.GetComponent<Image>().enabled);

		if (talkBalloon.GetComponent<Image> ().enabled == false && shopPanel.GetComponent<Image> ().enabled == false && painelFade.GetComponent<Image> ().enabled == false) {
			isMove = true;
		} else {
			isMove = false;
		}
	}

	void FixedUpdate () {

		//////

		if (!Input.anyKey) {                                        // <--- Resolve animação presa na transição de telas
			myAnimator.SetBool ("walkUp", false);
			myAnimator.SetBool ("walkDown", false);
			myAnimator.SetBool ("walkRight", false);
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) { 
			myAnimator.SetBool ("walkUp", false);

		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) { 
			myAnimator.SetBool ("walkDown", false);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) { 
			myAnimator.SetBool ("walkRight", false);
		}



		if (isMove) {
			Move ();
		}
	}

	void Move(){
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (0, -.1f, 0);
			myAnimator.SetBool ("walkDown", true);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (0, .1f, 0);
			myAnimator.SetBool ("walkUp", true);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (!isFlip) {
				mySprite.flipX = true;
				isFlip = true;
			}
			transform.Translate (-.1f, 0, 0);
			myAnimator.SetBool ("walkRight", true);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			if (isFlip) {
				mySprite.flipX = false;
				isFlip = false;
			}
			transform.Translate (.1f, 0, 0);
			myAnimator.SetBool ("walkRight", true);
		}

		//////
		if (Input.GetKeyUp (KeyCode.UpArrow)) { 
			myAnimator.SetBool ("walkUp", false);

		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) { 
			myAnimator.SetBool ("walkDown", false);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) { 
			myAnimator.SetBool ("walkRight", false);
		}

		if(Input.GetKeyDown(KeyCode.W)){
			thisScene= SceneManager.GetActiveScene().name;

			if (thisScene == "map_06" && _data.hasHoe == true) {	
				Arar ();
			} else
				Debug.Log ("sem arado");
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			PlantarSemente ();
		}

			
	}

	void Arar(){
		
		if(thisScene == "map_06" && _data.hasHoe==true && overPlow==false  ){	 //map_06
		
			Instantiate(terraArada, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), Quaternion.identity);


		}
	}

	void PlantarSemente(){
		
		Debug.Log (_data.itemHand);
		if (overPlow == true  && _data.itemHand>0 && _data.cornSeeds>0) {
				_data.cornSeeds -= 1;
		}
	}


}
		
