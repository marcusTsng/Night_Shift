using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gm;
    [SerializeField] private Text _interactTextObj;

    // SINGLETON STUFF
    public static UIManager Instance { get; private set; }

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
    public static UIManager GetInstance()
    {
        return Instance;
    } 
    // END OF SINGLETON STUFF

    void Start()
    {
        _gm = GameManager.GetInstance();

        _interactTextObj.enabled = false;
    }

    void Update()
    {
        CamFollowPlayer();
    }

    // INTERACTION PROMPT SYSTEM
    public void SetInteractText(string text = null)
    {
        _interactTextObj.enabled = text != null;
        if (text != null){_interactTextObj.text = text;}
    }

    // CAMERA
    private void CamFollowPlayer()
    {
        Vector3 plrPos = _gm.playerInstance.transform.position;
        _gm.camera.gameObject.transform.position = new Vector3(plrPos.x, plrPos.y, -10);
    }
}
