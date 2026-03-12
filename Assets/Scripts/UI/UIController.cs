using UnityEngine;
using UnityEngine.UI;
using SoundLab.Core;

namespace SoundLab.UI
{
    public class UIController : MonoBehaviour
    {

        [Header("Panels")]
        [SerializeField] private GameObject _UIPanel;
        [SerializeField] private GameObject _titlePanel;

        // Title Scene 
        [Header("Title")]
        [SerializeField] private Button _enterLabBtn;
        [SerializeField] private Button _titleQuitBtn;


        [Header("UI")]
        [SerializeField] private Button _restartBtn; // The variable for the Inspector
        [SerializeField] private Button _uiQuitBtn;
        [SerializeField] private Button _returnLabBtn;


        //Lab Scene
        // [Header("Lab")]
        //TODO: lab button added for test here
        // [SerializeField] private Button _backToTitleBtn;

        private void Start()
        {
            if (_titlePanel && _UIPanel)
            {
                ShowTitle();
            }
            if (_enterLabBtn) _enterLabBtn.onClick.AddListener(OnEnterLab);
            if (_titleQuitBtn) _titleQuitBtn.onClick.AddListener(OnQuit);
            if (_uiQuitBtn) _uiQuitBtn.onClick.AddListener(OnQuit);
            // if (_backToTitleBtn) _backToTitleBtn.onClick.AddListener(OnBackToTitle);
            if (_restartBtn) _restartBtn.onClick.AddListener(OnRestart);
            if (_returnLabBtn) _returnLabBtn.onClick.AddListener(OnEnterLab);
        }

        // switches scenes
        private void OnEnterLab() => GameController.Instance.Scenes.GoToLab();
        private void OnBackToTitle() => GameController.Instance.Scenes.GoToTitle();

        private void OnQuit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }



        public void ShowUI()
        {
            _titlePanel.SetActive(false);
            _UIPanel.SetActive(true);
        }

        public void ShowTitle()
        {
            _titlePanel.SetActive(true);
            _UIPanel.SetActive(false);
        }
        private void OnRestart()
        {
            Debug.Log("UI Action: Restart triggered. (Logic not yet implemented)");
        }
    }
}
