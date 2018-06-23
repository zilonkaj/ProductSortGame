using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product {

    public string Name;

    public List<string> Categories = new List<string>();

    public Product(string name, string category)
    {
        Name = name;
        Categories.Add(category);
    }




}
