using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class FollowerBehaviour : AIBase
    {
        public void SetTarget(Player player, int index)
        {
            if (index < 0)
            {
                SetTarget(player.transform);
                return;
            }
            
            SetTarget(player.followers[index].transform);
        }
    }
}