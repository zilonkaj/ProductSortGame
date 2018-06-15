using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Singleton<UI> {

    // guarantee this will always be a singleton
    protected UI() { }

    public List<Cube> Cubes;

    public List<Box> Boxes;

    public List<Sphere> Characters;

    // used for drag and drop
    RaycastHit hitresult;
    UIObject ObjectToMove = null;

    public void SetCubesToProducts()
    {
        foreach (Cube cube in Cubes)
        {
            if (cube.product != null)
            {
                cube.textmesh.text = cube.product.Name;
            }
        }
    }

    public void UpdateBoxTextMeshes()
    {
        foreach (Box BoxToSet in Boxes)
        {
            for (int i = 0; i < BoxToSet.BoxContents.Count; i++)
            {
                BoxToSet.ProductTextMeshs[i].text = BoxToSet.BoxContents[i].Name; 
            }
        }
    }

    public void ClearCube(Cube CubeToClear)
    {
        CubeToClear.SetText("");
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

    void CheckIfPlacedInBox()
    {
        Cube cube = ObjectToMove.GetCube();
        Box box = null;

        // GetUIObjectAtMousePos ignores ObjectToMove due to layer change.
        if (GetUIObjectAtMousePos() != null)
        {
            box = GetUIObjectAtMousePos().GetBox();
        }

        if (cube != null && box != null)
        {
           GameManager.Instance.ProductPlacedInBox(cube, box);
        }
    }

    public void SetSpheres()
    {
        foreach (Sphere sphere in Characters)
        {
            if (sphere.character != null)
            {
                sphere.textmesh.text = sphere.character.DesiredCategory;
            }
        }  
    }

    void CheckIfPlacedOnSphere()
    {
        Box box = ObjectToMove.GetBox();
        Sphere sphere = null;

        if (GetUIObjectAtMousePos() != null)
        {
            sphere = GetUIObjectAtMousePos().GetSphere();
        }

        if (box != null && sphere != null)
        {
            GameManager.Instance.BoxGivenToCharacter(box, sphere);
        }
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

            CheckIfPlacedInBox();

            ObjectToMove.gameObject.layer = 0;
            MoveUIObjectBack();
            ObjectToMove = null;
        }
    }  
}
