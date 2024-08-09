using Quirino;
using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
    public class Q_AIStatePersuit : Q_AIState
    {
        public Q_AIStatePersuit() : base()
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_AIState OnUpdate(Q_AI ai)
        {
            return Q_AISM.PersuitState;
        }

        public override Q_AIState OnFixedUpdate(Q_AI ai)
        {
            return Q_AISM.PersuitState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender(Q_AI ai)
        {

        }
    }
}