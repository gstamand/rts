using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{

    [SerializeField]private SelectionController selectionController;
    public bool isAbilityQueued = false;
    private Ability queuedAbility;

    public enum Abilities
    {
        Ability1,
        Ability2,
        Ability3,
        Ability4,
        Attack,
        Interact
    }

    private void Update()
    {
        if(isAbilityQueued)
        {
            ChangeRangeCircleRange(queuedAbility.range);
        }

    }

    public void CastQueuedAbility()
    {
        if (queuedAbility.AttemptExecuteAbility(selectionController.activeUnit.transform))
        {
            isAbilityQueued = false;
            queuedAbility = null;
            ChangeRangeCircleRange(0);
        }
    }

    public void QueueAbility(AbilityController.Abilities ability)
    {
        //first, check if unit active. if not, cancel
        //second, check if ability on CD. if on CD, cancel
        //third, check if ability queued. regardless, make new request active
        if (!CheckForActiveUnit()) return;
        switch (ability)
        {
            case AbilityController.Abilities.Ability1:
                {
                    if(selectionController.activeUnit.ability1.remainingCoolDown > 0)
                    {
                        print("COOLDOWN");
                    }
                    else
                    {
                        queuedAbility = selectionController.activeUnit.ability1;
                        isAbilityQueued = true;
                    }
                    break;
                }
            case AbilityController.Abilities.Ability2:
                {
                    break;
                }
            case AbilityController.Abilities.Ability3:
                {
                    if (selectionController.activeUnit.ability3.remainingCoolDown > 0)
                    {
                        print("COOLDOWN");
                    }
                    else
                    {
                        queuedAbility = selectionController.activeUnit.ability3;
                        isAbilityQueued = true;
                    }
                    break;
                }
            case AbilityController.Abilities.Ability4:
                {
                    break;
                }
            case AbilityController.Abilities.Attack:
                {
                    break;
                }
            case AbilityController.Abilities.Interact:
                {
                    break;
                }
        }
    }

    public void CancelQueuedAbility()
    {
        if (isAbilityQueued)
        {
            isAbilityQueued = false;
            ChangeRangeCircleRange(0);
            queuedAbility = null;
        }
    }

    private bool CheckForActiveUnit()
    {
        return selectionController.activeUnit != null;
    }

    private void ChangeRangeCircleRange(float range)
    {
        selectionController.activeUnit.rangeCircle.transform.localScale = new Vector3(range*2, .01f, range*2);
    }


}
