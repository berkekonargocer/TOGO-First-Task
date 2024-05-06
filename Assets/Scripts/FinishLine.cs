using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem[] winGameParticleFX;

    [SerializeField] Transform[] collectableStackPoints = new Transform[2];

    [SerializeField] float itemStackOffset;

    Stack<Transform> stackedSphereCollectableTransforms = new Stack<Transform>();
    Stack<Transform> stackedCubeCollectableTransforms = new Stack<Transform>();


    void OnTriggerExit(Collider other) {
        OnTriggerExitICollectable(other);

        OnTriggerExitPlayer(other);
    }


    void OnTriggerExitICollectable(Collider other) {
        if (other.TryGetComponent(out ICollectable collectable))
        {
            GameObject inventoryParent = collectable.transform.parent.gameObject;
            GameObject playerParent = inventoryParent.transform.parent.gameObject;
            Inventory inventory = playerParent.GetComponentInChildren<Inventory>();
            Debug.Log($"{inventory.Items.Count}");
            Destroy(collectable.transform.gameObject);
        }
    }

    void OnTriggerExitPlayer(Collider other) {
        if (other.TryGetComponent(out Inventory inventory))
        {
            if (inventory.Items.Count > 0)
            {
                WinResponse();
                return;
            }

            GameManager.Instance.LoseGame();
        }
    }

    void WinResponse() {
        for (int i = 0; i < winGameParticleFX.Length; i++)
        {
            winGameParticleFX[i].Play();
        }

        GameManager.Instance.WinGame();
    }

    void StackCollectables(ICollectable collectable) {
        Transform collectableTransform = collectable.transform;

        Destroy(collectable.GetFollowWithOffset);
        Destroy(collectable.GetSmoothFollow);

        if (collectable.Type.Point == 10)
        {
            collectableTransform.SetParent(collectableStackPoints[0]);

            if (stackedSphereCollectableTransforms.Count == 0)
            {
                collectableTransform.localPosition = Vector3.zero;
            }
            else
            {
                Transform lastCollectableTransform = stackedSphereCollectableTransforms.Peek();
                collectableTransform.localPosition = new Vector3(0, lastCollectableTransform.localPosition.y + lastCollectableTransform.localScale.y + itemStackOffset, 0);
            }

            stackedSphereCollectableTransforms.Push(collectableTransform);

            return;
        }

        collectableTransform.SetParent(collectableStackPoints[1]);

        if (stackedCubeCollectableTransforms.Count == 0)
        {
            collectableTransform.localPosition = Vector3.zero;
        }
        else
        {
            Transform lastCollectableTransform = stackedCubeCollectableTransforms.Peek();
            collectableTransform.localPosition = new Vector3(0, lastCollectableTransform.localPosition.y + lastCollectableTransform.localScale.y + itemStackOffset, 0);
            collectableTransform.localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        }

        stackedCubeCollectableTransforms.Push(collectableTransform);
    }
}