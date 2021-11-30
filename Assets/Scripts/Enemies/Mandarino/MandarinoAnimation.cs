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