﻿using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrate;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoDetailDal:GenericRepository<CargoDetail>,ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context):base(context)
        {
            
        }
    }
}
