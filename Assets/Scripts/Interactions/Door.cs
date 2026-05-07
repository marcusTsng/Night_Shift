using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

// Adding ", IInteractable" signs the contract
public class Door : MonoBehaviour, IInteractable 
{
    // Because we signed the contract, we MUST include this specific function
    public void Interact()
    {
        Debug.Log("test");
        
        // Later, you can put specific code here!
        // e.g., "If book is on floor, move book to shelf."
    }
}