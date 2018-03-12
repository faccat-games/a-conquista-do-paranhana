using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventario : MonoBehaviour {
	public RectTransform content;
	public List <GameObject> itens;
	public int indice1 =-1, indice2 =-1;

	public void adItem(GameObject item){
		itens.Add(item);
		item.GetComponent<item> ().indice = itens.Count-1;
		addItem ();
	}

	public void Trocaitem(int indice){
		if (indice1 == -1) {
			indice1 = indice;
		} else {
			indice2 = indice;
			GameObject aux_ = itens [indice1];
			itens [indice1] = itens [indice2];
			itens [indice2] = aux_;

			itens [indice1].GetComponent<item> ().indice = indice1;
			itens [indice2].GetComponent<item> ().indice = indice2;


			indice1 = -1;
			indice2 = -1;
			addItem ();

		}
	}

	void addItem(){

		while (content.childCount > 0) {

			Transform filho =  content.GetChild (0);
			filho.parent = null;
			Destroy (filho.gameObject);

		}
		for(int i =0; i< itens.Count; i++) {
			GameObject item = Instantiate (itens [i], content.position, Quaternion.identity) as GameObject;
			item.transform.parent = content.transform;
			
		}
	}
	// Use this for initialization
	void Start () {
		addItem ();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
