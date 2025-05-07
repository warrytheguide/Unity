using UnityEngine;
public class DevilChild : MonoBehaviour
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

        if(gm.hardModeOn){
            horizontalSpeed*= (float)1.5;
        }

        int randomInt = Random.Range(0, 3);
        switch (randomInt)
        {
            case (0):
                height = (float)-3.8;
                break;
            case (1):
                height = (float)-2.8;
                break;
            case (2):
                height = (float)-0.8;
                break;
        }

        startPosition = new Vector3(transform.position.x, height, transform.position.z);
    }

    void Update()
    {
        float horizontalMovement = horizontalSpeed * Time.deltaTime;

        float yOffset = amplitude * Mathf.Sin(Time.time * frequency * 2f * Mathf.PI);

        transform.position = startPosition + new Vector3(-horizontalMovement, yOffset, 0f);

        startPosition += new Vector3(-horizontalMovement, 0f, 0f);
    }
}
