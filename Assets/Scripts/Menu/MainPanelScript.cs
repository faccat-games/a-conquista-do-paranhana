using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelScript : MonoBehaviour {
	public GameObject background;
	private RectTransform backgroundRectTransform;
	public float vel = 1.00f;
	public float limit = -300f; //-388.5
	// Use this for initialization
	void Start () {
		backgroundRectTransform = background.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		float posY = backgroundRectTransform.localPosition.y + (vel * Time.deltaTime);	
		if (posY <= limit) {			
			backgroundRectTransform.localPosition = new Vector3(
				backgroundRectTransform.localPosition.x, 
				posY, 
				backgroundRectTransform.localPosition.z);
		}
	}
}
