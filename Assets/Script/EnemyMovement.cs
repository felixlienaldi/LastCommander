using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    public GameObject target;
    public Rigidbody rb;
    public float speed;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
            //pengaturan seek enemy
            Vector3 direction = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector3(speed * direction.x, 0f, speed * direction.z) * Time.deltaTime;
            //pengaturan rotate
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            transform.Rotate(Vector3.right, 90f);
        
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //referensi ke script sebelah, kalo kena collision kena damage player
            target.GetComponent<Movement>().takedamage();


        }
    }

}
