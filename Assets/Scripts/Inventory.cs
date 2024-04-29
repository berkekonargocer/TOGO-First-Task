using DG.Tweening;
using NOJUMPO;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class Inventory : MonoBehaviour
{
    [field: SerializeField] public Transform ItemCarryPosition { get; private set; }
    public Stack<ICollectable> Items { get; private set; } = new Stack<ICollectable>();

    public event Action<int> OnItemAmountChange;

    [SerializeField] float itemStackOffset = 0.15f;

    bool _isAddAnimationRunning = false;

    void OnEnable() {
        GameManager.Instance.OnWinGame += OnWinGame;
    }

    void OnDisable() {
        GameManager.Instance.OnWinGame -= OnWinGame;
    }


    public void AddItem(ICollectable collectable) {
        Transform collectableTransform = collectable.transform;

        Collider collectableCollider = collectableTransform.gameObject.GetComponent<Collider>();
        collectableCollider.enabled = false;

        collectableTransform.SetParent(ItemCarryPosition);

        FollowWithOffset fwOffset = collectableTransform.AddComponent<FollowWithOffset>();
        SmoothFollow smoothFollow = collectableTransform.AddComponent<SmoothFollow>();

        if (Items.Count == 0)
        {
            collectableTransform.localPosition = Vector3.zero;
            fwOffset.Setup(ItemCarryPosition, Vector3.zero, FollowDirection.Z);
            smoothFollow.Setup(transform, Vector3.zero, FollowDirection.X, 16);
        }
        else
        {
            Transform lastItemTransform = Items.Peek().transform;
            fwOffset.Setup(lastItemTransform, new Vector3(0, 0, lastItemTransform.localScale.z + itemStackOffset), FollowDirection.Z);
            smoothFollow.Setup(lastItemTransform, Vector3.zero, FollowDirection.X, 16);
            //collectableTransform.localPosition = new Vector3(0, 0, lastItemTransform.localPosition.z + lastItemTransform.localScale.z + itemStackOffset);
        }

        collectableTransform.localRotation = Quaternion.Euler(Vector3.zero);

        Items.Push(collectable);

        OnItemAmountChange?.Invoke(Items.Count);

        ItemAddAnimation();

        collectableCollider.enabled = true;
    }

    public void RemoveItem() {
        if (Items.Count <= 0)
            return;

        Transform removedItemTransform = Items.Pop().transform;
        GameObject removedObject = removedItemTransform.gameObject;
        removedItemTransform.SetParent(null);

        ItemRemoveAnimation(removedItemTransform, removedObject);

        OnItemAmountChange?.Invoke(Items.Count);
    }

    public void RemoveAllItems() {
        for (int i = Items.Count; i > 0; i--)
        {
            RemoveItem();
        }
    }

    void ItemAddAnimation() {
        StartCoroutine(ScaleUpAndDownItemsOrderly(Items));
    }

    void ItemRemoveAnimation(Transform removedItemTransform, GameObject removedObject) {
        removedObject.GetComponent<Collider>().enabled = false;
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

        removedItemTransform.DOMove(new Vector3(moveDirection, 0, 0), 0.75f).SetRelative().OnComplete(() => Destroy(removedObject));
    }

    void OnWinGame(int score) {
        for (int i = Items.Count; i > 0; i--)
        {
            Transform itemTransform = Items.Pop().transform;
            itemTransform.SetParent(null);
            Collider itemCollider = itemTransform.GetComponent<Collider>();
            itemCollider.enabled = true;
            itemCollider.isTrigger = false;
            itemTransform.AddComponent<Rigidbody>();
        }

        OnItemAmountChange?.Invoke(Items.Count);
    }

    IEnumerator ScaleUpAndDownItemsOrderly(Stack<ICollectable> stack) {
        WaitForSeconds waitTime = new WaitForSeconds(0.15f);

        List<ICollectable> tempList = new List<ICollectable>(stack);

        foreach (ICollectable collectable in tempList)
        {
            float initialScale = collectable.transform.localScale.x;
            collectable.transform.DOScale(0.1f, 0.2f).SetRelative().OnComplete(() => collectable.transform.DOScale(initialScale, 0.2f));
            yield return waitTime;
            collectable.transform.localScale = Vector3.one * initialScale;
        }
    }
}