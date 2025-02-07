using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{

    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    #endregion

    [SerializeField] private TextMeshProUGUI honeyedText;
    [SerializeField] private TextMeshProUGUI appledText;
    [SerializeField] private TextMeshProUGUI firedText;

    [SerializeField] private float buffDuration;
    [SerializeField] public float killScore;

    [SerializeField] public float obstacleSpeed;
    [SerializeField] public float scoreMultiplier;
    public bool isHoneyed = false;
    public bool isAppled = false;
    public bool isFired = false;

    private float phaseTwoScore = 1000;
    private float phaseThreeScore = 2000;
    private float phaseFourScore = 3000;

    public bool doubleJump = false;

    public float currentScore = 0f;

    public bool isPlaying = false;

    public PlayerHealth playerHealth;
    public bool phaseOne = true;
    public bool phaseTwo = false;
    public bool phaseThree = false;
    public bool phaseFour = false;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();
    private bool HardmodeOn = false;

    public GameObject spawnerOne;
    public GameObject spawnerTwo;
    public GameObject spawnerThree;

     public GameObject spawnerOneHard;
    public GameObject spawnerTwoHard;
    public GameObject spawnerThreeHard;

    public void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();

        honeyedText.gameObject.SetActive(false);
        appledText.gameObject.SetActive(false);
        firedText.gameObject.SetActive(false);

        spawnerOne.GetComponent<Spawner>().enabled = true;
    }
    private void Update()
    {

        if (isPlaying)
        {
            currentScore += Time.deltaTime*scoreMultiplier;
        }
        else{
            EndFired();
            EndAppled();
            EndHoneyed();
        }


        //ujra indul a jatek
        if (currentScore > phaseFourScore)
        {
            phaseFour = true;

            if(!HardmodeOn){
                HardmodeOn = true;
                Hardmode();
            }
            
            
            if (Mathf.FloorToInt(currentScore / 1000) % 3 == 0)
            {
                phaseThree = false;
                phaseOne = true;
                spawnerThreeHard.GetComponent<Spawner>().enabled = false;
                spawnerOneHard.GetComponent<Spawner>().enabled = true;
            }

            else if (Mathf.FloorToInt(currentScore / 1000) % 3 == 1)
            {
                phaseOne = false;
                phaseTwo = true;
                spawnerOneHard.GetComponent<Spawner>().enabled = false;
                spawnerTwoHard.GetComponent<Spawner>().enabled = true;
            }

            else if (Mathf.FloorToInt(currentScore / 1000) % 3 == 2)
            {
                phaseTwo = false;
                phaseThree = true;
                spawnerTwoHard.GetComponent<Spawner>().enabled = false;
                spawnerThreeHard.GetComponent<Spawner>().enabled = true;
            }

        }

        else if (currentScore > phaseThreeScore)
        {
            phaseTwo = false;
            phaseThree = true;

            spawnerTwo.GetComponent<Spawner>().enabled = false;
            spawnerThree.GetComponent<Spawner>().enabled = true;
        }

        else if (currentScore > phaseTwoScore)
        {
            phaseOne = false;
            phaseTwo = true;

            spawnerOne.GetComponent<Spawner>().enabled = false;
            spawnerTwo.GetComponent<Spawner>().enabled = true;
        }




    }

    public void StartGame()
    {

        honeyedText.gameObject.SetActive(false);
        appledText.gameObject.SetActive(false);
        firedText.gameObject.SetActive(false);

        onPlay.Invoke();
        isPlaying = true;
        playerHealth.currentHealth = 3;

        phaseFour = false;
        phaseThree = false;
        phaseTwo = false;
        phaseOne = true;

        spawnerOne.GetComponent<Spawner>().enabled = true;
        spawnerTwo.GetComponent<Spawner>().enabled = false;
        spawnerThree.GetComponent<Spawner>().enabled = false;
        spawnerOneHard.GetComponent<Spawner>().enabled = false;
        spawnerTwoHard.GetComponent<Spawner>().enabled = false;
        spawnerThreeHard.GetComponent<Spawner>().enabled = false;

    }

    public void GameOver()
    {
        EndAppled();
        EndFired();
        EndHoneyed();

        onGameOver.Invoke();
        currentScore = 0;
        isPlaying = false;

        doubleJump = false;
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public void Honeyed()
    {
        playerHealth.Heal(1);
        isHoneyed = true;
        honeyedText.gameObject.SetActive(true);
        CancelInvoke("EndHoneyed");
        Invoke("EndHoneyed", buffDuration);
    }

    public void EndHoneyed()
    {
        isHoneyed = false;
        honeyedText.gameObject.SetActive(false);
    }

    public void Appled()
    {
        doubleJump = true;
        isAppled = true;
        appledText.gameObject.SetActive(true);
        CancelInvoke("EndAppled");
        Invoke("EndAppled", buffDuration);
    }

    public void EndAppled()
    {
        isAppled = false;
        appledText.gameObject.SetActive(false);
    }

    public void Fired()
    {
        isFired = true;
        firedText.gameObject.SetActive(true);
        CancelInvoke("EndFired");
        Invoke("EndFired", 30f);
    }

    public void EndFired()
    {   
        isFired = false;
        firedText.gameObject.SetActive(false);
    }

    private void Hardmode(){
        buffDuration = buffDuration/2;
        obstacleSpeed = obstacleSpeed*2;
    }
}
