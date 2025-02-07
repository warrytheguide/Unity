using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform obstacleParent;
    public float obstacleSpawnTime = 2f;

    private float timeUntilObstacleSpawn;

    GameManager gm;

    private void Start(){
        gm = GameManager.Instance;
        GameManager.Instance.onGameOver.AddListener(ClearObstacles);
        GameManager.Instance.onPlay.AddListener(ClearObstacles);
    }


    private void Update(){
        if(GameManager.Instance.isPlaying){
            SpawnLoop();
        }
    }

    private void SpawnLoop(){
        timeUntilObstacleSpawn += Time.deltaTime;

        if(timeUntilObstacleSpawn >= obstacleSpawnTime){
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void ClearObstacles(){
        foreach(Transform child in obstacleParent){
            Destroy(child.gameObject);
        }
    }
    
    private void Spawn(){
        
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];
        
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        spawnedObstacle.transform.parent = obstacleParent;
        
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * gm.obstacleSpeed;
    }

}
