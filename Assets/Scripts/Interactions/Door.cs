using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable 
{
    public bool enabled {get; set;} = true;
    public string prompt {get; set;} = "E to open door";
    private BoxCollider2D _collider;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();

        _collider.isTrigger = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Interact();
        }
    }

    public void Interact()
    {
        _collider.isTrigger = !_collider.isTrigger;
        if (_collider.isTrigger) // Opens the door
        {
            prompt = "E to close door";
        }
        else // Closes the door
        {
            prompt = "E to open door";
        }
    }
}