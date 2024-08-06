using Quirino;
using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_AIStateFlee : Q_AIState
{
    public Q_AIStateFlee(Q_AI player, Q_AISM fsm) : base(player, fsm)
    {

    }

    public override void OnEnter()
    {

    }

    public override Q_AIState OnUpdate()
    {
        return m_fsm.FleeingState;
    }

    public override Q_AIState OnFixedUpdate()
    {
        return m_fsm.FleeingState;
    }

    public override void OnExit()
    {

    }
    public override void OnRender()
    {

    }
}