using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // public GameObject item;
    private GameObject itemInstance;
    public List<GameObject> listItem = new List<GameObject>();
    public float spawnTime;
    private IEnumerator coroutine;
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
            // for(int i = 0 ; i <= m_score / 10 ; i++)
            // {
            //     SpawnItem();
            //     m_spawnTime = spawnTime;
            // }
            coroutine = WaitToExecute(0.5f);
            StartCoroutine(coroutine);
            m_spawnTime = spawnTime;

        }

    }

    private IEnumerator WaitToExecute(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnItem();
        }
    }

    public void SpawnItem()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-3,3),6);
        if(listItem.Count!=0)
        {
            int random = Random.Range(0,6);

            itemInstance = 
            Instantiate(listItem[random],spawnPosition,Quaternion.identity);
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
