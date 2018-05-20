using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventoHistorico : MonoBehaviour {
	public Text AnoTexto;
	public Text Texto;
	public Text TextoWithImage;
	public Image EventImage;
	//public float YearEventDisplayTime = 5.0f;
	public bool MostraPainel = false;
	private float timer;
	private DateTime currentDateTime;
	// Use this for initialization
	Dictionary<string,string> yearEventsList = new Dictionary<string, string> ();

	private Movimento _mov;
	private Timer _timer;
	private GameObject _player;

	private string currentYear;
	private GameObject EventoHistoricoPanel;

	void Start () {
		EventoHistoricoPanel = gameObject.transform.GetChild (0).gameObject;
		_player = GameObject.FindWithTag ("Player");
		_mov = _player.GetComponent<Movimento> ();
		_timer = _player.GetComponent<Timer> ();
		//timer = YearEventDisplayTime;
		//gameObject.SetActive(true);
		yearEventsList.Add("1846","A sociedade Eggers & Monteiro comprou a fazenda do Mundo Novo, e no mesmo ano criaram o loteamento da Santa Maria do Mundo Novo.");
		//yearEventsList.Add("1846","1847 - construção da Casa de Pedra");
		yearEventsList.Add("1847","25 de novembro - criação da Capela de Santa Christina do Pinhal");
		yearEventsList.Add("1848","Parte da Fazenda do Mundo Novo pertence ao município de Triunfo e outra a Freguesia de Nossa Senhora dos Anjos.");
		yearEventsList.Add("1850","Presença periódica dos primeiros pastores. Por isso foi eleito um pastor entre os colonos (pastor colono) – 400 alemães");
		yearEventsList.Add("1851","Elevação a categoria de Freguesia para Santa Christina do Pinhal, pertencente ao município de Porto Alegre");
		//yearEventsList.Add("1851","Concluída a demarcação de terras da Santa Maria do Mundo Novo (até Três Coroas) para o loteamento de Monteiro.");
		//yearEventsList.Add("1851","1852 – Guerra contra Oribe e Rosas. Soldados convocados entre os colonos para defesa da Pátria.");
		yearEventsList.Add("1852","Sequestro da Família Watenpuhl");
		yearEventsList.Add("1854","Segundo censo");
		yearEventsList.Add("1857","Elevação de Santa Christina de Pinhal a categoria de Freguesia pertencente ao município de Porto Alegre.");
		yearEventsList.Add("1862","Fundação da comunidade Evangélica de Igrejinha, término da construção da Igreja");
		yearEventsList.Add("1864","Santa Christina é reintegrada ao município de São Leopoldo.");
		yearEventsList.Add("1865","1870 - Guerra do Paraguai. Convocação de soldados para o serviço militar e incorporação ao Exército e Marinha Brasileiras.");
		yearEventsList.Add("1868","Até 1874 - Movimento Mucker no Ferrabraz, na Fazenda Padre Eterno, 5º distrito de São Leopoldo.");
		yearEventsList.Add("1870","Guilherme Sauer funda um curtume e estabelece a fabricação de artigos de couro");
		yearEventsList.Add("1874","Inauguração da Igreja da Paz de Taquara – Epidemia de Varíola");
		yearEventsList.Add("1880","Lei nº 1251 de 14 de julho de 1880 eleva Santa Christina do Pinhal a categoria de vila. Emancipação de Santa Christina do Pinhal.");
		yearEventsList.Add("1882","Elevação a categoria de Freguesia para o distrito de Taquara do Mundo Novo em Santa Christina do Pinhal pela Lei nº 1382 de 27 de maio de 1882.");
		yearEventsList.Add("1886","Elevação a categoria de vila a freguesia de Taquara do Mundo Novo");
		yearEventsList.Add("1887","Fundação da Sociedade União de Cantores de Igrejinha");
		yearEventsList.Add("1892","Extinção dos municípios de São Francisco de Paula de Cima da Serra e Santa Christina do Pinhal e anexando-os ao de Taquara do Mundo Novo.");
		//yearEventsList.Add("1892","09 de julho, Falecimento de Tristão José Monteiro, em sua casa conhecida como “Casa de Zinco”");
		//yearEventsList.Add("1892","1895 - Revolução Federalista");
		yearEventsList.Add("1895","Cerco federalista a casa de Johannes Petry.");
		yearEventsList.Add("1900","Inauguração da Torre da Igreja.");
		yearEventsList.Add("1908","Elevação da vila de Taquara à categoria de Cidade em 18 de dezembro de 1908 através do decreto nº 1404.");

	}

	// Update is called once per frame
	void Update () {
		//EventoHistoricoPanel.SetActive (MostraPainel);
		//if (MostraPainel && _player.GetComponent<Movimento>().isMove) {
		//	_mov.isMove = false;
		//	_timer.isPaused = true;
		//}
	}

	void OnEnable ()
	{
		EventManager.StartListening ("timeUpdate", UpdateYear);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("timeUpdate", UpdateYear);
	}

	public void FecharPanel(){
        if (_mov != null) {
            _mov.isMove = true;
        }
		_timer.isPaused = false;
		MostraPainel = false;
		EventoHistoricoPanel.SetActive (MostraPainel);
	}

	void UpdateYear (string value)
	{

		currentDateTime = DateTime.Parse(value);
		string year = currentDateTime.Year.ToString ();

		//yearEventPanel.SetActive (true);
		//Debug.Log ("Current year: "+year);


		if (currentYear != year) {

			Texture2D texture = Resources.Load("Events/event-"+year) as Texture2D;

			if (yearEventsList.ContainsKey (year)) {
				if (texture) {
					Texto.gameObject.SetActive (false);
					TextoWithImage.gameObject.SetActive (true);
					EventImage.gameObject.SetActive (true);
					EventImage.sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.5f, 0.5f));
				} else {
					Texto.gameObject.SetActive (true);
					TextoWithImage.gameObject.SetActive (false);
					EventImage.gameObject.SetActive (false);
				}
				TextoWithImage.text = Texto.text = yearEventsList [year];
				EventManager.TriggerEvent ("newDiaryEntry", "<b>"+year+"</b> - " + yearEventsList [year]);
			} else {
				Texto.gameObject.SetActive (true);
				TextoWithImage.gameObject.SetActive (false);
				EventImage.gameObject.SetActive (false);
				Texto.text = "Ano Novo";
			}		
			MostraPainel = true;
			EventoHistoricoPanel.SetActive (MostraPainel);
			_mov.isMove = false;
			_timer.isPaused = true;
		}

		AnoTexto.text = currentYear = year;
	}
}
