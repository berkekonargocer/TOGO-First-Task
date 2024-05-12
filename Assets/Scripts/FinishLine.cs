using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem[] winGameParticleFX;

    //[SerializeField] Transform[] pointDestinations;

    //[SerializeField] Transform[] collectableStackPoints = new Transform[2];

    //[SerializeField] float itemStackOffset;

    //Stack<Transform> stackedSphereCollectableTransforms = new Stack<Transform>();
    //Stack<Transform> stackedCubeCollectableTransforms = new Stack<Transform>();

    Transform _playerTransform;


    void OnTriggerExit(Collider other) {
        OnTriggerExitICollectable(other);

        OnTriggerExitPlayer(other);
    }


    void OnTriggerExitICollectable(Collider other) {
        if (other.TryGetComponent(out ICollectable collectable))
        {
            collectable.transform.gameObject.SetActive(false);
        }
    }

    void OnTriggerExitPlayer(Collider other) {
        if (other.TryGetComponent(out Inventory inventory))
        {
            _playerTransform = inventory.transform;

            int inventoryItemCount = inventory.Items.Count;

            if (inventoryItemCount > 0)
            {
                WinResponse();
                return;
            }

            GameManager.Instance.LoseGame();
        }
    }

    void WinResponse() {
        //Vector3 targetDestination = pointDestinations[inventoryItemCount - 1].transform.position;
        //float targetDestinationZ = targetDestination.z;

        //await UniTask.WaitUntil(() => targetDestinationZ - _playerTransform.position.z < 0.01f);

        for (int i = 0; i < winGameParticleFX.Length; i++)
        {
            //Vector3 particleDestination = new Vector3(winGameParticleFX[i].transform.position.x, winGameParticleFX[i].transform.position.y, targetDestinationZ);
            //winGameParticleFX[i].transform.position = particleDestination;
            winGameParticleFX[i].Play();
        }

        GameManager.Instance.WinGame();
    }

    //void StackCollectables(ICollectable collectable) {
    //    Transform collectableTransform = collectable.transform;

    //    Destroy(collectable.GetFollowWithOffset);
    //    Destroy(collectable.GetSmoothFollow);

    //    if (collectable.Type.Point == 10)
    //    {
    //        collectableTransform.SetParent(collectableStackPoints[0]);

    //        if (stackedSphereCollectableTransforms.Count == 0)
    //        {
    //            collectableTransform.localPosition = Vector3.zero;
    //        }
    //        else
    //        {
    //            Transform lastCollectableTransform = stackedSphereCollectableTransforms.Peek();
    //            collectableTransform.localPosition = new Vector3(0, lastCollectableTransform.localPosition.y + lastCollectableTransform.localScale.y + itemStackOffset, 0);
    //        }

    //        stackedSphereCollectableTransforms.Push(collectableTransform);

    //        return;
    //    }

    //    collectableTransform.SetParent(collectableStackPoints[1]);

    //    if (stackedCubeCollectableTransforms.Count == 0)
    //    {
    //        collectableTransform.localPosition = Vector3.zero;
    //    }
    //    else
    //    {
    //        Transform lastCollectableTransform = stackedCubeCollectableTransforms.Peek();
    //        collectableTransform.localPosition = new Vector3(0, lastCollectableTransform.localPosition.y + lastCollectableTransform.localScale.y + itemStackOffset, 0);
    //        collectableTransform.localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
    //    }

    //    stackedCubeCollectableTransforms.Push(collectableTransform);
    //}
}