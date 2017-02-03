﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour {

    public GameObject conveyor;
    public bool direction = true;
    private float scrollSpeed = 0.5f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * scrollSpeed;
        if (direction)
            conveyor.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        else
            conveyor.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
