using UnityEngine;

public class DragonFire : MonoBehaviour
{
    private float height;
    private Vector3 startPosition;
    GameManager gm;
    void Start()
    {
        gm = GameManager.Instance;


        int randomInt = Random.Range(0, 2);

        switch (randomInt)
        {
            case (0):
                height = (float)-6.55;
                break;
            case (1):
                height = (float)-3.65;
                break;
        }


        transform.position = new Vector3(12, height, transform.position.z);
    }
}
