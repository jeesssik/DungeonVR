using UnityEngine;

public class ExteriorController : MonoBehaviour
{
    [SerializeField] private AudioEvent musicEvent;

    private void Start()
    {
        if (musicEvent != null)
        {
            GameManager.Instance.AudioManager.PlayAudio(musicEvent);
        }
    }
}
