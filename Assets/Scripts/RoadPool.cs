using UnityEngine;
using UnityEngine.Pool;

public class PointPool : MonoBehaviour
{
    public static PointPool Instance { get; private set; }

    [SerializeField] Road pointPrefab;
    [SerializeField] int defaultCapacity;
    [SerializeField] int maxSize;

    public IObjectPool<Road> Pool { get; private set; }

    private void Awake() {
        Initialize();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Pool.Get();
    }

    void Initialize() {
        Pool = new ObjectPool<Road>(OnCreate, OnGet, OnRelease, OnDestroyObject, true, defaultCapacity, maxSize);
    }

    Road OnCreate() {
        Road road = Instantiate(pointPrefab, new Vector3(0, 0, 65.4f), Quaternion.identity);
        //road.SetPool(Pool);
        return road;
    }

    void OnGet(Road road) {
        road.gameObject.SetActive(true);
    }

    void OnRelease(Road road) {
        road.gameObject.SetActive(false);
    }

    void OnDestroyObject(Road road) {
        Destroy(road.gameObject);
    }

}