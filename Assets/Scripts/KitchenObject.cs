using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParant kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO() 
    { 
        return kitchenObjectSO; 
    }

    public void SetKitchenObjectParent(IKitchenObjectParant kitchenObjectParent)
    {
        if(this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;
        
        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Has a IKitchenObjectParant!");
        }

        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParant GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
