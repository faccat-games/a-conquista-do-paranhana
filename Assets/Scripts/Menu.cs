using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

	public string newGame;
	public string loadGame;
	public string options;
	public string exitGame;

	public GameObject newGamePanel;

	// criar metodo do panel 

	public void ConfirmNewGame(){
		SceneManager.LoadScene (newGame);
	}

	public void CancelNewGame(){
		newGamePanel.SetActive (false);
	}

	public void NewGame(){

		if (PlayerPrefs.GetString ("Nome") == "") {
			Debug.Log ("vazio");
			SceneManager.LoadScene (newGame);
		}
		else {
			
			Debug.Log (PlayerPrefs.GetString ("Nome"));
			newGamePanel.SetActive (true);
		}
	}

	public void LoadGame(){

		//SceneManager.LoadScene (loadGame);
		Debug.Log("LoadGamebtn");

	}

	public void Options(){

		//SceneManager.LoadScene (options);
		Debug.Log("Optionbtn");
	}

	public void ExitGame(){

		//SceneManager.LoadScene (exitGame);
		Debug.Log("ExitGamebtn");
		Application.Quit ();
	}
}