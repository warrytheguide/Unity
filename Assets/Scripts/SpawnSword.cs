using UnityEngine;

public class SpawnSword : MonoBehaviour
{
    [SerializeField] GameObject sword;
    private bool spawned = false;

    private float horizontalSpeed = 8.5f;
    GameManager gm;

    void Start(){
        gm = GameManager.Instance;
        if(gm.hardModeOn)
            horizontalSpeed*=2;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log($"{other.gameObject.tag} entered the trigger");

        if(other.gameObject.tag=="Player"){
            if(!spawned){
                Spawn(other.gameObject.transform.position.y);
                spawned = true;
            }
        }
    }


    private void Spawn(float playerPosition){
        
    Debug.Log($"Parent X position: {transform.parent.position.x}");

        Vector3 spawnPosition = transform.position;
        
        spawnPosition.x = transform.parent.position.x+29;
        spawnPosition.y = playerPosition-2;
        spawnPosition.z = 0;
        
        GameObject obstacleToSpawn = sword;
        
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPosition, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * horizontalSpeed;

    }
}
