using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask targetLayer;
    public float baseCoolDown;
    public float remainingCoolDown;
    public Image icon;
    public float range;
    public float castTime;

    public virtual bool AttemptExecuteAbility(Transform controllableUnitTransform)
    {
        return false;
    }

    public void OnCoolDown()
    {
        print("ON COOLDOWN");
    }
    public void OutOfRange()
    {
        print("OUT OF RANGE");
    }

    void Update()
    {
        remainingCoolDown -= Time.deltaTime;
    }
}
