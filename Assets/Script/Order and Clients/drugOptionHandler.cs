using UnityEngine;
using TMPro;

public class drugOptionHandler : MonoBehaviour
{
    public TextMeshProUGUI amountText;

    private void Start()
    {
        amountText = this.gameObject.GetComponent<TextMeshProUGUI>();   
    }

    public void addAmount()
    {
        string optionName = this.gameObject.name;
        int orderAmountIndex = (int)char.GetNumericValue(optionName[optionName.Length - 1]);

        if (UIManager.drugOrderAmount[orderAmountIndex] < 5 && UIManager.orderLimit > 0)
        {
            UIManager.drugOrderAmount[orderAmountIndex]++;
            UIManager.orderLimit--;
            updateText(orderAmountIndex);
        }
    }

    public void substractAmount()
    {
        string optionName = this.gameObject.name;
        int orderAmountIndex = (int)char.GetNumericValue(optionName[optionName.Length - 1]);

        if (UIManager.drugOrderAmount[orderAmountIndex] > 0)
        {
            UIManager.drugOrderAmount[orderAmountIndex]--;
            UIManager.orderLimit++;
            updateText(orderAmountIndex);
        }
    }

    public void updateText(int orderAmountIndex)
    {
        amountText.text = UIManager.drugOrderAmount[orderAmountIndex].ToString();
    }
}
