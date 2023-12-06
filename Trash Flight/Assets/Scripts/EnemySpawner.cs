using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};
    [SerializeField]
    private float SpawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        StartEnemyRoutine();

    }

    void StartEnemyRoutine(){
        StartCoroutine("EnemyRoutine");
    }

    public void StopEnemyRoutine(){
        StopCoroutine("EnemyRoutine");
    }
     private int spawnCount = 0;

    IEnumerator EnemyRoutine(){
        yield return new WaitForSeconds(3f);

        int enemyIdx = 0;
        float moveSpeed = 5f;

        while(true){
            foreach(float posX in arrPosX){

                // int enemyIdx = Random.Range(0,enemies.Length);
                SpawnEnemy(posX,enemyIdx,moveSpeed);
            }

            spawnCount++;
            if(spawnCount % 10 == 0){
                enemyIdx ++;
                moveSpeed += 1;
            }

            if(enemyIdx >= enemies.Length){
                SpawnBoss();
                enemyIdx = 0;
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(SpawnInterval);
        }

    }

    void SpawnEnemy(float posX, int index, float moveSpeed){
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);


        if(Random.Range(0,5) == 0){
            index++;
        }


        if(index >= enemies.Length){
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);

        Enemy enemy = enemyObject.GetComponent<Enemy>();

        enemy.SetMoveSpeed(moveSpeed);

    }

    void SpawnBoss(){
        Instantiate(boss,transform.position, Quaternion.identity);
    }


    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
