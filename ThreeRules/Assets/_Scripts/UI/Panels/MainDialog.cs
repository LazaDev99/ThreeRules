using Game.Controllers;
using UnityEngine.UI;
using UnityEngine;


namespace Game.UI.Dialogs
{
    /// <summary>
    /// Class representing the main dialog in the game.
    /// Inherits from BaseDialog and provides functionality for the main menu.
    /// </summary>
    public class MainDialog : BaseDialog
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button statsButton;
        [SerializeField] private Button quitButton;
        protected override void Awake()
        {
            base.Awake();
            dialogType = DialogType.MainMenu;

            // Button listeners
            playButton.onClick.AddListener(() =>
            {
                DialogsController.Instance.ShowDialog(DialogType.ChoseGame);
                AudioController.Instance.PlaySound(clickSFX);
            });

            settingsButton.onClick.AddListener(() =>
            {
                DialogsController.Instance.ShowDialog(DialogType.Settings);
                AudioController.Instance.PlaySound(clickSFX);
            });

            statsButton.onClick.AddListener(() =>
            {
                DialogsController.Instance.ShowDialog(DialogType.Stats);
                AudioController.Instance.PlaySound(clickSFX);
            });

            quitButton.onClick.AddListener(() =>
            {
                DialogsController.Instance.ShowDialog(DialogType.Quit);
                AudioController.Instance.PlaySound(clickSFX);
            });
        }
    }
}

