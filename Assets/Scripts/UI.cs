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
    public bool MoveObjectBack = true;

    public void UpdateAllCubeText()
    {
        foreach (Cube cube in Cubes)
        {
            if (cube.product != null)
            {
                cube.SetText(cube.product.Name);
            }
        }
    }

    public void EnableSingleBoxText(Box BoxToEnable)
    {
        for (int i = 0; i < BoxToEnable.BoxContents.Count; i++)
        {
            BoxToEnable.ProductTextMeshs[i].text = BoxToEnable.BoxContents[i].Name;
        }
    }

    public void EnableAllBoxText()
    {
        foreach (Box BoxToEnable in Boxes)
        {
            for (int i = 0; i < BoxToEnable.BoxContents.Count; i++)
            {
                BoxToEnable.ProductTextMeshs[i].text = BoxToEnable.BoxContents[i].Name; 
            }
        }
    }

    public void ClearAllBoxText(Box BoxToClear)
    {
        foreach (TextMesh textmesh in BoxToClear.ProductTextMeshs)
        {
            textmesh.text = ""; 
        }

    }

    public void DisableBoxTimer(Box BoxTimerToDisable)
    {
        BoxTimerToDisable.TimerText.text = "";
    }

    public void ClearCubeText(Cube CubeToClear)
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

    public void MoveUIObjectBack(UIObject ObjectToMoveBack)
    {
        ObjectToMoveBack.transform.position = ObjectToMoveBack.OriginalTransform;
    }

    void CheckIfCubePlacedInBox()
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
            MoveObjectBack = true;
            GameManager.Instance.ProductPlacedInBox(cube, box);
        }
    }

    public void UpdateAllSphereText()
    {
        foreach (Sphere sphere in Characters)
        {
            if (sphere.character != null)
            {
                sphere.textmesh.text = sphere.character.DesiredCategory;
            }
        }  
    }

    public void ClearSphereText(Sphere SphereToClear)
    {
        SphereToClear.textmesh.text = "";
    }

    void CheckIfBoxPlacedOnSphere()
    {
        Box box = ObjectToMove.GetBox();
        Sphere sphere = null;

        if (GetUIObjectAtMousePos() != null)
        {
            sphere = GetUIObjectAtMousePos().GetSphere();
        }

        // THIS NEEDS TO BE FIXED
        if (box != null && box.IsMoveable && sphere != null && sphere.character != null)
        {
            MoveObjectBack = false;
            GameManager.Instance.BoxGivenToCharacter(box, sphere);
        }
    }

    public void SetSphereColor(Sphere sphere, Color SphereColor)
    {
        Renderer SphereRenderer = sphere.GetComponent<Renderer>();
        SphereRenderer.material.SetColor("_Color", SphereColor);
    }

    public void ShrinkBoxScale(Box BoxToChange)
    {
        BoxToChange.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void ResetBoxScale(Box BoxToReset)
    {
        BoxToReset.transform.localScale = BoxToReset.OriginalScale;
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

            CheckIfCubePlacedInBox();
            CheckIfBoxPlacedOnSphere();

            ObjectToMove.gameObject.layer = 0;

            if (MoveObjectBack)
            {
                MoveUIObjectBack(ObjectToMove);
            }

            ObjectToMove = null;
        }

        foreach (Box box in Boxes)
        {
            if (box.isTimerActive)
            {
                int TimeInt = (int)box.Timer;
                box.TimerText.text = TimeInt.ToString();
            }
        }
    }  
}
