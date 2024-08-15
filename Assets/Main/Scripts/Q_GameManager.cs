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
        private Q_AISM m_AI_FSM = new Q_AISM();

        [SerializeField] private Q_Player player;

        [SerializeField] private uint m_nToSpawn = 6;

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
            // asegurarse que todas las instancias de ai no existan
            //Q_CharacterManager.instance.deleteAllAI();
        }

        void Update()
        {
            var charManager = Q_CharacterManager.instance;
            m_playerFSM.OnUpdate(player);

            var allAI = charManager.getAllAI();

            foreach (Q_AI ai in allAI)
            {
                m_AI_FSM.OnUpdate(ai);
            }

            // game loop 
            if (allAI.Length <= 0)
            {
                // spawn ai
                charManager.spawnAI(m_nToSpawn);
                m_nToSpawn++;

            }



        }
    }
}