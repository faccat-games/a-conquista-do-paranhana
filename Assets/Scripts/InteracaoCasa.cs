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
	public AudioSource _audioporta;

	void Start () {
		_audioporta = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D (Collider2D other){
		//Debug.Log ("enter" + other.name + ' ' + isHome.ToString() + ' ' +timer);
		if (other.gameObject.tag == "Player" && !isHome) {
				other.gameObject.transform.Translate(0, +1.0f, 0);
				isHome = true;
				_home.sortingOrder = -1;
				insideHome.sortingOrder = 1;
				if (bed) {
					bed.sortingOrder = 4;
				}
				_audioporta.Play ();
			} 
	}

	void OnTriggerExit2D (Collider2D other){
		//Debug.Log ("exit ---- " + other.name + ' ' + isHome.ToString());
		if (other.gameObject.tag == "Player" && isHome) {
			other.gameObject.transform.Translate(0, -1.2f, 0);
			isHome = false;
			if (bed) {
				bed.sortingOrder = -1;
			}
			_home.sortingOrder = 3;
			insideHome.sortingOrder = -1;
			_audioporta.Play ();
		}
	}

	void Update (){
	}



}
