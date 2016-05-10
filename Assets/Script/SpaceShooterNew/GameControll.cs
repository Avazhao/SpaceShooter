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

    void Start()
    {
        setScore(0);
        player.updateScoreDelegateHandle = setScore;
        player.GameOverDelegateHandle = gameOver;

        StartCoroutine(generate());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
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
            for (int i = 0; i < count; i++)
            {
                generatePos = spawnPot.transform.position;
                generatePos.x = Random.Range(spawnPot.transform.position.x, -spawnPot.transform.position.x);
                Instantiate(trouble[Random.Range(0, trouble.Length)],spawnPot.transform.position,Quaternion.identity);
                yield return new WaitForSeconds(generateRate);
            }
            yield return new WaitForSeconds(beforeGenerate);
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

    private void gameOver()
    {
        gaming.show(false);
        overWin.show(true);
        overWin.setScore(totalscore);
        overWin.pressRDelegateHandle = delegate ()
        {
            Application.LoadLevel(Application.loadedLevel);
        };
        
    }
}
