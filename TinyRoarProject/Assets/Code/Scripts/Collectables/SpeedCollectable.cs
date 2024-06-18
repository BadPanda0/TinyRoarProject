using UnityEngine;

public class SpeedCollectable : Collectable
{

    [SerializeField] private float _amount = 4f;

    private void OnTriggerEnter(Collider other)
    {
        ISpeedAdjustable speedAdjustable = other.GetComponent<ISpeedAdjustable>();
        if (speedAdjustable != null)
        {
            speedAdjustable.TriggerManipulateSpeed(_amount, Duration);

            AudioToPlay.PlayAudio();

            ReturnToPool();
        }
    }

    public override void ReturnToPool()
    {
        CollectableManager.Instance.SpeedCollectableSpawned--;
        StartCoroutine(CollectableManager.Instance.SpawnSpeedCollectable());
        SpeedCollectablePool.Instance.ReturnToPool(this);
    }
}