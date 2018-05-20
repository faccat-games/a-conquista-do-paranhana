using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class splashFade : MonoBehaviour {

	public Image splashImage;
	public Image splashImage2;
	public Image splashImage3;
	public Canvas canvas;
	public string loadScene;

	public float delay = 2.5f;
	IEnumerator Start () {

		splashImage.canvasRenderer.SetAlpha(0.0f);
		splashImage2.canvasRenderer.SetAlpha(0.0f);
		splashImage3.canvasRenderer.SetAlpha(0.0f);


		FadeInFirst();
		yield return new WaitForSeconds(delay);
		FadeOutFirst();
		yield return new WaitForSeconds(delay);



		FadeInSecond();
		yield return new WaitForSeconds(delay);
		FadeOutSecond();
		yield return new WaitForSeconds(delay);

		FadeInThird();
		yield return new WaitForSeconds(delay);
		FadeOutThird();
		yield return new WaitForSeconds(delay);

		SceneManager.LoadScene(loadScene);

	}

	void FadeInFirst(){

		splashImage.CrossFadeAlpha (1.0f, 1.5f, false);

	}

	void FadeOutFirst(){

		splashImage.CrossFadeAlpha (0.0f, delay, false);
		//CrossFadeColor\

	}

	void FadeInSecond(){

		splashImage2.CrossFadeAlpha (1.0f, 1.5f, false);
		//canvas.GetComponent<Image>().color = new Color32(14,9,69,100);

	}

	void FadeOutSecond(){

		splashImage2.CrossFadeAlpha (0.0f, delay, false);
	}

	void FadeInThird(){

		splashImage3.CrossFadeAlpha (1.0f, 1.5f, false);
		canvas.GetComponent<Image>().color = new Color32(14,9,69,100);

	}

	void FadeOutThird(){

		splashImage3.CrossFadeAlpha (0.0f, delay, false);
	}

}
