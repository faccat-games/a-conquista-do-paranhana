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
			if (bed) {
				bed.sortingOrder = 3;
			}
		} else {
			if (bed) {
				bed.sortingOrder = -1;
			}
			_home.sortingOrder = 2;
			insideHome.sortingOrder = -1;
		}
	}


}
