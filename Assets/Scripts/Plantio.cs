using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantio : MonoBehaviour {

	public bool isUsed;


	public Movimento _mov;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
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
