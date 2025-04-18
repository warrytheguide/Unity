using UnityEngine;

public class SpawnDevilFire : MonoBehaviour
{
    
    [SerializeField] GameObject fire;
    
    private float horizontalSpeed = 7;
    GameManager gm;

    void Start(){
        gm = GameManager.Instance;
        if(gm.hardModeOn)
            horizontalSpeed*=2;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="DevilChild"){
            Spawn();
        }
    }


    private void Spawn(){
        
        Vector3 spawnPosition = transform.position;
        spawnPosition.z = 0;
        
        GameObject obstacleToSpawn = fire;
        
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * horizontalSpeed;

    }

}
