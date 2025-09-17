using Unity.Mathematics;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class GridCell : MonoBehaviour
    {
        private Gem _currentGem;
        public int2 Index { get; private set; }
        internal void Initialize(int x, int y)
        {
            Index = new int2(x, y);
        }
        internal Gem GetCurrentGem()
        {
            return _currentGem;
        }
        public void SetCurrentGem(Gem gem)
        {
            _currentGem = gem;
            if (gem != null)
                gem.SetCurrentCell(this);
        }

        public void ClearGem()
        {
            if (_currentGem != null)
            {
                _currentGem.SetCurrentCell(null);
                _currentGem = null;
            }
        }
    }
}