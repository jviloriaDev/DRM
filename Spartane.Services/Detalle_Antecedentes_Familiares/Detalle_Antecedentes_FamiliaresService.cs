using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Antecedentes_Familiares;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Antecedentes_Familiares
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Antecedentes_FamiliaresService : IDetalle_Antecedentes_FamiliaresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> _Detalle_Antecedentes_FamiliaresRepository;
        #endregion

        #region Ctor
        public Detalle_Antecedentes_FamiliaresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> Detalle_Antecedentes_FamiliaresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Antecedentes_FamiliaresRepository = Detalle_Antecedentes_FamiliaresRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares>("sp_SelAllDetalle_Antecedentes_Familiares");
        }

        public IList<Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Antecedentes_Familiares_Complete>("sp_SelAllComplete_Detalle_Antecedentes_Familiares");
            return data.Select(m => new Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares
            {
                Folio = m.Folio
                ,Folio_Pacientes = m.Folio_Pacientes
                ,Enfermedad_Padecimientos = new Core.Classes.Padecimientos.Padecimientos() { Clave = m.Enfermedad.GetValueOrDefault(), Descripcion = m.Enfermedad_Descripcion }
                ,Parentesco_Parentesco = new Core.Classes.Parentesco.Parentesco() { Clave = m.Parentesco.GetValueOrDefault(), Descripcion = m.Parentesco_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Antecedentes_Familiares>("sp_ListSelCount_Detalle_Antecedentes_Familiares", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Antecedentes_Familiares>("sp_ListSelAll_Detalle_Antecedentes_Familiares", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares
                {
                    Folio = m.Detalle_Antecedentes_Familiares_Folio,
                    Folio_Pacientes = m.Detalle_Antecedentes_Familiares_Folio_Pacientes,
                    Enfermedad = m.Detalle_Antecedentes_Familiares_Enfermedad,
                    Parentesco = m.Detalle_Antecedentes_Familiares_Parentesco,

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

        public IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_FamiliaresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Antecedentes_Familiares>("sp_ListSelAll_Detalle_Antecedentes_Familiares", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Antecedentes_FamiliaresPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Antecedentes_FamiliaresPagingModel
                {
                    Detalle_Antecedentes_Familiaress =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares
                {
                    Folio = m.Detalle_Antecedentes_Familiares_Folio
                    ,Folio_Pacientes = m.Detalle_Antecedentes_Familiares_Folio_Pacientes
                    ,Enfermedad = m.Detalle_Antecedentes_Familiares_Enfermedad
                    ,Enfermedad_Padecimientos = new Core.Classes.Padecimientos.Padecimientos() { Clave = m.Detalle_Antecedentes_Familiares_Enfermedad.GetValueOrDefault(), Descripcion = m.Detalle_Antecedentes_Familiares_Enfermedad_Descripcion }
                    ,Parentesco = m.Detalle_Antecedentes_Familiares_Parentesco
                    ,Parentesco_Parentesco = new Core.Classes.Parentesco.Parentesco() { Clave = m.Detalle_Antecedentes_Familiares_Parentesco.GetValueOrDefault(), Descripcion = m.Detalle_Antecedentes_Familiares_Parentesco_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares>("sp_GetDetalle_Antecedentes_Familiares", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Antecedentes_Familiares>("sp_DelDetalle_Antecedentes_Familiares", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares entity)
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
                var padreEnfermedad = _dataProvider.GetParameter();
                padreEnfermedad.ParameterName = "Enfermedad";
                padreEnfermedad.DbType = DbType.Int32;
                padreEnfermedad.Value = (object)entity.Enfermedad ?? DBNull.Value;

                var padreParentesco = _dataProvider.GetParameter();
                padreParentesco.ParameterName = "Parentesco";
                padreParentesco.DbType = DbType.Int32;
                padreParentesco.Value = (object)entity.Parentesco ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Antecedentes_Familiares>("sp_InsDetalle_Antecedentes_Familiares" , padreFolio_Pacientes
, padreEnfermedad
, padreParentesco
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

        public int Update(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares entity)
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
                var paramUpdEnfermedad = _dataProvider.GetParameter();
                paramUpdEnfermedad.ParameterName = "Enfermedad";
                paramUpdEnfermedad.DbType = DbType.Int32;
                paramUpdEnfermedad.Value = (object)entity.Enfermedad ?? DBNull.Value;

                var paramUpdParentesco = _dataProvider.GetParameter();
                paramUpdParentesco.ParameterName = "Parentesco";
                paramUpdParentesco.DbType = DbType.Int32;
                paramUpdParentesco.Value = (object)entity.Parentesco ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Antecedentes_Familiares>("sp_UpdDetalle_Antecedentes_Familiares" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdEnfermedad , paramUpdParentesco ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares Detalle_Antecedentes_FamiliaresDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Pacientes = _dataProvider.GetParameter();
                paramUpdFolio_Pacientes.ParameterName = "Folio_Pacientes";
                paramUpdFolio_Pacientes.DbType = DbType.Int32;
                paramUpdFolio_Pacientes.Value = (object)entity.Folio_Pacientes ?? DBNull.Value;
		var paramUpdEnfermedad = _dataProvider.GetParameter();
                paramUpdEnfermedad.ParameterName = "Enfermedad";
                paramUpdEnfermedad.DbType = DbType.Int32;
                paramUpdEnfermedad.Value = (object)entity.Enfermedad ?? DBNull.Value;
		var paramUpdParentesco = _dataProvider.GetParameter();
                paramUpdParentesco.ParameterName = "Parentesco";
                paramUpdParentesco.DbType = DbType.Int32;
                paramUpdParentesco.Value = (object)entity.Parentesco ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Antecedentes_Familiares>("sp_UpdDetalle_Antecedentes_Familiares" , paramUpdFolio , paramUpdFolio_Pacientes , paramUpdEnfermedad , paramUpdParentesco ).FirstOrDefault();

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

