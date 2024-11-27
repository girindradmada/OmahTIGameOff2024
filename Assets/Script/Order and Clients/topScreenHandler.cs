using UnityEngine;
using TMPro;

public class topScreenHandler : MonoBehaviour
{
    [SerializeField] Gamemanager _gameManager;
    [SerializeField] UIManager _uiManager;
    [SerializeField] TextMeshProUGUI listText;
    int index;

    private void Awake()
    {
        GameObject _handObject = GameObject.FindGameObjectWithTag("Hand");
        GameObject _uiManagerObject = GameObject.FindGameObjectWithTag("UI Manager");

        if (_handObject != null)
        {
            _gameManager = _handObject.GetComponent<Gamemanager>();
        }
        else
        {
            Debug.Log("hah?");
        }

        if (_uiManagerObject != null)
        {
            _uiManager = _uiManagerObject.GetComponent<UIManager>();
        }
        else
        {
            Debug.Log("hah 2");
        }
    }

    private void Start()
    {
        listText = this.GetComponent<TextMeshProUGUI>();
    }

}
