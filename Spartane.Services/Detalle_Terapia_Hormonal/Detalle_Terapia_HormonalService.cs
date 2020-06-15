using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Terapia_Hormonal;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Terapia_Hormonal
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Terapia_HormonalService : IDetalle_Terapia_HormonalService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> _Detalle_Terapia_HormonalRepository;
        #endregion

        #region Ctor
        public Detalle_Terapia_HormonalService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> Detalle_Terapia_HormonalRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Terapia_HormonalRepository = Detalle_Terapia_HormonalRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Terapia_HormonalRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal>("sp_SelAllDetalle_Terapia_Hormonal");
        }

        public IList<Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Terapia_Hormonal_Complete>("sp_SelAllComplete_Detalle_Terapia_Hormonal");
            return data.Select(m => new Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Nombre = m.Nombre
                ,Dosis = m.Dosis


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Terapia_Hormonal>("sp_ListSelCount_Detalle_Terapia_Hormonal", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Terapia_Hormonal>("sp_ListSelAll_Detalle_Terapia_Hormonal", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal
                {
                    Folio = m.Detalle_Terapia_Hormonal_Folio,
                    Folio_Pacientes = m.Detalle_Terapia_Hormonal_Folio_Pacientes,
                    Nombre = m.Detalle_Terapia_Hormonal_Nombre,
                    Dosis = m.Detalle_Terapia_Hormonal_Dosis,

                    //Id = m.Id,
                }).ToList();
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

        }

        public IList<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_HormonalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var padstartRowIndex = _dataProvider.GetParameter();
            padstartRowIndex.ParameterName = "startRowIndex";
            padstartRowIndex.DbType = DbType.Int32;
            padstartRowIndex.Value = startRowIndex;

            var padmaximumRows = _dataProvider.GetParameter();
            padmaximumRows.ParameterName = "maximumRows";
            padmaximumRows.DbType = DbType.Int32;
            padmaximumRows.Value = maximumRows;

            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var padOrder = _dataProvider.GetParameter();
            padOrder.ParameterName = "Order";
            padOrder.DbType = DbType.String;
            padOrder.Value = Order;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Terapia_Hormonal>("sp_ListSelAll_Detalle_Terapia_Hormonal", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Terapia_HormonalPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Terapia_HormonalPagingModel
                {
                    Detalle_Terapia_Hormonals =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal
                {
                    Folio = m.Detalle_Terapia_Hormonal_Folio
                    ,Folio_Pacientes = m.Detalle_Terapia_Hormonal_Folio_Pacientes
                    ,Nombre = m.Detalle_Terapia_Hormonal_Nombre
                    ,Dosis = m.Detalle_Terapia_Hormonal_Dosis

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal>("sp_GetDetalle_Terapia_Hormonal", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Terapia_Hormonal>("sp_DelDetalle_Terapia_Hormonal", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result.ToString() == "1";
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Pacientes = _dataProvider.GetParameter();
                padreFolio_Pacientes.ParameterName = "Folio_Pacientes";
                padreFolio_Pacientes.DbType = DbType.Int32;
                padreFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var padreNombre = _dataProvider.GetParameter();
                padreNombre.ParameterName = "Nombre";
                padreNombre.DbType = DbType.String;
                padreNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var padreDosis = _dataProvider.GetParameter();
                padreDosis.ParameterName = "Dosis";
                padreDosis.DbType = DbType.String;
                padreDosis.Value = (object)entity.Dosis ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Terapia_Hormonal>("sp_InsDetalle_Terapia_Hormonal" , padreFolio_Pacientes
, padreNombre
, padreDosis
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)entity.Dosis ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Terapia_Hormonal>("sp_UpdDetalle_Terapia_Hormonal" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdNombre , paramUpdDosis ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal Detalle_Terapia_HormonalDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
                var paramUpdNombre = _dataProvider.GetParameter();
                paramUpdNombre.ParameterName = "Nombre";
                paramUpdNombre.DbType = DbType.String;
                paramUpdNombre.Value = (object)entity.Nombre ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)entity.Dosis ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Terapia_Hormonal>("sp_UpdDetalle_Terapia_Hormonal" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdNombre , paramUpdDosis ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }


        #endregion
    }
}

