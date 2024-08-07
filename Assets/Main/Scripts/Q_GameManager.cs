using Quirino;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Qurino
{
    public class Q_GameManager : MonoBehaviour
    {
        public static Q_GameManager instance { get; private set; }
        private Q_PlayerSM m_playerFSM = new Q_PlayerSM();
        private Q_AISM m_AI_FSM;

        [SerializeField] private Q_Player player;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Debug.LogError("Hay mas de una instancia de Q_GameManager cuando es singleton");
            }
        }

        void Start()
        {

        }

        void Update()
        {
            m_playerFSM.OnUpdate(player);
        }
    }
}