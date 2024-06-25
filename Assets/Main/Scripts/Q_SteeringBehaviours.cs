using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    PERSUIT, 
    EVADE,
    ARRIVE,
    COUNT
}


public class Q_SteeringBehaviours
{


    public Vector3 GetDirection(Vector3 target, Vector3 pos, Vector3 targetDir, float targetProyection, float Inpetu, float Radio, STEERING_BEHAVIOUR beahaviour)
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
        else if (STEERING_BEHAVIOUR.PERSUIT == beahaviour)
        {
            return Persuit(target, pos, targetDir, targetProyection, Inpetu);
        }
        else if (STEERING_BEHAVIOUR.EVADE == beahaviour)
        {
            return Evade(target, pos, targetDir, targetProyection, Inpetu);
        }
        else if (STEERING_BEHAVIOUR.ARRIVE == beahaviour)
        {
            return Arrive(target, pos, Inpetu, Radio);
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


    private float waitTimer = 0;
    private float waitTime = 0;
    private bool hasToWait = false;
    private bool changeTragetPos = true;
    private Vector3 RandomPos;

    // en un area crear puntos, los puntos tienen un area al entrar al area se espera n tiempo y sigue otro punto
    public Vector3 Wander(Vector3 target, Vector3 pos, float Inpetu, float Radio)
    {
        const float targetRadius = 2.5f;
        Vector2 WaitTimeRange = new Vector3(1.25f, 3.0f, 0.0f); // (Min, Max)

        if (changeTragetPos == true)
        {

            RandomPos = new Vector2(Random.Range(pos.x - Radio, pos.x + Radio), Random.Range(pos.y - Radio, pos.y + Radio));
            changeTragetPos = false;
        }

        waitTimer += Time.deltaTime;
        if ((RandomPos - pos).magnitude < targetRadius && hasToWait == false) // inside target area
        {
            hasToWait = true;
            waitTimer = 0;
            waitTime = Random.Range(WaitTimeRange.x, WaitTimeRange.y);
        }
        if (waitTimer >= waitTime && hasToWait == true) // 
        {
            hasToWait = false;
            changeTragetPos = true;
        }

        if (hasToWait == false)
        {
            return Seek(RandomPos, pos, Inpetu);
        }

        Debug.Log("Timer = " + waitTimer);
        return Vector3.zero;
    }

    public Vector3 Persuit(Vector3 target, Vector3 pos, Vector3 targetDir, float targetProyection, float Inpetu)
    {
        Vector3 dir = (target + (targetDir * targetProyection))- pos;
        if(dir.magnitude < targetProyection)
        {
            return (targetDir.normalized * dir.magnitude) * Inpetu;
        }
        return dir.normalized * Inpetu;

            //dentro del radio:
            //TargetProyection.normalized * (targetPos - Position).magnitud
    }
    // PP = pos + targetDir * speed * TargetProyection

    public Vector3 Evade(Vector3 target, Vector3 pos, Vector3 targetDir, float targetProyection, float Inpetu)
    {
        return -Persuit(target, pos, targetDir, targetProyection, Inpetu);
        // dentro del radio huye del target y targetProyection
    }

    public Vector3 Arrive(Vector3 target, Vector3 pos, float Inpetu, float Radio)
    {
        Vector3 dir = target - pos;
        return dir.normalized * Inpetu;
    }


    // Follow the leader 
    // 2 areas 
    // si estas afuera del area grande sigues al lider
    // si estas adentro del area grande, imitas al lider
    // no puedes pasar por el area pequeña
    // no puedes estar en frente del lider, para calcular si estas atras se usa producto punto del vector forward del lider  y la posicion del seguidor
    // vector 3.dot
}
} // namespace