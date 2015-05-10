//-------------------------------------------------------------------------------
// <copyright file="ReadOnlyPriceValue.cs" company="Ltd">
//     Copyright (c) Ltd. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace XPrice
{
    using Mediachase.Commerce;
    using Mediachase.Commerce.Catalog;
    using Mediachase.Commerce.Pricing;
    using System;

    /// <summary>
    /// Read only price value
    /// </summary>
    public class ReadOnlyPriceValue : IPriceValue
    {
        #region Private Members
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="catalogKey">catalog key</param>
        /// <param name="marketId">market Id</param>
        /// <param name="minQuantity">min quantity</param>
        /// <param name="unitPrice">unit price</param>
        /// <param name="customerPricing">customer Pricing</param>
        /// <param name="validFrom">valid from</param>
        /// <param name="validUntil">valid until</param>
        public ReadOnlyPriceValue(CatalogKey catalogKey, MarketId marketId, decimal minQuantity, Money unitPrice, CustomerPricing customerPricing, DateTime validFrom, DateTime? validUntil)
        {
            this.CatalogKey = catalogKey;
            this.MarketId = marketId;
            this.CustomerPricing = customerPricing;
            this.ValidFrom = validFrom;
            this.ValidUntil = validUntil;
            this.MinQuantity = minQuantity;
            this.UnitPrice = unitPrice;
        }

        /// <summary>
        /// Constuctor to copy value from
        /// </summary>
        /// <param name="from"></param>
        public ReadOnlyPriceValue(IPriceValue from)
        {
            this.CatalogKey = new CatalogKey(from.CatalogKey.ApplicationId, from.CatalogKey.CatalogEntryCode);
            this.MarketId = from.MarketId;
            this.MinQuantity = from.MinQuantity;
            this.UnitPrice = from.UnitPrice;
            this.CustomerPricing = from.CustomerPricing;
            this.ValidFrom = from.ValidFrom;
            this.ValidUntil = from.ValidUntil;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Catalog key
        /// </summary>
        public CatalogKey CatalogKey
        {
            get;
            private set;
        }

        /// <summary>
        /// Customer based pricing
        /// </summary>
        public CustomerPricing CustomerPricing
        {
            get;
            private set;
        }

        /// <summary>
        /// Market id
        /// </summary>
        public MarketId MarketId
        {
            get;
            private set;
        }

        /// <summary>
        /// Min Qunatity
        /// </summary>
        public decimal MinQuantity
        {
            get;
            private set;
        }

        /// <summary>
        /// Unit Price
        /// </summary>
        public Money UnitPrice
        {
            get;
            private set;
        }

        /// <summary>
        /// Valid from
        /// </summary>
        public DateTime ValidFrom
        {
            get;
            private set;
        }

        /// <summary>
        /// Valid until
        /// </summary>
        public DateTime? ValidUntil
        {
            get;
            private set;
        }
        #endregion

        #region Methods
        #region Public
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