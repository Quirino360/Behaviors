using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
    public class Q_AIStateIdle : Q_AIState
    {
        public Q_AIStateIdle() : base()
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_AIState OnUpdate(Q_AI ai)
        {

            return Q_AISM.IdleState;
        }

        public override Q_AIState OnFixedUpdate(Q_AI ai)
        {
            return Q_AISM.IdleState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender(Q_AI ai)
        {

        }
    }
}