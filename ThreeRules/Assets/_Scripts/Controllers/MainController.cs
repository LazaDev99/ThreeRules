using UnityEngine.SceneManagement;
using Game.Scriptables;
using Game.Utilities;
using UnityEngine;
using System;


namespace Game.Controllers
{
    /// <summary>
    /// MainController is a singleton class that manages the main game logic.
    /// It inherits from DontDestroySingleton to ensure it persists across scenes.
    /// </summary>
    public class MainController : DontDestroySingleton<MainController>
    {
        [SerializeField] private AudioData bgMusic;
        public event Action<Scene, LoadSceneMode> OnSceneLoaded;

        
        protected override void Awake()
        {
            base.Awake();
            SceneManager.sceneLoaded += OnSceneChanged;
        }
        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneChanged; // Unsubscribe to avoid memory leaks
        }



        /// <summary>
        /// Handles scene changes by subscribing to the SceneManager's sceneLoaded event.
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="mode"></param>
        private void OnSceneChanged(Scene scene, LoadSceneMode mode)
        {
            OnSceneLoaded?.Invoke(scene, mode);
            HandleSceneLogic((SceneIndexes) scene.buildIndex);
        }



        /// <summary>
        /// Method for scene control. 
        /// Also, we can delete OnAwake() functions in Controllers and manage all initializations from here. 
        /// </summary>
        /// <param name="sceneIndexes"></param>
        private void HandleSceneLogic(SceneIndexes sceneIndexes)
        {
            switch (sceneIndexes)
            {
                case SceneIndexes.Loading:
                    break;
                case SceneIndexes.EntryUI:
                    HandleMainMenuScene();
                    break;
                case SceneIndexes.Game:
                    HandleMiniGame2DScene();
                    break;
                default:
                    break;
            }
        }



        /// <summary>
        /// Method used to set up main scene.
        /// </summary>
        private void HandleMainMenuScene()
        {
            if (!AudioController.Instance.IsMusicPlaying())
                AudioController.Instance.PlaySound(bgMusic);

            DialogsController.Instance.TurnDialogOn(UI.Dialogs.DialogType.MainMenu);
        }



        /// <summary>
        /// Method used to set up scene for 2D mini game.
        /// </summary>
        private void HandleMiniGame2DScene()
        {
            DialogsController.Instance.TurnDialogOff();
        }
    }
}
