using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] private int doorId;
    [SerializeField] private GameObject door;
    private bool isOpen = false;
    private bool canOpenDoor = false;

    [Header("Spawn Enemies")]
    [SerializeField] GameObject enemy;
    [SerializeField] private int numberEnemies;
    [SerializeField] Vector2 limitX;
    [SerializeField] Vector2 limitZ;


    private void Awake()
    {
        CheckPlayerInBackDoor.onPlayerInBackDoor += PlayerEntered;
        CheckPlayerInBackDoor.onPlayerInBackDoor += SpawnEnemies;
    }

    private void OnDisable()
    {
        CheckPlayerInBackDoor.onPlayerInBackDoor -= PlayerEntered;
        CheckPlayerInBackDoor.onPlayerInBackDoor -= SpawnEnemies;
    }

    void Start()
    {
        UIManager.instance.HideRecommendOpenDoor();
    }

    private void Update()
    {
        if (canOpenDoor)
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIManager.instance.HideRecommendOpenDoor();
                AudioSFXManager.instance.openDoorSound.Play();
                isOpen = true;
            }

        if (isOpen)
            OpenDoor();
        else
            CloseDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (!isOpen && EnemyManager.instance.isClearRoom)
            {
                UIManager.instance.ShowRecommendOpenDoor();
                canOpenDoor = true;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        canOpenDoor = false;
        UIManager.instance.HideRecommendOpenDoor();
    }
    private void OpenDoor()
    {
        door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, Quaternion.Euler(0f, 90f, 0f) * transform.rotation, 360 * Time.deltaTime);
    }
    private void CloseDoor()
    {
        door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, Quaternion.Euler(0f, 0, 0f) * transform.rotation, 360 * Time.deltaTime);
    }

    private void PlayerEntered(int _doorId)
    {
        if (_doorId == doorId)
            isOpen = false;
    }    

    private void SpawnEnemies(int _doorId)
    {
        if (_doorId != doorId) return;
        if (numberEnemies <= 0) return;

        for (int i = 0; i < numberEnemies; i++)
        {
            Instantiate(
                enemy,
                new Vector3(Random.Range(limitX.x, limitX.y), .5f, Random.Range(limitZ.x, limitZ.y)),
                Quaternion.identity, EnemyManager.instance.enemiesParent);
        }
    }
}
