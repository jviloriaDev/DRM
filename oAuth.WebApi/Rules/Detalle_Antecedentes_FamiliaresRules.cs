using oAuth.WebApi.Helpers;
using Spartane.Core.Classes.Detalle_Antecedentes_Familiares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace oAuth.WebApi.Rules
{
    public static class Detalle_Antecedentes_FamiliaresRules
    {
        public static bool EjecutarValidacionesBeforePost(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {
            bool ret = true;

            //NEWBUSINESSRULE_BEFOREPOST//
            return ret;
        }
        public static void EjecutarValidacionesAfterPost(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {

            //NEWBUSINESSRULE_AFTERPOST//
        }

        public static bool EjecutarValidacionesBeforePut(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {
            bool ret = true;

            //NEWBUSINESSRULE_BEFOREPUT//
            return ret;
        }
        public static void EjecutarValidacionesAfterPut(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {
			//NEWBUSINESSRULE_AFTERPUT//
        }

        public static bool EjecutarValidacionesBeforeDelete(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {
            bool ret = true;

            //NEWBUSINESSRULE_BEFOREDELETE//
            return ret;
        }
        public static void EjecutarValidacionesAfterDelete(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {
            //NEWBUSINESSRULE_AFTERDELETE//
        }

        public static bool EjecutarValidacionesBeforeGet()
        {
            bool ret = true;

            //NEWBUSINESSRULE_BEFOREGET//
            return ret;
        }
        public static void EjecutarValidacionesAfterGet(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {
            //NEWBUSINESSRULE_AFTERGET//
        }

        public static bool EjecutarValidacionesBeforeListSelAll()
        {
            bool ret = true;

            //NEWBUSINESSRULE_BEFORELISTSELALL//
            return ret;
        }
        public static void EjecutarValidacionesAfterListSelAll(Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {
            //NEWBUSINESSRULE_AFTERLISTSELALL//
        }

        public static string ReplaceQuery(string query, Spartane.Core.Classes.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares obj)
        {
            //codigo para que reemplace los FLD
            Regex regex = new Regex(@"FLD\[([^\]]+)\]");
            MatchCollection matches = regex.Matches(query);
            string auxMatch = "";
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    auxMatch = capture.Value.Replace("FLD[", "").Replace("]", "");
                    PropertyInfo info = obj.GetType().GetProperty(auxMatch);
                    query = GeneralHelper.ReplaceFLD(query, auxMatch, obj, info, capture.Value);
                }
            }
            return query;
        }
    }
}

