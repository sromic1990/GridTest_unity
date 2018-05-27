using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewGridGame
{
    internal class GridElement : MonoBehaviour 
    {
        public MiningStatus mine;
        public VisitingStatus visit;

        private void OnEnable()
        {
            Reset();
        }

        public void Reset()
        {
            mine = MiningStatus.NotMined;
            visit = VisitingStatus.NotVisited;
        }

        public void SetVisited()
        {
            visit = VisitingStatus.Visited;
        }
        public void SetMined()
        {
            mine = MiningStatus.Mined;
        }

    }

    internal enum MiningStatus
    {
        NotMined,
        Mined
    }

    internal enum VisitingStatus
    {
        NotVisited,
        Visited
    }
    
}