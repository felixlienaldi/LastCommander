using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject pausemenu;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
        }
	}

    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void returntomainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu");
    }

    public void retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("aa");
    }
}
