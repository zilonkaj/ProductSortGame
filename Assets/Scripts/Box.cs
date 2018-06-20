using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : UIObject{

    public List<Product> BoxContents = new List<Product>();

    public List<TextMesh> ProductTextMeshs;

    public TextMesh TimerText;

    public float Timer = 0;

    public int TimerMultiplier = 1;

    public bool isTimerActive = false;

    public void AddProduct(Product ProductToAdd)
    {
        if (ProductToAdd != null)
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
        IsMoveable = false;
        OriginalTransform = transform.position;
        OriginalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
