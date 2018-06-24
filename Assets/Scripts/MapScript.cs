using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {

    public GameObject _map;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M) && _map.activeSelf == false)
        {
            _map.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.M) && _map.activeSelf == true)
        {
            _map.SetActive(false);
        }
    }

}
