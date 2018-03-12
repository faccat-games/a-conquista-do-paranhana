using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class splashFade : MonoBehaviour {

	public Image splashImage;
	public Image splashImage2;
	public string loadScene;

	IEnumerator Start () {

		splashImage.canvasRenderer.SetAlpha(0.0f);
		splashImage2.canvasRenderer.SetAlpha(0.0f);


		FadeInFirst();
		yield return new WaitForSeconds(2.5f);
		FadeOutFirst();
		yield return new WaitForSeconds(2.5f);



		FadeInSecond();
		yield return new WaitForSeconds(2.5f);
		FadeOutSecond();
		yield return new WaitForSeconds(2.5f);

		SceneManager.LoadScene(loadScene);

	}

	void FadeInFirst(){
	
		splashImage.CrossFadeAlpha (1.0f, 1.5f, false);

	}

	void FadeOutFirst(){

		splashImage.CrossFadeAlpha (0.0f, 2.5f, false);

	}

	void FadeInSecond(){
	
		splashImage2.CrossFadeAlpha (1.0f, 1.5f, false);
	}

	void FadeOutSecond(){
		
		splashImage2.CrossFadeAlpha (0.0f, 2.5f, false);
	}
}
