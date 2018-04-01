using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDialogPosition : MonoBehaviour {
	public Vector3 pos;

	public GameObject obj;
	//private Camera camera;
	private Vector3 dialogPos;
	private RectTransform rt;
	//private RectTransform canvasRT;
	private Vector3 dialogScreenPos;
	// Use this for initialization
	void Start () {
		//Vector2 screenPoint = Camera.main.WorldToScreenPoint(targetPosition);

		dialogPos = obj.transform.position;

		rt = GetComponent<RectTransform>();
		//canvasRT = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
		dialogScreenPos = Camera.main.WorldToViewportPoint(obj.transform.TransformPoint(dialogPos));
		rt.anchorMax = dialogScreenPos;
		rt.anchorMin = dialogScreenPos;


	}
	
	// Update is called once per frame
	void Update () {
		dialogScreenPos = Camera.main.WorldToViewportPoint(obj.transform.TransformPoint(dialogPos));
		rt.anchorMax = dialogScreenPos;
		rt.anchorMin = dialogScreenPos;
	}
}
