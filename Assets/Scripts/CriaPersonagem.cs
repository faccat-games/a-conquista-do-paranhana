using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CriaPersonagem : MonoBehaviour
{
    public Button confirmarEscolha;
    public InputField nomeDigitado; 
	public  Text sobrenomeDigitado;
    public GameObject panelCriacao;
	public string NomeCena;


	public PlayerData _data; 
   


    void Start ()
    { 
   
    }
    void Update()
    {

    }

	public void BotaoPersonagem(){

		if (nomeDigitado.text != "" && sobrenomeDigitado.text != "") {
			_data.playerName = nomeDigitado.text;
			_data.playerSurname = sobrenomeDigitado.text;
		
			_data.playerMoney = 20000;

			PlayerPrefs.SetString ("Nome", _data.playerName);
			PlayerPrefs.SetString ("Sobrenome", _data.playerSurname);
			PlayerPrefs.SetFloat ("Dinheiro", _data.playerMoney);
			Destroy (GameObject.Find ("Musicas"));


			SceneManager.LoadScene (NomeCena);
		} else {
			Debug.Log ("entre com um nome e sobrenome");
		}
	}

}