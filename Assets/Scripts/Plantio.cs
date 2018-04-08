using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Plantio : MonoBehaviour {

	public bool isUsed;
	public GameObject Milho;

	//private Movimento _mov;

	//public string thisScene;
	//private GameObject _gameobject;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (this);

		//if(_gameobject.GetComponent<SpriteRenderer>().sortingOrder<2){
	//		_gameobject.GetComponent<SpriteRenderer> ().sortingOrder = 2;	
	//	}

	}

	// Update is called once per frame
	void Update () {

	}

	public void PlantarMilho() {
		if (!isUsed) {
			var _milho = Instantiate (Milho, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			_milho.transform.SetParent (transform);
			isUsed = true;
		}
	}

	/*void OnTriggerStay2D(Collider2D col){

		if (col.tag=="Player") {
			_mov = col.GetComponent<Movimento> ();
			_mov.overPlow = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){

		if (col.tag=="Player") {
			_mov.overPlow = false;
		}
	}*/
}
