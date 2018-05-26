using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioCanvas : MonoBehaviour {

    private GridLayoutGroup _grid;
    private PlayerData _playerData;

	// Use this for initialization
	void Start () {
        _grid = GetComponentInChildren(typeof(GridLayoutGroup), true) as GridLayoutGroup;
        _playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDisable() {
        if (_grid != null) {
            foreach (string key in _playerData.items.Keys) {
                RemoveItem(key);
            }
        }
    }

    void OnEnable() {
        _playerData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        _grid = GetComponentInChildren(typeof(GridLayoutGroup), true) as GridLayoutGroup;
        if (_grid != null) {
            foreach (string key in _playerData.items.Keys) {
                int val = _playerData.items[key];
                AddItem(key, val);
            }                
        }
    }

    public GameObject GetItem(string name) {
        if (_grid == null) return null;
        Transform child = null;
        foreach (Transform _child in _grid.transform)
        {
            if (_child.GetComponent<Item>().id == name) {
                child = _child;
                break;
            }
        }
        //Transform item = _grid.transform.Find(name);
        return (child != null) ? child.gameObject : null;
    }

    public void SetValue(string name, int value) {
        GameObject item = GetItem(name);
        if (item != null) {
            item.GetComponent<Item>().Valor = value;
        }
    }

    public void RemoveItem(string name) {
        GameObject item = GetItem(name);
        if (item != null) {
            item.transform.SetParent(null);
            Destroy(item.gameObject);
        }
    }

    public void AddItem(string name, int value = 1) {
        GameObject item = GetItem(name);

        if (item == null) {
            GameObject prefab = Resources.Load("Prefabs/Objetos/" + name) as GameObject;
            item = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
            //item.transform.position = Vector3.one;
            item.transform.SetParent(_grid.transform);
            //item.transform.localScale = Vector3.one;
            //item.transform.localPosition = Vector3.zero;
            item.GetComponent<Item>().Valor = value;
        } else {
            item.GetComponent<Item>().Valor += value;
        }
    }

}
