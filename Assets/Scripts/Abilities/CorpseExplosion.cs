using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseExplosion : Ability
{

    public override bool AttemptExecuteAbility(Transform _transform)
    {
        GameObject target;

        target = TargetUnit();
        if (target == null)
        {
            InvalidTarget();
            return false;
        }
        if (Vector3.Distance(_transform.position, target.transform.position) > range)
        {
            OutOfRange();
            return false;
        }
        UseAbility(target, _transform);
        return true;
    }
    protected GameObject TargetUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, targetLayer))
        {
            //hit
            return hit.collider.gameObject;
        }
        else
        {
            //miss
            return null;
        }
    }
    private void UseAbility(GameObject target, Transform caster)
    {
        Destroy(target);
        //deal damage to enemies near
        caster.GetComponent<ControllableUnit>().InitiatePostCastDelays(castTime);
        remainingCoolDown = baseCoolDown;
    }
    private void InvalidTarget()
    {
        print("MUST TARGET CORPSE OR ZOMBIE");
    }



}
