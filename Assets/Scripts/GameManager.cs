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
        AssignProductsToCubes();
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
        testproducts.Add(new Product("Table", "Furniture"));
        testproducts.Add(new Product("Tablet", "Uncategorized"));
        testproducts.Add(new Product("Cabinet", "Uncategorized"));
        testproducts.Add(new Product("Broom", "Home"));
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

    void AssignProductsToCubes()
    {
        for (int i = 0; i < UI.Instance.Cubes.Count; i++)
        {
            UI.Instance.Cubes[i].product = products[i];
        }
    }

    void InitializeUI()
    {
        UI.Instance.SetCubesToProducts();
    }

    public void ProductPlacedInBox(Cube cube, Box BoxToAddTo)
    {
        BoxToAddTo.AddProduct(cube.product);
        UI.Instance.UpdateBoxTextMeshes();
    }




    // Update is called once per frame
    void Update()
    {

    }
}




