using Quirino;
using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

namespace Quirino
{
    public class Q_AIStatePatrol : Q_AIState
    {
        public Q_AIStatePatrol() : base()
        {

        }

        public override void OnEnter()
        {

        }

        public override Q_AIState OnUpdate(Q_AI ai)
        {
            
            return Q_AISM.PatrolingState;
        }

        public override Q_AIState OnFixedUpdate(Q_AI ai)
        {
            return Q_AISM.PatrolingState;
        }

        public override void OnExit()
        {

        }
        public override void OnRender(Q_AI ai)
        {

        }
    }
}