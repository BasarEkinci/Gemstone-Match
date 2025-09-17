using _GameFolders.Scripts.Objects;
using UnityEngine;

namespace _GameFolders.Scripts.Functionaries
{
    public class GridGenerator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform gridCellParent;
        [SerializeField] private GridCell gridCellPrefab;

        [Header("Grid Settings")]
        [SerializeField] private int gridWidth = 5;
        [SerializeField] private int gridHeight = 5;
        [SerializeField] private float cellSize = 1f;
        [SerializeField] private float gridSpacing = 0.1f;

        public GridCell[,] GridCells { get; private set; }
        public int GridWidth => gridWidth;
        public int GridHeight => gridHeight;

        private void CreateGrid()
        {
            ClearGrids();
            GridCells = new GridCell[gridWidth, gridHeight];
            
            float totalWidth = gridWidth * cellSize + (gridWidth - 1) * gridSpacing;
            float totalHeight = gridHeight * cellSize + (gridHeight - 1) * gridSpacing;
            
            Vector2 startPos = new Vector2(-totalWidth / 2f + cellSize / 2f, -totalHeight / 2f + cellSize / 2f);

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    Vector2 spawnPos = new Vector2(
                        startPos.x + x * (cellSize + gridSpacing),
                        startPos.y + y * (cellSize + gridSpacing)
                    );

                    GridCell newCell = Instantiate(gridCellPrefab, spawnPos, Quaternion.identity, gridCellParent);
                    newCell.transform.localScale = Vector3.one * cellSize;
                    newCell.Initialize(x, y);
                    newCell.name = $"Grid_{x}_{y}";
                    GridCells[x, y] = newCell;
                }
            }
        }

        private void ClearGrids()
        {
            if (gridCellParent == null) return;
            foreach (Transform child in gridCellParent)
                Destroy(child.gameObject);

            GridCells = null;
        }
    }
}
