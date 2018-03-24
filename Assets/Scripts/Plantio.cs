using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Plantio : MonoBehaviour {

	public bool isUsed;


	public Movimento _mov;

	public string thisScene;
	public GameObject _gameobject;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);

	}
	
	// Update is called once per frame
	void Update () {

		thisScene= SceneManager.GetActiveScene().name;
		if (thisScene != "map_06") {
			_gameobject.SetActive (false);
		} else
			_gameobject.SetActive (true);

		
	}

	void OnTriggerStay2D(Collider2D col){

		if (col.tag=="Player") {
			_mov = col.GetComponent<Movimento> ();
			_mov.overPlow = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){

		if (col.tag=="Player") {
			_mov.overPlow = false;
		}
	}
}
