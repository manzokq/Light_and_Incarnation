using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    [SerializeField] private GameObject searchObject;
    public bool Search=false;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Search = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Search = false;
    }
}
