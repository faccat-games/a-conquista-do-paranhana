using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

	public GameObject _player;

	//public GameObject _helpPanel;


	// Use this for initialization
	void Start () {


		
	}

	void Awake(){
		if (!GameObject.FindWithTag ("Player")) {
			GameObject clone;
			clone = Instantiate(_player, transform.position, Quaternion.identity) as GameObject;
			clone.GetComponent<Movimento> ().exit = -1;


		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
