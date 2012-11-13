using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebUI.Models
{
    public class CVIntArray : ValidationAttribute
    {
        private readonly string regStr = @"^[1-9][0-9]*$";

        public override bool IsValid(object value)
        {
            string[] pm = value as string[];
            if (pm == null)
            { return false; }
            Regex rex = new Regex(regStr);
            for (int x = 0; x != pm.Length; x++)
            {
                if (rex.IsMatch(pm[x]) == false)
                { return false; }
            }
            return true;
        }
    }
}