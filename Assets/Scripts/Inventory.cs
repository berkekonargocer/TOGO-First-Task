using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public Transform ItemCarryPosition { get; private set; }
    Stack<ICollectable> _items = new Stack<ICollectable>();

    public void AddItem(ICollectable collectable) {
        collectable.transform.SetParent(ItemCarryPosition);

        if (_items.Count == 0)
        {
            collectable.transform.localPosition = Vector3.zero;
        }
        else
        {
            Transform lastItemTransform = _items.Peek().transform;
            collectable.transform.localPosition = new Vector3(0, lastItemTransform.localPosition.y + lastItemTransform.localScale.y, 0);
        }

        collectable.transform.localRotation = Quaternion.Euler(new Vector3(collectable.transform.localRotation.x, Random.Range(0, 360), collectable.transform.localRotation.z));

        _items.Push(collectable);
    }

    public void RemoveAnItem() {
        ICollectable removedItem = _items.Pop();
        removedItem.transform.SetParent(null);
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

        removedItem.transform.DOMove(new Vector3(moveDirection, -2, 0), 0.75f).SetRelative();
    }

    public void RemoveAllItems() {

    }
}
