using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

    // guarantee this will always be a singleton
    protected UIManager() { }

    public List<Cube> productlist;
}
