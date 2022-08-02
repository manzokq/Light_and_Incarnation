using UnityEngine;
using UnityEngine.SceneManagement;

public class gm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Button()
   {
    SceneManager.LoadScene("GameOP");
        Time.timeScale = 1f;
    }

   void update()
   {
       
   }
}
