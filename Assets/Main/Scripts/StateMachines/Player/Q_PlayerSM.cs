using Qurino;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;

namespace Quirino
{
    public class Q_PlayerSM
    {
        #region FIELDS

        //private readonly PlayerController m_player;
        //private Q_PlayerState m_currentState;

        private static Q_PlayerState m_idleState;
        private static Q_PlayerState m_moveState;
        private static Q_PlayerState m_boostState;

        #endregion

        #region PROPERTIES

        /*private Q_PlayerState CurrentState
        {
            get { return m_currentState; }
            set
            {
                if (value != m_currentState)
                {
                    // if (_currentState != null)
                    // {
                    // 	_currentState.OnExit();
                    // }
                    m_currentState?.OnExit();
                    m_currentState = value;
                    m_currentState.OnEnter();
                }
            }
        }/**/

        public static Q_PlayerState IdleState { get { return m_idleState ??= new Q_PlayerStateIdle(); } }
        public static Q_PlayerState MovingState { get { return m_moveState ??= new Q_PlayerStateMove(); } }
        public static Q_PlayerState BoostingState { get { return m_boostState ??= new Q_PlayerStateBoost(); } }


        #endregion

        public Q_PlayerSM()
        {
            //character.m_state = IdleState;
        }

        public void OnUpdate(Q_Player character)
        {
            character.m_state = character.m_state.OnUpdate(character);
        }

        public void OnFixedUpdate(Q_Player character)
        {

            character.m_state = character.m_state.OnFixedUpdate(character);
        }

        public void OnRender(Q_Player character)
        {
            character.m_state.OnRender(character);
        }
    }
}