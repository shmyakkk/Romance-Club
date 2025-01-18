using System;
using System.Resources;
using UnityEngine;
using UnityEngine.Purchasing;

public class MyIAPManager : MonoBehaviour, IStoreListener
{

    private IStoreController controller;
    private IExtensionProvider extensions;

    public static string diamonds500 = "diamonds500";
    public static string diamonds150 = "diamonds150";
    public static string diamonds50 = "diamonds50";
    public static string diamonds25 = "diamonds25";


    void Start()
    {
        if (controller == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(diamonds500, ProductType.Consumable);
        builder.AddProduct(diamonds150, ProductType.Consumable);
        builder.AddProduct(diamonds50, ProductType.Consumable);
        builder.AddProduct(diamonds25, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void Buy_500()
    {
        BuyProductID(diamonds500);
    }

    public void Buy_150()
    {
        BuyProductID(diamonds150);
    }

    public void Buy_50()
    {
        BuyProductID(diamonds50);
    }
    public void Buy_25()
    {
        BuyProductID(diamonds25);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = controller.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                controller.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
    {
        if (String.Equals(args.purchasedProduct.definition.id, diamonds500, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            ResourceManager.Instance.Diamonds += 500;

        }
        else if (String.Equals(args.purchasedProduct.definition.id, diamonds150, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            ResourceManager.Instance.Diamonds += 150;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, diamonds50, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            ResourceManager.Instance.Diamonds += 150;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, diamonds25, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            ResourceManager.Instance.Diamonds += 25;
        }
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer) 
        {
            Debug.Log("RestorePurchases started ...");

            var apple = extensions.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions((result) =>
            {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        this.controller = controller;
        this.extensions = extensions;
    }

    private bool IsInitialized()
    {
        return controller != null && extensions != null;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new NotImplementedException();
    }
}
