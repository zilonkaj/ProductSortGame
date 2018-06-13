using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GameManager : Singleton<GameManager> {

    // predefined list used for testing. needs to be replaced with actual
    // products
    List<Product> testproducts = new List<Product>();





    List<Product> products;


    // guarantee this will always be a singleton
    protected GameManager() { }

    // Use this for initialization
	void Start () {
        BuildTestProducts();
        products = new List<Product>(testproducts);
        ShuffleProductList();
        InitializeUI();
	}

    // only used for mockup
    void BuildTestProducts()
    {
        testproducts.Add(new Product("TV", "Uncategorized"));
        testproducts.Add(new Product("Dress", "Fashion"));
        testproducts.Add(new Product("Phone", "Electronics"));
        testproducts.Add(new Product("Ring", "Jewelry"));
        testproducts.Add(new Product("Shoes", "Uncategorized"));
        testproducts.Add(new Product("Printer", "Uncategorized"));
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

    void InitializeUI()
    {
        for (int i = 0; i < UI.Instance.CubeList.Count; i++)
        {
            UI.Instance.SetCubeAtIndex(i, products[i]);
        }
    }

    //void RemoveOnDrag()
    //{
    //    products.In





    //}







    // Update is called once per frame
    void Update()
    {

    }
}




