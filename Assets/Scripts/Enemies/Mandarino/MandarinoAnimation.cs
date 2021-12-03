using System;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies.Mandarino
{
    public class MandarinoAnimation : EnemyAnimation
    {
        public UnityEvent onRollStartedEvent;
        public UnityEvent onRollEndedEvent;
        private static readonly int StartRoll = Animator.StringToHash("StartRoll");
        private static readonly int Walk = Animator.StringToHash("Walk");

        private void Awake()
        {
            if (onRollStartedEvent == null)
                onRollStartedEvent = new UnityEvent();
            if (onRollEndedEvent == null)
                onRollEndedEvent = new UnityEvent();
        }

        public void StartRolling()
        {
            anim.SetBool(StartRoll, true);
        }
        
        public void WalkAnimation(bool shouldWalk)
        {
            anim.SetBool(Walk, shouldWalk);
        }
        
        public override void DeadAnim()
        {
            WalkAnimation(false);
            base.DeadAnim();
        }
        
        public void Anim_OnStartedRolling()
        {
            onRollStartedEvent.Invoke();
        }
        
        public void Anim_OnRollEnded()
        {
            anim.SetBool(StartRoll, false);
            onRollEndedEvent.Invoke();
        }
    }
}