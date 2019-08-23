﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOrganization.CustomValidations
{
    public class NameValAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            if (value.ToString() == "Gokhan")
            {
                ErrorMessage = "Sen gelme";
                return false;
            }
            return base.IsValid(value);
        }
    }
}
