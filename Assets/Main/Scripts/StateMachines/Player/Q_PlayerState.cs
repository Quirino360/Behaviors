using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Quirino
{
    public abstract class Q_PlayerState
    {
        protected readonly Q_PlayerSM m_fsm;
        public Q_PlayerState()
        {

        }

        abstract public void OnEnter(); 
        abstract public Q_PlayerState OnUpdate(Q_Player character);
        abstract public Q_PlayerState OnFixedUpdate(Q_Player character);
        abstract public void OnExit();
        abstract public void OnRender(Q_Player character);
    }
}


// como poner el movimiento con el new input 
// crear clase game y clase actor manager?
