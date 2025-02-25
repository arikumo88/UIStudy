using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class ReturnButton : MonoBehaviour
{
    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
