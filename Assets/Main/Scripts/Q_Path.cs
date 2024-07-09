using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Quirino
{
    public class Q_Path : MonoBehaviour
    {

        private List<Vector3> checkpoints = new List<Vector3>();
        public List<Vector3> m_checkpoints
        {
            get { return checkpoints; }
            set { checkpoints = value; }
        }

        void Start()
        {
            foreach (Transform child in transform)
            {
                m_checkpoints.Add(child.transform.position);
            }
            

        }

    }
}