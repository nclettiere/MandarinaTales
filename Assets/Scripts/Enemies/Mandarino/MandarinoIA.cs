using UnityEngine;

namespace Enemies.Mandarino
{
    public class MandarinoIA : EnemyIA
    {
        private Vector3 playerPosition;
        
        private bool canAttack;

        public override void Start()
        {
            base.Start();
            
            controller.GetEnemyAnimator<MandarinoAnimation>()
                .onRollStartedEvent
                .AddListener(()=> canAttack = true);
            
            controller.GetEnemyAnimator<MandarinoAnimation>()
                .onRollEndedEvent
                .AddListener(()=> canAttack = false);
        }

        public override void OnUpdate()
        {
            if (controller.CheckPlayerInNearRange() || controller.CheckPlayerInLongRange())
            {
                playerPosition = GameManager.GM.playerManager.GetPlayerTransform().position;
                controller.GetEnemyAnimator<MandarinoAnimation>()
                    .StartRolling();
            }
            
            CheckForDamage();
        }

        private void CheckForDamage()
        {
            if (canAttack)
            {
                controller.enemyMovement.Move();
            }
        }
    }
}