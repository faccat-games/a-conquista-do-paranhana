using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearEventScript : MonoBehaviour {
	public Text YearText;
	public Text YearEventText;
	// Use this for initialization
	void Start () {
		//gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Timer");
	}
	void OnEnable ()
	{
		EventManager.StartListening ("newYear", UpdateYear);
		Debug.Log ("Start Listening newYear");
	}

	void OnDisable ()
	{
		EventManager.StopListening ("newYear", UpdateYear);
		Debug.Log ("Stop Listening newYear");

	}
	void UpdateYear (string value)
	{
		Debug.Log ("Current year: "+value);

		YearText.text = value;
	}
}
