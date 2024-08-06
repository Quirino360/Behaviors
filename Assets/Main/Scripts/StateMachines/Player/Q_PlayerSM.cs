using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Quirino
{
    public class Q_PlayerSM
    {
        #region FIELDS

        private readonly PlayerController m_player;
        private Q_PlayerState m_currentState;

        private Q_PlayerState m_idleState;
        private Q_PlayerState m_moveState;
        private Q_PlayerState m_boostState;

        #endregion

        #region PROPERTIES

        private Q_PlayerState CurrentState
        {
            get { return m_currentState; }
            set
            {
                if (value != m_currentState)
                {
                    //if (_currentState != null)
                    //{
                    //	_currentState.OnExit();
                    //}
                    m_currentState?.OnExit();
                    m_currentState = value;
                    m_currentState.OnEnter();
                }
            }
        }

        public Q_PlayerState IdleState
        {
            get
            {
                return m_idleState ??= new Q_PlayerStateIdle(m_player, this);
            }
        }
        public Q_PlayerState MovingState { get { return m_moveState ??= new Q_PlayerStateMove(m_player, this); } }
        public Q_PlayerState BoostingState { get { return m_boostState ??= new Q_PlayerStateBoost(m_player, this); } }


        #endregion

        public Q_PlayerSM(PlayerController player)
        {
            m_player = player;

            CurrentState = IdleState;
        }

        public void OnUpdate()
        {
            CurrentState = CurrentState.OnUpdate();
        }

        public void OnFixedUpdate()
        {

            CurrentState = CurrentState.OnFixedUpdate();
        }

        public void OnRender()
        {
            m_currentState.OnRender();
        }
    }
}