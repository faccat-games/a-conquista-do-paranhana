using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour {

    public GameObject pauseMenu;
    public int MainSceneIndex;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale > 0)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);

        }


    }

    public void ExitToMenu()
    {
        Destroy(GameObject.Find("Musica"));
        SceneManager.LoadScene(MainSceneIndex);
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
