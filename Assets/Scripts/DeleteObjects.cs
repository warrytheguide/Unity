using UnityEngine;

public class DeleteObjects : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    
    {
        Destroy(other.gameObject);
    }
}
