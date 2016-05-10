using UnityEngine;
using System.Collections;

public class Boltss : GameActor
{
    public delegate void updateScoreDelegate(int score);
    public updateScoreDelegate updateScoreDelegateHandle;

    public override void Contact(GameActor col)
    {
        if (this.fight == 1 || isSameFource(col)||col.gameObject.tag =="Bolt")
            return;

        updateScore(col.score);

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
