using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : UIObject{

    public TextMesh textmesh;

    public bool isEmpty = true;

    public void SetText(string newtext)
    {
        textmesh.text = newtext;
    }

	public string GetText()
    {
        return textmesh.text;
    }

    void Start()
    {
        OriginalTransform = transform.position;
    }


    void Update()
    {
        
    }


}
