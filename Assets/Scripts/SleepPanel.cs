using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepPanel : MonoBehaviour {

	// Use this for initialization
	//fade
	private Image _fadeImage;

	void Start () {
		_fadeImage = GetComponentInChildren<Image> ();
		//_fadeImage.canvasRenderer.SetAlpha(0.0f);
		//_fadeImage.CrossFadeAlpha (0.0f, 6.5f, false);

		/*yield return new WaitForSeconds(2);
		fadeOut();
		yield return new WaitForSeconds(2);
		fadeIn();*/

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetFadeIn(float time){
		StartCoroutine(FadeIn(_fadeImage,time));
		//_fadeImage.CrossFadeAlpha (4.0f, 2.5f, false);

	}
	public void SetFadeOut(float time){
		StartCoroutine(FadeOut(_fadeImage,time));
		//_fadeImage.CrossFadeAlpha (0.0f, 2.5f, false);
	}

	private YieldInstruction fadeInstruction = new YieldInstruction();

	private IEnumerator FadeOut(Image image, float fadeTime)
	{
		float elapsedTime = 0.0f;
		Color c = image.color;
		while (elapsedTime < fadeTime)
		{
			yield return fadeInstruction;
			elapsedTime += Time.deltaTime ;
			c.a = Mathf.Clamp01(elapsedTime / fadeTime);
			image.color = c;
		}
	}

	private IEnumerator FadeIn(Image image, float fadeTime)
	{
		float elapsedTime = 0.0f;
		Color c = image.color;
		while (elapsedTime < fadeTime)
		{
			yield return fadeInstruction;
			elapsedTime += Time.deltaTime ;
			c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
			image.color = c;
		}
	}
}
