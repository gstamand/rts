using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableUnit : Unit
{

    public GameObject tempSelectionVisual;
    public GameObject rangeCircle;

    public Ability ability1;
    public Ability ability2;
    public Ability ability3;
    public Ability ability4;

    public float delayRemaining = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayRemaining -= Time.deltaTime;
    }

    public void ToggleSelectionVisual(bool isVisible)
    {
        tempSelectionVisual.SetActive(isVisible);
    }

    public void InitiatePostCastDelays(float castTime)
    {
        navMeshAgent.isStopped = true;
        Invoke("RestoreMovement", castTime);
        delayRemaining = castTime;

    }
    private void RestoreMovement()
    {
        navMeshAgent.isStopped = false;
    }

}
