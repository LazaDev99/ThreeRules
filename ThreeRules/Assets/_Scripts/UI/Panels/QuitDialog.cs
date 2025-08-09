using Game.Controllers;
using UnityEngine.UI;
using UnityEngine;

namespace Game.UI.Dialogs
{
    /// <summary>
    /// Class representing the quit dialog in the game.
    /// Inherits from BaseDialog and provides functionality for quitting the game.
    /// </summary>
    public class QuitDialog : BaseDialog
    {
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;
        [SerializeField] private Button closeButton;

        protected override void Awake()
        {
            base.Awake();
            dialogType = DialogType.Quit;

            // Button listeners
            yesButton.onClick.AddListener(OnYesButtonClicked);

            noButton.onClick.AddListener(() =>
            {
                DialogsController.Instance.HideDialog(dialogType);
                AudioController.Instance.PlaySound(clickSFX);
            });

            closeButton.onClick.AddListener(() =>
            {
                DialogsController.Instance.HideDialog(dialogType);
                AudioController.Instance.PlaySound(clickSFX);
            });
        }

        private void OnYesButtonClicked()
        {
            AudioController.Instance.PlaySound(clickSFX);
            Application.Quit();

            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}
