using Data;
using UI;
using UnityEngine;
using UnityEngine.UIElements;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private UIProfile uiProfile;

    private UIDocument _uiDocument;
    private void Start()
    {
        InitializeSystems();
        InitializeUI();
    }

    private void InitializeSystems()
    {
        // Future systems initialization.
    }

    private void InitializeUI()
    {
        var uiGameObject = new GameObject("UIRoot");
        _uiDocument = uiGameObject.AddComponent<UIDocument>();
        _uiDocument.panelSettings = uiProfile.panelSettings;
        _uiDocument.visualTreeAsset = uiProfile.visualTreeAsset;
        
        // Instantiate controller from UIProfile (optional)
        if(uiProfile.controller != null)
        {
            UIControllerBase instantiatedController = Instantiate(uiProfile.controller, uiGameObject.transform);
            instantiatedController.InitializeUI();
        }
    }
}