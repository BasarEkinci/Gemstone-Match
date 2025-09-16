using UnityEngine;

namespace _GameFolders.Scripts.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
    public class LevelDataSO : ScriptableObject
    {
        [SerializeField] private int gridWidth;
        [SerializeField] private int gridHeight;
        
        public int GridWidth => gridWidth;
        public int GridHeight => gridHeight;
    }
}
