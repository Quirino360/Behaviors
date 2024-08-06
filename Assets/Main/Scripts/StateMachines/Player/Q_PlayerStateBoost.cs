using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
    public class Q_PlayerStateBoost :Q_PlayerState
{
        public Q_PlayerStateBoost(PlayerController player, Q_PlayerSM fsm) : base(player, fsm)
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_PlayerState OnUpdate()
        {
            return m_fsm.BoostingState;
        }

        public override Q_PlayerState OnFixedUpdate()
        {
            return m_fsm.BoostingState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender()
        {

        }
    }
}