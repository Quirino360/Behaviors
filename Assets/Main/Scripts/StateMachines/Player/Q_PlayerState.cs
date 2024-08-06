using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Quirino
{
    public abstract class Q_PlayerState
    {
        protected readonly PlayerController m_player;
        protected readonly Q_PlayerSM m_fsm;
        public Q_PlayerState(PlayerController player, Q_PlayerSM fsm)
        {
            m_player = player;
            m_fsm = fsm;
        }

        abstract public void OnEnter();
        abstract public Q_PlayerState OnUpdate();
        abstract public Q_PlayerState OnFixedUpdate();
        abstract public void OnExit();
        abstract public void OnRender();
    }
}


// como poner el movimiento con el new input 
// crear clase game y clase actor manager?
