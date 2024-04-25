using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class Inventory : MonoBehaviour
{
    [field: SerializeField] public Transform ItemCarryPosition { get; private set; }
    public Stack<ICollectable> Items { get; private set; } = new Stack<ICollectable>();

    public event Action<int> OnItemAmountChange;

    public void AddItem(ICollectable collectable) {
        Transform collectableTransform = collectable.transform;
        collectableTransform.gameObject.GetComponent<Collider>().enabled = false;
        collectableTransform.SetParent(ItemCarryPosition);

        if (Items.Count == 0)
        {
            collectableTransform.localPosition = Vector3.zero;
        }
        else
        {
            Transform lastItemTransform = Items.Peek().transform;
            collectableTransform.localPosition = new Vector3(0, lastItemTransform.localPosition.y + lastItemTransform.localScale.y, 0);
        }

        collectableTransform.localRotation = Quaternion.Euler(new Vector3(collectableTransform.localRotation.x, Random.Range(0, 360), collectableTransform.localRotation.z));

        Items.Push(collectable);
        OnItemAmountChange?.Invoke(Items.Count);
    }

    public void RemoveItem() {
        if (Items.Count <= 0)
            return;

        Transform removedItemTransform = Items.Pop().transform;
        GameObject removedObject = removedItemTransform.gameObject;
        removedObject.GetComponent<Collider>().enabled = false;
        removedItemTransform.SetParent(null);
        int randomNum = Random.Range(0, 2);
        int moveDirection;

        if (randomNum == 0)
        {
            moveDirection = -15;
        }
        else
        {
            moveDirection = 15;
        }

        removedItemTransform.DOMove(new Vector3(moveDirection, -2, 0), 0.75f).SetRelative().OnComplete(() => Destroy(removedObject));

        OnItemAmountChange?.Invoke(Items.Count);
    }

    public void RemoveAllItems() {
        for (int i = Items.Count; i > 0; i--)
        {
            RemoveItem();
        }
    }
}
