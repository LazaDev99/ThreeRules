using System.Collections.Generic;
using Game.UI.Dialogs;
using Game.Utilities;
using UnityEngine;
using System.Linq;

namespace Game.Controllers
{
    /// <summary>
    /// Class responsible for managing dialogs in the game.
    /// Main responsibilities include showing and hiding dialogs.
    /// </summary>
    public class DialogsController : Singleton<DialogsController>
    {

        [SerializeField] private List<BaseDialog> baseDialogs;
        [SerializeField] private GameObject dialogHolder;
        private Dictionary<DialogType, BaseDialog> dialogMap;
        

        protected override void Awake()
        {
            base.Awake();

            if (!BuildDialogMap())
                Debug.Log("Failed to build dialog map.");
        }



        /// <summary>
        /// This method is called to activate the dialog holder and show the dialog of the specified type.
        /// Call if you want to ensure the dialog holder is active and ready for use.
        /// </summary>
        /// <param name="dialogType"></param>
        public void TurnDialogOn(DialogType dialogType)
        {
            if (!dialogHolder.activeSelf)
                dialogHolder.gameObject.SetActive(true);

            HideAllActiveDialogs();

            ShowDialog(dialogType);
        }



        /// <summary>
        /// This method is called to deactivate the dialog holder and hide the dialog of the specified type.
        /// This is useful when you want to close the dialog and hide the dialog holder.
        /// </summary>
        /// <param name="dialogType"></param>
        public void TurnDialogOff()
        {
            HideAllActiveDialogs();

            if (dialogHolder.activeSelf)
                dialogHolder.gameObject.SetActive(false);
        }



        /// <summary>
        /// Displays a dialog of the specified type.
        /// Call this method if you want to switch between different dialogs in the game.
        /// </summary>
        /// <param name="dialogType"></param>
        public void ShowDialog(DialogType dialogType)
        {
            if (dialogMap.TryGetValue(dialogType, out var dialog))
                dialog.Open();
                
        }



        /// <summary>
        /// Closes the dialog of the specified type.
        /// Call this method if you want to swuitch between different dialogs in the game.
        /// </summary>
        /// <param name="dialogType"></param>
        public void HideDialog(DialogType dialogType)
        {
            if (dialogMap.TryGetValue(dialogType, out var dialog))
                dialog.Close();
        }




        /// <summary>
        /// Retrieves the currently active dialog.
        /// This method is created because all dialogs are opened over MainMenu dialog.
        /// </summary>
        /// <returns></returns>
        public BaseDialog GetCurrentActiveDialog()
        {
            return dialogMap.Values.Last(d => d.gameObject.activeSelf);
        }



        /// <summary>
        /// Checks if any dialog is currently active.
        /// </summary>
        /// <returns></returns>
        public bool IsAnyDialogActive()
        {
            return dialogHolder.gameObject.activeSelf;
        }



        /// <summary>
        /// Hides all currently active dialogs.
        /// </summary>
        private void HideAllActiveDialogs()
        {
            foreach (var dialog in GetAllActiveDialogs())
            {
                dialog.gameObject.SetActive(false);
            }
        }



        /// <summary>
        /// Gets a list of all currently active dialogs.
        /// </summary>
        /// <returns></returns>
        private List<BaseDialog> GetAllActiveDialogs()
        {
            return dialogMap.Values.Where(d => d.gameObject.activeSelf).ToList();
        }



        /// <summary>
        /// Fills the dialogMap dictionary with dialogs from baseDialogs based on their DialogType.
        /// Activates each dialog in the process, then deactivates them again, just to ensure they are initialized properly.
        /// </summary>
        /// <returns></returns>
        private bool BuildDialogMap()
        {
            if (dialogMap != null || baseDialogs == null)
                return false;

            dialogMap = new Dictionary<DialogType, BaseDialog>();
            foreach (var dialog in baseDialogs)
            {
                dialog.gameObject.SetActive(true);
                dialogMap[dialog.dialogType] = dialog;
                dialog.gameObject.SetActive(false);
            }
            return true;
        }
    }

}
