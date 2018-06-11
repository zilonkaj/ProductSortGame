using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    List<Product> products;

    // predefined list used for testing. needs to be replaced with actual
    // products
    List<Product> testproducts;





    // Use this for initialization
	void Start () {
        BuildTestProducts();
        products = new List<Product>(testproducts);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // only used for mockup
    void BuildTestProducts()
    {
        testproducts.Add(new Product("TV", "Electronics"));
        testproducts.Add(new Product("Dress", "Fashion"));
        testproducts.Add(new Product("Phone", "Electronics"));
        testproducts.Add(new Product("Ring", "Jewelry"));
        testproducts.Add(new Product("Mystery", "Uncategorized"));
    }

    void ShuffleProductList()
    {
        int randomnum;
        Product temp;

        for (int i = 0; i < products.Count; i++)
        {
            randomnum = Random.Range(0, products.Count);
            temp = products[randomnum];
            products[randomnum] = products[i];
            products[i] = temp;
        }



    }
}




