﻿using UnityEngine;
using System.Collections;

public class SlabCollision : Collision {

    public bool isMandatory;
    private bool _isActivated = false;

    public bool isActivated
    {
        get { return _isActivated; }
    }
    protected override void PlayerEnter(GameObject player)
    {
        if (_isActivated)
        {
            renderer.material.color = Color.red;
            _isActivated = false;
        }
        else
        {
            renderer.material.color = Color.green;
            _isActivated = true;
        }
    }
}