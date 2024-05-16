using Quirino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Q_AI : MonoBehaviour
{
    private Q_SteeringBehaviours m_behavior = new Q_SteeringBehaviours();
    [SerializeField] private Transform m_target;
    [SerializeField] private STEERING_BEHAVIOUR m_currentBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_behavior.Seek(m_target.position, transform.position, 0) * Time.deltaTime;
    }
}
