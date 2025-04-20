using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrate
{
    public class CargoCompanyMenager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyMenager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public void TDelete(int id)
        {
            _cargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
           return  _cargoCompanyDal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return _cargoCompanyDal.GetById(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoCompanyDal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoCompanyDal.Update(entity);
        }
    }
}
