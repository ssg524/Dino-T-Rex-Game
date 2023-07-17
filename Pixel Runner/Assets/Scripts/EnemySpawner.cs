using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        StartSpawnEnemy();
    }

    void StartSpawnEnemy()
    {
        StartCoroutine("SpawnRoutine");
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            int index = Random.Range(0, enemies.Length);
            SpawnEnemy(index);

            float ran = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(ran);
        }
    }


    void SpawnEnemy(int index)
    {
        Vector3 pos = new Vector3(transform.position.x, -3.5f, transform.position.z);
        Instantiate(enemies[index], pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
