using UnityEngine;
using System.Collections;

public class Boltss : GameActor
{
    public delegate void updateScoreDelegate(int score);
    public updateScoreDelegate updateScoreDelegateHandle;

    public override void Contact(GameActor col)
    {
        if (this.fight == 1 || isSameFource(col))
            return;

        updateScore(col.score);
        col.playExplore();
        Destroy(this.gameObject);
        Destroy(col.gameObject);
    }

    public void updateScore(int score)
    {
        if (updateScoreDelegateHandle != null)
        {
            updateScoreDelegateHandle(score);
        }
    }
}
