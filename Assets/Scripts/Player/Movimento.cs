using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour {

	public int exit;
	public GameObject talkBalloon;
	public GameObject shopPanel;
	//public GameObject painelFade;

	public bool isMove;

	public Animator myAnimator;
	public SpriteRenderer mySprite;
	bool isFlip;

	//public string thisScene;

	public GameObject terraArada;
	private PlayerData _data;

	private GameObject overPlow;
	private GameObject overFarm;

	public int walkSpeed;

	void Start(){
		//DontDestroyOnLoad (this);

		//overFarm = null;

		myAnimator = GetComponent<Animator> ();
		mySprite = GetComponent<SpriteRenderer> ();
		_data = GameObject.Find("PlayerData").GetComponent<PlayerData> ();             

//		Debug.Log (exit);
		//talkBalloon = GameObject.Find ("Balao");
		//shopPanel = GameObject.Find ("Panel");

		//Debug.Log (talkBalloon.GetComponent<Image>().enabled);
		//Debug.Log (shopPanel.GetComponent<Image>().enabled);
		//Debug.Log (painelFade.GetComponent<Image>().enabled);

		isMove = true;
//		if (talkBalloon.GetComponent<Image> ().enabled == false && shopPanel.GetComponent<Image> ().enabled == false && painelFade.GetComponent<Image> ().enabled == false) {
//			isMove = true;
//		} else {
//			isMove = false;
//		}
	}

	void Update () {

		//////

		/*if (!Input.anyKey) {                                        // <--- Resolve animação presa na transição de telas
			myAnimator.SetBool ("walkUp", false);
			myAnimator.SetBool ("walkDown", false);
			myAnimator.SetBool ("walkRight", false);
		}*/
		/*if (Input.GetKeyUp (KeyCode.UpArrow)) { 
			myAnimator.SetBool ("walkUp", false);

		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) { 
			myAnimator.SetBool ("walkDown", false);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) { 
			myAnimator.SetBool ("walkRight", false);
		}
*/


		if (isMove) {
			Move ();
		}
	}

	void Move(){
		if (Input.GetKey (KeyCode.DownArrow) && walkSpeed != 0) {
			transform.Translate (Vector3.down * Time.deltaTime * walkSpeed);
			myAnimator.SetBool ("walkDown", true);
		}

		if (Input.GetKey (KeyCode.UpArrow) && walkSpeed != 0) {
			transform.Translate (Vector3.up * Time.deltaTime * walkSpeed);
			myAnimator.SetBool ("walkUp", true);
		}

		if (Input.GetKey (KeyCode.LeftArrow ) && walkSpeed != 0) {
			if (!isFlip) {
				mySprite.flipX = true;
				isFlip = true;
			}
			transform.Translate (Vector3.left * Time.deltaTime * walkSpeed);
			myAnimator.SetBool ("walkRight", true);
		}

		if (Input.GetKey (KeyCode.RightArrow) && walkSpeed != 0) {
			if (isFlip) {
				mySprite.flipX = false;
				isFlip = false;
			}
			transform.Translate (Vector3.right * Time.deltaTime * walkSpeed);
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
			Arar ();

		}

		if (Input.GetKeyDown (KeyCode.E)) {
			PlantarSemente ();
		}
			
	}

	void Arar(){
		if (overFarm != null && _data.IsItem("Enxada")){	
			//Debug.Log ("PLANTOU");
			var _terraArada = Instantiate(terraArada, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), Quaternion.identity);
			_terraArada.transform.SetParent (overFarm.transform);
			overFarm.GetComponent<Ajuda> ().Interagir = false;
		}
	}

	void PlantarSemente(){
		//Debug.Log ("PlantarSemente" + _data.GetResource("cornSeeds"));
		if (overPlow != null  && _data.GetResource("cornSeeds")>0) {
			var _overPlow = overPlow.GetComponent<Plantio> ();
			if (!_overPlow.isUsed) {
				_data.SetResource("cornSeeds",_data.GetResource("cornSeeds") - 1);
				_overPlow.PlantarMilho ();
			}
		}
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "AreaPlantio") {
			overFarm = col.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.name == "AreaPlantio") {
			overFarm = null;
		}
		if (col.name == "Plantio") {
			overPlow = null;
		}
	}
	void OnTriggerStay2D(Collider2D col){

		if (col.name=="Plantio") {
			//_mov = col.GetComponent<Movimento> ();
			overPlow = col.gameObject;
		}
	}

}
		
