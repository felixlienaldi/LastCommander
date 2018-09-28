using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public GameObject victorymenu;
    public Transform[] location;
    private float spawnspeed;
    public float spawnspeedwave1;
    public float spawnspeedwave2;
    public float spawnspeedwave3;
    public int wave;
    public float timer;
    public Text timertext;
    public Text wavetext;
    public AudioSource[] sfx;
    
	// Use this for initialization
	void Start () {
        sfx[0].Play();
        wave = 1;
        sfx[0].volume = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        //ngurangin timer per detik
        timer -= Time.deltaTime;
        timertext.text = "Time : " + Mathf.Round(timer);//untuk menunjukkan waktu, mathf.round untuk membulatkan
        wavetext.text = "Wave : " + wave;//untuk menunjukkan wave
        if (wave == 1)
        {
            spawnspeed = spawnspeedwave1;
        }else if( wave == 2)
        {
            spawnspeed = spawnspeedwave2;
        }
        else if(wave == 3)
        {
            spawnspeed = spawnspeedwave3;
        }

        if(timer <= 0f && wave!=3)//kondisi wave berikutnya
        {
            timer = 70f;
            wave++;
            StartCoroutine(delay());
        }
        if(wave>=3 && timer <= 0f)//kondisi menang
        {
            sfx[2].Play();
            StopAllCoroutines();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }
            victorymenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (sfx[0].time >= 4.5f)//bunyi awal wave
        {
            sfx[0].Stop();
            sfx[0].time = 0f;
            StartCoroutine(enemyspawner());
            if(wave ==2)
            {
                StartCoroutine(enemyspawner());
            }
            if (wave == 3)
            {

                StartCoroutine(enemyspawner());
                StartCoroutine(enemyspawner());
            }
           
        }
        if (sfx[1].time > 3f)//bunyi menang wave
        {
            sfx[0].Play();
        }
    }
    
    //mulai spawn enemy
    public IEnumerator enemyspawner()
    {
        Instantiate(enemy,location[Random.Range(0,15)].position,Quaternion.identity);
        yield return new WaitForSeconds(spawnspeed);
        StartCoroutine(enemyspawner());
    }

    //nunggu wave berikutnya
    public IEnumerator delay()
    {
        StopAllCoroutines();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
        
        sfx[1].Play();
        yield return new WaitForSeconds(10f);
    }
}
