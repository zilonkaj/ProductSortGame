using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour{
    
    public TextMesh textmesh;

    public void SetText(string newtext)
    {
        textmesh.text = newtext;
    }

	
}
