using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataeDAL.UnitWork;
using AutoMapper;
using Models;
using DataeDAL;

namespace Service
{
    public class ServiceCRUD
    //class ServiceCRUD
    {
        private readonly UnitWork _unitWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ServiceCRUD()
        {
            _unitWork = new UnitWork();
        }

        public IEnumerable<ModelEmp> GetAllEmp()
        {
            var Emplist = _unitWork.DetailRepository.GetAll().ToList();
            if (Emplist.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<detailemp, ModelEmp>();
                });

                IMapper mapper = config.CreateMapper();
                var dest = mapper.Map<List<detailemp>, List<ModelEmp>>(Emplist);
                return dest;
            }
            return null;
        }


        public ModelEmp GetEmpEditDetailById(int EmpID)
        {
            var Empedit = _unitWork.DetailRepository.GetByID(EmpID);
            if (Empedit != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<detailemp, ModelEmp>();
                });

                IMapper mapper = config.CreateMapper();
                var dest = mapper.Map<detailemp, ModelEmp>(Empedit);
                return dest;
            }
            return null;
        }
        public bool EmpDetailUpdate(ModelEmp empmodel)
        {
            //var login = _unitOfWork.LoginRepository.GetByID(loginId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelEmp, detailemp>();
            });

            IMapper mapper = config.CreateMapper();
            var Empupdate = mapper.Map<ModelEmp, detailemp>(empmodel);
            //login = dest;
            _unitWork.DetailRepository.Update(Empupdate);
            _unitWork.Save();
            return false;
        }



        public bool CreateEmp(ModelEmp insertEntity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelEmp, detailemp>();
            });

            IMapper mapper = config.CreateMapper();
            var Empdelete = mapper.Map<ModelEmp, detailemp>(insertEntity);
            //login = dest;
            _unitWork.DetailRepository.Insert(Empdelete);
            _unitWork.Save();
            return false;
        }
        public ModelEmp GetEmpDeleteDetailById(int EmpID)
        {
            var Empdelete = _unitWork.DetailRepository.GetByID(EmpID);
            if (Empdelete != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<detailemp, ModelEmp>();
                });

                IMapper mapper = config.CreateMapper();
                var dest = mapper.Map<detailemp, ModelEmp>(Empdelete);
                return dest;
            }
            return null;
        }
        public bool EmpDetailDelete(ModelEmp empmodel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelEmp, detailemp>();
            });

            IMapper mapper = config.CreateMapper();
            var Empdelete = mapper.Map<ModelEmp, detailemp>(empmodel);
            //login = dest;
            _unitWork.DetailRepository.Delete(Empdelete);
            _unitWork.Save();
            return false;
        }
    }
}
