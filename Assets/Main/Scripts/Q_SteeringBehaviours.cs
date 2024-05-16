using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quirino
{
public enum STEERING_BEHAVIOUR
{
    NONE = 0,
    SEEK,
    FLEE,
    COUNT
}


public class Q_SteeringBehaviours : MonoBehaviour
{
    Vector3 direction = Vector2.zero; 
    float speed = 0.0f;
    float maxSpeed = 0.0f;
    float acceleration = 0.0f;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector3 Seek(Vector3 target, Vector3 pos, float Inpetu)
    {
        dynamic dir = target - pos;
        return dir;
    }

    public Vector3 Flee(Vector3 target, Vector3 pos, float Inpetu)
    {
        return -Seek(target, pos, Inpetu);
    }
}
}