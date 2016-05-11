using UnityEngine;
using System.Collections;

public class Player : GameActor {

    public Rigidbody rigid;

    public GameObject bolt;
    public GameObject boltGrid;

    public float boltRate;
    public float moveSpeed;
    public float rotateSpeed;

    private float lastShootTime = 0;
    private Vector3 pos = Vector3.zero;

    public AudioSource bolt_audio;

    public delegate void updateScoreDelegate(int score);
    public updateScoreDelegate updateScoreDelegateHandle;

    // Use this for initialization
    void Start()
    {

      //  rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetButton("Fire1") && lastShootTime + boltRate <= Time.time)
        {
            lastShootTime = Time.time;
            Fire();
        }
    }

    void FixedUpdate()
    {
        pos.x = Input.GetAxis("Horizontal");
        pos.z = Input.GetAxis("Vertical");
        pos.y = 0.0f;

        rigid.velocity = pos * moveSpeed;
        rigid.rotation = Quaternion.Euler(0, 0, pos.x * rotateSpeed);

        //防止飞船飞出镜头外
        rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, X_limit.x, X_limit.y), 0, Mathf.Clamp(rigid.position.z, Z_limit.x, Z_limit.y));

    }   
       

    public override void Contact(GameActor col)
    {
        if (!isSameFource(col))
        {            
            this.playExplore();
            col.playExplore();
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            gameOver();
        }
    }

    public void gameOver()
    {
        if (GameOverDelegateHandle != null)
        {
            GameOverDelegateHandle();
        }
    }

    private void updateScore(int score)
    {
        if (updateScoreDelegateHandle != null)
        {
            updateScoreDelegateHandle(score);
        }
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    public void Fire()
    {
        GameObject go = Instantiate(bolt, boltGrid.transform.position, boltGrid.transform.rotation) as GameObject;
        go.transform.SetParent(boltGrid.transform);
        Boltss actor = go.GetComponent<Boltss>();
        actor.updateScoreDelegateHandle = updateScore;
        
    }

}
