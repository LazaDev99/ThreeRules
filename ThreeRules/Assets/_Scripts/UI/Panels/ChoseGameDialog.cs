using UnityEngine.SceneManagement;
using Game.Controllers;
using UnityEngine.UI;
using Game.Utilities;
using UnityEngine;


namespace Game.UI.Dialogs
{
    /// <summary>
    /// ChoseGameDialog is responsible for allowing the player to choose between different mini-games.
    /// Inherits from BaseDialog to utilize common dialog functionality.
    /// </summary>
    public class ChoseGameDialog : BaseDialog
    {
        [SerializeField] private Button miniGame2DButton;
        [SerializeField] private Button closeButton;


        protected override void Awake()
        {
            base.Awake();
            dialogType = DialogType.ChoseGame;

            // Button listeners
            miniGame2DButton.onClick.AddListener(() => LoadMiniGame(SceneIndexes.Game));
            closeButton.onClick.AddListener(() =>
            {
                DialogsController.Instance.HideDialog(dialogType);
                AudioController.Instance.PlaySound(clickSFX);
            });
        }


        private void LoadMiniGame(SceneIndexes sceneIndex)
        {
            AudioController.Instance.PlaySound(clickSFX);
            SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Single);
        }
    }
}