﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{

    public float tumble;
    Rigidbody rigidbody;

    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}