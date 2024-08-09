using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Quirino
{
    public class Q_PlayerStateMove : Q_PlayerState
{
        public Q_PlayerStateMove() : base()
        {

        }

        public override void OnEnter()
        {
            Debug.Log(" entered move state");

        }

        public override Q_PlayerState OnUpdate(Q_Player character)
        {
            if (character.m_input.Player.Boost.IsPressed())
            {
                character.Move();
                return Q_PlayerSM.BoostingState;
            }   
            if (character.m_input.Player.Movement.IsInProgress())
            {
                character.Move();

                return Q_PlayerSM.MovingState;
            }

            return Q_PlayerSM.IdleState;
        }

        public override Q_PlayerState OnFixedUpdate(Q_Player character)
        {
            return Q_PlayerSM.MovingState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender(Q_Player character)
        {

        }
    }
}