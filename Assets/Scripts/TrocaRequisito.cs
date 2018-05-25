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
	public int MinQtdItem = 0;
    public int MinQtdRecurso = 0;
	public bool RemoveItem;
    public bool RemoveRecurso;
    //private Inventario _inventario;

	// Use this for initialization
	void Start () {
        //Player _player = GameObject.FindWithTag("Player").GetComponent<Player>();
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> (); 
		_interacaoNPC = GetComponent<InteracaoNPC> ();
        //_inventario = _player.GetComponent<Inventario>();
	}

	// Update is called once per frame
	void Update () {
		if (_interacaoNPC != null && _interacaoNPC.isTalk) {
            if (ItemRequerido != null && _playerData.IsItem (ItemRequerido) && _playerData.GetItem(ItemRequerido) >= MinQtdItem) {
				_interacaoNPC.isItemGiver = true;
				if (RemoveItem) {
					_playerData.RemoveItem (ItemRequerido);
                    //_inventario.RemoveItem (ItemRequerido);
				}
				//_interacaoNPC.giveItem = false;
			} 
            if (RecursoRequerido != null && _playerData.IsResource(RecursoRequerido)) {
				
                if (_playerData.GetResource(RecursoRequerido) >= MinQtdRecurso) {
					//_text.text = Convert.ToString(obj_property.GetValue(_data, null));
					_interacaoNPC.isItemGiver = true;
					//_interacaoNPC.giveItem = false;
                    if (RemoveRecurso) {
						_playerData.SetResource (RecursoRequerido,_playerData.GetResource(RecursoRequerido) - MinQtdRecurso);
					}
				}
			}
		}
	}
}
