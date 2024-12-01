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
    }

    public void getNCustomers(Customer[] Ncust)
    {
        for (int i = 0; i < Ncust.Length; i++)
        {
            listText.text += Ncust[i].name + ": ";
            
            for (int j = 0; j < _uiManager.listOfDrugs.Length; j++)
            {
                if (Ncust[i].Nitems[j] > 0)
                {
                    if (Ncust[i].Nitems[j] > 1)
                    {
                        listText.text += Ncust[i].Nitems[j].ToString() + " ";
                    }
                    listText.text += _uiManager.listOfDrugs[j].TheName;
                    if (j < Ncust[i].Nitems.Length-1)
                    if (Ncust[i].Nitems[j + 1] > 0)
                    {
                        listText.text += ", ";
                    }

                }
            }

            listText.text += "\n\n";
        }
    }
}
