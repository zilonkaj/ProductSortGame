using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : UIObject{

    public List<Product> BoxContents = new List<Product>();

    public List<TextMesh> ProductTextMeshs;

    //string Category = "Empty";


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

    //public void UpdateCategory()
    //{
    //    if (Category == "Empty")
    //    {
    //        Category = BoxContents[0].Category;
    //        print(Category);
    //    }
    //    else if (Category == "Invalid")
    //    {
    //        print(Category);
    //        // do nothing, box is permanently invalid
    //        return;
    //    }
    //    else
    //    {
    //        string CategoryToSet = DetermineCategory();

    //        if (CategoryToSet != null)
    //        {
    //            Category = CategoryToSet;
    //        }
    //        print(Category);
    //    }

    //}

    //public string DetermineCategory()
    //{
    //    foreach (Product product in BoxContents)
    //    {
    //        if (Category != product.Category)
    //        {
    //            // if box isn't set but product is
    //            if (Category == "Uncategorized")
    //            {
    //                return product.Category;
    //            }
    //            // if box is set but product isn't
    //            if (product.Category == "Uncategorized")
    //            {
    //                continue;
    //            }
    //            //else
    //            return "Invalid";
    //        }
    //    }
    //    // if products in box match category or are uncategorized
    //    return null;
    //}

    // Use this for initialization
    void Start () {
        IsMoveable = false;
        OriginalTransform = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
