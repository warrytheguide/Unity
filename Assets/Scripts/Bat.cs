using UnityEngine;
public class Bat : MonoBehaviour
{   
    
    [SerializeField] public float amplitude;
    [SerializeField] public float frequency;
    [SerializeField] public float horizontalSpeed;
    private float height;
    private Vector3 startPosition;

    GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;

        if(gm.hardModeOn)
            horizontalSpeed*=2;

        int randomInt = Random.Range(0, 2);
        switch(randomInt){
            case(0):
                height = -4;
                break;
            case(1):
                height = (float)-2.8;
                break;

        }
        
        startPosition = new Vector3(transform.position.x, height, transform.position.z);
    }

    void Update()
    {
        // Calculate the horizontal movement
        float horizontalMovement = horizontalSpeed * Time.deltaTime;
        
        // Calculate the vertical oscillation
        float yOffset = amplitude * Mathf.Sin(Time.time * frequency * 2f * Mathf.PI);
        
        // Combine horizontal movement and vertical oscillation
        transform.position = startPosition + new Vector3(-horizontalMovement, yOffset, 0f);
        
        // Update the start position for continuous leftward movement
        startPosition += new Vector3(-horizontalMovement, 0f, 0f);
    }
}
