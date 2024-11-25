using UnityEngine;

public class PopUpHandler : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Transform OnHand;

    [SerializeField] GameObject screen;
    [SerializeField] GameObject lookButton;

    private void FixedUpdate()
    {

        var mouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        OnHand.position = mouseWorldPos;

    }

    private void Update()
    {
        handleClick();
    }

    public void handleClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(OnHand.position, Vector2.zero);
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
