using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour {
	public int id, indice;
	public string Nome;
	public Texture2D Imagem;
	public GameObject Objeto;

	public int Qnt_max, Qnt_atual;
	public bool Consumivel;

	void NomeItem(){
		transform.GetChild(0).GetComponent<Text>().text = Nome;
	}

	void QntItem(){
		transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "x"+Qnt_atual;
	}

	void TrocaItem(){
		controller._inventarioController.Trocaitem (indice);
	}
	// Use this for initialization
	void Start () {
		Button aux_ = GetComponent<Button> ();
		aux_.onClick.AddListener (TrocaItem);

		NomeItem ();
		QntItem (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
