using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Qurino.Q_Character;

namespace Quirino
{
    public class Q_AIStateIdle : Q_AIState
    {
        public Q_AIStateIdle() : base()
        {

        }

        public override void OnEnter(Q_AI ai)
        {
            Q_Behaviour a;
            ai.m_beahviours = null;

            a.m_currentBehaviour = STEERING_BEHAVIOUR.NONE;
            a.m_target = Q_CharacterManager.instance.getPlayer().gameObject;
            a.m_inpetu = 90;
            a.targetProyection = 2;

            ai.m_beahviours = new Q_Behaviour[1];
            ai.m_beahviours[0] = a;
        }

        public override Q_AIState OnUpdate(Q_AI ai)
        {
            if (Q_CharacterManager.instance.getPlayer().m_lives > 0)
            {
                return Q_AISM.PersuitState;
            }

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