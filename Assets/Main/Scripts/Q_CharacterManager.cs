using Qurino;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

namespace Quirino
{
    public class Q_CharacterManager : MonoBehaviour
    {

        public static Q_CharacterManager instance { get; private set; }
        [SerializeField] private GameObject AIprefab;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Debug.LogError("Hay mas de una instancia de Q_CharacterManager Manager cuando es singleton");
            }
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Q_AI[] getAllAI()
        {
            Q_AI[] all_AI = null;
            GameObject[] AI_OBJ = GameObject.FindGameObjectsWithTag("AI");
            all_AI = new Q_AI[AI_OBJ.Length];

            for (int i = 0; i < AI_OBJ.Length; i++)
            {

                all_AI[i] = AI_OBJ[i].GetComponent<Q_AI>();
            }
            return all_AI;
        }

        public Q_Player getPlayer()
        {
            Q_Player player = null;
            GameObject Player_OBJ = GameObject.FindGameObjectWithTag("Player");
            if (Player_OBJ != null)
            {
                player = Player_OBJ.GetComponent<Q_Player>();
                if (player != null)
                {
                    return player;
                }
            }
            return null;
        }

        public void deleteAllAI()
        {
            Q_AI[] all_AI = null;
            GameObject[] AI_OBJ = GameObject.FindGameObjectsWithTag("AI");
            all_AI = new Q_AI[AI_OBJ.Length];

            for (int i = 0; i < AI_OBJ.Length; i++)
            {
                Destroy(AI_OBJ[i]);
            }

        }

        public void spawnAI(uint n)
        {
            if (n <= 0)
            {
                return;
            }

            var playerPos = Q_CharacterManager.instance.getPlayer().transform.position;
            float radioMin = 38.0f;
            float radioMax = 60.0f;
               
            for (int i = 0; i < n; i++) 
            {
                int aux = Random.Range(0, 1);
                if (aux == 0)
                {
                    aux = 1;
                    Debug.Log(aux);
                }
                

                var position = new Vector3(Random.Range(playerPos.x + (radioMin * aux), playerPos.x + (radioMax * aux)), Random.Range(playerPos.y + (radioMin * aux), playerPos.y + (radioMax * aux)), 0);
                Instantiate(AIprefab, position, Quaternion.identity);
            }

        }
    }
}