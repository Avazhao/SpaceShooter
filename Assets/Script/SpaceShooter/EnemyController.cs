using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    /// <summary>
    /// 开始左右移动前的等待时间
    /// </summary>
    public Vector2 startWait;
    /// <summary>
    /// 每次左右移动的时间
    /// </summary>
    public Vector2 maneuverTime;
    /// <summary>
    /// 每次左右移动结束开始下次左右移动的时间
    /// </summary>
    public Vector2 maneuverWait;
    public float doge;
    public float smoothing;
    public Baundry baudry;

    public GameObject shot;
    public Transform shotSpawn;
    public float delay;
    public float fireRate;

    public Trouble tro;

    private Rigidbody rig;
    private float ZSpeed = -5;

    private float targetManeuver = 0;
    private float target = 0;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
        StartCoroutine(RamdonTarget());
        InvokeRepeating("Fire", delay, fireRate);
    }	

    IEnumerator RamdonTarget()
    {
        //随机等待一段时间
        yield return new WaitForSeconds(Random.Range(startWait.x,startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, doge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void Fire()
    {
       GameObject go = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        go.GetComponent<Trouble>().GameOverDelegateHandle = tro.GameOverDelegateHandle;
        GetComponent<AudioSource>().Play();
    }

    void FixedUpdate()
    {
        target = Mathf.MoveTowards(rig.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rig.velocity = new Vector3(target, 0, ZSpeed);
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, baudry.XMin, baudry.XMax), 0, Mathf.Clamp(rig.position.z, baudry.YMin, baudry.YMax));
    }
}
