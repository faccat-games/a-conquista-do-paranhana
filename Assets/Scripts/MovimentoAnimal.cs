using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoAnimal : MonoBehaviour {

	public Animator _anim;
	public float fMovMax;
	public float fMovMin;
	public float fTeste;
	public float fSpeed;
	public bool turnRight;
	public SpriteRenderer mySprite;

	void Start () {
		fMovMax = this.transform.position.x + 1.0f;
		fMovMin = this.transform.position.x - 1.0f;
		mySprite = GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate () {
		if (turnRight==true) {
			transform.Translate (+fSpeed,0,0);
			if (this.transform.position.x>=fMovMax){
				turnRight = false;
				mySprite.flipX = true;
			}
		} else {
			transform.Translate (-fSpeed,0,0);
			if (this.transform.position.x<=fMovMin){
				turnRight = true;
				mySprite.flipX = false;
			}
		}
	}
}
