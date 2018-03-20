using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteracaoCasa : MonoBehaviour {

	private bool isHome;
	public SpriteRenderer _home;
	public SpriteRenderer insideHome;
	public SpriteRenderer bed;
	public float incremento;

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player" && isHome == false) {

			other.gameObject.transform.Translate(0, +0.7f, 0);
			isHome = true;

		} else {
			other.gameObject.transform.Translate(0, -0.5f, 0);
			isHome = false;
		}

	}
	void FixedUpdate (){
		if (isHome) {
			_home.sortingOrder = -1;
			insideHome.sortingOrder = 1;
			if (bed) {
				bed.sortingOrder = 4;
			}
		} else {
			if (bed) {
				bed.sortingOrder = -1;
			}
			_home.sortingOrder = 3;
			insideHome.sortingOrder = -1;
		}
	}



}
