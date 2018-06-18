using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GameManager : Singleton<GameManager> {

    // predefined list used for testing. needs to be replaced with actual
    // products
    List<Product> testproducts = new List<Product>();

    List<Product> ProductBacklog;

    List<string> CharacterCategories = new List<string>();


    // guarantee this will always be a singleton
    protected GameManager() { }

    // Use this for initialization
	void Start () {
        Time.timeScale = 1.0f;
        BuildTestProducts();
        BuildCharacterCategories();
        ProductBacklog = new List<Product>(testproducts);
        ShuffleProductList();
        InitializeCubes();
        InitializeUI();
        InitializeFirstCharacters();
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
        testproducts.Add(new Product("Chair", "Furniture"));

        testproducts.Add(new Product("Speaker", "Electronics"));
        testproducts.Add(new Product("Headphones", "Uncategorized"));
        testproducts.Add(new Product("Handbag", "Fashion"));
        testproducts.Add(new Product("Toy truck", "Uncategorized"));
        testproducts.Add(new Product("Lego", "Toys"));
        testproducts.Add(new Product("Monopoly", "Uncategorized"));
        testproducts.Add(new Product("Dryer", "Appliances"));
        testproducts.Add(new Product("Fridge", "Uncategorized"));
        testproducts.Add(new Product("Microwave", "Appliances"));
        testproducts.Add(new Product("Toaster", "Uncategorized"));
    }

    void BuildCharacterCategories()
    {
        CharacterCategories.Add("Electronics");
        CharacterCategories.Add("Fashion");
        CharacterCategories.Add("Appliances");
        CharacterCategories.Add("Jewelry");
        CharacterCategories.Add("Furniture");
        CharacterCategories.Add("Toys");
    }

    void ShuffleProductList()
    {
        int randomnum;
        Product temp;

        for (int i = 0; i < ProductBacklog.Count; i++)
        {
            randomnum = Random.Range(0, ProductBacklog.Count);
            temp = ProductBacklog[randomnum];
            ProductBacklog[randomnum] = ProductBacklog[i];
            ProductBacklog[i] = temp;
        }
    }

    void InitializeCubes()
    {
        for (int i = 0; i < UI.Instance.Cubes.Count; i++)
        {
            UI.Instance.Cubes[i].product = ProductBacklog[0];
            ProductBacklog.Remove(ProductBacklog[0]);
        }
    }

    void ResetCube(Cube CubeToReset)
    {
        UI.Instance.ClearCubeText(CubeToReset);
        AssignNewProduct(CubeToReset);
    }

    void AssignNewProduct(Cube CubeToSet)
    {
        if (ProductBacklog.Count != 0)
        {
            CubeToSet.product = ProductBacklog[0];
            ProductBacklog.Remove(ProductBacklog[0]);
            UI.Instance.UpdateCubeText();
        }
        else
        {
            CubeToSet.product = null;  
        }
    }

    void InitializeUI()
    {
        UI.Instance.UpdateCubeText();
    }

    public void ProductPlacedInBox(Cube cube, Box BoxToAddTo)
    {
        if (!BoxToAddTo.IsFull())
        {
            BoxToAddTo.AddProduct(cube.product);
            //BoxToAddTo.UpdateCategory();
            ResetCube(cube);
            StartPackingBox(BoxToAddTo);
        }
    }

    void StartPackingBox(Box BoxBeingPacked)
    {
        DisableBox(BoxBeingPacked);
        BoxBeingPacked.Timer += (2.5f * BoxBeingPacked.TimerMultiplier);
        BoxBeingPacked.isTimerActive = true;
    }

    void DisableBox(Box BoxToDisable)
    {
        BoxToDisable.IsMoveable = false;
        UI.Instance.ClearBoxText(BoxToDisable);
    }

    void BoxTimer(Box BoxWithActiveTimer)
    {
        if (BoxWithActiveTimer.Timer >= 1)
        {
            BoxWithActiveTimer.Timer -= Time.deltaTime;
        }
        else
        {
            BoxWithActiveTimer.Timer = 0;
            BoxWithActiveTimer.isTimerActive = false;
            BoxWithActiveTimer.TimerMultiplier++;
            EnableBox(BoxWithActiveTimer);
        }
    }

    void EnableBox(Box BoxToEnable)
    {
        UI.Instance.DisableBoxTimer(BoxToEnable);
        UI.Instance.EnableSingleBoxText(BoxToEnable);
        BoxToEnable.IsMoveable = true;
    }

    string PickRandomCategory()
    {
        int randomnum = Random.Range(0, CharacterCategories.Count);
        string SelectedCategory = CharacterCategories[randomnum];
        return SelectedCategory;
    }

    void InitializeFirstCharacters()
    {
        StartCoroutine(SpawnNewCharacter(10f));
        StartCoroutine(SpawnNewCharacter(20f));
        StartCoroutine(SpawnNewCharacter(30f));
    }

    IEnumerator SpawnNewCharacter(float timedelay)
    {
        yield return new WaitForSeconds(timedelay);
        Character NewCharacter = new Character();
        NewCharacter.DesiredCategory = PickRandomCategory();
        foreach (Sphere sphere in UI.Instance.Characters)
        {
            if (sphere.character == null)
            {
                sphere.character = NewCharacter;
                break;
            }
        }
        UI.Instance.SetSphereText();
    }

    public void BoxGivenToCharacter(Box box, Sphere sphere)
    {
        // - method to check product categories against desiredcategory
        // - method in UI to update "expressions" (color of sphere)
        // - catalog result of handing box to character
        // - method to reset character, wait for some time, then new desiredcategory
    }


    // Update is called once per frame
    void Update()
    {
        foreach (Box box in UI.Instance.Boxes)
        {
            if (box.isTimerActive)
            {
                BoxTimer(box); 
            }
        }



    }
}




