using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private IInteractable _current = null;
    private UIManager _uiManager;

    void Start()
    {
        _uiManager = UIManager.GetInstance();
    }

    void Update()
    {
        TryHover();
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryHover()
    {
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPosition);

        if (hitCollider != null)
        {
            IInteractable interactableObject = hitCollider.GetComponent<IInteractable>();
            _current = interactableObject;
            if (_current != null && _current.enabled)
            {
                _uiManager.SetInteractText(_current.prompt);
            }
            else
            {
                _uiManager.SetInteractText();
            }
        }
        else
        {
            _uiManager.SetInteractText();
        }
    }

    private void TryInteract()
    {
        if (_current != null)
        {
            _current.Interact();
        }
    }
}