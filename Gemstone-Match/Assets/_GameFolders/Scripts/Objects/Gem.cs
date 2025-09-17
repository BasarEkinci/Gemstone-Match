using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public enum GemType
    {
        Red,
        Blue,
        Green,
        Yellow
    }
    public class Gem : MonoBehaviour
    {
        [SerializeField] private GemType type;

        private GridCell _currentCell;
        public GemType Type => type;
        internal void SetCurrentCell(GridCell cell)
        {
            _currentCell = cell;
            cell.SetCurrentGem(this);
        }
        internal GridCell GetCurrentCell()
        {
            return _currentCell;
        }

        internal void MoveTo(Transform cellTransform)
        {
            transform.position = cellTransform.position;
        }
    }
}