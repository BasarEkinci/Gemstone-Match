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
        public GridCell CurrentCell { get; private set; }
        public GemType Type => type;
        internal void SetCurrentCell(GridCell cell)
        {
            CurrentCell = cell;
            cell.SetCurrentGem(this);
        }
    }
}