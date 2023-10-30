using UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace Data
{
    [CreateAssetMenu(menuName = "UI/UI Profile")]
    public class UIProfile : ScriptableObject
    {
        public PanelSettings panelSettings;
        public VisualTreeAsset visualTreeAsset;
        public UIControllerBase controller;
    }
}