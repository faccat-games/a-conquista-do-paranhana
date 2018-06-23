using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pauseMenu;
	private Player _player;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale > 0 ) {
            Time.timeScale = 0;
			pauseMenu.SetActive(true);
            
        }


    }

    public void ExitToMenu() {
        Destroy( GameObject.Find("Musica") );
        SceneManager.LoadScene(1);
    }

    public void ReturnToGame() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }


}
