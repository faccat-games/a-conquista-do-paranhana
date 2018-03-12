using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitarvore : MonoBehaviour {
	public void AudioPlay(){
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}
