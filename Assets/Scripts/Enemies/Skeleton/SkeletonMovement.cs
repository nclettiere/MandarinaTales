using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : EnemyMovement
{
    public override void DeadMovement()
    {
        Stop();
    }
}
