using UnityEngine;

public class SceneController : MonoBehaviour
{
    private GameObject _enemy;
    [SerializeField] private GameObject enemyPrefab;

    private void Start()
    {
    }

    private void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab);
            _enemy.transform.position = new Vector3(0, 2, 0);
            float angel = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angel, 0);
        }
    }
}