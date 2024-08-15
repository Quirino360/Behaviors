using Quirino;
using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Qurino.Q_Character;

namespace Quirino
{
    public class Q_AIStatePersuit : Q_AIState
    {
        public Q_AIStatePersuit() : base()
        {

        }

        public override void OnEnter(Q_AI ai)
        {
            Q_Behaviour a;
            Q_Behaviour b;
            ai.m_beahviours = null;

            a.m_currentBehaviour = STEERING_BEHAVIOUR.SEEK_RADIO;
            a.m_target = Q_CharacterManager.instance.getPlayer().gameObject;
            a.m_inpetu = 10;
            a.targetProyection = 2;

            b.m_currentBehaviour = STEERING_BEHAVIOUR.FLOCKING;
            b.m_target = Q_CharacterManager.instance.getPlayer().gameObject;
            b.m_inpetu = 4;
            b.targetProyection = 2;

            ai.m_beahviours = new Q_Behaviour[2];
            ai.m_beahviours[0] = b;
            ai.m_beahviours[1] = a;
        }

        public override Q_AIState OnUpdate(Q_AI ai)
        {
            var charManager = Q_CharacterManager.instance;
            if (charManager.getPlayer().m_lives <= 0)
            {
                return Q_AISM.IdleState;
            }
            else if (charManager.getAllAI().Length <= 1)
            {
                return Q_AISM.FleeingState;
            }

            ai.Shoot(ai.m_direction, true);

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