using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearEvent : MonoBehaviour {
	public Text YearText;
	public Text YearEventText;
	// Use this for initialization
	Dictionary<string,string> yearEventsList = new Dictionary<string, string> ();

	void Start () {
		gameObject.transform.GetChild (0).gameObject.SetActive (true);

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
		//yearEventPanel.SetActive (true);

//		Debug.Log ("Current year: "+value);
		if (yearEventsList.ContainsKey (value)) {
			YearEventText.text = yearEventsList [value];
			EventManager.TriggerEvent ("NewDiaryEntry", "<b>"+value+"</b> - " + yearEventsList [value]);
		} else {
			YearEventText.text = "";
		}
		YearText.text = value;

	}
}
