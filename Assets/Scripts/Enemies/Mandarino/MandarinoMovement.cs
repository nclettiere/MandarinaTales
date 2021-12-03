using UnityEngine;

namespace Enemies.Mandarino
{
    public class MandarinoMovement : EnemyMovement
    {
        [SerializeField] private float walkSpeed;

        public void Walk()
        {
            if(CheckWall())
                Flip();
            Move(walkSpeed);
        }
    }
}