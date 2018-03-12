using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour {

	public GameObject panelInventario;

	public GameObject axeItem;


	public bool isMenuOpen;

	public int activeItem;    // verificar os indices em playerData

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab ) && isMenuOpen ==false){
			Time.timeScale = 0;
			isMenuOpen = true;
		} else 	if(Input.GetKeyDown(KeyCode.Tab ) && isMenuOpen ==true){
					Time.timeScale = 1;
					isMenuOpen = false;
				}
		AbreInventario ();		
	}

	void AbreInventario(){
		if (isMenuOpen) {
			panelInventario.SetActive (true);
		}else panelInventario.SetActive (false);			
	}
}