using UnityEngine;
using System.Collections;

public class Enemy : GameActor
{
    public Rigidbody rigid;

    public GameObject bolt;
    public GameObject boltGrid;
    
    public float waitTime;
    public float waitShoot;
    public float shootRate;

    public float beforeTran;
    public float tranTime;
    public float tranSpeed;

    public float tilt;
    public int maxCount;

    private Vector3 nextPos = Vector3.zero;
    private float z_currSpeed;
    private float target;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Fire", waitShoot, shootRate);
        z_currSpeed = rigid.velocity.z;
        StartCoroutine(RandonVector());

    }	

    void FixedUpdate()
    {
        nextPos.x = target;
        nextPos.y = 0;
        nextPos.z = z_currSpeed;
        rigid.velocity = nextPos;
        rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, this.X_limit.x, this.X_limit.y), 0, Mathf.Clamp(rigid.position.z, this.Z_limit.x, this.Z_limit.y));
        rigid.rotation = Quaternion.Euler(0, 0, rigid.velocity.x * -tilt);
    }

    IEnumerator RandonVector()
    {
        yield return new WaitForSeconds(beforeTran);
        while (true)
        {
            target = Random.Range(1, tranSpeed) * - Mathf.Sign(rigid.position.x);
            yield return new WaitForSeconds(tranTime);
            target = 0;
            yield return new WaitForSeconds(tranTime);
        }
        
    }


    private void Fire()
    {
        int count = Random.Range(0, maxCount);
        if (count != 0)
        {
            StopCoroutine("AutoFire");
            StartCoroutine(AutoFire(count));
        }
        
    }

    IEnumerator AutoFire(int count)
    {        
        for(int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(bolt, boltGrid.transform.position, boltGrid.transform.rotation) as GameObject;
            GameActor actor = go.GetComponent<GameActor>();
            if (actor != null)
            {
                actor.fight = 1;
            }
            yield return new WaitForSeconds(waitTime);
        }
        
    }
}
