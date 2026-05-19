using UnityEngine;

public interface IInteractable
{
    bool enabled { get;  set;}

    string prompt { get; set;}
    void Interact();
}