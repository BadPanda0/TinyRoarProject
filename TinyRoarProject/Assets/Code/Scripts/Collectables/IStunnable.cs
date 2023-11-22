using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStunnable
{

    public void TriggerStun(float duration);

    IEnumerator Stun(float duration);
}
