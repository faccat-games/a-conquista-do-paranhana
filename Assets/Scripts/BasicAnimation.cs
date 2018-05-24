using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimation : MonoBehaviour {

    public Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;
    private Sprite _idle;
    public float AnimationInterval = 0.5f;
    private float _InstantiationTimer = 0;
    private int _currentIndex = 0;
    public float speed = 0.5f;
    public string startPosition = "right";
    public float LoopInterval = 0;
    private float _LoopInterval = 0;
    private string _currentDirection;
    public bool pause = false;
	// Use this for initialization
	void Start () {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //InvokeRepeating ("ChangeSprite", 0, AnimationInterval);
        _idle = _spriteRenderer.sprite;
        _currentDirection = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
        _InstantiationTimer -= Time.deltaTime;
        _LoopInterval -= Time.deltaTime;

        Vector3 t = Vector3.zero;

        if (LoopInterval > 0 && _LoopInterval <= 0) {
            _currentDirection = (_currentDirection == "right") ? "left" : "right";
            _LoopInterval = LoopInterval;
        }
        switch (_currentDirection) {
            case "right": 
                t = transform.right;
                break;
            case "left":
                t = -transform.right;
                break;
            case "up":
                t = transform.up;
                break;
            case "down":
                t = -transform.up;
                break;
        }
        if (pause) {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        } else {
            GetComponent<Rigidbody2D>().velocity = t * speed;
        }
        if (_InstantiationTimer <= 0)
        {
            //Instantiate(prefab, spawn.position, Quaternion.identity);
            ChangeSprite();
            _InstantiationTimer = AnimationInterval;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //if (coll.gameObject.tag == "Enemy")
        //    coll.gameObject.SendMessage("ApplyDamage", 10);
        _currentDirection = (_currentDirection == "right") ? "left" : "right";
    }

    void ChangeSprite() {


        if (_currentIndex == sprites.Length) {
            _currentIndex = 0;
        }
        _spriteRenderer.sprite = (pause) ? _idle : sprites[_currentIndex];
        _spriteRenderer.flipX = !(_currentDirection == "right");
        _currentIndex++;
    }
}
