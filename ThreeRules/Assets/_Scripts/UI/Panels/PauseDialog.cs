using UnityEngine.SceneManagement;
using Game.MiniGame2D.Managers;
using Game.Controllers;
using Game.Utilities;
using UnityEngine.UI;
using UnityEngine;


namespace Game.UI.Dialogs
{
    /// <summary>
    /// Class representing the pause dialog in the game.
    /// Inherits from BaseDialog and provides functionality for the pause menu.
    /// </summary>
    public class PauseDialog : BaseDialog
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button closeButton;
        protected override void Awake()
        {
            base.Awake();
            dialogType = DialogType.Pause;

            // Button listeners
            homeButton.onClick.AddListener(() => HomeButton(SceneIndexes.EntryUI));
            closeButton.onClick.AddListener(() => HomeButton(SceneIndexes.EntryUI));
            settingsButton.onClick.AddListener(() =>
            {
                AudioController.Instance.PlaySound(clickSFX);
                DialogsController.Instance.ShowDialog(DialogType.Settings);
            });
            resumeButton.onClick.AddListener(() =>
            {
                AudioController.Instance.PlaySound(clickSFX);
                MiniGame2DManager.Instance.ResumeGame();
            });
        }

        private void HomeButton(SceneIndexes sceneIndex)
        {
            AudioController.Instance.PlaySound(clickSFX);
            SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Single);
        }
    }
}
