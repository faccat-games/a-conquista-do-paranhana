using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour {

	public Object[] myPlaylist;
	public AudioSource _audio;
	private Scene  thisScene;
    public Timer _timer;

    public AudioSource nightSongs;

    

	//Play Global
	private static MusicScript instance = null;
	public static MusicScript Instance
	{
		get { return instance; }
	}

	void Awake()
	{
		_audio = GetComponent<AudioSource> ();
		myPlaylist = Resources.LoadAll ("Music", typeof(AudioClip));

        _timer = GameObject.FindGameObjectWithTag("Player").GetComponent<Timer>();

		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}
	//Play Gobal End

	void Start(){
		thisScene = SceneManager.GetActiveScene ();
	}
	void RandomPLaylist(){

		_audio.clip = myPlaylist [Random.Range (0, myPlaylist.Length)] as AudioClip;
		_audio.Play ();
	}


	// Update is called once per frame
	void Update () {

        if (_timer.isNight == false)
        {
            if (_audio.isPlaying == false)
            {
                PlayDayMusic();
            }
           
        }

        else if(_timer.isNight) {
            if (nightSongs.isPlaying == false)
            {
                // PlayDayMusic();
                PlayNightMusic();
            }
        }
	}

    public void PlayDayMusic() {
            nightSongs.Stop();
            RandomPLaylist();
    }

    public void PlayNightMusic() {
        _audio.Stop();
        nightSongs.Play();
    }
}
