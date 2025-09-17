using Unity.Mathematics;
using UnityEngine;

namespace _GameFolders.Scripts.Objects
{
    public class GridCell : MonoBehaviour
    {
        public Gem CurrentGem { get; private set; }
        public int2 Index { get; private set; }
        public void Initialize(int x, int y)
        {
            Index = new int2(x, y);
        }
        public void SetCurrentGem(Gem gem)
        {
            CurrentGem = gem;
        }
        public void ClearCell()
        {
            CurrentGem.SetCurrentCell(null);
            CurrentGem = null;
        }
    }
}