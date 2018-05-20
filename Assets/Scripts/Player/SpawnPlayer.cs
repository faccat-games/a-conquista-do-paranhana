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
        CreatePlayer();
    }

    public void CreatePlayer() {
        if (!GameObject.FindWithTag("Player"))
        {
            GameObject clone;
            clone = Instantiate(_player, transform.position, Quaternion.identity) as GameObject;
            clone.GetComponent<Movimento>().exit = -1;
            clone.GetComponent<Movimento>().isMove = false;
            clone.GetComponent<Timer>().isPaused = true;
        }
    }
	
	// Update is called once per frame
	void Update () {		
	}
}
