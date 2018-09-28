using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float health;
    public Rigidbody rb;
    public float speed;
    public RaycastHit hit;
    public RaycastHit melee;
    public float distancecamera;
    public float meleerange;
    public Animator animation;
    public GameObject gameover;
    public GameObject[] heart;
    public int imagenumber;
    public AudioSource takedamagesfx;
    public AudioSource swingsword;
    public AudioSource enemyhit;

    // Use this for initialization
    void Start () {

        imagenumber = 0;
    }

    // Update is called once per frame
    void Update() {
        
        animation.SetBool("run", false);
        animation.SetBool("attack", false);

        //pengaturan rotation player
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray.direction = new Vector3(Mathf.Clamp(ray.direction.x, -0.3f,0.3f), Mathf.Clamp(ray.direction.y,-1f,-0.9f), Mathf.Clamp(ray.direction.z, -0.3f, 0.3f));
        if (Physics.Raycast(ray, out hit, distancecamera,-1)){
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
        
        //pengaturan melee attack
        if (Input.GetMouseButton(0))
        {
            swingsword.Play();
            animation.SetBool("attack", true);
            StartCoroutine(attackanimation());
        }

        //pengaturan movement
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
            animation.SetBool("run", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
            animation.SetBool("run", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, 0f, -speed) * Time.deltaTime;
            animation.SetBool("run", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f, speed) * Time.deltaTime;
             animation.SetBool("run", true);
        }
        //pengaturan health
        if (health <= 0f)
        {
            gameover.SetActive(true);
            StopAllCoroutines();
            Time.timeScale = 0f;//untuk pause segala yang ada time. nya
        }
    }

    //kalo kena damage diambil dari enemymovement
    public void takedamage()
    {
        health -= 1f;
        heart[imagenumber].SetActive(false);
        takedamagesfx.Play();
        imagenumber++;
    }

    //pengaturan animasi attack
    IEnumerator attackanimation()
    {
        yield return new WaitForSeconds(0.3f);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.forward * meleerange, out melee, meleerange, -1))
        {

            if (melee.collider.tag == "Enemy")
            {
                enemyhit.Play();
                Destroy(melee.transform.gameObject);//hancur kalo serang musuh
            }
        }
    }
}
