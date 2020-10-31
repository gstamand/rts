using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableUnit : Unit
{

    public GameObject tempSelectionVisual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSelectionVisual(bool isVisible)
    {
        tempSelectionVisual.SetActive(isVisible);
    }
}
