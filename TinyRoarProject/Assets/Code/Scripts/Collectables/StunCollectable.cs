using UnityEngine;

public class StunCollectable : Collectable
{

    private void OnTriggerEnter(Collider other)
    {
        IStunnable stunnable = other.GetComponent<IStunnable>();
        if (stunnable != null)
        {
            stunnable.TriggerStun(Duration);
            ReturnToPool();
        }
    }

    public override void ReturnToPool()
    {
        CollectableManager.Instance.StunCollectableSpawned--;
        StartCoroutine(CollectableManager.Instance.SpawnStunCollectable());
        StunCollectablePool.Instance.ReturnToPool(this);
    }
}
