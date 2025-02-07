using UnityEngine;

public class Activate : MonoBehaviour
{

[SerializeField] GameObject platform1;
[SerializeField] GameObject platform2;
GameManager gm;

private void Start(){
    gm = GameManager.Instance;
}
    void Update()
    {
        if(gm.phaseOne){
            platform1.SetActive(false);
            platform2.SetActive(false);
        }
        if(gm.phaseTwo){
            platform1.SetActive(true);
        }
        if(gm.phaseThree){
            platform2.SetActive(true);
        }

        if(!gm.isPlaying){
            platform1.SetActive(false);
            platform2.SetActive(false);
        }
    }
}
