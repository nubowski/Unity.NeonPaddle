using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI
{
    public class MenuUIController : UIControllerBase
    {
        private Button _startButton;
        private Button _optionsButton;
        private Button _exitButton;

        public override void InitializeUI()
        {
            _startButton = UIDocument.rootVisualElement.Q<Button>("StartButton");
            _optionsButton = UIDocument.rootVisualElement.Q<Button>("OptionsButton");
            _exitButton = UIDocument.rootVisualElement.Q<Button>("ExitButton");

            if (_startButton == null || _optionsButton == null || _exitButton == null)
            {
                Debug.LogError($"Menu buttons not found in the UI document.");
                return;
            }

            _startButton.clicked += StartGame;
            _optionsButton.clicked += OpenOptions;
            _exitButton.clicked += ExitGame;
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void OpenOptions()
        {
            Debug.Log("Options opened!");
        }

        private void StartGame()
        {
            Debug.Log("Game started!");
            SceneManager.LoadScene("Game");
        }
    }
}