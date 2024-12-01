using UnityEngine;

public class PopUpHandler : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] GameObject lookButton;
    [SerializeField] bool paper;
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
        if (paper) 
        {
            SoundManager.Instance.PlaySFX(10);
        }else SoundManager.Instance.PlaySFX(1);
        screen.SetActive(true);
        lookButton.SetActive(false);
        Hand.Instance.take(false);
        Gamemanager.Instance.Nbox.take(false);
    }

    public void exitScreen()
    {
        screen.SetActive(false);
        lookButton.SetActive(true);
        Hand.Instance.take(true);
        Gamemanager.Instance.Nbox.take(true);
    }
}
