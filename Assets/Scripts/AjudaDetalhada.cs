using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjudaDetalhada : MonoBehaviour {
    private InteracaoObjeto _interacaoObjeto;
    public string TituloAjuda;
    public string NomeImagemAjuda;
    [TextArea]
    public string TextoAjuda;
	// Use this for initialization
	void Start () {
        _interacaoObjeto = GetComponent<InteracaoObjeto>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_interacaoObjeto != null && _interacaoObjeto.InteractingWithPlayer && _interacaoObjeto.Interagir && _interacaoObjeto.ActionRequired)
        {
            EventManager.TriggerEvent("mostrarAjudaTela", TituloAjuda +"|"+ NomeImagemAjuda +"|"+TextoAjuda);
        }
	}
}
