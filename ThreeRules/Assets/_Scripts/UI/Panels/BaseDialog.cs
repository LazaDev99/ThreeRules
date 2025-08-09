using System.Collections;
using Game.Scriptables;
using UnityEngine;


namespace Game.UI.Dialogs
{
    /// <summary>
    /// Base class for all dialog types in the game.
    /// This class provides common functionality for dialogs, such as opening and closing animations.
    /// </summary>

    public class BaseDialog : MonoBehaviour
    {
        protected Animator animator;
        [SerializeField] public AudioData clickSFX;
        public DialogType dialogType;


        protected virtual void Awake()
        {
            animator = GetComponent<Animator>();
            
            if (animator == null)
                animator = gameObject.AddComponent<Animator>();
        }



        /// <summary>
        /// Controler for opening the dialog with animation.
        /// </summary>
        public virtual void Open()
        {
            gameObject.SetActive(true);
            animator?.Play("DialogOpen");
        }



        /// <summary>
        /// Controler for closing the dialog with delay.
        /// </summary>
        public virtual void Close()
        {
            animator?.Play("DialogClose");
            StartCoroutine(DelayedClose());
        }
        private IEnumerator DelayedClose()
        {
            yield return new WaitForSeconds(0.4f);
            gameObject.SetActive(false);
        }

    }
}
