﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPreviousScene : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (SimpleInput.GetButton("Cancel")) {
            var prevScene = SceneManager.GetActiveScene().buildIndex - 1;
            SceneManager.LoadScene(prevScene);
        }
	}
}