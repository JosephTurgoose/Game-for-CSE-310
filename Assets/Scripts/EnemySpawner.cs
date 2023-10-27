using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float timerMax = 1.5f;
    private float timerTime;

    // Start is called before the first frame update
    void Start()
    {
        timerTime = timerMax;
    }

    // Update is called once per frame
    void Update()
    {
        timerTime -= Time.deltaTime;
        if (timerTime <= 0)
        {
            timerTime = timerMax;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randVal = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[randVal], gameObject.transform.position, Quaternion.identity);
    }
}
