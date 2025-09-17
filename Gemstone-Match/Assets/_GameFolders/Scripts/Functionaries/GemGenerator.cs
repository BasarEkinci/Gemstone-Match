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
            
        }
    }
}
