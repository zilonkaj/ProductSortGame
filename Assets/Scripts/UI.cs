using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Singleton<UI> {

    // guarantee this will always be a singleton
    protected UI() { }

    public List<Cube> CubeList;

    public void SetCubeAtPos(int pos, Product NewProduct)
    {
        CubeList[pos].SetText(NewProduct.Name);
        CubeList[pos].isEmpty = false;
    }

    public void ClearCubeAtPos(int pos)
    {
        CubeList[pos].SetText("");
        CubeList[pos].isEmpty = true;
    }
}
