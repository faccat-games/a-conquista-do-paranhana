using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private bool _paused = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool Paused
    {
        get { return _paused; }
        set { 
            Movimento _mov = GetComponent<Movimento>();
            Timer _timer = GetComponent<Timer>();
            _mov.isMove = !value;
            _timer.isPaused = value;
        }
    }

}
