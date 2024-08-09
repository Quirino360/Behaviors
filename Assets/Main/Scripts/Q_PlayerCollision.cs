using Qurino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_PlayerCollision : MonoBehaviour
{
    private Q_Player character;


    void Start()
    {
        character = gameObject.GetComponentInParent<Q_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet Hit Player");

            var bullet = collision.GetComponentInParent<Q_Bullet>();

            character.m_lives -= bullet.m_damage;
            if (character.m_lives <= 0)
            {
                // end the game
                Destroy(character.gameObject);
                Destroy(bullet.gameObject);
            }
        }
    }

}
