using DG.Tweening;
using NOJUMPO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class Inventory : MonoBehaviour
{
    [field: SerializeField] public Transform ItemCarryPosition { get; private set; }
    public Stack<ICollectable> Items { get; private set; } = new Stack<ICollectable>();

    public event Action<int> OnItemAmountChange;

    [SerializeField] float itemStackOffset = 0.15f;


    void OnEnable() {
        //GameManager.Instance.OnWinGame += OnWinGame;
    }

    void OnDisable() {
        //GameManager.Instance.OnWinGame -= OnWinGame;
    }


    public void AddItem(ICollectable collectable) {
        Transform collectableTransform = collectable.transform;

        Collider collectableCollider = collectable.GetCollider;
        collectableCollider.enabled = false;

        collectableTransform.SetParent(ItemCarryPosition);
        collectableTransform.localPosition = Vector3.zero;
        collectableTransform.localRotation = Quaternion.Euler(Vector3.zero);

        FollowWithOffset fwOffset = collectable.GetFollowWithOffset;
        SmoothFollow smoothFollow = collectable.GetSmoothFollow;

        if (Items.Count == 0)
        {
            fwOffset.Setup(ItemCarryPosition, Vector3.zero, FollowDirection.Z);
            smoothFollow.Setup(transform, Vector3.zero, FollowDirection.X, 16);
        }
        else
        {
            Transform lastItemTransform = Items.Peek().transform;
            fwOffset.Setup(lastItemTransform, new Vector3(0, 0, lastItemTransform.localScale.z + itemStackOffset), FollowDirection.Z);
            smoothFollow.Setup(lastItemTransform, Vector3.zero, FollowDirection.X, 16);
        }

        Items.Push(collectable);

        OnItemAmountChange?.Invoke(Items.Count);

        ItemAddAnimation();

        collectableCollider.enabled = true;
    }

    public void RemoveItem() {
        if (Items.Count <= 0)
            return;

        ICollectable removedItem = Items.Pop();
        ScoreManager.Instance.DecrementScore(removedItem.Type.Point);
        Transform removedItemTransform = removedItem.transform;
        GameObject removedItemObject = removedItemTransform.gameObject;
        removedItemTransform.SetParent(null);

        //ItemRemoveAnimation(removedItemTransform, removedItemObject);
        Destroy(removedItemObject);

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

    void ItemRemoveAnimation(Transform removedItemTransform, GameObject removedItemObject) {
        removedItemObject.GetComponent<Collider>().enabled = false;

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

        removedItemTransform.DOMove(new Vector3(moveDirection, 0, 0), 0.75f).SetRelative().OnComplete(() => Destroy(removedItemObject));
    }

    //void OnWinGame(int score) {
    //    for (int i = Items.Count; i > 0; i--)
    //    {
    //        Transform itemTransform = Items.Pop().transform;
    //        itemTransform.SetParent(null);
    //        Collider itemCollider = itemTransform.GetComponent<Collider>();
    //        itemCollider.enabled = true;
    //        itemCollider.isTrigger = false;
    //        itemTransform.gameObject.AddComponent<Rigidbody>();
    //    }

    //    OnItemAmountChange?.Invoke(Items.Count);
    //}

    IEnumerator ScaleUpAndDownItemsOrderly(Stack<ICollectable> stack) {
        WaitForSeconds waitTime = new WaitForSeconds(0.1f);

        List<ICollectable> tempList = new List<ICollectable>(stack);

        foreach (ICollectable collectable in tempList)
        {
            if (collectable == null)
                continue;

            float initialScale = collectable.transform.localScale.x;
            collectable.transform.DOScale(0.15f, 0.15f).SetRelative().OnComplete(() => collectable.transform.DOScale(initialScale, 0.15f));
            yield return waitTime;
            collectable.transform.localScale = Vector3.one * initialScale;
        }
    }
}