using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventoHistoricoSimples : MonoBehaviour
{
    public Text AnoTexto;
    public Text Texto;
    public Text TextoWithImage;

    public Image EventImage;
    private float timer;

    [TextArea(3, 10)]
    public string EventoTexto = "";

    public string Year = "";

    private Movimento _mov;
    private Timer _timer;
    private GameObject _player;

    private GameObject EventoHistoricoPanel;

    void Start()
    {
        EventoHistoricoPanel = gameObject.transform.GetChild(0).gameObject;
        //_player = GameObject.FindWithTag("Player");
        //_mov = _player.GetComponent<Movimento>();
        //_timer = _player.GetComponent<Timer>();
        UpdateYear();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FecharPanel()
    {
        //_mov.isMove = true;
        //_timer.isPaused = false;
        EventoHistoricoPanel.SetActive(false);
    }

    void UpdateYear()
    {
        
        //yearEventPanel.SetActive (true);
        //Debug.Log ("Current year: "+year);

        Texture2D texture = Resources.Load("Events/event-" + Year) as Texture2D;

        if (texture)
        {
            Texto.gameObject.SetActive(false);
            TextoWithImage.gameObject.SetActive(true);
            EventImage.gameObject.SetActive(true);
            EventImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        } else {
            Texto.gameObject.SetActive(true);
            TextoWithImage.gameObject.SetActive(false);
            EventImage.gameObject.SetActive(false);
        }

        TextoWithImage.text = Texto.text = EventoTexto;
        EventManager.TriggerEvent("newDiaryEntry", "<b>" + Year + "</b> - " + EventoTexto);

        EventoHistoricoPanel.SetActive(true);
        //_mov.isMove = false;
        //_timer.isPaused = true;

        AnoTexto.text = Year;
    }
}
