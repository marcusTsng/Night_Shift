using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    void Update()
    {
        // Check if the player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        // 1. Convert the mouse position on screen to a position in the 2D game world
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // 2. Check if there is a 2D Collider exactly where the mouse is
        Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPosition);

        if (hitCollider != null)
        {
            // 3. Try to find a script on that object that uses the IInteractable interface
            IInteractable interactableObject = hitCollider.GetComponent<IInteractable>();

            // 4. If it has one, trigger its specific interact function!
            if (interactableObject != null)
            {
                interactableObject.Interact();
            }
        }
    }
}