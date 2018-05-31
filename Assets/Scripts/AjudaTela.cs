using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjudaTela : MonoBehaviour {

    // Use this for initialization

    private GameObject HelpCanvas;

	private Player _player;
    private string _playername;

	public Text texto;
    public Text Titulo;
    public Image Imagem;  
    public Text TextoWithImage;

	void Start () {
        HelpCanvas = gameObject.transform.GetChild(0).gameObject;
        _player = GameObject.FindWithTag ("Player").GetComponent<Player>();
		
        PlayerData _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        _playername = _playerData.playerName + " " + _playerData.playerSurname;

        EventManager.StartListening ("mostrarAjudaTela", CreatePanel);
	}

	// Update is called once per frame
	void Update () {

	}


	public void CreatePanel (string value) {
        value = value.Replace("%player%", _playername);
        string[] tokens = value.Split('|');

        TextoWithImage.gameObject.SetActive(false);
        Imagem.gameObject.SetActive(false);
        Titulo.gameObject.SetActive(false);
        texto.gameObject.SetActive(true);

        if (tokens.Length >= 3) {
            Titulo.gameObject.SetActive(true);
            Titulo.text = tokens[0];
            texto.text = tokens[2];
            Texture2D texture = Resources.Load("Ajuda/ajuda-" + tokens[1]) as Texture2D;
            if (texture != null) {
                Imagem.gameObject.SetActive(true);
                Imagem.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                value = tokens[2];
                TextoWithImage.text = value;
                TextoWithImage.gameObject.SetActive(true);
                texto.gameObject.SetActive(false);
            }
        } else {
            texto.text = value;
        }

        _player.Paused = true;
        HelpCanvas.SetActive (true);
		
		//HelpPanel.GetComponent<Text> ().text = value;
	}

	public void FecharPanel(){
		_player.Paused = false;
        HelpCanvas.SetActive(false);
		/*if (!isInicio) {
			if (ProximoAno != 0) {
				_timer.SetNewYear (ProximoAno);
			}
			isInicio = true;
			_isInicio = false;
			//isInicio = true;
		}*/
	}

	void OnDestroy () {
        EventManager.StopListening ("mostrarAjudaTela", CreatePanel);
	}
}
