using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Btn_start()
    {
        SceneManager.LoadScene(1);
    }
}
