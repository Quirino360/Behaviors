using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Q_AICollision : MonoBehaviour
{
    private Q_AI character;


    void Start()
    {
        character = gameObject.GetComponentInParent<Q_AI>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            var bullet = collision.gameObject.GetComponentInParent<Q_Bullet>();
            if (bullet != null && bullet.m_isEnemy == false)
            {
                Debug.Log("Bullet Hit AI");

                character.m_lives -= bullet.m_damage;
                if (character.m_lives <= 0)
                {
                    Destroy(character.gameObject);
                    Destroy(bullet.gameObject);
                }
            }

        }

    }
}
