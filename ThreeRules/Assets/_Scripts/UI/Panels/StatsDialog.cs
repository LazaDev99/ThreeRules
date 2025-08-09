using Game.Controllers;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


namespace Game.UI.Dialogs
{
    /// <summary>
    /// Class representing the stats dialog in the game.
    /// Inherits from BaseDialog and provides functionality for displaying and resetting game statistics.
    /// </summary>
    public class StatsDialog : BaseDialog
    {
        [SerializeField] private Button resetStatsButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private TextMeshProUGUI bestTime2D;
        [SerializeField] private TextMeshProUGUI worstTime2D;
        protected override void Awake()
        {
            base.Awake();
            dialogType = DialogType.Stats;

            // Button listeners
            resetStatsButton.onClick.AddListener(() => ResetStats());
            closeButton.onClick.AddListener(() => 
            { 
                DialogsController.Instance.HideDialog(dialogType); 
                AudioController.Instance.PlaySound(clickSFX); 
            });
        }

        public override void Open()
        {
            base.Open();
            SetStats();
        }

        private void SetStats()
        {
            float timeElapsed = 0;//GameStatsController.Instance.GetBestGameTime(MiniGameType.TwoD);
            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);
            if (timeElapsed != float.MaxValue)
                bestTime2D.text = $"{minutes:00}:{seconds:00}";
            else
                bestTime2D.text = $"{00:00}:{00:00}";

            timeElapsed = 0;//GameStatsController.Instance.GetWorstGameTime(MiniGameType.TwoD);
            minutes = Mathf.FloorToInt(timeElapsed / 60);
            seconds = Mathf.FloorToInt(timeElapsed % 60);
            worstTime2D.text = $"{minutes:00}:{seconds:00}";
        }

        private void ResetStats()
        {
            AudioController.Instance.PlaySound(clickSFX);
            GameStatsController.Instance.ResetGameStats();
            SetStats();
        }
    }
}
