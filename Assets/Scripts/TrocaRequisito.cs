using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrocaRequisito : MonoBehaviour {
	private PlayerData _playerData;
	private InteracaoNPC _interacaoNPC;
    private Player _player;

    public string ItemRequerido;
    public int MinQtdItem = 0;
    public bool RemoveItem;

	public string RecursoRequerido;
    public int MinQtdRecurso = 0;
    public bool RemoveRecurso;

	
    public string InsuficienteTexto = "Você ainda não tem o suficiente.";

    //private Inventario _inventario;

	// Use this for initialization
	void Start () {
        //_player = GameObject.FindWithTag("Player").GetComponent<Player>();
		_playerData = GameObject.FindGameObjectWithTag ("Data").GetComponent<PlayerData> (); 
		_interacaoNPC = GetComponent<InteracaoNPC> ();
        //_inventario = _player.GetComponent<Inventario>();
	}

	// Update is called once per frame
	void Update () {
        if (_interacaoNPC != null && _interacaoNPC.InteractingWithPlayer) {
            if (ItemRequerido != "" && RecursoRequerido != "") {
                if (_playerData.IsItem(ItemRequerido) 
                    && _playerData.GetItem(ItemRequerido) >= MinQtdItem 
                    && _playerData.IsResource(RecursoRequerido) 
                    && _playerData.GetResource(RecursoRequerido) >= MinQtdRecurso) {
                    _interacaoNPC.Interagir = true;
                    if (RemoveItem) {
                        _playerData.RemoveItem(ItemRequerido);
                    }
                    if (RemoveRecurso) {
                        _playerData.SetResource(RecursoRequerido, _playerData.GetResource(RecursoRequerido) - MinQtdRecurso);
                    }
                }
            } else {
                if (ItemRequerido != "" && _playerData.IsItem(ItemRequerido)) {
                    if (_playerData.GetItem(ItemRequerido) >= MinQtdItem) {
                        _interacaoNPC.Interagir = true;
                        if (RemoveItem) {
                            _playerData.RemoveItem(ItemRequerido);
                            //_inventario.RemoveItem (ItemRequerido);
                        }
                    } else {
                        //_interacaoNPC.AddDialog(InsuficienteTexto);
                    }
                }
                if (RecursoRequerido != "" && _playerData.IsResource(RecursoRequerido)) {
                    if (_playerData.GetResource(RecursoRequerido) >= MinQtdRecurso) {
                        //_text.text = Convert.ToString(obj_property.GetValue(_data, null));
                        _interacaoNPC.Interagir = true;
                        //_interacaoNPC.giveItem = false;
                        if (RemoveRecurso) {
                            _playerData.SetResource(RecursoRequerido, _playerData.GetResource(RecursoRequerido) - MinQtdRecurso);
                        }
                    } else {
                        //_interacaoNPC.AddDialog(InsuficienteTexto);
                    }
                }
            }
		}
	}
}
