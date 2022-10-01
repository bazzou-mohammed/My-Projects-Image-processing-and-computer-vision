using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform EnemyPrefab;

    [SerializeField]
    private Transform spawnPoint;
    
    [SerializeField]
    private float timeBetweenWaves = 5f;
    private float countdown = 2f;

    [SerializeField]
    private Text WaveCountTimer;
    private int waveNumber = 0;
    
    void Update()
    {
       if(countdown <= 0f){
            StartCoroutine(SpawenWaves());
           countdown = timeBetweenWaves;
       } 
       countdown -= Time.deltaTime;
       WaveCountTimer.text = Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawenWaves(){
         waveNumber++;
        for(int i = 0; i<waveNumber; i++){
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    
}
