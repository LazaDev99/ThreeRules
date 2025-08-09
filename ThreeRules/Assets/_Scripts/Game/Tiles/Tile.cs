using Game.MiniGame2D.Managers;
using UnityEngine;

namespace Game.MiniGame2D.Tiles
{
    /// <summary>
    /// Represents a tile in the game world, providing functionality to manage its position and type.
    /// </summary>
    public class Tile : MonoBehaviour
    {
        private Vector2 position;
        //private static float animationDuration = 0.6f;
        [SerializeField] private TileType tileType;
        [SerializeField] private Vector2 startPosition;

        public void Initialize()
        {
            position = startPosition;
            transform.localPosition = new Vector2(startPosition.x, startPosition.y);
        }

        public Vector2 GetPosition()
        {
            position = transform.localPosition;
            return position;
        }
        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
            /*
            LeanTween.moveLocal(gameObject, newPosition, animationDuration)
                .setEase(LeanTweenType.easeInOutQuad)
                .setOnComplete(() =>
                {
                    MiniGame2DManager.Instance.AllowRotation();
                });
            */
        }
        public TileType GetTileType()
        {
            return tileType;
        }
    }
}
