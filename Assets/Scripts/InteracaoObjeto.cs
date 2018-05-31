using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoObjeto : MonoBehaviour {
	//public bool isTake;
	//public SpriteRenderer sr;
    public bool Interagir = false;
    private bool _interactingWithPlayer = false;
    private bool _actionRequired = false;
	void Start () {
		//sr = GetComponent<SpriteRenderer> ();
		//sr.color = new Color (1, 1, 1, 1);
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
            InteractingWithPlayer = true;
		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			//sr.color = new Color (1, 1, 1, 1);
            InteractingWithPlayer = false;
		}
	}

    public bool InteractingWithPlayer
    {
        get { return _interactingWithPlayer; }
        set { _interactingWithPlayer = value; }
    }

    public bool ActionRequired
    {
        get { return _actionRequired; }
        set { _actionRequired = value; }
    }

	void Update(){
        if (Interagir && InteractingWithPlayer && Input.GetKeyDown (KeyCode.Space)) {
            ActionRequired = true;
			//sr.color = new Color (1, 0, 0, 1);
			//Debug.Log ("Item pego");
        } else {
            ActionRequired = false;
        }
	}
}
