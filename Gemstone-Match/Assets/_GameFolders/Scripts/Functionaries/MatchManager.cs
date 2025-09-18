using System.Collections.Generic;
using _GameFolders.Scripts.Objects;
using UnityEngine;

namespace _GameFolders.Scripts.Functionaries
{
    public class MatchManager : MonoBehaviour
    {
        [SerializeField] private GridGenerator gridGenerator;

        private void Update()
        {
            if (CheckMatches().Count > 0)
            {
                List<Gem> matches = CheckMatches();
                foreach (var gem in matches)
                {
                    gem.Match();
                }
            }
        }
        public List<Gem> CheckMatches()
        {
            List<Gem> matchedGems = new List<Gem>();
            int width = gridGenerator.GridWidth;
            int height = gridGenerator.GridHeight;
            GridCell[,] grid = gridGenerator.GridCells;
            
            for (int y = 0; y < height; y++)
            {
                int matchCount = 1;
                for (int x = 1; x < width; x++)
                {
                    Gem current = grid[x, y].GetCurrentGem();
                    Gem previous = grid[x - 1, y].GetCurrentGem();

                    if (current != null && previous != null && current.Type == previous.Type)
                    {
                        matchCount++;
                    }
                    else
                    {
                        if (matchCount >= 3)
                        {
                            for (int k = 0; k < matchCount; k++)
                            {
                                Gem gem = grid[x - 1 - k, y].GetCurrentGem();
                                if (!matchedGems.Contains(gem))
                                    matchedGems.Add(gem);
                            }
                        }
                        matchCount = 1;
                    }
                }
                
                if (matchCount >= 3)
                {
                    for (int k = 0; k < matchCount; k++)
                    {
                        Gem gem = grid[width - 1 - k, y].GetCurrentGem();
                        if (!matchedGems.Contains(gem))
                            matchedGems.Add(gem);
                    }
                }
            }
            
            for (int x = 0; x < width; x++)
            {
                int matchCount = 1;
                for (int y = 1; y < height; y++)
                {
                    Gem current = grid[x, y].GetCurrentGem();
                    Gem previous = grid[x, y - 1].GetCurrentGem();

                    if (current != null && previous != null && current.Type == previous.Type)
                    {
                        matchCount++;
                    }
                    else
                    {
                        if (matchCount >= 3)
                        {
                            for (int k = 0; k < matchCount; k++)
                            {
                                Gem gem = grid[x, y - 1 - k].GetCurrentGem();
                                if (!matchedGems.Contains(gem))
                                    matchedGems.Add(gem);
                            }
                        }
                        matchCount = 1;
                    }
                }
                
                if (matchCount >= 3)
                {
                    for (int k = 0; k < matchCount; k++)
                    {
                        Gem gem = grid[x, height - 1 - k].GetCurrentGem();
                        if (!matchedGems.Contains(gem))
                            matchedGems.Add(gem);
                    }
                }
            }
            return matchedGems;
        }
    }
}