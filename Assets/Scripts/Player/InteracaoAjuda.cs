using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoAjuda : MonoBehaviour {
	private float timer;
	private bool showDialog = false;
	private Collider2D _other;
	public float TempoDialogo = 1.2f;
	// Use this for initialization
	void Start () {
		//Debug.Log (gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
			showDialog = false;
		}
		if (timer <= 0.0f) {			
			if (showDialog) {
				showDialog = false;
				OpenDialog (_other);
			}
		} else if (showDialog) {
			timer -= Time.deltaTime;
			//showDialog = false;
		}
	}

	void OnTriggerStay2D (Collider2D other) { 	
		
	}
	void OnTriggerEnter2D (Collider2D other) {
		//Destroy(other.gameObject);
		//Debug.Log("enter" + other.name);
		timer = TempoDialogo;
		showDialog = true;
		_other = other;
	}

	void OpenDialog(Collider2D other) {
		Ajuda info = other.GetComponent<Ajuda> ();
		if (info) {			
			if (info.Interagir) {
				string t = "";
				if (info.Descricao.Length != 0 && info.Texto.Length != 0) {
					t = info.Descricao + "\n" + info.Texto;
				} else if (info.Descricao.Length != 0) {
					t = info.Descricao;
				} else if (info.Texto.Length != 0) {
					t = info.Texto;
				}
				EventManager.TriggerEvent ("newPlayerDialog",t);
			} else {
				EventManager.TriggerEvent ("newPlayerDialog",info.Descricao);
			}
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		//Destroy(other.gameObject);
		//Debug.Log("exit" + other.name);
		EventManager.TriggerEvent ("newPlayerDialog","");
		showDialog = false;
	}
}
