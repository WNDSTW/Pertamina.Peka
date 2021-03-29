using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pertamina.Peka.Models;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace Pertamina.Peka.DAO
{
    public class PekerjaDAO
    {
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @Subfunction = new SqlParameter("@Subfunction", SqlDbType.Int);
        protected SqlParameter @id = new SqlParameter("@id", SqlDbType.Int);
        protected SqlParameter @idJabatan = new SqlParameter("@idJabatan", SqlDbType.Int);
        protected SqlParameter @idRole = new SqlParameter("@idRole", SqlDbType.Int);
        protected SqlParameter @NoPek = new SqlParameter("@NoPek", SqlDbType.VarChar, 50);
        protected SqlParameter @namapegawai = new SqlParameter("@namapegawai", SqlDbType.VarChar, 100);
        protected SqlParameter @bagian = new SqlParameter("@bagian", SqlDbType.VarChar, 100);
        protected SqlParameter @NoLevel = new SqlParameter("@NoLevel", SqlDbType.VarChar, 50);
        protected SqlParameter @NoStatus = new SqlParameter("@NoStatus", SqlDbType.VarChar, 100);
        protected SqlParameter @desccostcenter = new SqlParameter("@costcenter", SqlDbType.VarChar, 100);
        protected SqlParameter @direktur = new SqlParameter("@direktur", SqlDbType.VarChar, 50);
        protected SqlParameter @jabatan = new SqlParameter("@jabatan", SqlDbType.VarChar, 100);
        protected SqlParameter @nobagian = new SqlParameter("@nobagian", SqlDbType.Int);
        protected SqlParameter @nofungsi = new SqlParameter("@nofungsi", SqlDbType.Int);
        protected SqlParameter @email = new SqlParameter("@email", SqlDbType.VarChar, 100);
        protected SqlParameter @PRL = new SqlParameter("@PRL", SqlDbType.VarChar, 100);
        protected SqlParameter @tgllahir = new SqlParameter("@tgllahir", SqlDbType.DateTime);
        protected SqlParameter @tmt_dinas = new SqlParameter("@tmt_dinas", SqlDbType.DateTime);

        protected SqlParameter @CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        protected SqlParameter @ModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @ModifiedOn = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        protected SqlParameter @isActive = new SqlParameter("@isActive", SqlDbType.Bit);

        public DataSet 
            SearchPekerja(Pekerja pekerjas)
        {
            @function.Value = 14;

            if (pekerjas.NoPek != null)
            {
                @NoPek.Value = pekerjas.NoPek;
            }
            else
            {
                @NoPek.Value = DBNull.Value;
            }

            if (pekerjas.namapegawai != null)
            {
                @namapegawai.Value = pekerjas.namapegawai;
            }
            else
            {
                @namapegawai.Value = DBNull.Value;
            }
            if (pekerjas.nofungsi != null & pekerjas.nofungsi != 0)
            {
                @nofungsi.Value = pekerjas.nofungsi;
            }
            else
            {
                @nofungsi.Value = DBNull.Value;
            }
            if (pekerjas.email != null)
            {
                @email.Value = pekerjas.email;
            }
            else
            {
                @email.Value = DBNull.Value;
            }
            if (pekerjas.nobagian != null & pekerjas.nobagian != 0)
            {
                @nobagian.Value = pekerjas.nobagian;
            }
            else
            {
                @nobagian.Value = DBNull.Value;
            }
            return SqlHelper.ExecuteDataset(General.connString, CommandType.StoredProcedure, "SP_UserMgt", @function, @email, @NoPek, @namapegawai, @nofungsi, @nobagian);
        }
    }
}