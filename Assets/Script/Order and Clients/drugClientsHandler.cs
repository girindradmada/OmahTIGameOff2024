using UnityEngine;
using TMPro;

public class drugClientsHandler : MonoBehaviour
{
    [SerializeField] Gamemanager _gameManager;
    [SerializeField] UIManager _uiManager;
    [SerializeField] TextMeshProUGUI listText;

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
        getNCustomers();
    }

    [ContextMenu("try debug")]
    public void getNCustomers()
    {
        for (int i = 0; i < _gameManager.CustomerScripO.Ncust.Length; i++)
        {
            listText.text += _gameManager.CustomerScripO.Ncust[i].name + ": ";

            for (int j = 0; j < _uiManager.listOfDrugs.Length; j++)
            {
                if (_gameManager.CustomerScripO.Ncust[i].Nitems[j] > 0)
                {
                    listText.text += _gameManager.CustomerScripO.Ncust[i].Nitems[j].ToString() + " " + _uiManager.listOfDrugs[j].TheName;

                    if (_gameManager.CustomerScripO.Ncust[i].Nitems[j + 1] > 0)
                    {
                        listText.text += ", ";
                    }

                }
            }

            listText.text += "\n\n";
        }
    }
}
