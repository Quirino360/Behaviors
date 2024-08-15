using Quirino;
using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Qurino.Q_Character;

public class Q_AIStateFlee : Q_AIState
{
    public Q_AIStateFlee() : base()
    {

    }

    public override void OnEnter(Q_AI ai)
    {
        ai.m_speed *= 2;


        Q_Behaviour a;
        ai.m_beahviours = null;

        a.m_currentBehaviour = STEERING_BEHAVIOUR.FLEE;
        a.m_target = Q_CharacterManager.instance.getPlayer().gameObject;
        a.m_inpetu = 90;
        a.targetProyection = 2;

        ai.m_beahviours = new Q_Behaviour[1];
        ai.m_beahviours[0] = a;
    }

    public override Q_AIState OnUpdate(Q_AI ai)
    {
        var charManager = Q_CharacterManager.instance;

        float lenght = (ai.transform.position - charManager.getPlayer().transform.position).magnitude;
        if(lenght >= 80)
        {
            ai.OnDestroy();
        }
        else if (charManager.getPlayer().m_lives <= 0)
        {
            return Q_AISM.IdleState;
        }

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