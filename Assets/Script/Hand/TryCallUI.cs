using UnityEngine;

public class TryCallUI : MonoBehaviour
{
    [SerializeField] UIManager UIManager;

    private void Awake()
    {
        GameObject uiManagerObject = GameObject.FindGameObjectWithTag("UI Manager");

        if (uiManagerObject != null)
        {
            UIManager = uiManagerObject.GetComponent<UIManager>();
        } else
        {
            Debug.Log("UI Manager Not Found");
        }
    }

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

    [ContextMenu("debug employee")]

    public void employeePopUpDebug()
    {
        Coroutine showWarning = StartCoroutine(UIManager.warningCoroutine(0, new Vector2(800, 100), 3f));
    }

    [ContextMenu("debug supervisor")]
    public void supervisorPopUpDebug()
    {
        Coroutine showWarning = StartCoroutine(UIManager.warningCoroutine(1, new Vector2(200, 200), 3f));
    }

    [ContextMenu("debug message")]
    public void debugMassage()
    {
        UIManager.showMessage("this massage");
    }

    [ContextMenu("debug timer")]
    public void timerDebug()
    {
        UIManager.startTimer(10);
    }

    [ContextMenu("stop timer debug")]
    public void stopTimerDebug()
    {
        UIManager.stopTimer();
    }
}

