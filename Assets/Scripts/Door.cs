using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        if (gameObject.tag == "Casino")
        {
            GameManager.Instance.LoadGambleRoomScene();
            return;
        } else
        {
            GameManager.Instance.LoadScene(gameObject.tag);
            return;
        }
    }
}
