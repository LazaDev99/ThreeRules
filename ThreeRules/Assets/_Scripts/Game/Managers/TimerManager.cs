using Game.Utilities;
using UnityEngine;
using TMPro;


namespace Game.MiniGame2D.Managers
{
    /// <summary>
    /// This class is responsible for managing the time while playing the game.
    /// It can be used to start, stop, resume and reset the timer.
    /// </summary>
    public class TimerManager : Singleton<TimerManager>
    {
        [SerializeField] TextMeshProUGUI timer;
        private float timeElapsed;
        private bool startTimer = false;


        /// <summary>
        /// Control and update elapsed time
        /// </summary>
        private void Update()
        {
            if (startTimer)
            {
                timeElapsed += Time.deltaTime;
                UpdateTimerDisplay();
            }
        }



        /// <summary>
        /// Method responsible to set up timer and start it.
        /// </summary>
        public void StartTimer()
        {
            if (timeElapsed != 0)
                timeElapsed = 0f;
            UpdateTimerDisplay();
            startTimer = true;
        }




        /// <summary>
        /// Stop, Resume and Reset methos are created for timer flow control.
        /// </summary>
        public void StopTimer()
        {
            startTimer = false;
        }
        public void ResumeTimer()
        {
            if (timeElapsed == 0f)
                return;

            startTimer = true;
            UpdateTimerDisplay();
        }
        public void ResetTimer()
        {
            if (timeElapsed != 0)
                timeElapsed = 0f;

            UpdateTimerDisplay();
        }



        /// <summary>
        /// Getters for elapsed time and check if timer is running
        /// </summary>
        /// <returns></returns>
        public float GetTimeElapsed()
        {
            return timeElapsed;
        }
        public bool IsTimerRunning()
        {
            return startTimer;
        }

      

        /// <summary>
        /// Method responsible to update time displayed on board in game scene. 
        /// </summary>
        private void UpdateTimerDisplay()
        {
            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);
            timer.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
