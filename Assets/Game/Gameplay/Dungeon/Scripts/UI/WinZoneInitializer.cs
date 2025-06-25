using UnityEngine;

public class WinZoneInitializer : MonoBehaviour
{
    [SerializeField] private WinZone winZone;
    [SerializeField] private GameplayUI gameplayUI;

    private void Start()
    {
        winZone.Init(OnWin, null);
    }

    private void OnWin()
    {
        gameplayUI.OpenWinPanel();
    }
}
