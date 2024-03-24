using UnityEngine;
using UnityEngine.Pool;

public class PlayerTriggerCollider : MonoBehaviour
{
    PointSystem playerPointSystem;

    //[SerializeField] IObjectPool<Road> roadPool;

    private void Awake() {
        playerPointSystem = GetComponent<PointSystem>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectable")) 
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
            collectable.Collect(playerPointSystem);
        }

        //if (other.gameObject.CompareTag("Road Spawn Trigger"))
        //{
        //    Road road = PointPool.Instance.Pool.Get();
        //    road.transform.position = new Vector3(0, 0, 155f);
        //}
    }
}