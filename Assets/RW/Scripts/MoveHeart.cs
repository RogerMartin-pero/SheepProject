﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeart : MonoBehaviour
{
    public Transform thisTransform;
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.position += movement * Time.deltaTime;
    }
}
