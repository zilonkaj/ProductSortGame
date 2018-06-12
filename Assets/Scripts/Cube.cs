using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour{

    public TextMesh textmesh;

    public bool isEmpty = true;

    RaycastHit hit;

    GameObject g;

    public void SetText(string newtext)
    {
        textmesh.text = newtext;
    }

	public string GetText()
    {
        return textmesh.text;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {


            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.name == gameObject.name)
                {
                    g = hit.collider.gameObject;
                }
                else
                {
                    g = null;   
                }
            }

            if (g != null)
            {
                float x = Input.GetAxis("Mouse X");
                float y = Input.GetAxis("Mouse Y");

                g.transform.Translate(new Vector3(x, y, 0));
            }

        }
            
    }


}
