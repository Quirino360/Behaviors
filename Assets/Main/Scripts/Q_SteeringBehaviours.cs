using Qurino;
using System;
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
        FOLLOW_THE_LEADER,
        COUNT
    }


public class Q_SteeringBehaviours
{
    private float leaderRadio;
    public float m_leaderRadio
    {
        get { return leaderRadio; }
        set { leaderRadio = value; }
    }

    public Vector3 GetDirection(Vector3 target, Vector3 pos, Vector3 targetDir, float targetProyection, float samllRadio, float bigRadio, STEERING_BEHAVIOUR beahaviour)
    {
        if (STEERING_BEHAVIOUR.SEEK == beahaviour)
        {
            return Seek(target, pos, samllRadio);
        }
        else if (STEERING_BEHAVIOUR.FLEE == beahaviour)
        {
            return Flee(target, pos, samllRadio);
        }
        else if (STEERING_BEHAVIOUR.SEEK_RADIO == beahaviour)
        {
            return SeekRadio(target, pos, samllRadio, bigRadio);
        }
        else if (STEERING_BEHAVIOUR.FLEE_RADIO == beahaviour)
        {
            return FleeRadio(target, pos, samllRadio, bigRadio);
        }
        else if (STEERING_BEHAVIOUR.WANDER == beahaviour)
        {
            return Wander(target, pos, samllRadio, bigRadio);
        }
        else if (STEERING_BEHAVIOUR.PERSUIT == beahaviour)
        {
            return Persuit(target, pos, targetDir, targetProyection, samllRadio);
        }
        else if (STEERING_BEHAVIOUR.EVADE == beahaviour)
        {
            return Evade(target, pos, targetDir, targetProyection, samllRadio);
        }
        else if (STEERING_BEHAVIOUR.ARRIVE == beahaviour)
        {
            return Arrive(target, pos, samllRadio, bigRadio);
        }
        else if (STEERING_BEHAVIOUR.FOLLOW_THE_LEADER == beahaviour)
        {
            return FollowTheLeader(target, pos, targetDir, samllRadio, bigRadio);
        }
        return Vector3.zero;
    }

    public Vector3 Seek(Vector3 target, Vector3 pos, float samllRadio)
    {
        Vector3 dir = target - pos;
        return dir.normalized * samllRadio;
    }

    public Vector3 Flee(Vector3 target, Vector3 pos, float samllRadio)
    {
        return -Seek(target, pos, samllRadio);
    }

    public Vector3 SeekRadio(Vector3 target, Vector3 pos, float samllRadio, float bigRadio)
    {
        Vector3 dir = target - pos;
        if (dir.magnitude > bigRadio) // si esta afuera
        {
            return dir.normalized * samllRadio;
        }
        return Vector3.zero;
    }

    public Vector3 FleeRadio(Vector3 target, Vector3 pos, float samllRadio, float bigRadio)
    {
        Vector3 dir = target - pos;
        if (dir.magnitude < bigRadio) // si esta adentro
        {
            return -(dir.normalized * samllRadio);
        }
        return Vector3.zero;
    }


    private float waitTimer = 0;
    private float waitTime = 0;
    private bool hasToWait = false;
    private bool changeTragetPos = true;
    private Vector3 RandomPos;

    // en un area crear puntos, los puntos tienen un area al entrar al area se espera n tiempo y sigue otro punto
    public Vector3 Wander(Vector3 target, Vector3 pos, float samllRadio, float bigRadio)
    {
        const float targetRadius = 2.5f;
        Vector2 WaitTimeRange = new Vector3(1.25f, 3.0f, 0.0f); // (Min, Max)

        if (changeTragetPos == true)
        {

            RandomPos = new Vector2(UnityEngine.Random.Range(pos.x - bigRadio, pos.x + bigRadio), UnityEngine.Random.Range(pos.y - bigRadio, pos.y + bigRadio));
            changeTragetPos = false;
        }

        waitTimer += Time.deltaTime;
        if ((RandomPos - pos).magnitude < targetRadius && hasToWait == false) // inside target area
        {
            hasToWait = true;
            waitTimer = 0;
            waitTime = UnityEngine.Random.Range(WaitTimeRange.x, WaitTimeRange.y);
        }
        if (waitTimer >= waitTime && hasToWait == true) // 
        {
            hasToWait = false;
            changeTragetPos = true;
        }

        if (hasToWait == false)
        {
            return Seek(RandomPos, pos, samllRadio);
        }

        Debug.Log("Timer = " + waitTimer);
        return Vector3.zero;
    }

    public Vector3 Persuit(Vector3 target, Vector3 pos, Vector3 targetDir, float targetProyection, float samllRadio)
    {
        Vector3 dir = (target + (targetDir * targetProyection))- pos;
        if(dir.magnitude < targetProyection)
        {
            return (targetDir.normalized * dir.magnitude) * samllRadio;
        }
        return dir.normalized * samllRadio;

            //dentro del bigRadio:
            //TargetProyection.normalized * (targetPos - Position).magnitud
    }
    // PP = pos + targetDir * speed * TargetProyection

    public Vector3 Evade(Vector3 target, Vector3 pos, Vector3 targetDir, float targetProyection, float samllRadio)
    {
        return -Persuit(target, pos, targetDir, targetProyection, samllRadio);
        // dentro del bigRadio huye del target y targetProyection
    }

    public Vector3 Arrive(Vector3 target, Vector3 pos, float samllRadio, float bigRadio)
    {
        Vector3 dir = target - pos;
        return dir.normalized * samllRadio;
    }

    // target is leader
    public Vector3 FollowTheLeader(Vector3 target, Vector3 pos, Vector3 targetDir, float samllRadio, float bigRadio)
    {
        Vector3 dir = Vector3.zero;
        
        if(target.magnitude < m_leaderRadio)  // no puedes pasar por el area peque�a
        {
            dir = Flee(target, pos, samllRadio);
            
        }
        else if(Vector3.Dot(targetDir, pos) < 0) //no puedes estar en frente del lider
        {
            dir = targetDir;
        }
        else if(target.magnitude > bigRadio) // si estas afuera del area grande sigues al lider
        {
            dir = target - pos;
        }
        else if(target.magnitude < bigRadio) // si estas adentro del area grande, imitas al lider
        {
            dir = targetDir;
        }
        
        return dir.normalized * samllRadio;
    }


     // Follow the leader 
     // 2 areas 
     // si estas afuera del area grande sigues al lider
     // si estas adentro del area grande, imitas al lider
     // no puedes pasar por el area peque�a
     // no puedes estar en frente del lider, para calcular si estas atras se usa producto punto del vector forward del lider  y la posicion del seguidor
     // vector 3.dot

     // Sepration 
     // Tienes un bigRadio personal, 
     // Tienes una lista de todos los voids que estan en la escena, en el cual se compara si estan pegados o o no,
     // se separan en caso de que esten adentro con un flee (flee con bigRadio)

     //Cohesion - Mantener lo suficiemte juntos
     //  les das un bigRadio de vision a cada uno de los voids
     // Calcular un centro de masa, y cada uno se mueve al centro de masa calculado

     // Direction
     // Les das un bigRadio de vision a cada uno de los voids
     // Calcular la direccion promedio y aplicarla al void

     // Flocking
     // Llamar a Separataion 
     // Cohesion y Direction 

     // Follow path 
     // Circuit - le das la vuelta 
     // Inverese - De ida y de regereso

     // Obstacle colition
     // flee con samllRadio infinita 
     // clase nueva Obstacle, utilizar bigRadio

     // Obstacle avoid
     // caja de deteccion 
     // si entra al bigRadio (sabiendo la distancia,
     // punta (jugador) menos cola (obstaculo) * bigRadio del obstaculo y ver si esta andtro de los puntos de la caja (todo dentro de la posicion dle mundo))
     // si esta andentro haces el flee
    }
} // namespace