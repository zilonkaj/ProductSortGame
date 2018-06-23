using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIObject: MonoBehaviour {

    public bool IsMoveable = true;

    public Vector3 OriginalTransform;
    public Vector3 OriginalScale;

    public Cube GetCube()
    {
        return GetComponent<Cube>();
    }

    public Box GetBox()
    {
        return GetComponent<Box>();
    }

    public Sphere GetSphere()
    {
        return GetComponent<Sphere>();
    }
}
