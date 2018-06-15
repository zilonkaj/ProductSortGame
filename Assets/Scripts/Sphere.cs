using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : UIObject {

    public TextMesh textmesh;

    public Character character = null;

	// Use this for initialization
	void Start () {
        OriginalTransform = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
