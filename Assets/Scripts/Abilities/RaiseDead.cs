using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaiseDead : Ability
{

    [SerializeField] private GameObject zombie;

    public override bool AttemptExecuteAbility(Transform _transform)
    {
        Corpse target;

        target = TargetUnit();
        if (target == null)
        {
            InvalidTarget();
            return false;
        }
        if(Vector3.Distance(_transform.position, target.transform.position) > range)
        {
            OutOfRange();
            return false;
        }
        UseAbility(target, _transform);
        return true;
    }

    private void UseAbility(Corpse target, Transform caster)
    {
        print("casting ability");
        Destroy(target.gameObject);
        Instantiate(zombie, target.transform.position, target.transform.rotation);
        caster.GetComponent<ControllableUnit>().InitiatePostCastDelays(castTime);
        remainingCoolDown = baseCoolDown;
    }
    private void InvalidTarget()
    {
        print("MUST TARGET CORPSE");
    }

    protected Corpse TargetUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, targetLayer))
        {
            //hit
            return hit.collider.GetComponentInParent<Corpse>();
        }
        else
        {
            //miss
            return null;
        }
    }
}
