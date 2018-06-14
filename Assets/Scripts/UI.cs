using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Singleton<UI> {

    // guarantee this will always be a singleton
    protected UI() { }

    public List<Cube> CubeList;

    // used for drag and drop
    RaycastHit hitresult;
    UIObject ObjectToMove = null;

    public void SetCubeAtIndex(int index, Product NewProduct)
    {
        CubeList[index].SetText(NewProduct.Name);
        CubeList[index].isEmpty = false;
    }

    public void ClearCubeAtIndex(int index)
    {
        CubeList[index].SetText("");
        CubeList[index].isEmpty = true;
    }

    void MoveUIObjectAtMousePos()
    {
        if (ObjectToMove == null)
        {
            ObjectToMove = GetUIObjectAtMousePos();
        }

        else if (ObjectToMove.IsMoveable) 
        {
            // z is arbitrary
            Vector3 MouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            ObjectToMove.transform.position = Camera.main.ScreenToWorldPoint(MouseScreenPos);
        }
    }

    void PrintUIObjectName(UIObject uiobject)
    {
        if (uiobject != null)
        {
            print(uiobject.name);  
        }
    }

    UIObject GetUIObjectAtMousePos()
    {
        if (CollisionAtMousePos())
        {
            return hitresult.collider.gameObject.GetComponent<UIObject>();
        }
        return null;
    }

    bool CollisionAtMousePos()
    {
        return (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitresult, Mathf.Infinity));
    }

    void MoveUIObjectBack()
    {
        ObjectToMove.transform.position = ObjectToMove.OriginalTransform;
    }







    void Update()
    {
        // left click
        if (Input.GetMouseButton(0))
        {
            MoveUIObjectAtMousePos();  
        }

        if (Input.GetMouseButtonUp(0) && ObjectToMove != null)
        {
            // 2 is ignoreRaycast layer
            ObjectToMove.gameObject.layer = 2;
            PrintUIObjectName(GetUIObjectAtMousePos());
            ObjectToMove.gameObject.layer = 0;

            MoveUIObjectBack();
            ObjectToMove = null;
        }
    }  
}
