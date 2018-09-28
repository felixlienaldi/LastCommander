using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    public GameObject credits;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void play()
    {
        SceneManager.LoadScene("aa");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void Back()
    {
        credits.SetActive(false);
    }
}
