using UnityEngine;
using System.Collections;

public class GameActor : MonoBehaviour {

    public int fight;
    public int score;

    public Vector2 X_limit;
    public Vector2 Z_limit;

    public delegate void GameOverDelegate();
    public GameOverDelegate GameOverDelegateHandle;

    void OnTriggerEnter(Collider col)
    {
        GameActor actor = col.gameObject.GetComponent<GameActor>();
        if (actor != null)
        {
            Contact(actor);
        }

    }

    /// <summary>
    /// 碰撞处理
    /// </summary>
    /// <param name="col"></param>
    public virtual void Contact(GameActor col) { }

    /// <summary>
    /// 是否是相同阵营
    /// </summary>
    /// <param name="actor"></param>
    /// <returns></returns>
    public bool isSameFource(GameActor actor)
    {
        return this.fight == actor.fight;
    }
}
