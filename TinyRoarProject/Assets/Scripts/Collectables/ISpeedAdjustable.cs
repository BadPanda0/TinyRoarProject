using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpeedAdjustable
{
    public void TriggerManipulateSpeed(float amount, float duration);

    IEnumerator ManipulateSpeed(float amount, float duration);
}
