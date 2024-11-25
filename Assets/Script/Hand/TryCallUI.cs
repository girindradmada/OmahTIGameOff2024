using UnityEngine;

public class TryCallUI : MonoBehaviour
{
    [ContextMenu("debug credit")]
    public void creditDebug()
    {
        UIManager.creditUpdate(-10);
    }

    [ContextMenu("debug suspison")]
    public void susDebug()
    {
        UIManager.susUpdate(20);
    }
}
