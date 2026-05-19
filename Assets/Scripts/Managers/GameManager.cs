using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerInstance;
    public Camera camera;
    
    // SINGLETON STUFF
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }
    public static GameManager GetInstance()
    {
        return Instance;
    } 
    // END OF SINGLETON STUFF
}
