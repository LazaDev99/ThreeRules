using Game.MiniGame2D.Managers;
using UnityEngine;

namespace Game.MiniGame2D.Tiles
{
    /// <summary>
    /// This class handles the interaction with the tile rotation buttons.
    /// When clicked, it plays a sound and rotates the tiles in the specified group.
    /// </summary>
    public class RotationButton : MonoBehaviour
    {
        [SerializeField] private TileRotationGroup groupID;

        private void OnMouseDown()
        {
            MiniGame2DManager.Instance.Rotate(groupID);
        }
    }
}
