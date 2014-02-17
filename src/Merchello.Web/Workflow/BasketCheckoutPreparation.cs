﻿using Merchello.Core;
using Merchello.Core.Checkout;
using Merchello.Core.Models;

namespace Merchello.Web.Workflow
{
    public class BasketCheckoutPreparation : CheckoutPreparationBase, IBasketCheckoutPreparation
    {
        internal BasketCheckoutPreparation(IMerchelloContext merchelloContext, IItemCache itemCache, ICustomerBase customer) 
            : base(merchelloContext, itemCache, customer)
        { }

        internal static BasketCheckoutPreparation GetBasketCheckoutPreparation(IBasket basket)
        {
            return GetBasketCheckoutPreparation(Core.MerchelloContext.Current, basket);
        }

        internal static BasketCheckoutPreparation GetBasketCheckoutPreparation(IMerchelloContext merchelloContext, IBasket basket)
        {
            var customer = basket.Customer;
            var itemCache = GetItemCache(merchelloContext, customer, basket.VersionKey);
            foreach (var item in basket.Items)
            {
                // convert to a LineItem of the same type for use in the CheckoutPrepartion collection
                itemCache.AddItem(item.AsLineItemOf<ItemCacheLineItem>());
            }
            return new BasketCheckoutPreparation(merchelloContext, itemCache, customer);
        }

        public override void SaveBillToAddress(IAddress billToAddress)
        {
            base.SaveBillToAddress(billToAddress);
        }

        public override void SaveShipmentRateQuote(Core.Gateways.Shipping.IShipmentRateQuote approvedShipmentRateQuote)
        {
            base.SaveShipmentRateQuote(approvedShipmentRateQuote);
        }

        public override void SaveShipmentRateQuote(System.Collections.Generic.IEnumerable<Core.Gateways.Shipping.IShipmentRateQuote> approvedShipmentRateQuotes)
        {
            base.SaveShipmentRateQuote(approvedShipmentRateQuotes);
        }

        public override void SaveShipToAddress(IAddress shipToAddress)
        {
            base.SaveShipToAddress(shipToAddress);
        }

    }
}