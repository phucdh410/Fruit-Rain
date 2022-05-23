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
    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if(m_isGameover)
        {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }

        if(m_spawnTime <= 0)
        {
            // coroutine = WaitToExecute(1f);
            // StartCoroutine(coroutine);
            SpawnItem();
            m_spawnTime = spawnTime;
        }

    }

    private IEnumerator WaitToExecute(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnItem();
            m_spawnTime = spawnTime;
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
    public void Replay()
    {
        m_score = 0;
        m_isGameover = false;
        m_ui.SetScoreText("Score: " + m_score);
        m_ui.ShowGameoverPanel(false);
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
        m_ui.SetScoreText("Score: " + m_score);
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
