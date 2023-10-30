using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UIElements;

namespace UI
{
    public class UILoader : MonoBehaviour
    {
        [SerializeField] private string panelSettingsAddress = "PanelSettings"; 
        [SerializeField] private string uxmlAssetAddress = "MainMenu";

        private UIDocument _uiDocument;

        public void LoadUI()
        {
            var uiGameObject = new GameObject("UIRoot");
            _uiDocument = uiGameObject.AddComponent<UIDocument>();

            LoadPanelSettings();
            LoadUXMLTemplate();
        }

        private void LoadPanelSettings()
        {
            Addressables.LoadAssetAsync<PanelSettings>(panelSettingsAddress).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    _uiDocument.panelSettings = handle.Result;
                }
                else
                {
                    Debug.LogError($"Failed to load PanelSettings from Addressables.");
                }
            };
        }

        private void LoadUXMLTemplate()
        {
            Addressables.LoadAssetAsync<VisualTreeAsset>(uxmlAssetAddress).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    _uiDocument.visualTreeAsset = handle.Result;
                    Addressables.Release(handle);
                }
                else
                {
                    Debug.LogError($"Failed to load UXML asset from Addressables.");
                }
            };
        }
    }
}