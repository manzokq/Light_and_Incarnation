using UnityEngine;
using UnityEngine.SceneManagement;

public class OP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MapTutorial");
        }
    }
}