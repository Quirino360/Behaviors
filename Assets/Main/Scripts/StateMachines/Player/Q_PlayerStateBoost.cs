using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
    public class Q_PlayerStateBoost :Q_PlayerState
{
        public Q_PlayerStateBoost() : base()
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_PlayerState OnUpdate(Q_Player character)
        {
            return Q_PlayerSM.BoostingState;
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