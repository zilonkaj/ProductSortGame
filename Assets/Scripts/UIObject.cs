﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIObject: MonoBehaviour {

    public bool IsMoveable = true;

    public Vector3 OriginalTransform;

    public bool isEmpty = true;

    public Cube GetCube()
    {
        return GetComponent<Cube>();
    }

    public Box GetBox()
    {
        return GetComponent<Box>();
    }

    // Use this for initialization
	void Start () {
        
	}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
