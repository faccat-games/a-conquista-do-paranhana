using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour {

	public GameObject tronco;

	public bool isCortada = false;


	void Start () {
		tronco = gameObject.transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (isCortada) {
			GetComponent<SpriteRenderer> ().sortingOrder = -1;
		} else {
			GetComponent<SpriteRenderer> ().sortingOrder = 3;
		}
	}
}
