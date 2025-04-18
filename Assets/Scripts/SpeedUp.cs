using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private bool spedUp = false;

    private float horizontalSpeed = 2.5f;
    GameManager gm;

    void Start(){
        gm = GameManager.Instance;
    }
    
    void Update(){
        Transform parentParent = transform.parent.parent;
        parentParent.position += Vector3.left * horizontalSpeed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag=="Player"){
            if(!spedUp){
                Dash();
                spedUp = true;
            }
        }
    }

    private void Dash(){
        horizontalSpeed *= 7;
    }

}
