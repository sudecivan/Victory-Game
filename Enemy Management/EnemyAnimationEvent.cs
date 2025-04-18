using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    public event System.Action OnDying;

    // This method should be called from the "Dying" animation state's animation event
    public void TriggerDyingEvent()
    {
        if (OnDying != null)
        {
            OnDying.Invoke();
        }
    }
}

