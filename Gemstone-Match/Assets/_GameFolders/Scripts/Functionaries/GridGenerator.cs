using System.Collections.Generic;
using System.Linq;
using _GameFolders.Scripts.Data.ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GameFolders.Scripts.Functionaries
{
    public class GridGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform gridCellParent;
        [SerializeField] private LevelDataSO levelDataSo;
        [SerializeField] private GameObject gridPrefab;
        
        [Header("Grid Settings")]
        [SerializeField] private Vector2 gridStartPosition;
        [SerializeField] private float gridSpacing = 0.1f;
        [SerializeField] private int gridWidth = 5;
        [SerializeField] private int gridHeight = 5;

        [Header("Cell Settings")]
        [SerializeField] private float cellSize = 1f;
        
        private List<GameObject> _grids;
        
        [Button("Create Grids", ButtonSizes.Large, ButtonStyle.FoldoutButton, Expanded = false)]
        private void CreateGrid()
        {
            ClearGrids();
            _grids ??= new List<GameObject>();
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    Vector2 spawnPos = new Vector2(gridStartPosition.x + x * gridSpacing, gridStartPosition.y + y * gridSpacing);
                    GameObject newGrid = Instantiate(gridPrefab, spawnPos, Quaternion.identity, gridCellParent);
                    newGrid.transform.localScale = Vector3.one * cellSize;
                    _grids.Add(newGrid);
                    newGrid.name = $"Grid_{x}_{y}";
                }
            }
        }
        
        [Button("Reorder Grids", ButtonSizes.Large, ButtonStyle.FoldoutButton, Expanded = false)]
        private void ReorderGrids()
        {
            if (_grids == null)
                return;

            foreach (var cell in _grids)
            {
                cell.transform.localScale = Vector3.one * cellSize;
            }
            
            int i = 0;
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    
                    _grids[i].transform.position = new Vector2(gridStartPosition.x + x * gridSpacing, gridStartPosition.y + y * gridSpacing);
                    i++;
                }
            }
        }
        
        [Button("Clear Grids", ButtonSizes.Large, ButtonStyle.FoldoutButton, Expanded = false)]
        private void ClearGrids()
        {
            if (_grids == null)
                return;
            
            foreach (var grid in _grids.ToList())
            {
                _grids.Remove(grid);
                DestroyImmediate(grid);
            }
        }
    }
}
