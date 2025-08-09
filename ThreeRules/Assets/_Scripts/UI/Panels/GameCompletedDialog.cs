using UnityEngine.SceneManagement;
using Game.MiniGame2D.Managers;
using Game.Controllers;
using Game.Utilities;
using UnityEngine.UI;
using UnityEngine;
using TMPro;




namespace Game.UI.Dialogs
{
    /// <summary>
    /// Class representing the game completed dialog in the game.
    /// Inherits from BaseDialog and provides functionality for the game completed state.
    /// </summary>
    public class GameCompletedDialog : BaseDialog
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Button playAgainButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private TextMeshProUGUI time;

        protected override void Awake()
        {
            base.Awake();
            dialogType = DialogType.GameCompleted;
            
            // Button listeners
            homeButton.onClick.AddListener(() => HomeButton(SceneIndexes.EntryUI));
            playAgainButton.onClick.AddListener(() =>
            {
                AudioController.Instance.PlaySound(clickSFX);
                MiniGame2DManager.Instance.RestartGame();
            });
            closeButton.onClick.AddListener(() => HomeButton(SceneIndexes.EntryUI));
        }

        public override void Open()
        {
            base.Open();

            UpdateTextTIme();
        }

        private void UpdateTextTIme()
        {
            float timeElapsed = TimerManager.Instance.GetTimeElapsed();
            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);
            time.text = $"{minutes:00}:{seconds:00}";
        }

        private void HomeButton(SceneIndexes sceneIndex)
        {
            AudioController.Instance.PlaySound(clickSFX);
            SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Single);
        }
    }
}
