//-------------------------------------------------------------------------------
// <copyright file="DummyPriceDetailService.cs" company="Ltd">
//     Copyright (c) Ltd. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace XPrice
{
    using Mediachase.Commerce.Pricing;
    using System;
    using System.Collections.Generic;
    using Mediachase.Commerce.Catalog;
    using EPiServer.Core;
    using Mediachase.Commerce;

    public class DummyPriceDetailService : IPriceDetailService
    {
        #region Private Members
        #endregion

        #region Constructors
        #endregion

        #region Properties
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
        public void Delete(IEnumerable<long> priceValueIds)
        {
        }

        public IPriceDetailValue Get(long priceValueId)
        {
            return new PriceDetailValue();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IList<IPriceDetailValue> List(ContentReference catalogContentReference, MarketId marketId, PriceFilter filter, int offset, int count, out int totalCount)
        {
            totalCount = 0;
            return new List<IPriceDetailValue>();
        }

        public IList<IPriceDetailValue> List(ContentReference catalogContentReference, int offset, int count, out int totalCount)
        {
            totalCount = 0;
            return new List<IPriceDetailValue>();
        }

        public IList<IPriceDetailValue> List(ContentReference catalogContentReference)
        {
            return new List<IPriceDetailValue>();
        }

        public void ReplicatePriceServiceChanges(IEnumerable<CatalogKey> catalogKeySet, IEnumerable<IPriceValue> priceValuesList)
        {
        }

        public IList<IPriceDetailValue> Save(IEnumerable<IPriceDetailValue> priceValues)
        {
            return new List<IPriceDetailValue>();
        }
    }
}