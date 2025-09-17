using System.Collections.Generic;
using _GameFolders.Scripts.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GameFolders.Scripts.Functionaries
{
    public class GemGenerator : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;
        [SerializeField] private List<Gem> gems;
        [SerializeField] private Transform gemParent;

        [Button("Create Gems", ButtonSizes.Large, ButtonStyle.FoldoutButton, Expanded = false)]
        private void CreateGems()
        {
            for (int x = 0; x < gridGenerator.GridWidth; x++)
            {
                for (int y = 0; y < gridGenerator.GridHeight; y++)
                {
                    int randomIndex = Random.Range(0, gems.Count);

                    while (IsMatchAt(x, y, gems[randomIndex].Type))
                    {
                        randomIndex = Random.Range(0, gems.Count);
                    }

                    Gem newGem = Instantiate(gems[randomIndex], gemParent);
                    newGem.SetCurrentCell(gridGenerator.GridCells[x, y]);
                    newGem.MoveTo(newGem.GetCurrentCell().transform);
                }
            }   
        }

        private bool IsMatchAt(int x, int y, GemType gemType)
        {
            if (x >= 2)
            {
                Gem left1 = gridGenerator.GridCells[x - 1, y].GetCurrentGem();
                Gem left2 = gridGenerator.GridCells[x - 2, y].GetCurrentGem();

                if (left1 != null && left2 != null && left1.Type == gemType && left2.Type == gemType)
                {
                    return true;
                }
            }

            if (y >= 2)
            {
                Gem down1 = gridGenerator.GridCells[x, y - 1].GetCurrentGem();
                Gem down2 = gridGenerator.GridCells[x, y - 2].GetCurrentGem();

                if (down1 != null && down2 != null &&
                    down1.Type == gemType && down2.Type == gemType)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
