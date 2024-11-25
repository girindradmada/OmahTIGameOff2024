using UnityEngine;

public class PopUpHandler : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] GameObject lookButton;

    private void Update()
    {
        handleClick();
    }

    public void handleClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    screenPopUp();
                    Debug.Log("Pop Up Flag");
                }
            }
        }
    }

    public void screenPopUp()
    {
        screen.SetActive(true);
        lookButton.SetActive(false);
    }

    public void exitScreen()
    {
        screen.SetActive(false);
        lookButton.SetActive(true);
    }
}
