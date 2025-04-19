using UnityEngine;

public class DevilFire : MonoBehaviour
{
    private float height;
    private Vector3 startPosition;
    GameManager gm;
    void Start()
    {
        gm = GameManager.Instance;


        int randomInt = Random.Range(0, 3);

        switch (randomInt)
        {
            case (0):
                height = (float)-6.55;
                break;
            case (1):
                height = (float)-3.65;
                break;
            case (2):
                height = (float)-0.55;
                break;
        }


        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}
