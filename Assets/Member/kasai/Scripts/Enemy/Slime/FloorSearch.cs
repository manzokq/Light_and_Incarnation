using UnityEngine;

public class FloorSearch : MonoBehaviour
{
    private GameObject searchObject;
    private bool searcher = false;
    [HideInInspector] public bool Search = false;//Œ´ˆö‚Á‚Û‚¢

    private void Start()
    {
        searchObject = this.gameObject;
    }

    private void Update()
    {
        Search = searcher;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        searcher = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        searcher = false;
    }
}
