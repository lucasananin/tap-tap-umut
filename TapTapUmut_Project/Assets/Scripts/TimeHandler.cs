using System.Collections;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] float _slowMotionDuration = 3f;
    [SerializeField] float _slowMotionTime = 0.1f;

    public void StartSlowMotion()
    {
        Time.timeScale = _slowMotionTime;
        StopAllCoroutines();
        StartCoroutine(SlowMotion_Routine());
    }

    private IEnumerator SlowMotion_Routine()
    {
        yield return new WaitForSecondsRealtime(_slowMotionDuration);
        ResetTime();
    }

    public void ResetTime()
    {
        Time.timeScale = 1;
    }
}
