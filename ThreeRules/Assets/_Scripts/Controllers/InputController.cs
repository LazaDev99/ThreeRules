using UnityEngine.SceneManagement;
using Game.MiniGame2D.Managers;
using Game.UI.Dialogs;
using Game.Utilities;
using UnityEngine;



namespace Game.Controllers
{
    /// <summary>
    /// Responsible for handling input related to dialog interactions.
    /// It listens for the Escape key to hide dialogs or show the quit dialog.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().buildIndex == (int)SceneIndexes.EntryUI)
                {
                    var controller = DialogsController.Instance;
                    var currentDialog = controller.GetCurrentActiveDialog();
                    if (currentDialog != null)
                    {
                        if (currentDialog.dialogType == DialogType.MainMenu)
                            controller.ShowDialog(DialogType.Quit);
                        else
                            controller.HideDialog(currentDialog.dialogType);
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == (int)SceneIndexes.Game)
                {
                    MiniGame2DManager.Instance.PauseGame(); 
                }
            }
        }
    }
}
