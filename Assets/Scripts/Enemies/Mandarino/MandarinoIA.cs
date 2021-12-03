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
                .AddListener(()=> {
                    controller.enemyMovement.Stop();
                    canAttack = false;
                });
        }

        public override void OnUpdate()
        {
            DoWalk();
            
            if (controller.CheckPlayerInNearRange() || controller.CheckPlayerInLongRange())
            {
                playerPosition = GameManager.GM.playerManager.GetPlayerTransform().position;
                controller.GetEnemyAnimator<MandarinoAnimation>()
                    .StartRolling();
                canAttack = true;
            }
            
            CheckForDamage();
        }

        private void CheckForDamage()
        {
            if (canAttack)
            {
                controller.GetEnemyAnimator<MandarinoAnimation>().WalkAnimation(false);
                controller.enemyMovement.Move();
                controller.enemyAttack.DoBasicAttack();
            }
        }

        private void DoWalk()
        {
            if (!canAttack)
            {
                controller.GetEnemyMovement<MandarinoMovement>().Walk();
                controller.GetEnemyAnimator<MandarinoAnimation>().WalkAnimation(true);
            }
        }
    }
}