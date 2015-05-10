//-------------------------------------------------------------------------------
// <copyright file="XPriceParser.cs" company="Ltd">
//     Copyright (c) Ltd. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace XPrice
{
    using Mediachase.Commerce;
    using Mediachase.Commerce.Catalog;
    using Mediachase.Commerce.Pricing;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class XPriceParser
    {
        #region Properties
        /// <summary>
        /// prices
        /// </summary>
        public static Dictionary<string, decimal> prices = new Dictionary<string, decimal>() { { "9781405329767", 10.99m }, { "156756", 23.45m }, { "270664", 13.45m } };
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Retrive price value from enterprise services
        /// </summary>
        /// <param name="item">catalog item key</param>
        /// <param name="market">market id</param>
        /// <param name="currency">currency</param>
        /// <returns>product price</returns>
        public static IPriceValue GetPrice(CatalogKey item, MarketId market, Currency currency)
        {
            if (prices.ContainsKey(item.CatalogEntryCode))
            {
                return new ReadOnlyPriceValue(item, market, 0, new Money(prices[item.CatalogEntryCode], currency), CustomerPricing.AllCustomers, DateTime.MinValue, DateTime.MaxValue);
            }
            else
            {
                return new ReadOnlyPriceValue(item, market, 0, new Money(0m, currency), CustomerPricing.AllCustomers, DateTime.MinValue, DateTime.MaxValue);
            }
        }
        #endregion

        #region Internal
        #endregion

        #region Protected
        #endregion

        #region Private
        #endregion
        #endregion
    }
}