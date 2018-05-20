using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CriaPersonagem : MonoBehaviour
{
    //public Button confirmarEscolha;
    //public Text nomeDigitado; 
	//public  Text sobrenomeDigitado;
    public GameObject panelCriacao;
    public InputField nomeInputField;
    public Dropdown sobrenomeDropdown;
    public Button iniciarButton;
	public string NomeCena;

	public PlayerData _data; 
   
    void Start ()
    {
        nomeInputField.ActivateInputField();
    }

    void Update()
    {
        _data.playerSurname = sobrenomeDropdown.options[sobrenomeDropdown.value].text;
        _data.playerName = nomeInputField.text;
        if (_data.playerName != "") {
            iniciarButton.gameObject.SetActive(true);
        } else {
            iniciarButton.gameObject.SetActive(false);
        }
    }

	public void BotaoPersonagem(){
        if (_data.playerName != "") {						
			Destroy (GameObject.Find ("Musicas"));
			SceneManager.LoadScene (NomeCena);
		} else {
			Debug.Log ("entre com um nome e sobrenome");
		}
	}

}