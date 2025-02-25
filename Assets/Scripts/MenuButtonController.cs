using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{

    public void GotoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
