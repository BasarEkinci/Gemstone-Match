using System.Collections.Generic;
using _GameFolders.Scripts.Data.ScriptableObjects;
using _GameFolders.Scripts.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GameFolders.Scripts.Functionaries
{
    public class GridGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform gridCellParent;
        [SerializeField] private LevelDataSO levelDataSo;
        [SerializeField] private GridCell gridCell;
        
        [Header("Grid Settings")]
        [SerializeField] private Vector2 gridStartPosition;
        [SerializeField] private float gridSpacing = 0.1f;
        [SerializeField] private int gridWidth = 5;
        [SerializeField] private int gridHeight = 5;

        [Header("Cell Settings")]
        [SerializeField] private float cellSize = 1f;

        public List<GridCell> GridListCells => _gridList;
        public int GridWidth => gridWidth;
        public int GridHeight => gridHeight;
        private List<GridCell> _gridList;
        
        [Button("Create Grids", ButtonSizes.Large, ButtonStyle.FoldoutButton, Expanded = false)]
        private void CreateGrid()
        {
            ClearGrids();
            _gridList ??= new List<GridCell>();
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    Vector2 spawnPos = new Vector2(gridStartPosition.x + x * gridSpacing, gridStartPosition.y + y * gridSpacing);
                    GridCell newGrid = Instantiate(gridCell, spawnPos, Quaternion.identity, gridCellParent);
                    newGrid.transform.localScale = Vector3.one * cellSize;
                    newGrid.Initialize(x, y);
                    _gridList.Add(newGrid);
                    newGrid.name = $"Grid_{x}_{y}";
                }
            }
        }
        
        [Button("Reorder Grids", ButtonSizes.Large, ButtonStyle.FoldoutButton, Expanded = false)]
        private void ReorderGrids()
        {
            if (_gridList == null)
                return;

            foreach (var cell in _gridList)
            {
                cell.transform.localScale = Vector3.one * cellSize;
            }
            
            int i = 0;
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    
                    _gridList[i].transform.position = new Vector2(gridStartPosition.x + x * gridSpacing, gridStartPosition.y + y * gridSpacing);
                    i++;
                }
            }
        }
        
        [Button("Clear Grids", ButtonSizes.Large, ButtonStyle.FoldoutButton, Expanded = false)]
        private void ClearGrids()
        {
            if (_gridList == null)
                return;
            
            foreach (var grid in _gridList)
                DestroyImmediate(grid);
            _gridList.Clear();
        }
    }
}
