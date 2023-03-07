using UnityEngine;

namespace DefaultNamespace
{
    public class FollowerBehaviour : AIBase
    {
        private void SetTarget(Player player, int index)
        {
            if (index == 0)
            {
                SetTarget(player.transform);
                return;
            }
            
            SetTarget(player.followers[index].transform);
        }
    }
}