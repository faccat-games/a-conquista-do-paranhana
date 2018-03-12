using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

	public GameObject _player;

	public GameObject _helpPanel;


	// Use this for initialization
	void Start () {


		
	}

	void Awake(){
		if (!GameObject.FindWithTag ("Player")) {
			GameObject clone;
			clone = Instantiate(_player, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			clone.GetComponent<Movimento> ().exit = -1;

			_helpPanel.SetActive (true);
			Debug.Log ("Não achou");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
