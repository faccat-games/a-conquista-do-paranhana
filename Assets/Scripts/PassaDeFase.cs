using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassaDeFase : MonoBehaviour {

	public Movimento _mov;
	public GameObject _player;
	public GameObject playerStart;   // posicao de saida

	public int scenarioExit;    // qual entrada do cenario

	public string nextScene;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag ("Player");
		_mov= _player.GetComponent<Movimento> ();

		if (_mov.exit==scenarioExit){
			_player.transform.position = playerStart.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log (other.name);
		if (other.gameObject.CompareTag("Player"))
		{
			_mov.exit = scenarioExit;
			SceneManager.LoadScene (nextScene);

		}
	}
}
