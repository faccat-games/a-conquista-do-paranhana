using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerNewYear : MonoBehaviour {
	private float nextActionTime = 0.0f;
	public float updateInterval = 5.0f;
	public int initialYear = 1800;
	private int currentYear;
	// Use this for initialization
	void Start () {
		currentYear = initialYear;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextActionTime ) {
			nextActionTime += updateInterval;
			currentYear += 1;
			EventManager.TriggerEvent ("newYear",currentYear.ToString());
			Debug.Log ("newYear: " + currentYear);
		}
		//if (Input.GetKeyDown ("q"))
		//{
		//	
		//}
		//EventManager.TriggerEvent ("test");
	}
}
