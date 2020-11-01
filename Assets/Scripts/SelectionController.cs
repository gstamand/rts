using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    Camera cam;
    private Vector2 startPos;
    private List<ControllableUnit> controllableUnits;
    private List<ControllableUnit> selectedUnits;
    private int selectionThreshold = 10;
    private float timeHeld = 0f;
    private float timeHeldThreshold = .1f;
    private bool selectionBoxActive = false;

    public RectTransform selectionBox;
    public LayerMask groundLayer;
    public LayerMask unitLayerMask;
    public ControllableUnit activeUnit;

    //temp
    public ControllableUnit test;

    void Awake()
    {
        cam = Camera.main;
        controllableUnits = new List<ControllableUnit>();
        selectedUnits = new List<ControllableUnit>();
        controllableUnits.Add(test);
    }



    // Update is called once per frame
    void Update()
    {
        if (selectionBoxActive) UpdateSelectionBox(Input.mousePosition);
    }

    public void MoveSelectedUnits()
    {
        
        Vector3 destination = GetPointUnderCursor();
        foreach(ControllableUnit unit in selectedUnits)
        {
            unit.SetDestination(destination);
        }
        
    }
    public void SelectClick()
    {
        ClearSelectedUnits();
        TrySelect();
        startPos = Input.mousePosition;
    }


    private void ClearSelectedUnits()
    {
        selectedUnits = new List<ControllableUnit>();
        selectionBoxActive = false;
        timeHeld = 0;
        foreach (ControllableUnit unit in controllableUnits)
        {
            unit.ToggleSelectionVisual(false);
        }
    }

    private void TrySelect()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, unitLayerMask))
        {
            ControllableUnit unit = hit.collider.GetComponentInParent<ControllableUnit>();
            selectedUnits.Add(unit);
            unit.ToggleSelectionVisual(true);
            SetActiveUnit(unit);
        }
    }
    public void StartSelectionBox()
    {
        selectionBoxActive = true;

    }
    public void ReleaseSelectionBox()
    {
        selectionBox.gameObject.SetActive(false);
        UpdateToggleSelectionVisual(true);
        selectionBoxActive = false;
        print("releaseddddddddddd");
    }


    private Vector3 GetPointUnderCursor()
    {
        Vector2 screenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(screenPosition);

        RaycastHit hitPosition;

        Physics.Raycast(mouseWorldPosition, cam.transform.forward, out hitPosition, 100, groundLayer);

        return hitPosition.point;
    }
    public void UpdateSelectionBox(Vector2 curMousePosition)
    {

        if (!selectionBox.gameObject.activeInHierarchy) selectionBox.gameObject.SetActive(true);

        float width = curMousePosition.x - startPos.x;
        float height = curMousePosition.y - startPos.y;

        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = startPos + new Vector2(width / 2, height / 2);

        UpdateToggleSelectionVisual(false);
    }


    private void UpdateToggleSelectionVisual(bool addUnitsToList)
    {
        if (selectionBoxActive)
        {
            Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
            Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

            foreach (ControllableUnit unit in controllableUnits)
            {

                Vector3 screenPos = cam.WorldToScreenPoint(unit.transform.position);

                if (screenPos.x + selectionThreshold > min.x && screenPos.x - selectionThreshold < max.x && screenPos.y + selectionThreshold > min.y && screenPos.y - selectionThreshold < max.y)
                {
                    if (addUnitsToList) selectedUnits.Add(unit);
                    unit.ToggleSelectionVisual(true);
                }
                else
                {
                    unit.ToggleSelectionVisual(false);
                }
            }
        }
        if (selectedUnits.Count == 1) SetActiveUnit(selectedUnits[0]);


    }

    private void SetActiveUnit(ControllableUnit activeUnit)
    {
        this.activeUnit = activeUnit;
    }

}
