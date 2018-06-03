using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diario : MonoBehaviour {

	public Text DiarioText;
	public bool MostrarDiario = false;
	//private Queue<string> content = new Queue<string>();
	private List<string> DiarioContent = new List<string>();
	// Use this for initialization

	private GameObject DiarioPanel;

	void Start () {
		EventManager.StartListening ("newDiaryEntry", UpdateDiario);
		DiarioPanel = gameObject.transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
			MostrarDiario = !MostrarDiario; 
		}
		DiarioPanel.SetActive (MostrarDiario);
	}

	void OnDestroy () {
		EventManager.StopListening ("newDiaryEntry", UpdateDiario);
	}

	void UpdateDiario (string value) {
		//if (yearEventsList.ContainsKey (value)) {
		//	YearEventText.text = yearEventsList [value];
		//} else {
		//	YearEventText.text = "";
		//}
		//YearText.text = value;
		//content.Enqueue(value);

		if (!DiarioContent.Contains (value)) {
			DiarioContent.Add (value);
			DiarioText.text = "";
			foreach (string eventText in DiarioContent) {
				DiarioText.text += eventText;
				DiarioText.text += "\n";
			}
		}
	}
}
