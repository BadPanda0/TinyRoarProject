using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput _playerInput;
    public GameObject HeldObject = null;
    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    [SerializeField] private Transform _interactionTransform;
    [SerializeField] private float _interactionRadius = 3f;
    [SerializeField] private Transform _handTransform;
    [SerializeField] private LayerMask _interactableMask;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnInteract += Interact;
    }

    private void Interact()
    {
        IInteractable interactable = CanInteract();

        if (interactable != null)
        {
            interactable.Interact(this);
        }

    }

    private IInteractable CanInteract()
    {
        if (HeldObject == null)
        {
            if (_numFound > 0)
            {
                IInteractable interactable = _colliders[0].GetComponent<IInteractable>();
                if (interactable != null)
                    return interactable;
                else
                    return null;
            }
            else
                return null;
        }
        else
        {
            return HeldObject.GetComponent<IInteractable>();
        }

    }

    private void Update()
    {
        if (HeldObject)
        {
            HeldObject.transform.position = _handTransform.position;
            HeldObject.transform.rotation = this.gameObject.transform.rotation;
        }
        else
            _numFound = Physics.OverlapSphereNonAlloc(_interactionTransform.position, _interactionRadius, _colliders, _interactableMask);
    }
}
