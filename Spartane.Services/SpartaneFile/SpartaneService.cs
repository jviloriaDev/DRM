using System;
using System.Data;
using System.Data.Common;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Classes.SpartaneFile;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;
using Spartane.Services.SpartaneFile;

namespace Spartane.Services.Departamento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class SpartaneFileService : ISpartaneFileService
    {

                #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        //private List<Spartane.Core.Classes.Departamento.Departamento> _Departamento;
        private readonly IRepository<Spartane.Core.Classes.SpartaneFile.SpartaneFile> _SpartaneFileRepository;
        #endregion

        #region Ctor
        public SpartaneFileService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.SpartaneFile.SpartaneFile> SpartaneFileRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._SpartaneFileRepository = SpartaneFileRepository;
        }
        #endregion

        public long Insert(Spartane.Core.Classes.SpartaneFile.SpartaneFile entity)
        {
            long rta = 0;
            try
            {
                var padreFileName = _dataProvider.GetParameter();
                padreFileName.ParameterName = "File_Name";
                padreFileName.DbType = DbType.String;
                padreFileName.Value = entity.File_Name;

                var padreFileSize = _dataProvider.GetParameter();
                padreFileSize.ParameterName = "File_Size";
                padreFileSize.DbType = DbType.Int64;
                padreFileSize.Value = entity.File_Size == entity.File.Length ? entity.File_Size : entity.File.Length;

                var padreFile = _dataProvider.GetParameter();
                padreFile.ParameterName = "File";
                padreFile.DbType = DbType.Binary;
                padreFile.Value = entity.File;
               // padreFile.Size = entity.File_Size == entity.File.Length ? entity.File_Size : entity.File.Length;
                


                var data =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_InsSpartaneFile>("sp_InsSpartaneFile", padreFileName, padreFileSize, padreFile).FirstOrDefault();
                if (data != null)
                    rta = Convert.ToInt64(data.FileId);

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

        public Spartane.Core.Classes.SpartaneFile.SpartaneFile GetByKey(long? Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "FileId";
            padreKey.DbType = DbType.Int64;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.SpartaneFile.SpartaneFile>("sp_GetSpartaneFile", padreKey).SingleOrDefault();
        }

        public bool Delete(long? Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "FileId";
                padreKey.DbType = DbType.Int64;
                padreKey.Value = Key;
                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelSpartaneFile>("sp_DelSpartaneFile", padreKey).SingleOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result == 1;
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

        public long Update(Spartane.Core.Classes.SpartaneFile.SpartaneFile entity)
        {

            long rta = 0;
            try
            {

                var padreId = _dataProvider.GetParameter();
                padreId.ParameterName = "FileId";
                padreId.DbType = DbType.Int64;
                padreId.Value = entity.File_Id;

                var padreFileName = _dataProvider.GetParameter();
                padreFileName.ParameterName = "File_Name";
                padreFileName.DbType = DbType.String;
                padreFileName.Value = entity.File_Name;

                var padreFileSize = _dataProvider.GetParameter();
                padreFileSize.ParameterName = "File_Size";
                padreFileSize.DbType = DbType.Int64;
                padreFileSize.Value = entity.File_Size == entity.File.Length ? entity.File_Size : entity.File.Length;

                var padreFile = _dataProvider.GetParameter();
                padreFile.ParameterName = "File";
                padreFile.DbType = DbType.Binary;
                padreFile.Value = entity.File;
                //padreFile.Size = entity.File_Size == entity.File.Length ? entity.File_Size : entity.File.Length;

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdateSpartaneFile>(
                        "sp_UpdateSpartaneFile", padreId, padreFileName,
                        padreFileSize,padreFile).FirstOrDefault();


                if (empEntity != null)
                    rta = Convert.ToInt64(empEntity.FileId);
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
    }
}
