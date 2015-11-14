// ReSharper disable All
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using MixERP.Net.Entities.Core;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Core.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "core.get_menu_id_by_menu_code(_menu_code character varying)" on the database.
    /// </summary>
    public class GetMenuIdByMenuCodeProcedure : DbAccess, IGetMenuIdByMenuCodeRepository
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "core";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "get_menu_id_by_menu_code";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
        public long _LoginId { get; set; }
        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Maps to "_menu_code" argument of the function "core.get_menu_id_by_menu_code".
        /// </summary>
        public string MenuCode { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "core.get_menu_id_by_menu_code(_menu_code character varying)" on the database.
        /// </summary>
        public GetMenuIdByMenuCodeProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "core.get_menu_id_by_menu_code(_menu_code character varying)" on the database.
        /// </summary>
        /// <param name="menuCode">Enter argument value for "_menu_code" parameter of the function "core.get_menu_id_by_menu_code".</param>
        public GetMenuIdByMenuCodeProcedure(string menuCode)
        {
            this.MenuCode = menuCode;
        }
        /// <summary>
        /// Prepares and executes the function "core.get_menu_id_by_menu_code".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public int Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"GetMenuIdByMenuCodeProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM core.get_menu_id_by_menu_code(@MenuCode);";

            query = query.ReplaceWholeWord("@MenuCode", "@0::character varying");


            List<object> parameters = new List<object>();
            parameters.Add(this.MenuCode);

            return Factory.Scalar<int>(this._Catalog, query, parameters.ToArray());
        }


    }
}