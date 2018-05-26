using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteracaoNPCNoite : MonoBehaviour {

	private bool isNoite = false;
	private bool _isNoite = false;
	private Vector3 _oriScale;
    //private Vector3 _oriPos;
    //private int _oriOrder;
    public bool Desaparecer = true;
    public bool Parar = false;
    //public Vector3 NovaPosicao;
    private SpriteRenderer _sprite;
	// Use this for initialization
	void Start () {
		EventManager.StartListening ("newDayCicle", UpdateBackground);
        _sprite = GetComponent<SpriteRenderer>();
		_oriScale = transform.localScale;
        //_oriPos = transform.position;
        //_oriOrder = (_sprite != null) ? _sprite.sortingOrder : 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateBackground(string value) {
		isNoite = (Boolean.Parse (value)) ? false : true;
		if (isNoite != _isNoite) {
			//background.GetComponent<Image> ().color = new Color (0.0f, 0.0f, 0.0f, (isNoite) ? 0.50f : 0.0f);
			//iconeLua.SetActive (isNoite);
           
            if (Desaparecer) {                
                if (_sprite != null){
                    _sprite.color = new Color(255.0f, 255.0f, 255.0f, (isNoite) ? 0.0f : 1.0f);
                }
                transform.localScale = (isNoite) ? Vector3.zero : _oriScale;
            }

            if (Parar) {
                BasicAnimation basic = GetComponent<BasicAnimation>();
                if (basic != null) {
                    basic.pause = isNoite;
                }
            }

            /*if (!NovaPosicao.Equals(Vector3.zero)) {
                transform.position = (isNoite) ? NovaPosicao : _oriPos;
            }*/

			_isNoite = isNoite;
		}
	}

	void OnDestroy () {
		EventManager.StopListening ("newDayCicle", UpdateBackground);
	}
}
