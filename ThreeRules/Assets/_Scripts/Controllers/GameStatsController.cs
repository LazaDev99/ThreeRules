using System.Collections.Generic;
using Game.Utilities;
using UnityEngine;
using System;


namespace Game.Controllers
{
    /// <summary>
    /// Singleton that keeps track a player statistics for each mini-game
    /// </summary>
    public class GameStatsController : Singleton<GameStatsController>
    {

        /*
        private Dictionary<MiniGameType, (float worstTime, float bestTime)> stats = new Dictionary<MiniGameType, (float worstTime, float bestTime)>
        {
            {MiniGameType.TwoD, (0f, float.MaxValue) },
            {MiniGameType.ThreeD, (0f, float.MaxValue) }
        };
        */

        private const string PREFS_BEST_TIME_PREFIX = "BestTime_";
        private const string PREFS_WORST_TIME_PREFIX = "WorstTime_";

        
        protected override void Awake()
        {
            base.Awake();
            InitializeStats();
        }



        /// <summary>
        /// Update game stats based on mini game we've played.
        /// </summary>
        /// <param name="miniGameType"></param>
        /// <param name="time"></param>
        public void UpdateGameStats(float time)
        {
            /*
            var statistic = stats[miniGameType];

            if (time < statistic.bestTime)
            {
                statistic.bestTime = time;
                PlayerPrefs.SetFloat(PREFS_BEST_TIME_PREFIX + miniGameType, time);
            }

            if (time > statistic.worstTime)
            {
                statistic.worstTime = time;
                PlayerPrefs.SetFloat(PREFS_WORST_TIME_PREFIX + miniGameType, time);
            }

            stats[miniGameType] = statistic;
            PlayerPrefs.Save();
            */
        }



        /// <summary>
        /// Resets all stored statistics to initial values.
        /// </summary>
        public void ResetGameStats()
        {
            /*
            foreach (var miniGameType in Enum.GetValues(typeof(MiniGameType)))
            {
                stats[(MiniGameType)miniGameType] = (0f, float.MaxValue);
                PlayerPrefs.SetFloat(PREFS_BEST_TIME_PREFIX + miniGameType, float.MaxValue);
                PlayerPrefs.SetFloat(PREFS_WORST_TIME_PREFIX + miniGameType, 0f);
            }
            PlayerPrefs.Save();
           */
        }



        /// <summary>
        /// Getter for best and worst game time.
        /// </summary>
        /// <returns></returns>
        //public float GetBestGameTime( MiniGameType miniGameType) => stats[miniGameType].bestTime;
        //public float GetWorstGameTime(MiniGameType miniGameType) => stats[miniGameType].worstTime;



        /// <summary>
        /// Initializes statistics with saved values from PlayerPrefs or defaults.
        /// </summary>
        private void InitializeStats()
        {
            /*
            foreach (MiniGameType miniGameType in Enum.GetValues(typeof(MiniGameType)))
            {
                float savedBestTime = PlayerPrefs.GetFloat(PREFS_BEST_TIME_PREFIX + miniGameType, float.MaxValue);
                float savedWorstTime = PlayerPrefs.GetFloat(PREFS_WORST_TIME_PREFIX + miniGameType, 0f);
                stats[miniGameType] = (savedWorstTime, savedBestTime);
            }
            */
        }

    }
}
