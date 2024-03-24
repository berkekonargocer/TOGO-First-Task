using UnityEngine;
using UnityEngine.Pool;

public class PlayerTriggerCollider : MonoBehaviour
{
    //[SerializeField] IObjectPool<Road> roadPool;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectable")) 
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
            collectable.Collect();
        }

        //if (other.gameObject.CompareTag("Road Spawn Trigger"))
        //{
        //    Road road = RoadPool.Instance.Pool.Get();
        //    road.transform.position = new Vector3(0, 0, 155f);
        //}
    }
}