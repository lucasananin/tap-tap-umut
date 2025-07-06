using UnityEngine;

public class DamageUiVfx : CanvasView
{
    private void OnEnable()
    {
        BalloonBehaviour.OnDestroyAllEffect += Play;
        ScoreHandler.OnDecrease += Play;
    }

    private void OnDisable()
    {
        BalloonBehaviour.OnDestroyAllEffect -= Play;
        ScoreHandler.OnDecrease -= Play;
    }

    [ContextMenu("Play()")]
    private void Play()
    {
        Play((BalloonBehaviour)null);
    }

    private void Play(ScoreHandler arg0)
    {
        Play((BalloonBehaviour)null);
    }

    private void Play(BalloonBehaviour arg0)
    {
        InstantShow();
        Hide();
    }
}
