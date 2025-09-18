using _GameFolders.Scripts.Objects;
using DG.Tweening;
using UnityEngine;

namespace _GameFolders.Scripts.Functionaries
{
    public class GemSelector : MonoBehaviour
    {
        private Gem _firstGem;
        private Gem _secondGem;
        private bool _canSwap;
        private void Update()
        {
            if (Input.GetMouseButton(0))
            { 
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (hit.collider == null)
                {
                    return;
                }
                if (hit.collider.TryGetComponent(out Gem gem))
                {
                    if (_secondGem != null || !_canSwap)
                    {
                        return;
                    }
                    if (_firstGem == null)
                    {
                        _firstGem = gem;
                    }
                    else if (_firstGem != null && _firstGem != gem)
                    {
                        _secondGem = gem;
                        if (IsNearBy(_firstGem,_secondGem))
                        {
                            SwapGems(_firstGem, _secondGem).OnComplete(() =>
                            {
                                _firstGem = null;
                                _secondGem = null;
                                _canSwap = false;
                            });
                        }
                        else
                        {
                            _firstGem = gem;
                            _secondGem = null;
                        }
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _canSwap = true;
            }
        }
        
        private bool IsNearBy(Gem selected, Gem target)
        {
            int selectX = selected.GetCurrentCell().Index.x;
            int selectY = selected.GetCurrentCell().Index.y;
            int targetX = target.GetCurrentCell().Index.x;
            int targetY = target.GetCurrentCell().Index.y;

            if (selectX == targetX && Mathf.Abs(selectY - targetY) == 1 || selectY == targetY && Mathf.Abs(selectX - targetX) == 1)
            {
                return true;
            }
            return false;
        }

        private Sequence SwapGems(Gem first, Gem second)
        {
            GridCell firstCell = first.GetCurrentCell();
            GridCell secondCell = second.GetCurrentCell();
            Sequence sequence = DOTween.Sequence();
            sequence.Join(first.MoveTo(secondCell.transform));
            sequence.Join(second.MoveTo(firstCell.transform));
            second.SetCurrentCell(firstCell);
            first.SetCurrentCell(secondCell);
            return sequence;
        }
    }
}