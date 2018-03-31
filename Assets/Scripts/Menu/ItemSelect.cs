using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour {

	public int idItem;
	public Inventario _inventario;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ItemSelected(){
		_inventario.activeItem = idItem;
	}
}
