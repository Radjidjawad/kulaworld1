using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Moveball : MonoBehaviour {
    Rigidbody rb;
    public int ballspeed;
    public int jumpspeed;
    private bool istouching = true;
    private int counter;
    public Text cointext;
    public Text leveltext;
    public string Level;
    public string nextLevel;
    public AudioSource asource;
    public AudioClip aclip;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody> ();
        counter = 6;
        cointext.text = "COINS: " + counter;
        leveltext.text = "LEVEL: " + Level;
    }
	
	// Update is called once per frame
	void Update () {
        float Hmove = Input.GetAxis("Horizontal");

        float Vmove = Input.GetAxis("Vertical");

        Vector3 ballmove = new Vector3(Hmove, 0.0f, Vmove);

        rb.AddForce(ballmove * ballspeed);

        if ((Input.GetKey(KeyCode.Space)) && istouching == true)
        {
            Vector3 balljump = new Vector3(0.0f, 6.0f, 0.0f);
            rb.AddForce(balljump * jumpspeed);
        }

        istouching = false;
    }

    private void OnCollisionStay()
    {
        istouching = true; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coinstag"))
        {
            other.gameObject.SetActive(false);
            counter = counter - 1;
            cointext.text = "COINS: " + counter.ToString();
            asource.PlayOneShot(aclip);
 
        }

        if (counter == 0)
        {
            SceneManager.LoadScene(nextLevel);
        }

    }
}
