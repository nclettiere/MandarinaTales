using UnityEngine;

namespace Enemies.Mandarino
{
    public class MandarinoIA : EnemyIA
    {
        [SerializeField] private float mandarinoRollCooldown = 1f;
        private float mandarinoRollTime = float.NegativeInfinity;
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
                    mandarinoRollTime = Time.time + mandarinoRollCooldown;
                });
        }

        public override void OnUpdate()
        {
            if (controller.died) return;
            
            DoWalk();
            
            if (Time.time >= mandarinoRollTime && (controller.CheckPlayerInNearRange() || controller.CheckPlayerInLongRange()))
            {
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