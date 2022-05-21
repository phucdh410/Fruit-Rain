using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject item;
    public float spawnTime;
    float m_spawnTime;
    int m_score;
    bool m_isGameover;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if(m_isGameover)
        {
            m_spawnTime = 0;
            
            return;
        }

        if(m_spawnTime <= 0)
        {
            SpawnItem();

            m_spawnTime = spawnTime;
        }
    }
    public void SpawnItem()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-3,3),6);
        if(item)
        {
            Instantiate(item,spawnPosition,Quaternion.identity);
        }
    }

    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void AddScore()
    {
        m_score++;
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
    public void SetGameover(bool state)
    {
        m_isGameover = state;
    }
}
