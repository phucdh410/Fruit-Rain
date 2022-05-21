using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameController m_gc;

    private void Start() {
        m_gc = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Player"))
        {
            m_gc.AddScore();
            
            Destroy(gameObject);

            Debug.Log("Qua bong da va cham voi player");
        }
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("DeathZone"))
        {
            m_gc.SetGameover(true);

            Destroy(gameObject);

            Debug.Log("Qua bong da va cham voi death zone");
        }
    }
}
