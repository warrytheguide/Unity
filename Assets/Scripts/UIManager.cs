using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject doubleJumpIndicator;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    [SerializeField] public Image[] hearts;

GameManager gm;
private void Start(){
    gm = GameManager.Instance;
    gm.onGameOver.AddListener(ActivateGameOverUI);
}

private void Update(){
    for(int i=0; i< hearts.Length; i++){
        
        if(i < gm.playerHealth.Health){
            hearts[i].sprite = fullHeart;
        }
        else{
            hearts[i].sprite = emptyHeart;
        }

        if(i<gm.playerHealth.maxHealth){
            hearts[i].enabled = true;
        }
        else{
            hearts[i].enabled = false;
        }
    }

    if(gm.doubleJump){
        doubleJumpIndicator.SetActive(true);
    }

    else{
        doubleJumpIndicator.SetActive(false);
    }
}

public void PlayButtonHandler(){
    gm.StartGame();
}

public void ExitButtonHandler(){
    Application.Quit();
}

public void ActivateGameOverUI(){
    gameOverUI.SetActive(true);
}

private void OnGUI(){
    scoreUI.text = gm.PrettyScore();
}

}
