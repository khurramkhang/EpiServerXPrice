//-------------------------------------------------------------------------------
// <copyright file="DummyPriceService.cs" company="Ltd">
//     Copyright (c) Ltd. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace XPrice
{
    using System;
    using System.Collections.Generic;
    using Mediachase.Commerce;
    using Mediachase.Commerce.Catalog;
    using Mediachase.Commerce.Pricing;
    
    /// <summary>
    /// Prices are retrived from XML
    /// ignoring other concerns as Events, Cache
    /// </summary>
    public class DummyPriceService : IPriceService
    {
        #region Private Members
        private ICatalogSystem catalogSystem;
        private IPriceDetailService priceDetailService;
        //private IChangeNotificationManager changeManager;
        #endregion

        #region Constructors
        public DummyPriceService(ICatalogSystem iCatalogSystem, IPriceDetailService iPriceDetailService)
        {
            this.catalogSystem = iCatalogSystem;
            this.priceDetailService = iPriceDetailService;
            //Change notifications and others injected components
        }
        #endregion

        #region Properties
        /// <summary>
        /// Is read only
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Get Catalog Entry Prices
        /// </summary>
        /// <param name="catalogKeys">catalog Keys</param>
        /// <returns>list of <c>IPriceValue</c></returns>
        public IEnumerable<IPriceValue> GetCatalogEntryPrices(IEnumerable<CatalogKey> catalogKeys)
        {
            //ToDo:Cache
            List<IPriceValue> prices = new List<IPriceValue>();
            foreach (var key in catalogKeys)
            {
                prices.Add(XPriceParser.GetPrice(key, MarketId.Empty, new Currency("GBP")));
            }
            return prices;
        }

        /// <summary>
        /// Get catalog entry prices of a catalog item
        /// </summary>
        /// <param name="catalogKey">catalog Key</param>
        /// <returns>list of <c>IPriceValue</c></returns>
        public IEnumerable<IPriceValue> GetCatalogEntryPrices(CatalogKey catalogKey)
        {
            List<IPriceValue> prices = new List<IPriceValue>();
            prices.Add(XPriceParser.GetPrice(catalogKey, MarketId.Empty, new Currency("GBP")));
            return prices;
        }

        /// <summary>
        /// Get Default price
        /// </summary>
        /// <param name="market">market id</param>
        /// <param name="validOn"> valid on</param>
        /// <param name="catalogKey">catalog key</param>
        /// <param name="currency">currency</param>
        /// <returns>returns <c>IPriceValue</c></returns>
        public IPriceValue GetDefaultPrice(MarketId market, DateTime validOn, CatalogKey catalogKey, Currency currency)
        {
            return XPriceParser.GetPrice(catalogKey, market, currency);
        }

        /// <summary>
        /// Get prices
        /// </summary>
        /// <param name="market">market id</param>
        /// <param name="validOn">valid on</param>
        /// <param name="catalogKeysAndQuantities">catalog keys and quantities</param>
        /// <param name="filter">price filter</param>
        /// <returns>list of <c>IPriceValue</c></returns>
        public IEnumerable<IPriceValue> GetPrices(MarketId market, DateTime validOn, IEnumerable<CatalogKeyAndQuantity> catalogKeysAndQuantities, PriceFilter filter)
        {
            List<IPriceValue> prices = new List<IPriceValue>();
            foreach (var key in catalogKeysAndQuantities)
            {
                prices.Add(XPriceParser.GetPrice(key.CatalogKey, MarketId.Empty, new Currency("GBP")));
            }
            return prices;
        }

        /// <summary>
        /// get prices
        /// </summary>
        /// <param name="market">market Id</param>
        /// <param name="validOn">valid on</param>
        /// <param name="catalogKeys">catalog keys</param>
        /// <param name="filter">price filter</param>
        /// <returns>list of <c>IPriceValue</c></returns>
        public IEnumerable<IPriceValue> GetPrices(MarketId market, DateTime validOn, IEnumerable<CatalogKey> catalogKeys, PriceFilter filter)
        {
            List<IPriceValue> prices = new List<IPriceValue>();
            foreach (var key in catalogKeys)
            {
                prices.Add(XPriceParser.GetPrice(key, MarketId.Empty, new Currency("GBP")));
            }
            return prices;
        }

        /// <summary>
        /// get prices
        /// </summary>
        /// <param name="market">market id</param>
        /// <param name="validOn">valid on</param>
        /// <param name="catalogKey">catalog key</param>
        /// <param name="filter">price filter</param>
        /// <returns>list of <c>IPriceValue</c></returns>
        public IEnumerable<IPriceValue> GetPrices(MarketId market, DateTime validOn, CatalogKey catalogKey, PriceFilter filter)
        {
            List<IPriceValue> prices = new List<IPriceValue>();
            prices.Add(XPriceParser.GetPrice(catalogKey, MarketId.Empty, new Currency("GBP")));
            return prices;
        }

        /// <summary>
        /// Replicate price detail changes
        /// </summary>
        /// <param name="catalogKeys">catalog keys</param>
        /// <param name="priceValues">price values</param>
        public void ReplicatePriceDetailChanges(IEnumerable<CatalogKey> catalogKeys, IEnumerable<IPriceValue> priceValues)
        {
            this.priceDetailService.ReplicatePriceServiceChanges(catalogKeys, priceValues);
        }

        /// <summary>
        /// set catalog entry prices
        /// </summary>
        /// <param name="catalogKeys">catalog keys</param>
        /// <param name="priceValues">price values</param>
        public void SetCatalogEntryPrices(IEnumerable<CatalogKey> catalogKeys, IEnumerable<IPriceValue> priceValues)
        {
            foreach (var key in catalogKeys)
            {
                if (!XPriceParser.prices.ContainsKey(key.CatalogEntryCode))                
                {
                    XPriceParser.prices.Add(key.CatalogEntryCode, 10.99m);
                }
            }
        }

        /// <summary>
        /// Set catalog item prices
        /// </summary>
        /// <param name="catalogKey">catalog key</param>
        /// <param name="priceValues">price values</param>
        public void SetCatalogEntryPrices(CatalogKey catalogKey, IEnumerable<IPriceValue> priceValues)
        {
            if (!XPriceParser.prices.ContainsKey(catalogKey.CatalogEntryCode))
            {
                XPriceParser.prices.Add(catalogKey.CatalogEntryCode, 10.99m);
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