using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private float[] posY = { -3.5f, -2f };
    
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
            int enemyIndex = Random.Range(0, enemies.Length);
            int posIndex = Random.Range(0, posY.Length);
            SpawnEnemy(enemyIndex, posIndex);

            // 1.0~4.0 사이의 숫자를 뽑아 랜덤한 시간마다 적을 만들어준다. (점수가 오를때마다 이 사이 시간이 조금씩 짧아지게 만들 것)
            float ran = Random.Range(1.0f, 4.0f);
            yield return new WaitForSeconds(ran);
        }
    }


    void SpawnEnemy(int enemyIndex, int posIndex)
    {
        Vector3 pos = new Vector3(transform.position.x, posY[posIndex], transform.position.z);
        Instantiate(enemies[enemyIndex], pos, Quaternion.identity);
    }
}
