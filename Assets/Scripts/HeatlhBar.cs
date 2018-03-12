using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBar : MonoBehaviour 
{
	public Image CurrentHealth;
	public Text RatioText;

	private float hitpoint = 150;
	private float maxHitpoint = 150;

	private void Start()
	{
		UpdateHealthbar ();
	}

	private void UpdateHealthbar()
	{
		float ratio = hitpoint / maxHitpoint;
		CurrentHealth.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		RatioText.text = (ratio * 100).ToString () + '%';
	}

	private void TakeDamage(float damage)
	{
		hitpoint -= damage;
		if (hitpoint < 0) {
			hitpoint = 0;
			Debug.Log ("Dead!");
		}

		UpdateHealthbar ();
	}

	private void HealDamage(float heal)
	{
		hitpoint += heal;
		if (hitpoint > maxHitpoint)
			hitpoint = maxHitpoint;

		UpdateHealthbar ();
	}
		
}
