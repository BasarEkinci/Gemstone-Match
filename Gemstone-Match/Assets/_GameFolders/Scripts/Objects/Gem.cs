using DG.Tweening;
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
        internal Tween MoveTo(Transform cellTransform,float duration = 0.1f)
        {
            transform.DOKill();
            return transform.DOMove(cellTransform.position, duration);
        }

        internal void Match()
        {
            transform.DOKill();
            transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                _currentCell.ClearGem();
                Destroy(gameObject);
            });
        }
    }
}