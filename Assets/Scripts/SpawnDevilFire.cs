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
            Spawn(other.gameObject);
        }
    }

    private void Spawn(GameObject otherObject){
        // Get the x position from the DevilChild
        float devilChildX = otherObject.transform.position.x + 7;
        
        // Determine random height
        float height;
        int randomInt = Random.Range(0, 3);

        switch (randomInt)
        {
            case 0:
                height = -6.55f;
                break;
            case 1:
                height = -3.65f;
                break;
            case 2:
                height = -0.55f;
                break;
            default:
                height = -3.65f;
                break;
        }
        
        // Create spawn position using the x coordinate from the other object and random height
        Vector3 spawnPosition = new Vector3(devilChildX, height, 0);
        
        // Instantiate the fire at the correct position
        GameObject spawnedObstacle = Instantiate(fire, spawnPosition, Quaternion.identity);

        // Apply velocity
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * horizontalSpeed;
    }
}
