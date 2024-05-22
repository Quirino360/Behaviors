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
    SEEK_RADIO,
    FLEE_RADIO,
    WANDER,
    COUNT
}


public class Q_SteeringBehaviours
    {
    private Vector3 m_direction = Vector2.zero; 

    public Vector3 GetDirection(Vector3 target, Vector3 pos, float Inpetu, float Radio, STEERING_BEHAVIOUR beahaviour)
    { 
        if (STEERING_BEHAVIOUR.SEEK == beahaviour)
        {
            return Seek(target, pos, Inpetu);
        }
        else if (STEERING_BEHAVIOUR.FLEE == beahaviour)
        {
            return Flee(target, pos, Inpetu);
        }
        else if (STEERING_BEHAVIOUR.SEEK_RADIO == beahaviour)
        {
            return SeekRadio(target, pos, Inpetu, Radio);
        }
        else if (STEERING_BEHAVIOUR.FLEE_RADIO == beahaviour)
        {
            return FleeRadio(target, pos, Inpetu, Radio);
        }
        else if (STEERING_BEHAVIOUR.WANDER == beahaviour)
        {
            return Wander(target, pos, Inpetu, Radio);
        }
        return Vector3.zero;
    }


    
    public Vector3 Seek(Vector3 target, Vector3 pos, float Inpetu)
    {
        Vector3 dir = target - pos;
        return dir.normalized * Inpetu;
    }

    public Vector3 Flee(Vector3 target, Vector3 pos, float Inpetu)
    {
        return -Seek(target, pos, Inpetu);
    }

    public Vector3 SeekRadio(Vector3 target, Vector3 pos, float Inpetu, float Radio)
    {
        Vector3 dir = target - pos;
        if (dir.magnitude > Radio)
        {
            return dir.normalized * Inpetu;
        }
        return Vector3.zero;
    }

    public Vector3 FleeRadio(Vector3 target, Vector3 pos, float Inpetu, float Radio)
    {
        Vector3 dir = target - pos;
        if (dir.magnitude < Radio)
        {
            return -(dir.normalized * Inpetu);
            }
        return Vector3.zero;
    }

    public Vector3 Wander(Vector3 target, Vector3 pos, float Inpetu, float Radio)
    {
        return Vector3.zero;
    }

}
} // namespace