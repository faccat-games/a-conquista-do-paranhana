using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoAjuda : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		//Destroy(other.gameObject);
		Debug.Log("enter" + other.name);
		EventManager.TriggerEvent ("newPlayerDialog","Eu sou "+other.name);
	}

	void OnTriggerExit2D (Collider2D other) {
		//Destroy(other.gameObject);
		Debug.Log("exit" + other.name);
		//EventManager.TriggerEvent ("newPlayerDialog","");
		EventManager.TriggerEvent ("newPlayerDialog","");
	}
}
