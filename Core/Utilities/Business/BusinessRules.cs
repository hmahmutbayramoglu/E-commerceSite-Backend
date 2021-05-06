using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Bussiness
{
    public class BusinessRules
    {

        //params istediğimiz kadar IResult verebilmemizi sağlıyo 
        //IResult dizisi adı logics

        public static IResult Run(params IResult[] logics)
        {

            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;

        }
    }
}
