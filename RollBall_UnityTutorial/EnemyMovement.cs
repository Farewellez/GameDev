using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent enemy;
    public TextMeshProUGUI countText; // UI text component to display count of "PickUp" objects collected.
    public GameObject winText; // UI object to display winning text.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();

        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            enemy.SetDestination(player.position);
        }
        else
        {
            enemy.isStopped = true;
        }
    }

    void OnTriggerEnter(Collider target)
    {
        Debug.Log("OnTrigger aktif!");
        if (target.gameObject.CompareTag("Pemain"))
        {
            Debug.Log("Menyentuh player");
            Destroy(target.gameObject);

            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!!!";
            winText.gameObject.SetActive(true);
        }
    }
}
