﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

// game start korle player guli kore

    // apatoto bolt k hide kore somadhan kora holo. vdo abr dekhe sothik somadhan lagbe

public class PlayerController : MonoBehaviour {
    
    Rigidbody rigidbody;
    public int speed;
    public Boundary boundary;
    public float tilt;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Debug.Log(Input.GetButton("Fire1"));
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
             0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax )
            );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }
}
