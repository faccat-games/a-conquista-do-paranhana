using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrocaRequisito : MonoBehaviour {
	private PlayerData _playerData;
	private InteracaoNPC _interacaoNPC;
	public string RecursoRequerido;
	public string ItemRequerido;
	public string InsuficienteTexto = "";
	public int MinQtd;
	public bool RemoveItem;

	// Use this for initialization
	void Start () {
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> (); 
		_interacaoNPC = GetComponent<InteracaoNPC> ();

	}

	// Update is called once per frame
	void Update () {
		if (_interacaoNPC != null && _interacaoNPC.isTalk) {
			if (ItemRequerido != null && _playerData.IsItem (ItemRequerido)) {
				_interacaoNPC.isItemGiver = true;
				if (RemoveItem) {
					_playerData.RemoveItem (ItemRequerido);
				}
				//_interacaoNPC.giveItem = false;
			} else if (RecursoRequerido != null && _playerData.IsResource(RecursoRequerido)) {
				
				if (_playerData.GetResource(RecursoRequerido) >= MinQtd) {
					//_text.text = Convert.ToString(obj_property.GetValue(_data, null));
					_interacaoNPC.isItemGiver = true;
					//_interacaoNPC.giveItem = false;
					if (RemoveItem) {
						_playerData.SetResource (RecursoRequerido,_playerData.GetResource(RecursoRequerido) - MinQtd);
					}
				}
			}
		}
	}
}
