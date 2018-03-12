using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public static LevelManager levelManager; 

	private int Coin = 0;
	private bool gameOver = false;
	public Text CoinText;
	public int iSede;
	public Text sedeText;
	public int iFome;
	public Text fomeText;


	// Use this for initialization
	void Awake () {

		if (levelManager == null) {
			levelManager = this;
		} else if (levelManager != this) {
			Destroy (gameObject);
		}
	}
	void Start (){
		iSede = 100;
		iFome = 100;
		CoinText.text = Coin.ToString ();
		sedeText.text = iSede.ToString ();
		fomeText.text = iFome.ToString ();
	}
	public void SetCoin(int x)
	{
		Coin = Coin + x;
		CoinText.text = Coin.ToString ();
	
	}
	public void SetSede(int x)
	{
		iSede = iSede - x;
		sedeText.text = iSede.ToString ();

	}
	public void SetFome(int x)
	{
		iFome = iFome - x;
		fomeText.text = iFome.ToString ();

	}

	public int GetCoin()
	{
		return Coin;
    }

	public int GetSede()
	{
		return iSede;
	}

	public int GetFome()
	{
		return iFome;
	}
}

