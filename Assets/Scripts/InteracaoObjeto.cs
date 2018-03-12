using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoObjeto : MonoBehaviour {
	public bool isTake;
	public SpriteRenderer sr;
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		sr.color = new Color (1, 1, 1, 1);
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isTake = true;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Inativo");
			sr.color = new Color (1, 1, 1, 1);
			isTake = false;
		}
	}

	void FixedUpdate(){
		if (isTake && Input.GetKeyDown (KeyCode.E)) {
			sr.color = new Color (1, 0, 0, 1);
			Debug.Log ("Item pego");
		}
	}
}
