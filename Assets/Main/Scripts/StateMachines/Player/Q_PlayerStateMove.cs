using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
    public class Q_PlayerStateMove : Q_PlayerState
{
        public Q_PlayerStateMove(PlayerController player, Q_PlayerSM fsm) : base(player, fsm)
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_PlayerState OnUpdate()
        {
            if (m_player.Player.Movement.IsInProgress())
            {
                return m_fsm.MovingState;
            }

            return m_fsm.IdleState;
        }

        public override Q_PlayerState OnFixedUpdate()
        {
            return m_fsm.MovingState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender()
        {

        }
    }
}