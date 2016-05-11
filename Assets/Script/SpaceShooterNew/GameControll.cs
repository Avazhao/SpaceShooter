using UnityEngine;
using System.Collections;

public class GameControll : MonoBehaviour {

    public Player player;
    public GameObject[] trouble;
    public GameOverWin overWin;
    public GamingWin gaming;

    public int maxCount;
    public float beforeGenerate;
    public float generateRate;
    public GameObject spawnPot;

    private int totalscore = 0;
    private Vector3 generatePos = Vector3.zero;
    private bool gameOver = false;

    void Start()
    {
        setScore(0);
        player.updateScoreDelegateHandle = setScore;
        player.GameOverDelegateHandle = GameOver;

        StartCoroutine(generate());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R) && gameOver)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator generate()
    {
        yield return new WaitForSeconds(beforeGenerate);

        int count = Random.Range(1, maxCount);
        while (true)
        {
           // if (!gameOver)
          //  {
                for (int i = 0; i < count; i++)
                {
                    generatePos = spawnPot.transform.position;
                    generatePos.x = Random.Range(spawnPot.transform.position.x, -spawnPot.transform.position.x);
                    GameObject go = Instantiate(trouble[Random.Range(0, trouble.Length)], generatePos, Quaternion.identity) as GameObject;
                    go.transform.SetParent(spawnPot.transform);
                    yield return new WaitForSeconds(generateRate);
                }

                yield return new WaitForSeconds(beforeGenerate);
         //   }            
            
        }
        
    }

    private void updateScore()
    {
        gaming.updateScore(totalscore);
    }

    private void setScore(int score)
    {
        this.totalscore += score;
        updateScore();
    }

    private void GameOver()
    {
        gameOver = true;
        gaming.show(false);
        overWin.show(true);
        overWin.setScore(totalscore);
        overWin.pressRDelegateHandle = delegate ()
        {
            Application.LoadLevel(Application.loadedLevel);
        };
        
    }
}
