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
        collectable.transform.SetParent(ItemCarryPosition);

        if (Items.Count == 0)
        {
            collectable.transform.localPosition = Vector3.zero;
        }
        else
        {
            Transform lastItemTransform = Items.Peek().transform;
            collectable.transform.localPosition = new Vector3(0, lastItemTransform.localPosition.y + lastItemTransform.localScale.y, 0);
        }

        collectable.transform.localRotation = Quaternion.Euler(new Vector3(collectable.transform.localRotation.x, Random.Range(0, 360), collectable.transform.localRotation.z));

        Items.Push(collectable);
        OnItemAmountChange?.Invoke(Items.Count);
    }

    public void RemoveItem() {
        if (Items.Count <= 0)
            return;

        Transform removedItem = Items.Pop().transform;
        GameObject removedObject = removedItem.gameObject;
        removedObject.GetComponent<Collider>().enabled = false;
        removedItem.SetParent(null);
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

        removedItem.DOMove(new Vector3(moveDirection, -2, 0), 0.75f).SetRelative().OnComplete(() => Destroy(removedObject));

        OnItemAmountChange?.Invoke(Items.Count);
    }

    public void RemoveAllItems() {
        for (int i = Items.Count; i > 0; i--)
        {
            RemoveItem();
        }
    }
}
