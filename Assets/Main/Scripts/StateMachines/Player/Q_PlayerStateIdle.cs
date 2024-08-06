using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace Quirino
{
    public class Q_PlayerStateIdle : Q_PlayerState
    {
        public Q_PlayerStateIdle(PlayerController player, Q_PlayerSM fsm) : base(player, fsm)
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_PlayerState OnUpdate()
        {

            if (m_player.Player.Movement.IsPressed())
            {
                return m_fsm.MovingState;
            }
            return m_fsm.IdleState;
        }

        public override Q_PlayerState OnFixedUpdate()
        {
            return m_fsm.IdleState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender()
        {

        }
    }
}