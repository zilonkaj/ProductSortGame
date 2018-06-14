using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : UIObject{

    public List<Product> BoxContents = new List<Product>();

    public List<TextMesh> ProductTextMeshs;

    public void AddProduct(Product ProductToAdd)
    {
        if (!IsFull())
        {
            BoxContents.Add(ProductToAdd);
        }
    }


    public bool IsFull()
    {
        return (BoxContents.Count == 3);
    }


    // Use this for initialization
	void Start () {
        OriginalTransform = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
