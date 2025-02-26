using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//test
public class MenuNavigation : MonoBehaviour
{
    public Button[] menuButtons;
    private int selectedIndex = 0;
    private bool canMove = true;
    public RectTransform cursorImage;
    void Start()
    {
        SelectButton(selectedIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveSelection(-1);
        }
        
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            menuButtons[selectedIndex].onClick.Invoke();
        }
    }

    void MoveSelection(int direction)
    {
        if (!canMove) return;

        selectedIndex += direction;

        if (selectedIndex < 0) selectedIndex = menuButtons.Length - 1;
        if (selectedIndex >= menuButtons.Length) selectedIndex = 0;

        SelectButton(selectedIndex);
    }

    void SelectButton(int index)
    {
        EventSystem.current.SetSelectedGameObject(menuButtons[index].gameObject);

        if (cursorImage != null)
        {
            cursorImage.position = menuButtons[index].transform.position;
        }
    }
}
