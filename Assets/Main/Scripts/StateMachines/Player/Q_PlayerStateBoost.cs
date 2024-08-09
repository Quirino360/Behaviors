using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Quirino
{
    public class Q_PlayerStateBoost :Q_PlayerState
{
        public Q_PlayerStateBoost() : base()
        {

        }

        public override void OnEnter()
        {
            Debug.Log(" entered boost state");

        }

        public override Q_PlayerState OnUpdate(Q_Player character)
        {
            character.Move();
            if (character.m_input.Player.Boost.IsPressed())
            {
                character.Move();
                return Q_PlayerSM.BoostingState;
            }
            else if (character.m_input.Player.Movement.IsPressed())
            {
                character.Move();
                return Q_PlayerSM.MovingState;
            }

            return Q_PlayerSM.IdleState;
        }

        public override Q_PlayerState OnFixedUpdate(Q_Player character)
        {
            return Q_PlayerSM.BoostingState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender(Q_Player character)
        {

        }
    }
}