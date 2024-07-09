using Qurino;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quirino
{
    public class Q_CharacterManager
    {
        // Start is called before the first frame update
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
    }
}