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
            
        }

        public override Q_PlayerState OnUpdate(Q_Player character)
        {
            Debug.Log(character + " is on iddle state");
            if (character.m_input.Player.Movement.IsPressed())
            {
                Debug.Log(character + " is changing to move state");
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