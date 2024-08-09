using Quirino;
using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_AIStateFlee : Q_AIState
{
    public Q_AIStateFlee() : base()
    {

    }

    public override void OnEnter()
    {

    }

    public override Q_AIState OnUpdate(Q_AI ai)
    {
        return Q_AISM.FleeingState;
    }

    public override Q_AIState OnFixedUpdate(Q_AI ai)
    {
        return Q_AISM.FleeingState;
    }

    public override void OnExit()
    {

    }
    public override void OnRender(Q_AI ai)
    {

    }
}