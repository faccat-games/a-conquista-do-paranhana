using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaEstadoObjeto : MonoBehaviour {

    public GameObject EstadoInicial;
    public GameObject EstadoFinal;

    private PlayerData _playerData;
    private InteracaoObjeto _interacaoObjeto;
    private Player _player;
    public string ItemRequerido;
    public int MinQtdItem = 0;
    public bool RemoveItem;  

    public string RecursoRequerido;
    public int MinQtdRecurso = 0;
    public bool RemoveRecurso;

    public bool MoverPlayerFora = false;
    public string TextoPlayer;
	// Use this for initialization
	void Start () {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        _interacaoObjeto = GetComponent<InteracaoObjeto>();
	}
	
    void MovePlayerAway() {
        if (MoverPlayerFora)
        {
            _player.transform.position = EstadoFinal.transform.position;
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            _player.gameObject.transform.Translate(0, -rend.bounds.size.y, 0);
        }
    }
	
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        EventManager.TriggerEvent("newPlayerDialog", TextoPlayer);       
    }

	void Update () {
        
        if (_interacaoObjeto != null && _interacaoObjeto.InteractingWithPlayer && _interacaoObjeto.Interagir && _interacaoObjeto.ActionRequired)
        {
            if (ItemRequerido != "" && RecursoRequerido != "")
            {
                if (_playerData.IsItem(ItemRequerido)
                    && _playerData.GetItem(ItemRequerido) >= MinQtdItem
                    && _playerData.IsResource(RecursoRequerido)
                    && _playerData.GetResource(RecursoRequerido) >= MinQtdRecurso)
                {
                    _interacaoObjeto.Interagir = false;
                    MovePlayerAway();
                    if (RemoveItem)
                    {
                        _playerData.RemoveItem(ItemRequerido);
                    }
                    if (RemoveRecurso)
                    {
                        _playerData.SetResource(RecursoRequerido, _playerData.GetResource(RecursoRequerido) - MinQtdRecurso);
                    }
                    EstadoInicial.SetActive(false);
                    EstadoFinal.SetActive(true);
                    StartCoroutine(ExecuteAfterTime(1));

                }
            }
            else
            {
                if (ItemRequerido != "" && _playerData.IsItem(ItemRequerido))
                {
                    if (_playerData.GetItem(ItemRequerido) >= MinQtdItem)
                    {
                        _interacaoObjeto.Interagir = false;
                        MovePlayerAway(); 
                        if (RemoveItem)
                        {
                            _playerData.RemoveItem(ItemRequerido);
                        }
                        EstadoInicial.SetActive(false);
                        EstadoFinal.SetActive(true);                                 
                        StartCoroutine(ExecuteAfterTime(1));
                         
                    }

                }
                if (RecursoRequerido != "" && _playerData.IsResource(RecursoRequerido))
                {
                    if (_playerData.GetResource(RecursoRequerido) >= MinQtdRecurso)
                    {                        
                        _interacaoObjeto.Interagir = false;
                        MovePlayerAway();
                        if (RemoveRecurso)
                        {
                            _playerData.SetResource(RecursoRequerido, _playerData.GetResource(RecursoRequerido) - MinQtdRecurso);
                        }
                        EstadoInicial.SetActive(false);
                        EstadoFinal.SetActive(true);
                        StartCoroutine(ExecuteAfterTime(1));

                    }
                }
            }
        }
	}
}
