using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoAreaPlantioCorvos : MonoBehaviour {

    private Component[] _corvos;
    private PlayerData _playerData;
    public int CriaCorvoCadaMadeira = 10;
	// Use this for initialization
	void Start () {
        _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData> ();
        _corvos = GetComponentsInChildren(typeof(Transform), true);
	}
	
	// Update is called once per frame
	void Update () {
        int cindex = ((1 + _playerData.Madeira - 1) / CriaCorvoCadaMadeira)+1;
        if (cindex < _corvos.Length) {            
            _corvos[cindex].gameObject.SetActive(true);
        }
	}
}
