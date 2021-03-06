﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState {

    void Start();

    void NonDamagedUpdate();

    void DamagedUpdate();

    void ResetKart();

    string GetGameStateName();

    void OnCollisionEnter(GameObject other);
    void OnTriggerEnter(GameObject other);
}
