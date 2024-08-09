using Qurino;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Q_Bullet : MonoBehaviour
{
    //[SerializeField] private GameObject bulletPrefab;

    private float speed = 1.0f;
    public float m_speed
    {
        set { speed = value; }
    }

    private Vector3 direction = Vector3.zero;
    public Vector3 m_direction
    {
        set { direction = value; }
    }

    private uint damage = 1;
    public uint m_damage
    {
        get { return damage; }
        set { damage = value; }
    }

    [SerializeField] private float lifeTime = 5.0f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AI")
        {
            Q_AI actor = collision.gameObject.GetComponent<Q_AI>();

            actor.m_lives -= damage;
            if(actor.m_lives <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            Q_Character actor = collision.gameObject.GetComponent<Q_Character>();

            actor.m_lives -= damage;
            if (actor.m_lives <= 0)
            {
                // end the game
                Destroy(collision.gameObject);
            }

        }

        Destroy(gameObject);

    }
}
