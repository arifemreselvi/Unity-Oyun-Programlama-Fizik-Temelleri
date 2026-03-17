using UnityEngine;

public class DelikYokEtme : MonoBehaviour
{
    void OnTriggerEnter(Collider diger)
    {
        if (diger.gameObject.tag == "Delik")
        {
            Destroy(gameObject);
        }
    }
}