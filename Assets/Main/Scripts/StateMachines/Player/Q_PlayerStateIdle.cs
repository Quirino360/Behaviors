using Qurino;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using UnityEngine.Windows;

namespace Quirino
{
    public class Q_PlayerStateIdle : Q_PlayerState
    {
        public Q_PlayerStateIdle() : base()
        {

        }

        public override void OnEnter()
        {
            Debug.Log(" entered iddle state");

        }

        public override Q_PlayerState OnUpdate(Q_Player character)
        {

            if (character.m_input.Player.Boost.IsPressed())
            {
                return Q_PlayerSM.BoostingState;
            }
            else if (character.m_input.Player.Movement.IsPressed())
            {

                return Q_PlayerSM.MovingState;
            }

            return Q_PlayerSM.IdleState;
        }

        public override Q_PlayerState OnFixedUpdate(Q_Player character)
        {
            return Q_PlayerSM.IdleState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender(Q_Player character)
        {

        }
    }
}