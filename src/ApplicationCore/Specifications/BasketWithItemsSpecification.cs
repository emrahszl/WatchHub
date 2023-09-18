﻿using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class BasketWithItemsSpecification : Specification<Basket>
    {
        public BasketWithItemsSpecification(string buyerId)
        {
            Query.Where(b => b.BuyerId == buyerId)
                .Include(b => b.BasketItems)
                .ThenInclude(bi => bi.Product);
        }
    }
}