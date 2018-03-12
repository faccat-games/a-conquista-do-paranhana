using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteracaoCasa : MonoBehaviour {

	private bool isHome;
	public SpriteRenderer _home;
	public SpriteRenderer insideHome;
	public SpriteRenderer bed;

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player" && isHome == false) {
		
			isHome = true;
		
		} else { 
			isHome = false;
		}
	
	}


	void FixedUpdate (){

		if (isHome) {


			_home.sortingOrder = -1;
			insideHome.sortingOrder = 1;
			bed.sortingOrder = 3;

		} else {

			_home.sortingOrder = 2;
			insideHome.sortingOrder = -1;
			bed.sortingOrder = -1;
		}
	}


}
