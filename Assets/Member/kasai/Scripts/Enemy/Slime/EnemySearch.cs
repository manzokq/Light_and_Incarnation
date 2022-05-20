using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    [SerializeField] private GameObject searchObject;
    public bool Search=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Search = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Search = false;
    }
}
